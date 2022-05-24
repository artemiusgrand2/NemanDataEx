using System.Configuration;

namespace NdeDataClasses.Configuration
{
    [ConfigurationCollection(typeof(TrimmedEventElement),
      CollectionType = ConfigurationElementCollectionType.BasicMap,
      AddItemName = "event")]
    public class TrimmedEventCollection : ConfigurationElementCollection
    {
        private static readonly ConfigurationPropertyCollection _properties;

        static TrimmedEventCollection()
        {
            _properties = new ConfigurationPropertyCollection();
        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get { return ConfigurationElementCollectionType.BasicMap; }
        }

        protected override string ElementName
        {
            get { return "event"; }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new TrimmedEventElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as TrimmedEventElement).Id;
        }

        protected override ConfigurationPropertyCollection Properties
        {
            get { return _properties; }
        }

        public void Add(TrimmedEventElement element)
        {
            base.BaseAdd(element);
        }
    }
}
