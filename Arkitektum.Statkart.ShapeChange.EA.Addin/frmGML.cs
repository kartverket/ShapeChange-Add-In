using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using EA;
using File = System.IO.File;

namespace Kartverket.ShapeChange.EA.Addin
{
    public partial class frmGML : Form
    {
        private static Repository _repository;
        delegate void SetTextCallback(string text);
        string dokformat;

        public frmGML()
        {
            InitializeComponent();
        }

        public void SetRepository(Repository newrepository)
        {
            _repository = newrepository;
            Boolean isValid = false;
            txtEapfil.Text = _repository.ConnectionString;

            //Sjekke tagged values
            Package aPackage;
            aPackage = _repository.GetTreeSelectedPackage();

            foreach (TaggedValue theTags in aPackage.Element.TaggedValues)
            {
                    
                switch (theTags.Name)
                {
                    case "xsdDocument": 
                        txtXsdfil.Text = theTags.Value;
                        break;
                    case "targetNamespace":
                        txtTargetNamespace.Text = theTags.Value;
                        break;
                    case "version":
                        txtVersion.Text = theTags.Value;
                        break;
                    case "xmlns":
                        txtXmlns.Text = theTags.Value;
                        break;
                    case "xsdEncodingRule":
                        txtEncoding.Text = theTags.Value;
                        break;
                    case "SOSI_produsent":
                        txtFCProducer.Text = theTags.Value;
                        break;
                }
                
            }

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string dlldir = Path.GetDirectoryName(path);
            txtShapechangeJar.Text = dlldir + "\\ShapeChange-2.9.0.jar";

            txtFCName.Text = aPackage.Name;
            txtFCName2.Text = txtFCName.Text;
            txtFCNote.Text = aPackage.Notes;
            txtVersionDate.Text = DateTime.Now.ToShortDateString();
            //txtFCProducer.Text = "";
            txtDocxTemplDir.Text = dlldir + "\\templates";
            txtDocxTemplFilename.Text = "mal.docx";
            txtFeatureTerm.Text = "Objekttype";

            string fil = _repository.ConnectionString;
            string eadirectory = Path.GetDirectoryName(fil);
            
            

            txtXsdKatalog.Text = eadirectory + "\\XSD\\";
            txtKodelisterkatalog.Text = eadirectory + "\\CL\\";
            txtExcelKatalog.Text = eadirectory + "\\Excel\\";
            txtFCKatalog.Text = eadirectory + "\\FC\\";
            //valideringsrutine

            //if (ValidateVersion() && ValidateXmlns() && ValidateXsdfil() && ValidateTargetNamespace()) isValid = true;
            //else isValid = false;
            isValid = true;
            btnGML.Enabled = isValid;

            btnLogg.Enabled = false;
            btnResult.Enabled = false;


        }

        private bool ValidateTargetNamespace()
        {
            bool bStatus = true;
            if (txtTargetNamespace.Text == "")
            {
                errorProvider1.SetError(txtTargetNamespace, "Namespace må være angitt. Feks http://skjema.geonorge.no/sosi/produktspesifikasjon/navn");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtTargetNamespace, "");
            return bStatus;
        }

        private bool ValidateXsdfil()
        {
            bool bStatus = true;
            if (txtXsdfil.Text == "")
            {
                errorProvider1.SetError(txtXsdfil, "Xsd filnavn må være angitt. Feks navn.xsd");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtXsdfil, "");
            return bStatus;
        }

        private bool ValidateXmlns()
        {
            bool bStatus = true;
            if (txtXmlns.Text == "")
            {
                errorProvider1.SetError(txtXmlns, "Xmlns må være angitt. Som regel sosi");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtXmlns, "");
            return bStatus;
        }

        private bool ValidateVersion()
        {
            bool bStatus = true;
            if (txtVersion.Text == "")
            {
                errorProvider1.SetError(txtVersion, "Version må være angitt. Feks 4.3 eller 1.0RC");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtVersion, "");
            return bStatus;
        }
        private bool ValidateEncoding()
        {
            bool bStatus = true;
            if (txtEncoding.Text == "")
            {
                errorProvider1.SetError(txtEncoding, "Encoding må være angitt. Feks iso19136_2007 eller iso19136_2007_INSPIRE_Extensions");
                bStatus = false;
            }
            else
                errorProvider1.SetError(txtEncoding, "");
            return bStatus;
        }

