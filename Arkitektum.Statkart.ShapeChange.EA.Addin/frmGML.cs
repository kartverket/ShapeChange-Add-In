using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using EA;
using Kartverket.ShapeChange.EA.Addin.Extensions;
using Kartverket.ShapeChange.EA.Addin.Properties;
using Kartverket.ShapeChange.EA.Addin.TargetSettings;
using static Kartverket.ShapeChange.EA.Addin.Resources.formGml;
using File = System.IO.File;

namespace Kartverket.ShapeChange.EA.Addin
{
    public partial class frmGML : Form
    {
        private static Repository _repository;
        private delegate void SetTextCallback(string text);

        private XmlSchemaSettings _xmlSchemaSettings;
        private FeatureCatalogueSettings _featureCatalogueSettings;
        private CodelistDictionariesSettings _codelistDictionariesSettings;

        private string _applicationDirectory;
        private string _eaProjectFilePath;
        private string _resultDirectory;
        private string _featureCatalogueFormat;
        private string _featureCatalogueDirectory;
        private string _codeListDirectory;
        private string _configDirectory;
        private string _excelDirectory;
        private string _tmpDirectory;
        private string _xsdDirectory;
        private string _shapeChangeJarFullFilename;

        public frmGML()
        {
            InitializeComponent();
            if (Settings.Default.UpdateSettings)
            {
                var proxyHost = Settings.Default.ProxyHost;
                var proxyPort = Settings.Default.ProxyPort;
                var reportLevel = Settings.Default.ReportLevel;
                Settings.Default.Upgrade();
                Settings.Default.ProxyHost = proxyHost;
                Settings.Default.ProxyPort = proxyPort;
                Settings.Default.ReportLevel = reportLevel;
                Settings.Default.UpdateSettings = false;
                Settings.Default.Save();
            }
        }

        public void SetRepository(Repository newrepository)
        {
            _repository = newrepository;
            _eaProjectFilePath = _repository.ConnectionString;
            var codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);
            _applicationDirectory = Path.GetDirectoryName(path);
            if (_applicationDirectory == null)
            {
                HandleError(applicationDirectoryErrorMessage);
                return;
            }
            var eaDirectory = Path.GetDirectoryName(_eaProjectFilePath);
            if (eaDirectory == null)
            {
                HandleError(eaProjectDirectoryErrorMessage);
                return;
            }

            _resultDirectory = Path.Combine(eaDirectory, $"gmlTransform_{_repository.GetTreeSelectedPackage().Name}");

            SetProperties();

            buttonTransform.Enabled = true;
            buttonLogOpenLog.Enabled = false;
            buttonLogOpenResult.Enabled = false;
        }

        private void HandleError(string errorMessage)
        {
            MessageBox.Show(errorMessage);
            SetText($"Error: {errorMessage}");
        }

        private void SetProperties()
        {
            var selectedPackage = _repository.GetTreeSelectedPackage();

            foreach (TaggedValue taggedValue in selectedPackage.Element.TaggedValues)
            {
                switch (taggedValue.Name)
                {
                    case "xsdDocument":
                        textBoxPropsXsdFile.Text = taggedValue.Value;
                        break;
                    case "targetNamespace":
                        textBoxPropsTargetNamespace.Text = taggedValue.Value;
                        break;
                    case "version":
                        textBoxPropsVersion.Text = taggedValue.Value;
                        break;
                    case "xmlns":
                        textBoxPropsXmlns.Text = taggedValue.Value;
                        break;
                    case "xsdEncodingRule":
                        textBoxPropsEncoding.Text = taggedValue.Value;
                        break;
                    case "SOSI_produsent":
                        textBoxFeatureCatalogueProducer.Text = taggedValue.Value;
                        break;
                }
            }

            _featureCatalogueDirectory = Path.Combine(_resultDirectory, "FC");
            _codeListDirectory = Path.Combine(_resultDirectory, "CL");
            _configDirectory = Path.Combine(_resultDirectory, "config");
            _excelDirectory = Path.Combine(_resultDirectory, "Excel");
            _tmpDirectory = Path.Combine(_resultDirectory, "tmp");
            _xsdDirectory = Path.Combine(_resultDirectory, "XSD");
            
            _shapeChangeJarFullFilename = Path.IsPathRooted(Settings.Default.ShapeChangeJar)
                ? Settings.Default.ShapeChangeJar
                : Path.Combine(_applicationDirectory, Settings.Default.ShapeChangeJar);

            textBoxPropsCodeListDirectory.Text = _codeListDirectory;
            textBoxPropsEaProjectFile.Text = _eaProjectFilePath;
            textBoxPropsExcelDirectory.Text = _excelDirectory;
            textBoxPropsFeatureCatalogueName.Text = selectedPackage.Name;
            textBoxPropsXsdDirectory.Text = _xsdDirectory;

            textBoxFeatureCatalogueDescription.Text = selectedPackage.Notes;
            textBoxFeatureCatalogueDocxTemplateDirectory.Text = Path.Combine(_applicationDirectory, "templates");
            textBoxFeatureCatalogueDocxTemplateFilename.Text = featureCatalogueTemplateFilename;
            textBoxFeatureCatalogueExportDirectory.Text = _featureCatalogueDirectory;
            textBoxFeatureCatalogueFeatureTerm.Text = featureCatalogueFeatureTerm;
            textBoxFeatureCatalogueName.Text = selectedPackage.Name;
            textBoxFeatureCatalogueVersionDate.Text = DateTime.Now.ToShortDateString();
        }

