using System;
using System.Windows.Forms;

namespace Kartverket.ShapeChange.EA.Addin
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
#if X64
            textBoxJavaRuntimeExecutablePath.Text = Properties.Settings.Default.JavaRuntimeX64;
#elif X86
            textBoxJavaRuntimeExecutablePath.Text = Properties.Settings.Default.JavaRuntimeX86;
#endif
            textBoxShapeChangeJarPath.Text = Properties.Settings.Default.ShapeChangeJar;
            comboBoxLogReportLevel.Text = Properties.Settings.Default.ReportLevel;
            textBoxProxyHost.Text = Properties.Settings.Default.ProxyHost;
            textBoxProxyPort.Text = Properties.Settings.Default.ProxyPort;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
#if X64
            Properties.Settings.Default.JavaRuntimeX64 = textBoxJavaRuntimeExecutablePath.Text;
#elif X86
            Properties.Settings.Default.JavaRuntimeX86 = textBoxJavaRuntimeExecutablePath.Text;
#endif
            Properties.Settings.Default.ShapeChangeJar = textBoxShapeChangeJarPath.Text;
            Properties.Settings.Default.ReportLevel = comboBoxLogReportLevel.Text;
            Properties.Settings.Default.ProxyHost = textBoxProxyHost.Text;
            Properties.Settings.Default.ProxyPort = textBoxProxyPort.Text;
            Properties.Settings.Default.Save();
            Close();
        }
    }
}