        private void GenerateGML(string format)
        {

            try
            {

            
            string fil = _repository.ConnectionString;

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string dlldir = Path.GetDirectoryName(path);
            string shapechangejar = txtShapechangeJar.Text;
            string eadirectory = Path.GetDirectoryName(fil);
            string shapechangeconfig = eadirectory +"\\config\\ShapeChangeConfiguration.xml";

            if (!Directory.Exists(eadirectory +"\\config\\"))
            {
                Directory.CreateDirectory(eadirectory + "\\config\\");
            }
            if (!Directory.Exists(eadirectory + "\\Excel\\"))
            {
                Directory.CreateDirectory(eadirectory + "\\Excel\\");
            }
            if (!Directory.Exists(eadirectory + "\\FC\\"))
            {
                Directory.CreateDirectory(eadirectory + "\\FC\\");
            }
            if (!Directory.Exists(eadirectory + "\\JSON\\"))
            {
                Directory.CreateDirectory(eadirectory + "\\JSON\\");
            }
            if (!Directory.Exists(eadirectory + "\\RDF\\"))
            {
                Directory.CreateDirectory(eadirectory + "\\RDF\\");
            }
            if (!Directory.Exists(eadirectory + "\\tmp\\"))
            {
                Directory.CreateDirectory(eadirectory + "\\tmp\\");
            }
            this.SetText("Starts config...");

            this.SetText("Copies ShapeChangeConfiguration.xsd, FC.xsd, html2.xsl, XInclude.xsd, StandardMapEntries.xml to " + eadirectory + "\\config\\");
            //Kopier noen standard config mapping filer
            File.Copy(dlldir + "\\config\\ShapeChangeConfiguration.xsd", eadirectory + "\\config\\ShapeChangeConfiguration.xsd", true);
            File.Copy(dlldir + "\\config\\FC.xsd", eadirectory + "\\FC\\FC.xsd", true);
            File.Copy(dlldir + "\\config\\html2.xsl", eadirectory + "\\FC\\html2.xsl", true);
            File.Copy(dlldir + "\\config\\html.xsl", eadirectory + "\\FC\\html.xsl", true);
            File.Copy(dlldir + "\\config\\docx-compact.xsl", eadirectory + "\\FC\\docx-compact.xsl", true);
            File.Copy(dlldir + "\\config\\docx.xsl", eadirectory + "\\FC\\docx.xsl", true);
            File.Copy(dlldir + "\\config\\docx_rels.xsl", eadirectory + "\\FC\\docx_rels.xsl", true);
            File.Copy(dlldir + "\\config\\localization.xsl", eadirectory + "\\FC\\localization.xsl", true);
            File.Copy(dlldir + "\\config\\localizationMessages.xml", eadirectory + "\\FC\\localizationMessages.xml", true);
            File.Copy(dlldir + "\\config\\stylesheet.css", eadirectory + "\\FC\\stylesheet.css", true);
            File.Copy(dlldir + "\\config\\frameHtml.xsl", eadirectory + "\\FC\\frameHtml.xsl", true);
            File.Copy(dlldir + "\\config\\XInclude.xsd", eadirectory + "\\config\\XInclude.xsd", true);
            File.Copy(dlldir + "\\config\\StandardMapEntries.xml", eadirectory + "\\config\\StandardMapEntries.xml", true);
            File.Copy(dlldir + "\\config\\StandardMapEntries_sosi.xml", eadirectory + "\\config\\StandardMapEntries_sosi.xml", true);


            
            this.SetText("Writes ShapeChangeConfiguration.xml");
            WriteConfig(fil, eadirectory, shapechangeconfig, txtFCName.Text, txtEncoding.Text, format);

            this.SetText("Writes runshapechange.bat");
            TextWriter tw = new StreamWriter(eadirectory + "\\runshapechange.bat");
            //proxy 
            if (!string.IsNullOrWhiteSpace(Properties.Settings.Default.ProxyHost))
                tw.WriteLine("\"" + Properties.Settings.Default.JavaRuntime + "\" -Dfile.encoding=UTF-8 -Dhttp.proxyHost=" + Properties.Settings.Default.ProxyHost + " -Dhttp.proxyPort=" + Properties.Settings.Default.ProxyPort + " -jar \"" + shapechangejar + "\" -c \"" + shapechangeconfig + "\"");
            else
                tw.WriteLine("\"" + Properties.Settings.Default.JavaRuntime + "\" -Dfile.encoding=UTF-8 -jar \"" + shapechangejar + "\" -c \"" + shapechangeconfig + "\"");
            tw.Close();

            
            this.SetText(DateTime.Now + " - Runs runshapechange.bat ...");
            
            string fileName = eadirectory + "\\runshapechange.bat";
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = fileName;
            
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            
            proc.ErrorDataReceived += proc_DataReceived;
            proc.OutputDataReceived += proc_DataReceived;
            proc.EnableRaisingEvents = true;
            proc.Exited += proc_Exited;
            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
           
           
            proc.WaitForExit();

           
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
                this.SetText("Error -> " + e.Message);
            }

        }

