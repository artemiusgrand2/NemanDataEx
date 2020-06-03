using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class SetDefSendFlagCommand :BindingCommand
  {
    [DataMember] 
    public int      defIdn   { get; set; }
    [DataMember]
    public int      sendFlag { get; set; }
    [DataMember]
    public DateTime tmDefC { get; set; }
  }
}
