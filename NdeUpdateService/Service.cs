using System;
using System.Linq;
using System.Configuration;
using System.ServiceProcess;
using BCh.Ktc.Nde.MiddleTier;
using NdeDataAccessFb;
using NdeDataAccessSql;
using NdeDataClasses.Configuration;

namespace BCh.Ktc.Nde.NdeUpdateService
{
  public partial class Service : ServiceBase
  {
    private readonly UpdaterEngine _updaterEngine;

    public Service(){
      InitializeComponent();

      bool flPlay;
      try {
        flPlay = bool.Parse(ConfigurationManager.AppSettings["GidPlay"]);
      } catch (Exception e) {
        var err = e.ToString();
        flPlay = false;
      }

      int deltaTimeStart = int.Parse(ConfigurationManager.AppSettings["deltaTimeStart"]);
      int deltaTimeStop  = int.Parse(ConfigurationManager.AppSettings["deltaTimeStop"]);
      BuhSection[] buhSections = NdeConfigurationHelper.RetrieveBuhSectionsFromConfiguration("engine");

      //Репозитории функций для работы с данными
      var cnfRepository   = new CnfRepository(ConfigurationManager.ConnectionStrings["cnfDb"].ConnectionString);
      var gidRepository   = new GidRepository(ConfigurationManager.ConnectionStrings["gidDb"].ConnectionString,flPlay
                                             , deltaTimeStart, deltaTimeStop
                                             ,ConfigurationManager.ConnectionStrings["buhDb"].ConnectionString
                                             ,buhSections, NdeConfigurationHelper.ParseNodeEsr(ConfigurationManager.AppSettings.AllKeys.Contains("nodeEsr") ? ConfigurationManager.AppSettings["nodeEsr"] : string.Empty));
      var asoupRepository = new AsoupRepository(ConfigurationManager.ConnectionStrings["mesDb"].ConnectionString);
      //var asoupRepository = new IaspurgpRepository(ConfigurationManager.ConnectionStrings["mesDb"].ConnectionString);
      //Функции для работы со справками по поездам
      var trainMessagesManager = new TrainMessagesManager(cnfRepository,gidRepository, asoupRepository);
      //и их "запускальщик" (по встроенному таймеру)
      _updaterEngine = new UpdaterEngine(trainMessagesManager, int.Parse(ConfigurationManager.AppSettings["timerPeriod"]));
    }
    //вызов при старте службы
    protected override void OnStart(string[] args){
      _updaterEngine.Start();
    }
    //и при останове
    protected override void OnStop(){
      _updaterEngine.Stop();
    }
  }
}
