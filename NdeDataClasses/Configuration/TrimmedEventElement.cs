using System.Collections.Generic;
using System.Configuration;

using NdeDataClasses.Enums;

namespace NdeDataClasses.Configuration
{
    public class TrimmedEventElement : ConfigurationElement
    {
        private static readonly ConfigurationProperty _id;
        private static readonly ConfigurationProperty _station;
        private static readonly ConfigurationProperty _type;
        private static readonly ConfigurationProperty _ndo;
        private static readonly ConfigurationPropertyCollection _properties;

        static TrimmedEventElement()
        {
            _id = new ConfigurationProperty("id", typeof(string), string.Empty);
            _station = new ConfigurationProperty("station", typeof(string), string.Empty);
            _type = new ConfigurationProperty("type", typeof(TypeEvent), Enums.TypeEvent.none);
            _ndo = new ConfigurationProperty("ndo", typeof(string), string.Empty);
            _properties = new ConfigurationPropertyCollection { _id,  _station, _type, _ndo };
        }

        public string Id
        {
            get { return base[_id] as string; }
            set { base[_id] = value; }
        }

        public string Station
        {
            get { return base[_station] as string; }
            set { base[_station] = value; }
        }

        public TypeEvent TypeEvent
        {
            get { return (TypeEvent)base[_type]; }
            set { base[_type] = value; }
        }

        public string Ndo
        {
            get { return (string)base[_ndo]; }
            set { base[_ndo] = value; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
}
