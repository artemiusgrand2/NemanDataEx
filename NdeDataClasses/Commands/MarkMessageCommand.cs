using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class MarkMessageCommand : BindingCommand
  {
    [DataMember]
    public int    messageIdn { get; set; }
    [DataMember]
    public string strMarker  { get; set; }
  }
}
