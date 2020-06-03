using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class SetTrackInCommand : BindingCommand
  {
    [DataMember]
    public int    trainIdn    { get; set; }
    [DataMember]
    public string trackName   { get; set; }
    [DataMember]
    public string stationCode { get; set; }
  }
}
