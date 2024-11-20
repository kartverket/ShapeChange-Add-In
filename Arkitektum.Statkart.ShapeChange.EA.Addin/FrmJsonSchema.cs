using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using EA;
using Kartverket.ShapeChange.EA.Addin.JsonSchema;
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

            _resultDirectory = Path.Combine(eaDirectory, $"jsonSchema_{_repository.GetTreeSelectedPackage().Name}");

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
            textBoxPropsSchemaName.Text = selectedPackage.Name;
            foreach (TaggedValue taggedValue in selectedPackage.Element.TaggedValues)
            {
                switch (taggedValue.Name)
                {
                    case "xsdDocument":
                        //textBoxPropsSchemaName.Text = taggedValue.Value;
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

        private void GenerateJsonSchema()
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
                WriteConfig(shapeChangeConfigurationXmlFullFilename);

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


        private void WriteConfig(string shapeChangeConfigFullFilename)
        {
            var writer = new ShapeChangeConfigurationFileWriter(shapeChangeConfigFullFilename, Encoding.UTF8);

            writer.WriteInitialElements(CreateInputSetting());

            writer.WriteStartElement("targets");

            var jsonSchemaSettings = new JsonSchemaSettings(_jsonDirectory, _schemaVersion);

            writer.WriteJsonSchemaTarget(jsonSchemaSettings);

            writer.WriteEndElement(); //close targets

            writer.WriteEndElement();

            writer.WriteEndDocument();
            writer.Close();
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

        private InputSettings CreateInputSetting()
        {
            return new InputSettings(_resultDirectory, _eaProjectFilePath, _tmpDirectory, _configDirectory,
                textBoxPropsSchemaName.Text, false);
        }


        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GenerateJsonSchema();
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
