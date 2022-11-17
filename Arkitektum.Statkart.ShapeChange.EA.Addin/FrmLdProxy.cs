using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using EA;
using Kartverket.ShapeChange.EA.Addin.LdProxy;
using Kartverket.ShapeChange.EA.Addin.Properties;
using static Kartverket.ShapeChange.EA.Addin.Resources.FileNameResources;
using static Kartverket.ShapeChange.EA.Addin.Resources.formGml;
using File = System.IO.File;

namespace Kartverket.ShapeChange.EA.Addin
{
    public partial class FrmLdProxy: Form
    {
        private static Repository _repository;
        private Package _selectedPackage;
        private delegate void SetTextCallback(string text);

        private string _applicationDirectory;
        private string _eaProjectFilePath;
        private string _resultDirectory;
        private string _templatesDirectory;
        private string _ldProxyDirectory;
        private string _configDirectory;
        private string _tmpDirectory;
        private string _shapeChangeJarFullFilename;

        public FrmLdProxy()
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

            _selectedPackage = _repository.GetTreeSelectedPackage();

            _resultDirectory = Path.Combine(eaDirectory, $"shapeChange_{_selectedPackage.Name}");
            _templatesDirectory = Path.Combine(_applicationDirectory, "templates");
            _ldProxyDirectory = "ldProxy";
            _configDirectory = Path.Combine(_resultDirectory, "config");
            _tmpDirectory = Path.Combine(_resultDirectory, "tmp");

            _shapeChangeJarFullFilename = Path.IsPathRooted(Settings.Default.ShapeChangeJar)
                ? Settings.Default.ShapeChangeJar
                : Path.Combine(_applicationDirectory, Settings.Default.ShapeChangeJar);

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
            foreach (TaggedValue taggedValue in _selectedPackage.Element.TaggedValues)
            {
                switch (taggedValue.Name)
                {
                    case "epsgCode":
                        textBoxLdProxyEpsgCode.Text = taggedValue.Value;
                        break;
                    case "SOSI_presentasjonsnavn":
                    case "sosi_presentasjonsnavn":
                        textBoxLdProxyServiceLabel.Text = taggedValue.Value;
                        break;
                }
            }

            textBoxPropsEaProjectFile.Text = _eaProjectFilePath;
            textBoxPropsFeatureCatalogueName.Text = _selectedPackage.Name;
            textBoxPropsOutputDirectory.Text = _resultDirectory;
        }

        private bool ValidateEpsgCode()
        {
            if (textBoxLdProxyEpsgCode.Text == "")
            {
                errorProvider.SetError(textBoxLdProxyEpsgCode, validateEpsgCodeErrorMessage);
                return false;
            }
            
            errorProvider.SetError(textBoxLdProxyEpsgCode, "");
            return true;
        }

        private bool ValidateSosiPresentationName()
        {
            if (textBoxLdProxyServiceLabel.Text == "")
            {
                errorProvider.SetError(textBoxLdProxyServiceLabel, validateSosiRepresentationNameErrorMessage);
                return false;
            }

            errorProvider.SetError(textBoxLdProxyServiceLabel, "");
            return true;
        }

