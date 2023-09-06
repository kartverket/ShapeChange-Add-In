namespace Kartverket.ShapeChange.EA.Addin.TargetSettings
{
    public class XmlSchemaSettings
    {
        public bool Enabled { get; }
        public string DirectoryName { get; }
        public string EncodingRule { get; }

        public XmlSchemaSettings(bool enabled, string directoryName, string encodingRule)
        {
            Enabled = enabled;
            DirectoryName = directoryName;
            EncodingRule = encodingRule;
        }
    }
}
