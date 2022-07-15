using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NdeDataClasses;
using NdeDataClasses.Commands;
using NdeDataClasses.Configuration;

namespace NdeInterfases
{
    public interface IGidRepository
    {
        //Внешние запросы
        IList<TrainEvent> GetLastTrainEvents();
        IList<TrainWorking> GetWorkVectors();
        IList<WorkMessage> GetWorkMessages();
        IList<GIDMessage> GetGIDMessages();
        IList<ComDefinition> GetComDefinitions();
        IList<ComDefinition> GetComDefinitionsNoRun();
        IList<int> GetPlanTrainIdns();
        IList<string> GetRequests();
        //Внешние команды
        string DelPlanWire(int trainIdn);
        string BindTrainThreads(int sourceThreadId, int targetThreadId);
        string AssignTrainNumber(int threadId, string trainNumberPrefix, string trainNumber, string trainNumberSuffix, string StationCode);
        string AssignMessageForTrain(int messageIdn, int trainIdn);
        string RunTrackIoTrack(int trainIdn, string trackName, string stationCode);
        string TrainProcess(TrainProcessCommand trainProcessCommand);
        string SetTrackIn(int trainIdn, string trackName, string stationCode);
        string MarkTrain(int trainIdn, string strMarker);
        string MarkMessage(int messageIdn, string strMarker);
        string StopMessForTrain(int trainIdn);
        string WriteTrainInput(string stationCode, string trackName, string destName);
        string WriteTrainOutput(string stationCode, string trackName, string destName);
        string TrackPointMessages(IList<TrackPointMessage> trackPointMessages);
        BaseCommandAnswer BindPlanToTrain(IList<GIDMessage> planEvents, int trainIdn);
        BaseCommandAnswer SetDefSendFlag(int defIdn, int sendFlag, DateTime tmDefC);
        BaseCommandAnswer SetServiceFlag(int defIdn, int serviceFlag);

        string SetReplys(IList<string> replys);
        string WriteBuh2Data(Buh2DataCommand buh2DataCommand);
        BaseCommandAnswer CleanPlan();
        string WriteEnterExecutedPlan(string trainNumber, int planEvId, string station, string axis, string ndo);

        BaseCommandAnswer UpdatePathInPlanDefCommand(string trainNumber, int planEvId, int defId, string station, string axis, string ndo);

        BaseCommandAnswer DelDefCommands();
        //Внутренние функции
        void WriteAllSaipsDataToGid();
        IList<ActualTrain> GetActualTrains();
        void ClearTMessages();
        void ClearWMessages(DateTime stpTime);
        TrainMessage GetActualMessage(ActualTrain actualTrain);
        IList<TrainEvent> GetTrainEventsForMess(TrainMessage trainMessage, ActualTrain actualTrain, ICnfRepository cnfRepository);
        void WriteNewMessForTrain(TrainMessage trainMessage, ActualTrain actualTrain);
        void ChangeNewMessForTrain(TrainMessage trainMessage, ActualTrain actualTrain);
        void WriteWorkMessage(TrainMessage trainMessage);
        void PrepareWorkMessages();
        void SetStopMess();
        void SetMessProperties();
        string RunMessCommands();
        DateTime GetTimeGIDStart();
        DateTime GetTimeGIDStop();
        IList<WorkMessage> GetActualMessages();

        TimeSpan MaxBindDelta { get; }
        int GetTrainByForm(string StForm, string NmSost, string StDest);

        IList<int> GetIdComDefinitionsInWork(IList<int> idsCom);
        //    void ClearGidMessages(DateTime stpTime);
        //    void SrhTrEventsForMessages();
        //    int WritePlanWire(IList<GIDMessage> planEvents);
    }
}
