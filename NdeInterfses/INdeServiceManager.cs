using System.Collections.Generic;
using NdeDataClasses;
using NdeDataClasses.Commands;

namespace NdeInterfases
{
    public interface INdeServiceManager
    {
        IList<TrainEvent> GetLastTrainEvents();
        IList<TrainWorking> GetWorkVectors();
        IList<WorkMessage> GetWorkMessages();
        IList<GIDMessage> GetGIDMessages();
        IList<ComDefinition> GetComDefinitions();
        IList<ComDefinition> GetComDefinitionsNoRun();

        IList<int> GetIdComDefinitionsInWork(IList<int> idsCom);
        IList<string> GetRequests();
        IList<int> GetPlanTrainIdns();
        string ExecuteBindingCommand(BindingCommand command);
    }
}
