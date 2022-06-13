using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EA;

namespace Arkitektum.Statkart.ShapeChange.EA.Addin
{
    public partial class frmWsdlXsd : Form
    {
        private Repository _rep;

        public frmWsdlXsd()
        {
            InitializeComponent();
        }
        public void SetRepository(Repository newrepository)
        {
            _rep = newrepository;
        }

        private void btnGenerer_Click(object sender, EventArgs e)
        {
            WsdlConverter conv = new WsdlConverter();
            conv.wsdl = chWSDL.Checked;
            conv.xsd = chXSD.Checked;
            conv.merknader = chMerknad.Checked;
            conv.lokaleFiler = chLokaleFiler.Checked;
            conv.ingenNorskeTegn = chIngenNorskeTegn.Checked;
            conv.execute(_rep);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.arkitektum.no/prosjekter/geosynkronisering/");
        }
    }
}
