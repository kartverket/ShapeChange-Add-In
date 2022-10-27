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

            writer.WriteIncludeElement("http://shapechange.net/resources/config/StandardAliases.xml");

            writer.WriteEndElement();
        }
    }

    internal class InputSettings
    {
        public string EaProjectFilePath { get; }
        public string TempDirectory { get; }
        public string SchemaName { get; }
        public bool IncludeDiagrams { get; }

        public InputSettings(string eaProjectFilePath, string tempDirectory, string schemaName, bool includeDiagrams)
        {
            EaProjectFilePath = eaProjectFilePath;
            TempDirectory = tempDirectory;
            SchemaName = schemaName;
            IncludeDiagrams = includeDiagrams;
        }
    }
}
