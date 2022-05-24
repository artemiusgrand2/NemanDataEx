using System.Configuration;

namespace NdeDataClasses.Configuration
{
    public class EngineConfigurationSection : ConfigurationSection
    {
        private static readonly ConfigurationProperty _buhSectionCollection;
        private static readonly ConfigurationProperty _trimmedCollection;
        private static readonly ConfigurationPropertyCollection _properties;

        static EngineConfigurationSection()
        {
            _buhSectionCollection = new ConfigurationProperty(
              "buhSections",
              typeof(BuhSectionCollection));
            _trimmedCollection = new ConfigurationProperty("trimmedEvents", typeof(TrimmedEventCollection));
            _properties = new ConfigurationPropertyCollection{
          _buhSectionCollection, _trimmedCollection
      };
        }

        public BuhSectionCollection BuhSectionCollection
        {
            get { return base[_buhSectionCollection] as BuhSectionCollection; }
            set { base[_buhSectionCollection] = value; }
        }

        public TrimmedEventCollection TrimmedEvents
        {
            get { return base[_trimmedCollection] as TrimmedEventCollection; }
            set { base[_trimmedCollection] = value; }
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }
    }
}
