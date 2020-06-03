using System.Runtime.Serialization;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class BindTrainThreadsCommnand : BindingCommand
  {
    [DataMember]
    public int SourceId { get; set; }
    [DataMember]
    public int TargetId { get; set; }
  }
}
