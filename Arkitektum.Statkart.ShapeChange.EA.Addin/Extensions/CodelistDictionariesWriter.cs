using System.Xml;
using Kartverket.ShapeChange.EA.Addin.TargetSettings;

namespace Kartverket.ShapeChange.EA.Addin.Extensions
{
    public static class CodelistDictionariesWriter
    {
        public static void WriteCodelistDictionariesTarget(this XmlTextWriter writer, CodelistDictionariesSettings settings)
        {
            writer.WriteStartElement("Target");
            writer.WriteAttributeString("class", "de.interactive_instruments.ShapeChange.Target.Codelists.CodelistDictionaries");
            writer.WriteAttributeString("mode", "enabled");

            writer.WriteTargetParameterElement("outputDirectory", settings.DirectoryName);

            writer.WriteTargetParameterElement("enumerations", settings.IncludeEnumerations ? "true" : "false");

            writer.WriteEndElement();
        }
    }
}
