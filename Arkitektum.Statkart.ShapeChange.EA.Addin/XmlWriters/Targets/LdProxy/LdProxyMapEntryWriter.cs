using System.Collections.Generic;
using System.Xml;

namespace Kartverket.ShapeChange.EA.Addin.LdProxy
{
    internal static class LdProxyMapEntryWriter
    {
        private static readonly Dictionary<string, string> GeometryMappings = new Dictionary<string, string>
        {
            { "Kurve", "LINE_STRING" },
            { "Sverm", "MULTI_POINT" },
            { "Punkt", "POINT" },
            { "Flate", "POLYGON" },
        };

        public static void WriteLdProxyMapEntries(this XmlWriter writer)
        {
            writer.WriteStartElement("mapEntries");

            writer.WriteLdProxyGeometryMappings();

            writer.WriteEndElement();
        }

        private static void WriteLdProxyGeometryMappings(this XmlWriter writer)
        {
            foreach (var mapping in GeometryMappings)
            {
                writer.WriteStartElement("MapEntry");
                writer.WriteAttributeString("type", mapping.Key);
                writer.WriteAttributeString("rule", "*");
                writer.WriteAttributeString("targetType", "GEOMETRY");
                writer.WriteAttributeString("param", $"geometryInfos{{geometryType={mapping.Value}}}");
                writer.WriteEndElement();
            }
        }
    }
}