        private void CreateTargetSettings()
        {
            _xmlSchemaSettings = CreateXmlSchemaSettings();

            _featureCatalogueSettings = CreateFeatureCatalogueSettings();

            if (checkBoxCodeLists.Checked)
                _codelistDictionariesSettings = CreateCodelistDictionariesSettings();
        }

        private XmlSchemaSettings CreateXmlSchemaSettings()
        {
            return new XmlSchemaSettings(
                enabled: checkBoxMakeXsd.Checked,
                directoryName: _xsdDirectory,
                encodingRule: textBoxPropsEncoding.Text
            );
        }
        private FeatureCatalogueSettings CreateFeatureCatalogueSettings()
        {
            return new FeatureCatalogueSettings(
                directory: _featureCatalogueDirectory,
                format: _featureCatalogueFormat,
                description: textBoxFeatureCatalogueDescription.Text,
                version: textBoxPropsVersion.Text,
                versionDate: textBoxFeatureCatalogueVersionDate.Text,
                producer: textBoxFeatureCatalogueProducer.Text,
                docxTemplateFullFilename: Path.Combine(textBoxFeatureCatalogueDocxTemplateDirectory.Text, textBoxFeatureCatalogueDocxTemplateFilename.Text),
                featureTerm: textBoxFeatureCatalogueFeatureTerm.Text,
                includeDiagrams: checkBoxFeatureCatalogueIncludeDiagrams.Checked,
                includeTitle: checkBoxFeatureCatalogueIncludeTitle.Checked,
                includeVoidable: checkBoxFeatureCatalogueIncludeVoidable.Checked
            );
        }

        private CodelistDictionariesSettings CreateCodelistDictionariesSettings()
        {
            return new CodelistDictionariesSettings(
                directoryName: _codeListDirectory,
                includeEnumerations: checkBoxGenerateEnums.Checked
            );
        }

        private bool ValidateTargetNamespace()
        {
            var bStatus = true;
            if (textBoxPropsTargetNamespace.Text == "")
            {
                errorProvider.SetError(textBoxPropsTargetNamespace, validateNamespaceErrorMessage);
                bStatus = false;
            }
            else
                errorProvider.SetError(textBoxPropsTargetNamespace, "");
            return bStatus;
        }

        private bool ValidateXsdFile()
        {
            var bStatus = true;
            if (textBoxPropsXsdFile.Text == "")
            {
                errorProvider.SetError(textBoxPropsXsdFile, validateXsdErrorMessage);
                bStatus = false;
            }
            else
                errorProvider.SetError(textBoxPropsXsdFile, "");
            return bStatus;
        }

        private bool ValidateXmlns()
        {
            var bStatus = true;
            if (textBoxPropsXmlns.Text == "")
            {
                errorProvider.SetError(textBoxPropsXmlns, validateXmlnsErrorMessage);
                bStatus = false;
            }
            else
                errorProvider.SetError(textBoxPropsXmlns, "");
            return bStatus;
        }

        private bool ValidateVersion()
        {
            var bStatus = true;
            if (textBoxPropsVersion.Text == "")
            {
                errorProvider.SetError(textBoxPropsVersion, validateVersionErrorMessage);
                bStatus = false;
            }
            else
                errorProvider.SetError(textBoxPropsVersion, "");
            return bStatus;
        }

        private bool ValidateEncoding()
        {
            var bStatus = true;
            if (textBoxPropsEncoding.Text == "")
            {
                errorProvider.SetError(textBoxPropsEncoding, validateEncodingErrorMessage);
                bStatus = false;
            }
            else
                errorProvider.SetError(textBoxPropsEncoding, "");
            return bStatus;
        }

