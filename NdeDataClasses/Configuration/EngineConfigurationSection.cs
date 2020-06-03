using System.Configuration;

namespace NdeDataClasses.Configuration
{
  public class EngineConfigurationSection : ConfigurationSection
  {
    private static readonly ConfigurationProperty _buhSectionCollection;
    private static readonly ConfigurationPropertyCollection _properties;

    static EngineConfigurationSection(){
      _buhSectionCollection = new ConfigurationProperty(
        "buhSections",
        typeof (BuhSectionCollection));
      _properties = new ConfigurationPropertyCollection{
          _buhSectionCollection
      };
    }

    public BuhSectionCollection BuhSectionCollection{
      get { return base[_buhSectionCollection] as BuhSectionCollection; }
      set { base[_buhSectionCollection] = value; }
    }

    protected override ConfigurationPropertyCollection Properties{
      get { return _properties; }
    }
  }
}
