namespace Kartverket.ShapeChange.EA.Addin.JsonSchema
{
    internal class JsonSchemaSettings : TargetBaseSettings
    {
        public string SchemaVersion { get; set; }

        public JsonSchemaSettings(string outputDirectory, string schemaVersion) : base(outputDirectory)
        {
            SchemaVersion = schemaVersion;
        }
    }
}