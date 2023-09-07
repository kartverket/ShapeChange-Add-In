using System.Xml;
using Kartverket.ShapeChange.EA.Addin.Util;
using static Kartverket.ShapeChange.EA.Addin.Resources.LdProxy;

namespace Kartverket.ShapeChange.EA.Addin.LdProxy
{
    internal static class LdProxyPreprocessingTransformerWriter
    {
        public static void WriteLdProxyPreprocessingTransformers(this XmlWriter writer)
        {
            writer.WriteClassInheritanceFlattener();
            writer.WritePropertyTypeFlattener();
        }

        private static void WriteClassInheritanceFlattener(this XmlWriter writer)
        {
            writer.WriteStartElement("Transformer");
            writer.WriteTransformerAttributes(
                "de.interactive_instruments.ShapeChange.Transformation.Flattening.Flattener",
                "INPUT",
                "INHERITANCE_FLATTENING");

            writer.WriteStartElement("rules");

            writer.WriteStartElement("ProcessRuleSet");
            writer.WriteAttributeString("name", "flattener");

            writer.WriteStartElement("rule");
            writer.WriteAttributeString("name", "rule-trf-cls-flatten-inheritance");
            writer.WriteEndElement();

            writer.WriteEndElement(); //close ProcessRuleSet

            writer.WriteEndElement(); //close rules

            writer.WriteEndElement(); //close Transformer
        }

        private static void WritePropertyTypeFlattener(this XmlWriter writer)
        {
            writer.WriteStartElement("Transformer");
            writer.WriteTransformerAttributes(
                "de.interactive_instruments.ShapeChange.Transformation.Flattening.Flattener",
                "INHERITANCE_FLATTENING",
                InputId);

            writer.WriteStartElement("parameters");

            writer.WriteProcessParameterElement("flattenObjectTypes", "true");
            writer.WriteProcessParameterElement("flattenDataTypesExcludeRegex", ".*");
            writer.WriteProcessParameterElement("separatorForPropertyFromUnion", ".");
            writer.WriteProcessParameterElement("descriptorModification_nonUnionSeparator",
                "documentation{ : }, alias{ : }, definition{ : }, description{ : }, primaryCode{ : }");
            writer.WriteProcessParameterElement("descriptorModification_unionSeparator",
                "documentation{ : }, alias{ : }, definition{ : }, description{ : }, primaryCode{ : }");

            writer.WriteEndElement(); //close parameters

            writer.WriteStartElement("rules");

            writer.WriteStartElement("ProcessRuleSet");
            writer.WriteAttributeString("name", "flattener");

            writer.WriteStartElement("rule");
            writer.WriteAttributeString("name", "rule-trf-cls-flatten-inheritance");
            writer.WriteEndElement();

            writer.WriteEndElement(); //close ProcessRuleSet

            writer.WriteEndElement(); //close rules

            writer.WriteEndElement(); //close Transformer
        }
    }
}
