using System.Reflection;
using System.Windows.Forms;
using static Kartverket.ShapeChange.EA.Addin.Resources.frmAbout;

namespace Kartverket.ShapeChange.EA.Addin
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
            labelVersion.Text = string.Format(VersionInfoText, Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void linkLabelAddInCreator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(MailToStandardiseringssekretariatetUrl);
        }

        private void linkLabelShapeChangeCreator_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(InteractiveInstrumentsUrl);
        }
    }
}
