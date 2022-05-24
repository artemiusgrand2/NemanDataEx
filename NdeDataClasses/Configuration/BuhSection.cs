using System;

namespace NdeDataClasses.Configuration
{
  public class BuhSection
  {
    public string StationName     { get; set; }
    public int NsuNumber          { get; set; }
    public string RewriteStation  { get; set; }
    public DateTime CurStartTime  { get; set; }
  }
}
