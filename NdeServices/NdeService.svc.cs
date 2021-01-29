using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Configuration;
using BCh.Ktc.Nde.MiddleTier;
using NdeDataAccessFb;
using NdeDataAccessSql;
using NdeDataClasses;
using NdeDataClasses.Commands;
using NdeDataClasses.Configuration;
using NdeInterfases;
using System.ServiceModel.Channels;

namespace NdeServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "NdeService" in code, svc and config file together.
    public class NdeService : INdeService
    {
        private readonly INdeServiceManager _serviceManager;


        RemoteEndpointMessageProperty GetIpUserConnect
        {
            get
            {
                OperationContext oOperationContext = OperationContext.Current;
                var oMessageProperties = oOperationContext.IncomingMessageProperties;
                var oRemoteEndpointMessageProperty = (RemoteEndpointMessageProperty)oMessageProperties[RemoteEndpointMessageProperty.Name];

                return oRemoteEndpointMessageProperty;
            }
        }

        public NdeService()
        {
            var conString = WebConfigurationManager.ConnectionStrings["gidDb"].ConnectionString;
            var conStringBuh = WebConfigurationManager.ConnectionStrings["buhDb"].ConnectionString;
            var conStringIas = string.Empty;// WebConfigurationManager.ConnectionStrings["iasDb"].ConnectionString;

            bool flPlay;
            try
            {
                flPlay = bool.Parse(WebConfigurationManager.AppSettings["GidPlay"]);
            }
            catch (Exception e)
            {
                var err = e.ToString();
                flPlay = false;
            }

            int deltaTimeStart = int.Parse(WebConfigurationManager.AppSettings["deltaTimeStart"]);
            int deltaTimeStop = int.Parse(WebConfigurationManager.AppSettings["deltaTimeStop"]);

            BuhSection[] buhSections = NdeConfigurationHelper.RetrieveBuhSectionsFromConfiguration("engine");
            var nodeEsr = NdeConfigurationHelper.ParseNodeEsr(WebConfigurationManager.AppSettings.AllKeys.Contains("nodeEsr") ? WebConfigurationManager.AppSettings["nodeEsr"] : string.Empty);
            //Репозиторий для работы с данными ГИД
            var gidRepo = new GidRepository(conString, flPlay,
              deltaTimeStart, deltaTimeStop, conStringBuh, buhSections,
               nodeEsr);
            //
            var iasRepo = new IaspurgpRepository(conStringIas);
            _serviceManager = new NdeServiceManager(gidRepo, iasRepo, GetIpUserConnect.Address, $"{GetIpUserConnect.Address}:{GetIpUserConnect.Port}",
                WebConfigurationManager.AppSettings.AllKeys.Contains("IpCommand") ? WebConfigurationManager.AppSettings["IpCommand"] : string.Empty);
        }

        public static void Start()
        {
            NdeServiceManager.Start();
        }

        public static void Stop()
        {
            NdeServiceManager.Stop();
        }


        //Дублируем функции (но делаем их контрактными).......................................................
        public IList<TrainEvent> GetLastTrainEvents()
        {
            return _serviceManager.GetLastTrainEvents();
        }
        public IList<TrainWorking> GetWorkVectors()
        {
            return _serviceManager.GetWorkVectors();
        }
        public IList<WorkMessage> GetWorkMessages()
        {
            return _serviceManager.GetWorkMessages();
        }
        public IList<GIDMessage> GetGIDMessages()
        {
            return _serviceManager.GetGIDMessages();
        }
        public IList<ComDefinition> GetComDefinitions()
        {
            return _serviceManager.GetComDefinitions();
        }
        public IList<int> GetPlanTrainIdns()
        {
            return _serviceManager.GetPlanTrainIdns();
        }


        //public IList<ComDefinition> GetComDefinitionsNoRun() {
        //  return _serviceManager.GetComDefinitionsNoRun();
        //}
        public IList<string> GetRequests()
        {
            return _serviceManager.GetRequests();
        }

        public string ExecuteBindingCommand(BindingCommand command)
        {
            return _serviceManager.ExecuteBindingCommand(command);
        }
    }
}