        private void GenerateGml()
        {
            try
            {
                var shapeChangeConfigurationXmlFullFilename = Path.Combine(_configDirectory, "ShapeChangeConfiguration.xml");
                const string shapeChangeBatFilename = "runshapechange.bat";
                var shapeChangeBatFullFilename = Path.Combine(_resultDirectory, shapeChangeBatFilename);

                EnsureRequiredDirectoriesExists();

                CreateTargetSettings();

                SetText(logMessageStartConfig);

                SetText(string.Format(logMessageCopyConfigFiles, _configDirectory));
                CopyStandardShapeChangeConfigAndMappingFiles();

                SetText("Write ShapeChangeConfiguration.xml");
                WriteConfig(shapeChangeConfigurationXmlFullFilename, textBoxPropsFeatureCatalogueName.Text);

                SetText($"Write {shapeChangeBatFilename}");
                WriteShapeChangeBat(shapeChangeBatFullFilename, shapeChangeConfigurationXmlFullFilename);

                SetText(DateTime.Now + " - Run ShapeChange ...");

                RunShapeChange(shapeChangeConfigurationXmlFullFilename);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                SetText("Error -> " + e.Message);
            }

        }

        private void EnsureRequiredDirectoriesExists()
        {
            Directory.CreateDirectory(_configDirectory);
            Directory.CreateDirectory(_excelDirectory);
            Directory.CreateDirectory(_featureCatalogueDirectory);
            Directory.CreateDirectory(Path.Combine(_resultDirectory, "JSON"));
            Directory.CreateDirectory(Path.Combine(_resultDirectory, "RDF"));
            Directory.CreateDirectory(_tmpDirectory);
            if (checkBoxCodeLists.Checked)
            {
                Directory.CreateDirectory(_codeListDirectory);
            }
        }

        private void CopyStandardShapeChangeConfigAndMappingFiles()
        {
            var configSourceDirectory = Path.Combine(_applicationDirectory, "config");

            File.Copy(Path.Combine(configSourceDirectory, "ShapeChangeConfiguration.xsd"), Path.Combine(_configDirectory, "ShapeChangeConfiguration.xsd"), true);
            File.Copy(Path.Combine(configSourceDirectory, "FC.xsd"), Path.Combine(_featureCatalogueDirectory, "FC.xsd"), true);
            File.Copy(Path.Combine(configSourceDirectory, "html2.xsl"), Path.Combine(_featureCatalogueDirectory, "html2.xsl"), true);
            File.Copy(Path.Combine(configSourceDirectory, "html.xsl"), Path.Combine(_featureCatalogueDirectory, "html.xsl"), true);
            File.Copy(Path.Combine(configSourceDirectory, "docx-compact.xsl"), Path.Combine(_featureCatalogueDirectory, "docx-compact.xsl"), true);
            File.Copy(Path.Combine(configSourceDirectory, "docx.xsl"), Path.Combine(_featureCatalogueDirectory, "docx.xsl"), true);
            File.Copy(Path.Combine(configSourceDirectory, "docx_rels.xsl"), Path.Combine(_featureCatalogueDirectory, "docx_rels.xsl"), true);
            File.Copy(Path.Combine(configSourceDirectory, "localization.xsl"), Path.Combine(_featureCatalogueDirectory, "localization.xsl"), true);
            File.Copy(Path.Combine(configSourceDirectory, "localizationMessages.xml"), Path.Combine(_featureCatalogueDirectory, "localizationMessages.xml"), true);
            File.Copy(Path.Combine(configSourceDirectory, "stylesheet.css"), Path.Combine(_featureCatalogueDirectory, "stylesheet.css"), true);
            File.Copy(Path.Combine(configSourceDirectory, "frameHtml.xsl"), Path.Combine(_featureCatalogueDirectory, "frameHtml.xsl"), true);
            File.Copy(Path.Combine(configSourceDirectory, "XInclude.xsd"), Path.Combine(_configDirectory, "XInclude.xsd"), true);
            File.Copy(Path.Combine(configSourceDirectory, "StandardMapEntries.xml"), Path.Combine(_configDirectory, "StandardMapEntries.xml"), true);
            File.Copy(Path.Combine(configSourceDirectory, "StandardNamespaces.xml"), Path.Combine(_configDirectory, "StandardNamespaces.xml"), true);
            File.Copy(Path.Combine(configSourceDirectory, "StandardAliases.xml"), Path.Combine(_configDirectory, "StandardAliases.xml"), true);
            File.Copy(Path.Combine(configSourceDirectory, "StandardRules.xml"), Path.Combine(_configDirectory, "StandardRules.xml"), true);
        }

