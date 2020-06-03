using System.Runtime.Serialization;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class AssignTrainNumberCommand : BindingCommand
  {
    [DataMember]
    public int TrainThreadId        { get; set; }
    [DataMember]
    public string TrainNumberPrefix { get; set; }
    [DataMember]
    public string TrainNumber       { get; set; }
    [DataMember]
    public string TrainNumberSuffix { get; set; }
    [DataMember]
    public string StationCode       { get; set; }
  }
}
