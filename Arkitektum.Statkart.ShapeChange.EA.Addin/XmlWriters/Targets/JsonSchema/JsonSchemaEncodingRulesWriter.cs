using System.Xml;
using Kartverket.ShapeChange.EA.Addin.Util;

namespace Kartverket.ShapeChange.EA.Addin.JsonSchema
{
    internal static class JsonSchemaEncodingRulesWriter
    {
        public static void WriteJsonSchemaEncodingRules(this XmlWriter writer)
        {
            writer.WriteStartElement("rules");

            writer.WriteStartElement("EncodingRule");
            writer.WriteAttributeString("name", "defaultJson");

            writer.WriteRuleElement("rule-json-cls-basictype");
            writer.WriteRuleElement("rule-json-cls-codelist-uri-format");
            writer.WriteRuleElement("rule-json-cls-name-as-entityType");
            
            writer.WriteEndElement();

            writer.WriteEndElement();
        }
    }
}
