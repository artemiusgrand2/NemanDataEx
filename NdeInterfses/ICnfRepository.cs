using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NdeInterfases
{
  public interface ICnfRepository
  {
    IList<string> GetStationGroup(string stationCode);
  }
}