        private void WriteShapeChangeBat(string shapeChangeBatFullFilename, string shapeChangeConfigurationXmlFullFilename)
        {
            var stringBuilder = new StringBuilder($"\"{GetJavaRuntimeExecutablePath()}\" ");
            stringBuilder.Append(CreateRunShapeChangeArguments(shapeChangeConfigurationXmlFullFilename));

            using (var stream = new FileStream(shapeChangeBatFullFilename, FileMode.Create))
            {
                using (var writer = new StreamWriter(stream, Encoding.GetEncoding(1252)))
                {
                    writer.WriteLine(stringBuilder.ToString());
                    writer.Close();
                }
            }
        }

        private void RunShapeChange(string shapeChangeConfigurationXmlFullFilename)
        {
            var process = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo
                {
                    FileName = GetJavaRuntimeExecutablePath(),
                    Arguments = CreateRunShapeChangeArguments(shapeChangeConfigurationXmlFullFilename),
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    StandardErrorEncoding = Encoding.UTF8,
                    StandardOutputEncoding = Encoding.UTF8,
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden
                },
            };

            process.ErrorDataReceived += Proc_DataReceived;
            process.OutputDataReceived += Proc_DataReceived;
            process.Exited += Proc_Exited;

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            process.WaitForExit();
        }

        private string CreateRunShapeChangeArguments(string shapeChangeConfigurationXmlFullFilename)
        {
            var stringBuilder = new StringBuilder("-Dfile.encoding=UTF-8 ");
            if (!string.IsNullOrWhiteSpace(Settings.Default.ProxyHost))
            {
                stringBuilder.Append($"-Dhttp.proxyHost={Settings.Default.ProxyHost} -Dhttp.proxyPort={Settings.Default.ProxyPort} ");
            }
            stringBuilder.Append($"-jar \"{_shapeChangeJarFullFilename}\" -c \"{shapeChangeConfigurationXmlFullFilename}\"");

            return stringBuilder.ToString();
        }

        private string GetJavaRuntimeExecutablePath()
        {
#if X86
            var javaRuntimePath = Settings.Default.JavaRuntimeX86;
#elif X64
            var javaRuntimePath = Settings.Default.JavaRuntimeX64;
#endif
            return Path.Combine(_applicationDirectory, javaRuntimePath);
        }

        private void Proc_Exited(object sender, EventArgs e)
        {
            SetText(DateTime.Now + " - Completed");
            //If LogFile exists, open and display to user
            var logFile = new FileInfo(Path.Combine(_resultDirectory, "log.html"));
            if (logFile.Exists)
            {
                Process.Start(logFile.FullName);
            }
        }


        private void Proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            SetText(e.Data);
        }

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (textBoxLog.InvokeRequired)
            {
                SetTextCallback d = SetText;
                Invoke(d, text);
            }
            else
            {
                textBoxLog.AppendText($"{text}{Environment.NewLine}");
            }
        }


        private void WriteConfig(string shapeChangeConfigFullFilename, string schemaName)
        {
            var xmlTextWriter = new XmlTextWriter(shapeChangeConfigFullFilename, Encoding.UTF8)
            {
                Formatting = Formatting.Indented,
                Indentation = 2,
                IndentChar = ' ',
                QuoteChar = '"',
            };

            xmlTextWriter.WriteStartDocument();

            // Write first element

            xmlTextWriter.WriteStartElement("ShapeChangeConfiguration", "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1");
            xmlTextWriter.WriteAttributeString("xmlns", "xi", null, "http://www.w3.org/2001/XInclude");
            xmlTextWriter.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            xmlTextWriter.WriteAttributeString("xmlns", "sc", null, "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1");
            xmlTextWriter.WriteAttributeString("xsi", "schemaLocation", null, "http://www.interactive-instruments.de/ShapeChange/Configuration/1.1 http://shapechange.net/resources/schema/ShapeChangeConfiguration.xsd");

            xmlTextWriter.WriteStartElement("input");
            
            xmlTextWriter.WriteParameterElement("inputModelType", "EA7");

            xmlTextWriter.WriteParameterElement("inputFile", _eaProjectFilePath);

            xmlTextWriter.WriteParameterElement("loadDiagrams", _featureCatalogueSettings.IncludeDiagrams ? "true" : "false");

            xmlTextWriter.WriteParameterElement("tmpDirectory", _tmpDirectory);

            if (_featureCatalogueSettings.IncludeDiagrams)
            {
                xmlTextWriter.WriteParameterElement("packageDiagramRegex", @"^(.*[\W]+)?Overview([\W]+.*)?$");

                xmlTextWriter.WriteParameterElement("classDiagramRegex", @"^(.*[\W]+)?NAME([\W]+.*)?$");
            }

            if (checkBoxMakeXsd.Checked || checkBoxCodeLists.Checked)
            {
                xmlTextWriter.WriteParameterElement("appSchemaName", schemaName);
            }

            xmlTextWriter.WriteParameterElement("addTaggedValues", "SOSI_navn,NVDB_ID,SOSI_verdi");

            xmlTextWriter.WriteParameterElement("representTaggedValues", "alwaysVoid,neverVoid,Code,lastChange,appliesTo,SOSI_navn,NVDB_ID,SOSI_verdi,SOSI_presentasjonsnavn,SOSI_bildeAvModellElement");

            //<xi:include href="StandardAliases.xml"/>
            xmlTextWriter.WriteIncludeElement(Path.Combine(_configDirectory, "StandardAliases.xml"));

            xmlTextWriter.WriteEndElement(); //close input

            xmlTextWriter.WriteStartElement("log");

            xmlTextWriter.WriteParameterElement("reportLevel", Settings.Default.ReportLevel);

            xmlTextWriter.WriteParameterElement("logFile", Path.Combine(_resultDirectory, "log.xml"));

            xmlTextWriter.WriteEndElement(); //close log

            xmlTextWriter.WriteStartElement("targets");

            xmlTextWriter.WriteXmlSchemaTarget(_xmlSchemaSettings, _configDirectory);

            if (checkBoxCodeLists.Checked)
            {
                xmlTextWriter.WriteCodelistDictionariesTarget(_codelistDictionariesSettings);
            }

            if (checkBoxFeatureCatalog.Checked)
            {
                xmlTextWriter.WriteFeatureCatalogueTarget(_featureCatalogueSettings, schemaName);
            }

            xmlTextWriter.WriteEndElement(); //close targets

            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
        }

        private void ButtonTransform_Click(object sender, EventArgs e)
        {
            var isValid = true;
            if (checkBoxCodeLists.Checked || checkBoxMakeXsd.Checked) 
            {
                // We want all validations to evaluate in order to display all errors in the UI, therefore we do not
                // use short-circuit OR operators (||) in the if-statement
                if (!ValidateEncoding() | !ValidateVersion() | !ValidateXmlns() | !ValidateXsdFile() | !ValidateTargetNamespace())
                {
                    isValid = false;
                }
            }
            if (isValid)
            {
                progressBar.Style = ProgressBarStyle.Marquee;
                progressBar.Visible = true;
                buttonLogOpenLog.Enabled = false;
                buttonTransform.Enabled = false;
                buttonClose.Enabled = false;
                buttonLogOpenResult.Enabled = false;
                textBoxLog.Text = "";
                tabControl.SelectedTab = tabPageLog;
                _featureCatalogueFormat = comboBoxFeatureCatalogueFormat.Text;

                var bw = new BackgroundWorker();
                bw.DoWork += BackgroundWorker_DoWork;
                bw.RunWorkerCompleted += delegate
                                             {
                                                 progressBar.Visible = false;
                                                 buttonLogOpenLog.Enabled = true;
                                                 buttonTransform.Enabled = true;
                                                 buttonClose.Enabled = true;
                                                 buttonLogOpenResult.Enabled = true;
                                             };
                bw.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show(missingTaggedValuesMessage);
            }
        }


        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GenerateGml();
        }
 

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void ButtonLog_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(_resultDirectory, "log.html"));
        }

        private void ButtonResult_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(_xsdDirectory, textBoxPropsXsdFile.Text));
        }

        private void ButtonSettings_Click(object sender, EventArgs e)
        {
            new frmSettings().ShowDialog();
        }

        private void FormGML_Load(object sender, EventArgs e)
        {
            errorProvider.ContainerControl = this;
        }
        
        private void ButtonHelp_Click(object sender, EventArgs e)
        {
            Process.Start(shapeChangeAddInHelpUrl);
        }

        private void checkBoxCodeLists_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCodeLists.Checked)
            {
                checkBoxGenerateEnums.Enabled = true;
            }
            else
            {
                checkBoxGenerateEnums.Enabled = false;
                checkBoxGenerateEnums.Checked = false;
            }
        }
    }
}
