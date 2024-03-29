﻿using System.Xml;
using Kartverket.ShapeChange.EA.Addin.Util;

namespace Kartverket.ShapeChange.EA.Addin.JsonSchema
{
    internal static class JsonSchemaWriter
    {
        public static void WriteJsonSchemaTarget(this XmlWriter writer, JsonSchemaSettings settings)
        {
            writer.WriteTargetStartElement("de.interactive_instruments.ShapeChange.Target.JSON.JsonSchemaTarget");

            writer.WriteTargetParameterElement("outputDirectory", settings.OutputDirectory);

            writer.WriteTargetParameterElement("jsonSchemaVersion", settings.SchemaVersion);

            writer.WriteTargetParameterElement("prettyPrint", "true");

            writer.WriteTargetParameterElement("sortedOutput", "true");

            writer.WriteTargetParameterElement("jsonBaseUri", "http://sosi.geonorge.no/ShapeChangeAddIn/");

            writer.WriteTargetParameterElement("defaultEncodingRule", "defaultJson");

            writer.WriteJsonSchemaEncodingRules();

            writer.WriteIncludeElement("http://shapechange.net/resources/config/StandardMapEntries_JSON.xml");

            writer.WriteEndElement();
        }
    }
}
