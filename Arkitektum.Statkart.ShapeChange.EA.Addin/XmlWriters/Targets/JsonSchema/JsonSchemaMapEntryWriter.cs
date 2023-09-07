using System.Xml;
using Kartverket.ShapeChange.EA.Addin.Util;

namespace Kartverket.ShapeChange.EA.Addin.JsonSchema
{
    internal static class JsonSchemaMapEntryWriter
    {
        public static void WriteJsonSchemaMapEntries(this XmlWriter writer)
        {
            writer.WriteStartElement("mapEntries");

            writer.WriteGeometryMapEntry("Punkt", "https://geojson.org/schema/Point.json");
            writer.WriteGeometryMapEntry("Kurve", "https://geojson.org/schema/LineString.json");
            writer.WriteGeometryMapEntry("Flate", "https://geojson.org/schema/Polygon.json");
            writer.WriteGeometryMapEntry("Sverm", "https://geojson.org/schema/MultiPoint.json");

            writer.WriteEndElement();
        }

        private static void WriteGeometryMapEntry(this XmlWriter writer, string type, string targetTypeUrl)
        {
            writer.WriteStartElement("MapEntry");
            writer.WriteAttributeString("type", type);
            writer.WriteAttributeString("rule", "*");
            writer.WriteAttributeString("targetType", targetTypeUrl);
            writer.WriteAttributeString("param", "geometry");
            writer.WriteEndElement();
        }
    }
}
