namespace Kartverket.ShapeChange.EA.Addin.XmlSchema
{
    internal class XmlSchemaSettings : TargetBaseSettings
    {
        public string EncodingRule { get; }
        public string ConfigDirectory { get; }

        public XmlSchemaSettings(string outputDirectory, string encodingRule, string configDirectory) : base(outputDirectory)
        {
            EncodingRule = encodingRule;
            ConfigDirectory = configDirectory;
        }
    }
}