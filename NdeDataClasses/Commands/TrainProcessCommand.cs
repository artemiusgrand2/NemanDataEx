using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses.Commands
{
 [DataContract]
  public class TrainProcessCommand : BindingCommand
  {
   [DataMember]
   public  int   Command      { get; set; }
   [DataMember]
   public int    SubCommand   { get; set; }
   [DataMember]
   public string StationCdode { get; set; }
   [DataMember]
   public string Track        { get; set; }
   [DataMember]
   public string TrainPrefix { get; set; }
   [DataMember]
   public string TrainNubmer { get; set; }
   [DataMember]
   public string TrainSuffix { get; set; }
   [DataMember]
   public string NeibStation { get; set; }
   [DataMember]
   public string Remark      { get; set; }
  }
}
