using System;

namespace NdeDataClasses {
  public class ComDefAppendix {
    public string LocoSeries { get; set; }
    public string OversizeBottom { get; set; }
    public string OversizeSide { get; set; }
    public string OversizeTop { get; set; }
    public string SuperOversize { get; set; }
    public int LengthConv { get; set; }
    public string HeavyAndLongMark { get; set; }
    public string OperationCode { get; set; }
    public DateTime OperationTime { get; set; }
    public string StationCode { get; set; }
    public string VidSled { get; set; }
  }
}
