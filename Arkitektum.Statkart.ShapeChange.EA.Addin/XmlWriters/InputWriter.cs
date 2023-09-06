using System.IO;
using Kartverket.ShapeChange.EA.Addin.Util;
using System.Xml;

namespace Kartverket.ShapeChange.EA.Addin
{
    internal static class InputWriter
    {
        public static void WriteInputElement(this XmlWriter writer, InputSettings settings)
        {
            writer.WriteStartElement("input");
            writer.WriteAttributeString("id", "INPUT");

            writer.WriteParameterElement("inputModelType", "EA7");
            writer.WriteParameterElement("inputFile", settings.EaProjectFilePath);
            writer.WriteParameterElement("tmpDirectory", settings.TempDirectory);

            if (settings.IncludeDiagrams)
            {
                writer.WriteParameterElement("loadDiagrams", "true");
                writer.WriteParameterElement("packageDiagramRegex", @"^(.*[\W]+)?Overview([\W]+.*)?$");
                writer.WriteParameterElement("classDiagramRegex", @"^(.*[\W]+)?NAME([\W]+.*)?$");
            }

            writer.WriteParameterElement("appSchemaName", settings.SchemaName);

            writer.WriteParameterElement("addTaggedValues", "SOSI_navn,NVDB_ID,SOSI_verdi");

            writer.WriteParameterElement("representTaggedValues",
                "alwaysVoid,neverVoid,Code,lastChange,appliesTo,SOSI_navn,NVDB_ID,SOSI_verdi,SOSI_presentasjonsnavn,SOSI_bildeAvModellElement");

            writer.WriteIncludeElement(Path.Combine(settings.ConfigDirectory, "StandardAliases.xml"));

            writer.WriteEndElement();
        }
    }

    internal class InputSettings : TargetBaseSettings
    {
        public string EaProjectFilePath { get; }
        public string TempDirectory { get; }
        public string ConfigDirectory { get; }
        public string SchemaName { get; }
        public bool IncludeDiagrams { get; }

        public InputSettings(string outputDirectory, string eaProjectFilePath, string tempDirectory,
            string configDirectory, string schemaName, bool includeDiagrams) : base(outputDirectory)
        {
            EaProjectFilePath = eaProjectFilePath;
            TempDirectory = tempDirectory;
            ConfigDirectory = configDirectory;
            SchemaName = schemaName;
            IncludeDiagrams = includeDiagrams;
        }
    }
}
