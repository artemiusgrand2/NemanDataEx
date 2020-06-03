using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class WriteTrainOutputCommand : BindingCommand
  {
    [DataMember]
    public string stationCode { get; set; }
    [DataMember]
    public string trackName   { get; set; }
    [DataMember]
    public string destName    { get; set; }
  }
}
