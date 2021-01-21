using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses
{
  [DataContract]
  public class GIDMessage
  {
    [DataMember]
    public  int     MsIdn     { get; set; }
    [DataMember]
    public int      MsType    { get; set; }
    [DataMember]
    public DateTime MsTime    { get; set; }
    [DataMember]
    public string   MsStation { get; set; }
    [DataMember]
    public string   TrainNum  { get; set; }
    [DataMember]
    public string   MsAxis    { get; set; }
    [DataMember]
    public string   NeStation { get; set; }
    [DataMember]
    public string   MsFlags   { get; set; }
    [DataMember]
    public int      TrainIdn  { get; set; }
    [DataMember]
    public int      FlCnfm    { get; set; }
    [DataMember]
    public int      FlColSt   { get; set; }
    [DataMember]
    public int      FlColSp   { get; set; }
    [DataMember]
    public string   TechStop { get; set; }
    }
}
