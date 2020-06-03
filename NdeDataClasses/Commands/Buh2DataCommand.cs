using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
  [DataContract]
  public class Buh2DataCommand : BindingCommand
  {
    [DataMember]
    public string Station       { get; set; }
    [DataMember]
    public int NsuNumber        { get; set; }
    [DataMember]
    public int Direction        { get; set; }
    [DataMember]
    public DateTime MessageTime { get; set; }
    [DataMember]
    public string TrainNumber   { get; set; }
    [DataMember]
    public string TrainIndex    { get; set; }
    [DataMember]
    public string LocoSeries    { get; set; }
    [DataMember]
    public string LocoNumber    { get; set; }
    [DataMember]
    public int MessageIdn       { get; set; }
  }
}
