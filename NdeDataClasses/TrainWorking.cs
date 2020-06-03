using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses
{
  [DataContract]
  //Вектор обработки поезда
  public class TrainWorking
  {
    [DataMember]
    public int      MsType      { get; set; }
    [DataMember]
    public string   Station     { get; set; }
    [DataMember]
    public string   Track       { get; set; }
    [DataMember]
    public string   TrainPrefix { get; set; }
    [DataMember]
    public string   TrainNumber { get; set; }
    [DataMember]
    public string   TrainSuffix { get; set; }
    [DataMember]
    public string   NeStation   { get; set; }
    [DataMember]
    public string   Remark      { get; set; }
    [DataMember]
    public DateTime StartTime   { get; set; }
    [DataMember]
    public DateTime StopTime    { get; set; }
  }
}
