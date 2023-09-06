using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using EA;
using Kartverket.ShapeChange.EA.Addin.Properties;
using static Kartverket.ShapeChange.EA.Addin.Resources.Common;
using static Kartverket.ShapeChange.EA.Addin.Resources.ErrorMessages;
using static Kartverket.ShapeChange.EA.Addin.Resources.FormJsonSchema;
using static Kartverket.ShapeChange.EA.Addin.Resources.LogMessages;
using File = System.IO.File;

namespace Kartverket.ShapeChange.EA.Addin
{
    public partial class FrmJsonSchema: Form
    {
        private static Repository _repository;
        private delegate void SetTextCallback(string text);

        private string _applicationDirectory;
        private string _eaProjectFilePath;
        private string _resultDirectory;
        private string _configDirectory;
        private string _jsonDirectory;
        private string _tmpDirectory;
        private string _shapeChangeJarFullFilename;
        private string _schemaVersion;

        public FrmJsonSchema()
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
                        textBoxPropsSchemaName.Text = taggedValue.Value;
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
                    case "jsonEncodingRule":
                        textBoxPropsJsonEncoding.Text = taggedValue.Value;
                        break;
                    case "SOSI_produsent":
                        //textBoxFeatureCatalogueProducer.Text = taggedValue.Value;
                        break;
                }
            }

            _configDirectory = Path.Combine(_resultDirectory, "config");
            _jsonDirectory = Path.Combine(_resultDirectory, "JSON");
            _tmpDirectory = Path.Combine(_resultDirectory, "tmp");

            _shapeChangeJarFullFilename = Path.IsPathRooted(Settings.Default.ShapeChangeJar)
                ? Settings.Default.ShapeChangeJar
                : Path.Combine(_applicationDirectory, Settings.Default.ShapeChangeJar);

            _schemaVersion = comboBoxPropsSchemaVersion.Text;

            textBoxPropsEaProjectFile.Text = _eaProjectFilePath;
            textBoxPropsFeatureCatalogueName.Text = selectedPackage.Name;
            textBoxPropsJsonDirectory.Text = _jsonDirectory;
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

        private bool ValidateSchemaFile()
        {
            var bStatus = true;
            if (textBoxPropsSchemaName.Text == "")
            {
                errorProvider.SetError(textBoxPropsSchemaName, validateSchemaNameErrorMessage);
                bStatus = false;
            }
            else
                errorProvider.SetError(textBoxPropsSchemaName, "");
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
            if (textBoxPropsJsonEncoding.Text == "")
            {
                errorProvider.SetError(textBoxPropsJsonEncoding, validateEncodingErrorMessage);
                bStatus = false;
            }
            else
                errorProvider.SetError(textBoxPropsJsonEncoding, "");
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

                SetText(logMessageStartConfig);

                SetText(string.Format(logMessageCopyConfigFiles, _configDirectory));
                CopyStandardShapeChangeConfigAndMappingFiles();

                SetText("Write ShapeChangeConfiguration.xml");
                WriteConfig(shapeChangeConfigurationXmlFullFilename, textBoxPropsFeatureCatalogueName.Text, textBoxPropsJsonEncoding.Text);

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
            Directory.CreateDirectory(_jsonDirectory);
            Directory.CreateDirectory(_tmpDirectory);
        }

        private void CopyStandardShapeChangeConfigAndMappingFiles()
        {
            var configSourceDirectory = Path.Combine(_applicationDirectory, "config");

            File.Copy(Path.Combine(configSourceDirectory, "ShapeChangeConfiguration.xsd"), Path.Combine(_configDirectory, "ShapeChangeConfiguration.xsd"), true);
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


        private void WriteConfig(string shapeChangeConfigFullFilename, string schemaName, string encodingRule)
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
            
            xmlTextWriter.WriteStartElement("parameter");
            xmlTextWriter.WriteAttributeString("name", "inputModelType");
            xmlTextWriter.WriteAttributeString("value", "EA7");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("parameter");
            xmlTextWriter.WriteAttributeString("name", "inputFile");
            xmlTextWriter.WriteAttributeString("value", _eaProjectFilePath);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("parameter");
            xmlTextWriter.WriteAttributeString("name", "tmpDirectory");
            xmlTextWriter.WriteAttributeString("value", _tmpDirectory);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("parameter");
            xmlTextWriter.WriteAttributeString("name", "appSchemaName");
            xmlTextWriter.WriteAttributeString("value", schemaName);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("parameter");
            xmlTextWriter.WriteAttributeString("name", "addTaggedValues");
            xmlTextWriter.WriteAttributeString("value", "SOSI_navn,NVDB_ID,SOSI_verdi");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("parameter");
            xmlTextWriter.WriteAttributeString("name", "representTaggedValues");
            xmlTextWriter.WriteAttributeString("value", "alwaysVoid,neverVoid,Code,lastChange,appliesTo,SOSI_navn,NVDB_ID,SOSI_verdi,SOSI_presentasjonsnavn,SOSI_bildeAvModellElement");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("include", "http://www.w3.org/2001/XInclude");
            xmlTextWriter.WriteAttributeString("href", Path.Combine(_configDirectory, "StandardAliases.xml"));
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement(); //close input

            xmlTextWriter.WriteStartElement("log");

            xmlTextWriter.WriteStartElement("parameter");
            xmlTextWriter.WriteAttributeString("name", "reportLevel");
            xmlTextWriter.WriteAttributeString("value", Settings.Default.ReportLevel);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("parameter");
            xmlTextWriter.WriteAttributeString("name", "logFile");
            xmlTextWriter.WriteAttributeString("value", Path.Combine(_resultDirectory, "log.xml"));
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement(); //close log

            xmlTextWriter.WriteStartElement("targets");

            xmlTextWriter.WriteStartElement("Target");
            xmlTextWriter.WriteAttributeString("class", "de.interactive_instruments.ShapeChange.Target.JSON.JsonSchemaTarget");
            xmlTextWriter.WriteAttributeString("mode", "enabled");

            xmlTextWriter.WriteStartElement("targetParameter");
            xmlTextWriter.WriteAttributeString("name", "outputDirectory");
            xmlTextWriter.WriteAttributeString("value", _jsonDirectory);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("targetParameter");
            xmlTextWriter.WriteAttributeString("name", "prettyPrint");
            xmlTextWriter.WriteAttributeString("value", "true");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("targetParameter");
            xmlTextWriter.WriteAttributeString("name", "sortedOutput");
            xmlTextWriter.WriteAttributeString("value", "true");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("targetParameter");
            xmlTextWriter.WriteAttributeString("name", "jsonBaseUri");
            xmlTextWriter.WriteAttributeString("value", "http://sosi.geonorge.no/ShapeChangeAddIn/");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("targetParameter");
            xmlTextWriter.WriteAttributeString("name", "jsonSchemaVersion");
            xmlTextWriter.WriteAttributeString("value", _schemaVersion);
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("targetParameter");
            xmlTextWriter.WriteAttributeString("name", "defaultEncodingRule");
            xmlTextWriter.WriteAttributeString("value", "defaultJson");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("rules");

            xmlTextWriter.WriteStartElement("EncodingRule");
            xmlTextWriter.WriteAttributeString("name", "defaultJson");

            xmlTextWriter.WriteStartElement("rule");
            xmlTextWriter.WriteAttributeString("name", "rule-json-cls-basictype");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("rule");
            xmlTextWriter.WriteAttributeString("name", "rule-json-cls-codelist-uri-format");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("rule");
            xmlTextWriter.WriteAttributeString("name", "rule-json-cls-name-as-entityType");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement(); //EncodingRule
            xmlTextWriter.WriteEndElement(); //rules

            //Includes
            xmlTextWriter.WriteStartElement("include", "http://www.w3.org/2001/XInclude");
            xmlTextWriter.WriteAttributeString("href", "http://shapechange.net/resources/config/StandardMapEntries_JSON.xml");
            xmlTextWriter.WriteEndElement();

            //MapEntries
            xmlTextWriter.WriteStartElement("mapEntries");

            xmlTextWriter.WriteStartElement("MapEntry");
            xmlTextWriter.WriteAttributeString("type", "Punkt");
            xmlTextWriter.WriteAttributeString("rule", "*");
            xmlTextWriter.WriteAttributeString("targetType", "https://geojson.org/schema/Point.json");
            xmlTextWriter.WriteAttributeString("param", "geometry");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("MapEntry");
            xmlTextWriter.WriteAttributeString("type", "Kurve");
            xmlTextWriter.WriteAttributeString("rule", "*");
            xmlTextWriter.WriteAttributeString("targetType", "https://geojson.org/schema/LineString.json");
            xmlTextWriter.WriteAttributeString("param", "geometry");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("MapEntry");
            xmlTextWriter.WriteAttributeString("type", "Flate");
            xmlTextWriter.WriteAttributeString("rule", "*");
            xmlTextWriter.WriteAttributeString("targetType", "https://geojson.org/schema/Polygon.json");
            xmlTextWriter.WriteAttributeString("param", "geometry");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteStartElement("MapEntry");
            xmlTextWriter.WriteAttributeString("type", "Sverm");
            xmlTextWriter.WriteAttributeString("rule", "*");
            xmlTextWriter.WriteAttributeString("targetType", "https://geojson.org/schema/MultiPoint.json");
            xmlTextWriter.WriteAttributeString("param", "geometry");
            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndElement(); //close Json

            xmlTextWriter.WriteEndElement(); //close targets

            xmlTextWriter.WriteEndElement();

            xmlTextWriter.WriteEndDocument();
            xmlTextWriter.Close();
        }

        private void ButtonTransform_Click(object sender, EventArgs e)
        {
            var isValid = ValidateSchemaFile() & ValidateVersion();

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
            Process.Start(Path.Combine(_jsonDirectory, textBoxPropsSchemaName.Text));
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
    }
}
