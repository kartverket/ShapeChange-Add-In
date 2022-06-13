using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Kartverket.ShapeChange.EA.Addin
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            lbVersion.Text = "Versjon: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //label3.Text = "ShapeChange plugin opprinnelig laget av Arkitektum AS";
        }

       

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.statkart.no");

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:standardiseringssekretariatet@kartverket.no");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.interactive-instruments.de/index.php?id=1&L=1");
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {

        }

        private void LbVersion_Click(object sender, EventArgs e)
        {

        }
    }
}
