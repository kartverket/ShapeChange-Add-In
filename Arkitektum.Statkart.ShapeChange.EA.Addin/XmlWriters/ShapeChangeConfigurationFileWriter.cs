using Kartverket.ShapeChange.EA.Addin.Util;
using System.IO;
using System.Text;
using System.Xml;

namespace Kartverket.ShapeChange.EA.Addin
{
    internal sealed class ShapeChangeConfigurationFileWriter : XmlTextWriter
    {
        public ShapeChangeConfigurationFileWriter(string shapeChangeConfigFullFilename, Encoding encoding) : 
            base(shapeChangeConfigFullFilename, encoding)
        {
            Formatting = Formatting.Indented;
            Indentation = 2;
            IndentChar = ' ';
            QuoteChar = '"';
        }

        /// <summary>
        /// Writes the initial elements of the ShapeChangeConfiguration.xml
        /// </summary>
        public void WriteInitialElements(InputSettings inputSettings)
        {
            WriteStartDocument();

            // Write first element

            WriteStartElement("ShapeChangeConfiguration", "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1");
            WriteAttributeString("xmlns", "xi", null, "http://www.w3.org/2001/XInclude");
            WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            WriteAttributeString("xmlns", "sc", null, "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1");
            WriteAttributeString("xsi", "schemaLocation", null, "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1 http://shapechange.net/resources/schema/ShapeChangeConfiguration.xsd");

            this.WriteInputElement(inputSettings);

            WriteLogElement(inputSettings.OutputDirectory);
        }

        public void WriteClosingElements()
        {
            WriteEndElement(); //close ShapeChangeConfiguration

            WriteEndDocument();
            Close();
        }

        private void WriteLogElement(string resultDirectory)
        {
            WriteStartElement("log");

            this.WriteParameterElement("reportLevel", Properties.Settings.Default.ReportLevel);
            this.WriteParameterElement("logFile", Path.Combine(resultDirectory, "log.xml"));

            WriteEndElement();
        }
    }
}
