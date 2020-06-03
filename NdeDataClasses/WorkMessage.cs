using System;
using System.Runtime.Serialization;

namespace NdeDataClasses
{
  [DataContract]
  //Рабочая справка по поезду
  public class WorkMessage
  {
    [DataMember]
    public int      MessIdn     { get; set; }
    [DataMember]
    public DateTime MessTime    { get; set; }
    [DataMember]
    public string   MessStation { get; set; }
    [DataMember]
    public string   Operation   { get; set; }
    [DataMember]
    public string   Flags       { get; set; }
    [DataMember]
    public int      TrainIdn    { get; set; }
    [DataMember]
    public string   TrainNum    { get; set; }
    [DataMember]
    public int      MessType    { get; set; }
    [DataMember]
    public string   StForm      { get; set; }
    [DataMember]
    public string   NmSost      { get; set; }
    [DataMember]
    public string   StDest      { get; set; }
    [DataMember]
    public int      MessProp    { get; set; }
    [DataMember]
    public int      CrewStTimeH { get; set; }
    [DataMember]
    public int      CrewStTimeM { get; set; }
    [DataMember]
    public string   Machinist   { get; set; }
    [DataMember]
    public int      CWagCount   { get; set; }
    [DataMember]
    public int      NtWeight    { get; set; }
    [DataMember]
    public int      GrWeight    { get; set; }
    [DataMember]
    public string   Marker      { get; set; }
    [DataMember]
    public string   BadCode     { get; set; }
    [DataMember]
    public string   LocoSeries  { get; set; }
    [DataMember]
    public string   LocoNum     { get; set; }
    [DataMember]
    public string   TrainAttr   { get; set; }
    [DataMember]
    public byte     WagLoaded   { get; set; }
    [DataMember]
    public byte     WagEmpty    { get; set; }
    [DataMember]
    public byte     WagNoWork   { get; set; }
    //
    public int MessIdnPrev { get; set; }
    public int WirIdnPrev  { get; set; }
    public int ComCngNum   { get; set; }
    public int ComCngWir   { get; set; }
  }
}
