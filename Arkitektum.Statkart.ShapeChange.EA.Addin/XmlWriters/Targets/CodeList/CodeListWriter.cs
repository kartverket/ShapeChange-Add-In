using Kartverket.ShapeChange.EA.Addin.Util;
using System.Xml;

namespace Kartverket.ShapeChange.EA.Addin.CodeList
{
    internal static class CodeListWriter
    {
        public static void WriteCodeListTarget(this XmlWriter writer, CodeListSettings settings)
        {
            writer.WriteTargetStartElement("de.interactive_instruments.ShapeChange.Target.Codelists.CodelistDictionaries");

            writer.WriteTargetParameterElement("outputDirectory", settings.OutputDirectory);

            writer.WriteTargetParameterElement("enumerations", settings.GenerateEnums.ToString().ToLower());

            writer.WriteEndElement();
        }
    }
}
