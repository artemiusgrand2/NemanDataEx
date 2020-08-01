using System.Collections.Generic;
using System.ServiceModel;
using NdeDataClasses;
using NdeDataClasses.Commands;

namespace NdeServices
{
    //Внешне доступны
    [ServiceContract]
    public interface INdeService
    {
        [OperationContract]
        IList<TrainEvent> GetLastTrainEvents();
        [OperationContract]
        IList<TrainWorking> GetWorkVectors();
        [OperationContract]
        IList<WorkMessage> GetWorkMessages();
        [OperationContract]
        IList<GIDMessage> GetGIDMessages();
        [OperationContract]
        IList<ComDefinition> GetComDefinitions();
        //[OperationContract]
        //IList<ComDefinition> GetComDefinitionsNoRun();
        [OperationContract]
        IList<int> GetPlanTrainIdns();
        [OperationContract]
        IList<string> GetRequests();
        [OperationContract]
        string ExecuteBindingCommand(BindingCommand command);
    }
}
