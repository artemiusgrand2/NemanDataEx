using System.Runtime.Serialization;

namespace NdeDataClasses.Commands
{
  //Абстрактная внешняя команда, но...
  [DataContract]
  [KnownType(typeof(BindTrainThreadsCommnand))]
  [KnownType(typeof(AssignTrainNumberCommand))]
  [KnownType(typeof(AssignMessForTrainCommand))]
  [KnownType(typeof(StopMessForTrainCommand))]
  [KnownType(typeof(RunTrackIoTrackCommand))]
  [KnownType(typeof(TrainProcessCommand))]
  [KnownType(typeof(SetTrackInCommand))]
  [KnownType(typeof(MarkTrainCommand))]
  [KnownType(typeof(MarkMessageCommand))]
  [KnownType(typeof(WriteTrainInputCommand))]
  [KnownType(typeof(WriteTrainOutputCommand))]
  [KnownType(typeof(TrackPointMessagesCommand))]
  [KnownType(typeof(BindPlanToTrainCommand))]
  [KnownType(typeof(DelPlanWireCommand))]
  [KnownType(typeof(SetDefSendFlagCommand))]
  [KnownType(typeof(SetReplysCommand))]
  [KnownType(typeof(Buh2DataCommand))]
  [KnownType(typeof(CleanPlanCommand))]
  [KnownType(typeof(WriteEnterExecutedPlanCommand))]
  [KnownType(typeof(UpdatePathInPlanDefCommand))]
  [KnownType(typeof(DelDefCommands))]
    public abstract class BindingCommand
  {
  }
}