        private void GenerateLdProxyFiles()
        {
            try
            {
                var shapeChangeConfigurationXmlFullFilename = Path.Combine(_configDirectory, ShapeChangeConfigurationXml);

                EnsureRequiredDirectoriesExists();

                SetText(logMessageStartConfig);

                SetText(string.Format(logMessageCopyConfigFiles, _configDirectory));
                CopyStandardShapeChangeConfigAndMappingFiles();

                SetText("Write LdProxy overrides");
                LdProxyProviderOverrideFileWriter.WriteProviderOverrides(Path.Combine(_resultDirectory, _ldProxyDirectory),
                    CreateProviderOverrideFileSettings());

                SetText($"Write {ShapeChangeConfigurationXml}");
                WriteConfig(shapeChangeConfigurationXmlFullFilename);

                SetText($"Write {RunShapeChangeBat}");
                WriteShapeChangeBat(shapeChangeConfigurationXmlFullFilename);

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
            Directory.CreateDirectory(Path.Combine(_resultDirectory, "RDF"));
            Directory.CreateDirectory(_tmpDirectory);
            Directory.CreateDirectory(Path.Combine(_resultDirectory, _ldProxyDirectory));
        }

        private void CopyStandardShapeChangeConfigAndMappingFiles()
        {
            var configSourceDirectory = Path.Combine(_applicationDirectory, "config");

            File.Copy(Path.Combine(configSourceDirectory, "ShapeChangeConfiguration.xsd"), Path.Combine(_configDirectory, "ShapeChangeConfiguration.xsd"), true);
            File.Copy(Path.Combine(configSourceDirectory, "XInclude.xsd"), Path.Combine(_configDirectory, "XInclude.xsd"), true);
            File.Copy(Path.Combine(configSourceDirectory, "StandardMapEntries.xml"), Path.Combine(_configDirectory, "StandardMapEntries.xml"), true);
        }

        private void WriteShapeChangeBat(string shapeChangeConfigurationXmlFullFilename)
        {
            var stringBuilder = new StringBuilder($"\"{GetJavaRuntimeExecutablePath()}\" ");
            stringBuilder.Append(CreateRunShapeChangeArguments(shapeChangeConfigurationXmlFullFilename));

            using (var stream = new FileStream(Path.Combine(_resultDirectory, RunShapeChangeBat), FileMode.Create))
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

            writer.WriteInitialElements(CreateInputSettings());

            writer.WriteStartElement("transformers");

            writer.WriteLdProxyPreprocessingTransformers();

            writer.WriteEndElement();

            writer.WriteStartElement("targets");

            writer.WriteLdProxyTarget(CreateLdproxySettings());

            writer.WriteEndElement(); //close targets

            writer.WriteClosingElements();
        }

        private InputSettings CreateInputSettings()
        {
            return new InputSettings(_resultDirectory, _eaProjectFilePath, _tmpDirectory, _configDirectory,
                _selectedPackage.Name, false);
        }

        private LdproxySettings CreateLdproxySettings()
        {
            return new LdproxySettings(Path.Combine(_resultDirectory, _ldProxyDirectory), _templatesDirectory,
                textBoxLdProxyEpsgCode.Text, textBoxLdProxyServiceLabel.Text, _selectedPackage.Notes);
        }

        private LdProxyProviderOverrideFileSettings CreateProviderOverrideFileSettings()
        {
            return new LdProxyProviderOverrideFileSettings()
            {
                Id = _selectedPackage.Name.ToLower().Replace('-', '_').Replace('.', '_').Replace(' ', '_'),
                ConnectionInfo = new ConnectionInfo
                {
                    Database = textBoxLdproxyDbName.Text,
                    Host = textBoxLdProxyDbHost.Text,
                    User = textBoxLdProxyDbUser.Text,
                    Password = Convert.ToBase64String(Encoding.UTF8.GetBytes(textBoxLdProxyDbPassword.Text)),
                    PathSyntax = new PathSyntax(textBoxLdProxyDbPrimaryKey.Text),
                }
            };
        }

        private void ButtonTransform_Click(object sender, EventArgs e)
        {
            // the logical operator is supposed to be singular, as to avoid 'short-circuiting'
            var isValid = ValidateEpsgCode() & ValidateSosiPresentationName();

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

        private void UpdateOrAddTaggedValue(string tagName, string tagValue)
        {
            var selectedPackageElement = _selectedPackage.Element;

            TaggedValue taggedValue = selectedPackageElement.TaggedValues.GetByName(tagName) ??
                                      selectedPackageElement.TaggedValues.AddNew(tagName, "string");

            taggedValue.Value = tagValue;
            taggedValue.Update();
            selectedPackageElement.Update();
            selectedPackageElement.Refresh();
        }
        
        private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            GenerateLdProxyFiles();
        }

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private void ButtonLog_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(_resultDirectory, "log.html"));
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

        private void TextBoxLdProxyEpsgCode_Leave(object sender, EventArgs e)
        {
            UpdateOrAddTaggedValue("epsgCode", (sender as TextBox).Text);
        }

        private void TextBoxLdProxyServiceLabel_Leave(object sender, EventArgs e)
        {
            UpdateOrAddTaggedValue("SOSI_presentasjonsnavn", (sender as TextBox).Text);
        }
    }
}
