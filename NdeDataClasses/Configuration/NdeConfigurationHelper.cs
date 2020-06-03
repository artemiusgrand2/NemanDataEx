using System;
using System.Configuration;

namespace NdeDataClasses.Configuration
{
  public static class NdeConfigurationHelper
  {
    public static BuhSection[] RetrieveBuhSectionsFromConfiguration(string sectionName)
    {
      var configSection = ConfigurationManager.GetSection(sectionName) as EngineConfigurationSection;
      int i = 0;
      var _buhSections = new BuhSection[configSection.BuhSectionCollection.Count];
      foreach (BuhSectionElement buhSection in configSection.BuhSectionCollection) {
        _buhSections[i] = new BuhSection {
          StationName = buhSection.StationName,
          NsuNumber = buhSection.NsuNumber,
          RewriteStation = buhSection.RewriteStation,
          CurStartTime = DateTime.Now - new TimeSpan(1, 0, 0, 0)
        };
        i++;
      }
      return _buhSections;
    }
  }
}
