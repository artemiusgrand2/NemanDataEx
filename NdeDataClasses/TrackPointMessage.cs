using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace NdeDataClasses
{
  [DataContract]
  public class TrackPointMessage
  {
    [DataMember]
    public int      MsType       { get; set; }
    [DataMember]
    public DateTime MsTime       { get; set; }
    [DataMember]
    public int      StCodeStart  { get; set; }
    [DataMember]
    public int      StCodeStop   { get; set; }
    [DataMember]
    public string   SpanTrack    { get; set; }
    [DataMember]
    public string   PointName    { get; set; }
    [DataMember]
    public int      TrPointStart { get; set; }
    [DataMember]
    public int      TrPointStop  { get; set; }
    [DataMember]
    public string   Direction    { get; set; }
  }
}
