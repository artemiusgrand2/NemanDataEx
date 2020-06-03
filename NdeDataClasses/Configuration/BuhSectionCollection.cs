using System.Configuration;

namespace NdeDataClasses.Configuration
{
  [ConfigurationCollection(typeof(BuhSectionElement),
      CollectionType = ConfigurationElementCollectionType.BasicMap,
      AddItemName = "buhSection")]
  public class BuhSectionCollection : ConfigurationElementCollection
  {
    private static ConfigurationPropertyCollection _properties;

    static BuhSectionCollection() {
      _properties = new ConfigurationPropertyCollection();
    }

    public override ConfigurationElementCollectionType CollectionType {
      get { return ConfigurationElementCollectionType.BasicMap; }
    }

    protected override string ElementName {
      get { return "buhSection"; }
    }

    protected override ConfigurationElement CreateNewElement() {
      return new BuhSectionElement();
    }

    protected override object GetElementKey(ConfigurationElement element) {
      return (element as BuhSectionElement).StationName;
    }

    protected override ConfigurationPropertyCollection Properties {
      get {
        return _properties;
      }
    }
  }
}
