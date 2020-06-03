using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
