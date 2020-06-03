using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class StopMessForTrainCommand : BindingCommand
  {
    [DataMember]
    public int trainIdn { get; set; }
  }
}
