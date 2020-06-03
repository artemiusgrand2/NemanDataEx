using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class TrackPointMessagesCommand : BindingCommand
  {
    [DataMember]
    public IList<TrackPointMessage> trackPointMessages { get; set; }
  }
}
