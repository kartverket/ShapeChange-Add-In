using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kartverket.ShapeChange.EA.Addin
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            txtJava.Text = Properties.Settings.Default.JavaRuntime;
            cbReportlevel.Text = Properties.Settings.Default.ReportLevel;
            txtProxyHost.Text = Properties.Settings.Default.ProxyHost;
            txtProxyPort.Text = Properties.Settings.Default.ProxyPort;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.JavaRuntime = txtJava.Text;
            Properties.Settings.Default.ReportLevel = cbReportlevel.Text;
            Properties.Settings.Default.ProxyHost = txtProxyHost.Text;
            Properties.Settings.Default.ProxyPort = txtProxyPort.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void TxtJava_TextChanged(object sender, EventArgs e)
        {

        }

        private void CbReportlevel_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