        private void proc_Exited(object sender, EventArgs e)
        {
            SetText(DateTime.Now + " - Completed");
            //Hvis loggfil finnes så vis denne
            string fil = _repository.ConnectionString;
            string eadirectory = Path.GetDirectoryName(fil);
            FileInfo f = new FileInfo(eadirectory + "\\log.html");
            if (f.Exists) System.Diagnostics.Process.Start(eadirectory + "\\log.html");

        }



        void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            SetText(e.Data);
        }
       
        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtLogg.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.txtLogg.Text = this.txtLogg.Text + Environment.NewLine + text;
            }
        }


        private void WriteConfig(string fil, string eadirectory, string shapechangeconfig, string skjemanavn, string encodingRule, string dokformat)
        {
            XmlTextWriter textWriter = new XmlTextWriter(shapechangeconfig, null);
            textWriter.WriteStartDocument();

            // Write first element

            textWriter.WriteStartElement("ShapeChangeConfiguration", "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1");
            textWriter.WriteAttributeString("xmlns", "xi", null, "http://www.w3.org/2001/XInclude");
            textWriter.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            textWriter.WriteAttributeString("xmlns", "sc", null, "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1");
            textWriter.WriteAttributeString("xsi", "schemaLocation", null, "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1 http://shapechange.net/resources/schema/ShapeChangeConfiguration.xsd");

            textWriter.WriteStartElement("input");
            
            textWriter.WriteStartElement("parameter");
            textWriter.WriteStartAttribute("name");
            textWriter.WriteString("inputModelType");
            textWriter.WriteEndAttribute();
            textWriter.WriteStartAttribute("value");
            textWriter.WriteString("EA7");
            textWriter.WriteEndAttribute();
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("parameter");
            textWriter.WriteStartAttribute("name");
            textWriter.WriteString("inputFile");
            textWriter.WriteEndAttribute();
            textWriter.WriteStartAttribute("value");
            textWriter.WriteString(fil);
            textWriter.WriteEndAttribute();
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("parameter");
            textWriter.WriteAttributeString("name", "loadDiagrams");
            if (chIncludeDiagrams.Checked)
                textWriter.WriteAttributeString("value", "true");
            else
                textWriter.WriteAttributeString("value", "false");
            textWriter.WriteEndElement();


            textWriter.WriteStartElement("parameter");
            textWriter.WriteStartAttribute("name");
            textWriter.WriteString("tmpDirectory");
            textWriter.WriteEndAttribute();
            textWriter.WriteStartAttribute("value");
            textWriter.WriteString(eadirectory + "\\tmp");
            textWriter.WriteEndAttribute();
            textWriter.WriteEndElement();
            if (chIncludeDiagrams.Checked)
            {
                textWriter.WriteStartElement("parameter");
                textWriter.WriteStartAttribute("name");
                textWriter.WriteString("packageDiagramRegex");
                textWriter.WriteEndAttribute();
                textWriter.WriteStartAttribute("value");
                textWriter.WriteString(@"^(.*[\W]+)?Overview([\W]+.*)?$");
                textWriter.WriteEndAttribute();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("parameter");
                textWriter.WriteStartAttribute("name");
                textWriter.WriteString("classDiagramRegex");
                textWriter.WriteEndAttribute();
                textWriter.WriteStartAttribute("value");
                textWriter.WriteString(@"^(.*[\W]+)?NAME([\W]+.*)?$");
                textWriter.WriteEndAttribute();
                textWriter.WriteEndElement();
            }

            if (chMakeXsd.Checked || chKodelister.Checked)
            {
                textWriter.WriteStartElement("parameter");
                textWriter.WriteStartAttribute("name");
                textWriter.WriteString("appSchemaName");
                textWriter.WriteEndAttribute();
                textWriter.WriteStartAttribute("value");
                textWriter.WriteString(skjemanavn);
                textWriter.WriteEndAttribute();
                textWriter.WriteEndElement();
            }

            textWriter.WriteStartElement("parameter");
            textWriter.WriteStartAttribute("name");
            textWriter.WriteString("addTaggedValues");
            textWriter.WriteEndAttribute();
            textWriter.WriteStartAttribute("value");
            textWriter.WriteString("SOSI_navn,NVDB_ID,SOSI_verdi");
            textWriter.WriteEndAttribute();
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("parameter");
            textWriter.WriteStartAttribute("name");
            textWriter.WriteString("representTaggedValues");
            textWriter.WriteEndAttribute();
            textWriter.WriteStartAttribute("value");
            textWriter.WriteString("alwaysVoid,neverVoid,Code,lastChange,appliesTo,SOSI_navn,NVDB_ID,SOSI_verdi,SOSI_presentasjonsnavn,SOSI_bildeAvModellElement");
            textWriter.WriteEndAttribute();
            textWriter.WriteEndElement();

            //<xi:include href="StandardAliases.xml"/>
            textWriter.WriteStartElement("include", "http://www.w3.org/2001/XInclude");
            textWriter.WriteAttributeString("href", "http://shapechange.net/resources/config/StandardAliases.xml");
            textWriter.WriteEndElement();

            textWriter.WriteEndElement(); //close input

            textWriter.WriteStartElement("log");

            textWriter.WriteStartElement("parameter");
            textWriter.WriteStartAttribute("name");
            textWriter.WriteString("reportLevel");
            textWriter.WriteEndAttribute();
            textWriter.WriteStartAttribute("value");
            textWriter.WriteString(Properties.Settings.Default.ReportLevel);
            textWriter.WriteEndAttribute();
            textWriter.WriteEndElement();

            textWriter.WriteStartElement("parameter");
            textWriter.WriteStartAttribute("name");
            textWriter.WriteString("logFile");
            textWriter.WriteEndAttribute();
            textWriter.WriteStartAttribute("value");
            textWriter.WriteString(eadirectory + "\\log.xml");
            textWriter.WriteEndAttribute();
            textWriter.WriteEndElement();

            textWriter.WriteEndElement(); //close log

            textWriter.WriteStartElement("targets");

            
                textWriter.WriteStartElement("TargetXmlSchema");
                textWriter.WriteStartAttribute("class");
                textWriter.WriteString("de.interactive_instruments.ShapeChange.Target.XmlSchema.XmlSchema");
                textWriter.WriteEndAttribute();
                if (chMakeXsd.Checked) textWriter.WriteAttributeString("mode", "enabled");
                else textWriter.WriteAttributeString("mode", "disabled");

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteStartAttribute("name");
                textWriter.WriteString("outputDirectory");
                textWriter.WriteEndAttribute();
                textWriter.WriteStartAttribute("value");
                textWriter.WriteString(eadirectory + "\\XSD");
                textWriter.WriteEndAttribute();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteStartAttribute("name");
                textWriter.WriteString("defaultEncodingRule");
                textWriter.WriteEndAttribute();
                textWriter.WriteStartAttribute("value");
                textWriter.WriteString(encodingRule);
                textWriter.WriteEndAttribute();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("include", "http://www.w3.org/2001/XInclude");
                textWriter.WriteAttributeString("href", "http://sosi.geonorge.no/ShapeChangeAddIn/3.0/StandardRules.xml");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("include", "http://www.w3.org/2001/XInclude");
                textWriter.WriteAttributeString("href", "http://shapechange.net/resources/config/StandardNamespaces.xml");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("include", "http://www.w3.org/2001/XInclude");
                textWriter.WriteAttributeString("href", eadirectory +"/config/StandardMapEntries.xml");
                textWriter.WriteEndElement();

               

                textWriter.WriteEndElement(); //close xsd
           
            
            if (chKodelister.Checked)
            {
                textWriter.WriteStartElement("Target");
                textWriter.WriteStartAttribute("class");
                textWriter.WriteString("de.interactive_instruments.ShapeChange.Target.Codelists.CodelistDictionaries");
                textWriter.WriteEndAttribute();
                textWriter.WriteAttributeString("mode", "enabled");

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteStartAttribute("name");
                textWriter.WriteString("outputDirectory");
                textWriter.WriteEndAttribute();
                textWriter.WriteStartAttribute("value");
                textWriter.WriteString(eadirectory + "\\CL");
                textWriter.WriteEndAttribute();
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteStartAttribute("name");
                textWriter.WriteString("enumerations");
                textWriter.WriteEndAttribute();
                textWriter.WriteStartAttribute("value");
                if (chEnums.Checked) textWriter.WriteString("true");
                else textWriter.WriteString("false");
                textWriter.WriteEndAttribute();
                textWriter.WriteEndElement();

                textWriter.WriteEndElement(); //close CL target
            }

            if (chfeatureCatalog.Checked)
            {

                //Test på dokumenttype
               

                textWriter.WriteStartElement("Target");
                textWriter.WriteStartAttribute("class");
                textWriter.WriteString("de.interactive_instruments.ShapeChange.Target.FeatureCatalogue.FeatureCatalogue");
                textWriter.WriteEndAttribute();
                textWriter.WriteAttributeString("mode", "enabled");
              

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "outputDirectory");
                textWriter.WriteAttributeString("value", eadirectory + "\\FC");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "outputFilename");
                textWriter.WriteAttributeString("value", "FeatureCatalogue");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "inheritedProperties");
                textWriter.WriteAttributeString("value", "true");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "changeInfo");
                textWriter.WriteAttributeString("value", "false");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "outputFormat");
                if (dokformat=="DOCX-COMPACT")
                    textWriter.WriteAttributeString("value", "DOCX");
                else
                    textWriter.WriteAttributeString("value", dokformat);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "name");
                textWriter.WriteAttributeString("value", skjemanavn);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "scope");
                textWriter.WriteAttributeString("value", txtFCNote.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "versionNumber");
                textWriter.WriteAttributeString("value", txtVersion.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "versionDate");
                textWriter.WriteAttributeString("value", txtVersionDate.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "producer");
                textWriter.WriteAttributeString("value", txtFCProducer.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "xsltPfad");
                textWriter.WriteAttributeString("value", eadirectory + "\\FC");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "xsltPath");
                textWriter.WriteAttributeString("value", eadirectory + "\\FC");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "tmpDirectory");
                textWriter.WriteAttributeString("value", eadirectory + "\\tmp");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "xslhtmlFile");
                textWriter.WriteAttributeString("value", "html2.xsl");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "xslframeHtmlFileName");
                textWriter.WriteAttributeString("value", "frameHtml.xsl");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "xsldocxFile");
                if (dokformat == "DOCX-COMPACT")
                    textWriter.WriteAttributeString("value", "docx-compact.xsl");
                else
                    textWriter.WriteAttributeString("value", "docx.xsl");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "docxTemplateDirectory");
                textWriter.WriteAttributeString("value", txtDocxTemplDir.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "docxTemplateFilename");
                textWriter.WriteAttributeString("value", txtDocxTemplFilename.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "docxTemplateFilePath");
                textWriter.WriteAttributeString("value", txtDocxTemplDir.Text + @"\" + txtDocxTemplFilename.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "notesRuleMarker");
                textWriter.WriteAttributeString("value", "-==-");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "xslTransformerFactory");
                textWriter.WriteAttributeString("value", "net.sf.saxon.TransformerFactoryImpl");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "featureTerm");
                textWriter.WriteAttributeString("value", txtFeatureTerm.Text);
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "includeDiagrams");
                if (chIncludeDiagrams.Checked)
                    textWriter.WriteAttributeString("value", "true");
                else
                    textWriter.WriteAttributeString("value", "false");
                textWriter.WriteEndElement();

                
                
                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "includeTitle");
                if (chIncludeTitle.Checked)
                    textWriter.WriteAttributeString("value", "true");
                else
                    textWriter.WriteAttributeString("value", "false");
                textWriter.WriteEndElement();

                textWriter.WriteStartElement("targetParameter");
                textWriter.WriteAttributeString("name", "includeVoidable");
                if (chIncludeVoidable.Checked)
                    textWriter.WriteAttributeString("value", "true");
                else
                    textWriter.WriteAttributeString("value", "false");
                textWriter.WriteEndElement();
               
                textWriter.WriteEndElement(); //close FeatureCatalog target
            }

            //if (chmappingtabeller.checked)
            //{
            //    textWriter.WriteStartElement("Target");
            //    textWriter.WriteStartAttribute("class");
            //    textWriter.WriteString("de.interactive_instruments.ShapeChange.Target.Mapping.Excel");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteAttributeString("mode", "enabled");

            //    textWriter.WriteStartElement("targetParameter");
            //    textWriter.WriteStartAttribute("name");
            //    textWriter.WriteString("outputDirectory");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteStartAttribute("value");
            //    textWriter.WriteString(eadirectory + "\\Excel");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteEndElement();

            //    textWriter.WriteEndElement(); //close Excel target
            //}
            //if (chJSON.Checked)
            //{
            //    textWriter.WriteStartElement("Target");
            //    textWriter.WriteStartAttribute("class");
            //    textWriter.WriteString("de.interactive_instruments.ShapeChange.Target.JSON.JsonSchema");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteAttributeString("mode", "enabled");

            //    textWriter.WriteStartElement("targetParameter");
            //    textWriter.WriteStartAttribute("name");
            //    textWriter.WriteString("outputDirectory");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteStartAttribute("value");
            //    textWriter.WriteString(eadirectory + "\\JSON");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteEndElement();

            //    textWriter.WriteEndElement(); //close Excel target
            //}
            //if (chOWL.Checked)
            //{
            //    textWriter.WriteStartElement("Target");
            //    textWriter.WriteStartAttribute("class");
            //    textWriter.WriteString("de.interactive_instruments.ShapeChange.Target.Ontology.RDF");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteAttributeString("mode", "enabled");

            //    textWriter.WriteStartElement("targetParameter");
            //    textWriter.WriteStartAttribute("name");
            //    textWriter.WriteString("outputDirectory");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteStartAttribute("value");
            //    textWriter.WriteString(eadirectory + "\\RDF");
            //    textWriter.WriteEndAttribute();
            //    textWriter.WriteEndElement();

            //    textWriter.WriteEndElement(); //close Excel target
            //}

            textWriter.WriteEndElement(); //close targets

            textWriter.WriteEndElement();

            textWriter.WriteEndDocument();
            textWriter.Close();
        }

        private void btnGML_Click(object sender, EventArgs e)
        {
            bool isValid = true;
            if (chKodelister.Checked || chMakeXsd.Checked) {
                if (ValidateEncoding() && ValidateVersion() && ValidateXmlns() && ValidateXsdfil() && ValidateTargetNamespace()) isValid = true;
                else isValid = false;
            }
            if (isValid)
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                progressBar1.Visible = true;
                btnLogg.Enabled = false;
                btnGML.Enabled = false;
                btnClose.Enabled = false;
                btnResult.Enabled = false;
                txtLogg.Text = "";
                tabControl1.SelectedTab = tpLogg;
                dokformat = cbFormat.Text;

                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                bw.RunWorkerCompleted += delegate
                                             {
                                                 progressBar1.Visible = false;
                                                 btnLogg.Enabled = true;
                                                 btnGML.Enabled = true;
                                                 btnClose.Enabled = true;
                                                 btnResult.Enabled = true;
                                             };
                bw.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Tagged values missing for correct generation. Please update tagged values.");
            }
        }



        void bw_DoWork(object sender, DoWorkEventArgs e)
        {


            GenerateGML(dokformat);

            
        }
 

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            string fil = _repository.ConnectionString;

            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            string dlldir = Path.GetDirectoryName(path);
            string shapechangejar = dlldir + "\\lib\\ShapeChange.jar";
            string eadirectory = Path.GetDirectoryName(fil);
            string shapechangeconfig = eadirectory + "\\config\\ShapeChangeConfiguration.xml";

            //WriteConfig(fil, eadirectory, shapechangeconfig);
        }

        private void btnLogg_Click(object sender, EventArgs e)
        {
            string fil = _repository.ConnectionString;
            string eadirectory = Path.GetDirectoryName(fil);
            System.Diagnostics.Process.Start(eadirectory + "\\log.html");

        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string fil = _repository.ConnectionString;
            string eadirectory = Path.GetDirectoryName(fil);
            System.Diagnostics.Process.Start(eadirectory + "\\XSD\\" + txtXsdfil.Text);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        private void frmGML_Load(object sender, EventArgs e)
        {
            errorProvider1.ContainerControl = this;

        }

        private void txtXsdfil_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://kartverket.no/geodataarbeid/Standarder/SOSI/Programmer-og-verktoy/");
        }

        private void chMappingtabeller_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chfeatureCatalog_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtFCProducer_TextChanged(object sender, EventArgs e)
        {

        }

        private void tpFC_Click(object sender, EventArgs e)
        {

        }

        private void TxtShapechangeJar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
