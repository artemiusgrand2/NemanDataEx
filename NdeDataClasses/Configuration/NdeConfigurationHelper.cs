using System;
using System.Linq;
using System.Collections.Generic;
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
            foreach (BuhSectionElement buhSection in configSection.BuhSectionCollection)
            {
                _buhSections[i] = new BuhSection
                {
                    StationName = buhSection.StationName,
                    NsuNumber = buhSection.NsuNumber,
                    RewriteStation = buhSection.RewriteStation,
                    CurStartTime = DateTime.Now - new TimeSpan(1, 0, 0, 0)
                };
                i++;
            }
            return _buhSections;
        }

        public static IList<TrimmedEvent> GetTrimmedEvents()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var engineSection = config.GetSection("engine") as EngineConfigurationSection;

            var trimmedEvents = new List<TrimmedEvent>();
            foreach (TrimmedEventElement eventEl in engineSection.TrimmedEvents)
                trimmedEvents.Add(new TrimmedEvent(eventEl.Station, eventEl.TypeEvent, eventEl.Ndo));
            //
            return trimmedEvents.Distinct().ToList();
        }

        public static IList<string> ParseNodeEsr(string data)
        {
            return data.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
        }
    }
}
