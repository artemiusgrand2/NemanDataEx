using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace NdeDataClasses.Configuration
{
  public class BuhSectionElement : ConfigurationElement
  {
    private static readonly ConfigurationProperty _stationName;
    private static readonly ConfigurationProperty _nsuNumber;
    private static readonly ConfigurationProperty _rewriteStation;
    private static readonly ConfigurationPropertyCollection _properties;

    static BuhSectionElement() {
      _stationName = new ConfigurationProperty("stationName",
                                        typeof(string));
      _nsuNumber = new ConfigurationProperty("nsuNumber",
                                           typeof(int));
      _rewriteStation = new ConfigurationProperty("rewriteStation",
                                                  typeof(string));
      _properties = new ConfigurationPropertyCollection{
        _stationName,
        _nsuNumber,
        _rewriteStation
      };
    }

    public string StationName {
      get { return base[_stationName] as string; }
      set { base[_stationName] = value; }
    }

    public int NsuNumber {
      get { return (int)base[_nsuNumber]; }
      set { base[_nsuNumber] = value; }
    }

    public string RewriteStation {
      get { return base[_rewriteStation] as string; }
      set { base[_rewriteStation] = value; }
    }

    protected override ConfigurationPropertyCollection Properties {
      get { return _properties; }
    }
  }
}
