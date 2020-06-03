using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NdeDataClasses
{
  public class TrainMessage
  {
    public int        RecId           { get; set; }
    public DateTime   MessageTime     { get; set; }
    public int        RawMessageRecId { get; set; }
    public string     StationCode     { get; set; }
    public string     Operation       { get; set; }
    public string     Flags           { get; set; }
    public int        TrainNumber     { get; set; }
    public TrainIndex TrainIndex      { get; set; }
    public string     LocoSeries      { get; set; }
    public string     LocoNumber      { get; set; }
    public int        CrewStTimeH     { get; set; }
    public int        CrewStTimeM     { get; set; }
    public string     Machinist       { get; set; }
    public int        CWagCount       { get; set; }
    public int        NtWeight        { get; set; }
    public int        GrWeight        { get; set; }
    public byte[]     WagCounts       { get; set; }
    public DateTime   LastUpTime      { get; set; }
  }
  
  public sealed class TrainIndex
  {
    public string Index1 { get; set; }
    public string Index2 { get; set; }
    public string Index3 { get; set; }
    public string Index4 { get; set; }
  }
}
