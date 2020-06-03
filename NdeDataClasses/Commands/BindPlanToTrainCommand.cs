using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class BindPlanToTrainCommand : BindingCommand
  {
    [DataMember] 
    public IList<GIDMessage> planEvents;
    [DataMember]
    public int trainIdn;
  }
}
