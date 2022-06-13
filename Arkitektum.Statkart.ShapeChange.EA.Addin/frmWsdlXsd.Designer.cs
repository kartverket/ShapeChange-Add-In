namespace Arkitektum.Statkart.ShapeChange.EA.Addin
{
    partial class frmWsdlXsd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerer = new System.Windows.Forms.Button();
            this.chWSDL = new System.Windows.Forms.CheckBox();
            this.chXSD = new System.Windows.Forms.CheckBox();
            this.chMerknad = new System.Windows.Forms.CheckBox();
            this.chIngenNorskeTegn = new System.Windows.Forms.CheckBox();
            this.chLokaleFiler = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(357, 116);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(93, 23);
            this.btnHelp.TabIndex = 29;
            this.btnHelp.Text = "Hjelp";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(357, 41);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 23);
            this.btnClose.TabIndex = 28;
            this.btnClose.Text = "Lukk";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenerer
            // 
            this.btnGenerer.Location = new System.Drawing.Point(357, 12);
            this.btnGenerer.Name = "btnGenerer";
            this.btnGenerer.Size = new System.Drawing.Size(93, 23);
            this.btnGenerer.TabIndex = 27;
            this.btnGenerer.Text = "Generer";
            this.btnGenerer.UseVisualStyleBackColor = true;
            this.btnGenerer.Click += new System.EventHandler(this.btnGenerer_Click);
            // 
            // chWSDL
            // 
            this.chWSDL.AutoSize = true;
            this.chWSDL.Checked = true;
            this.chWSDL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chWSDL.Location = new System.Drawing.Point(12, 12);
            this.chWSDL.Name = "chWSDL";
            this.chWSDL.Size = new System.Drawing.Size(88, 17);
            this.chWSDL.TabIndex = 30;
            this.chWSDL.Text = "Generer wsdl";
            this.chWSDL.UseVisualStyleBackColor = true;
            // 
            // chXSD
            // 
            this.chXSD.AutoSize = true;
            this.chXSD.Checked = true;
            this.chXSD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chXSD.Location = new System.Drawing.Point(12, 35);
            this.chXSD.Name = "chXSD";
            this.chXSD.Size = new System.Drawing.Size(83, 17);
            this.chXSD.TabIndex = 31;
            this.chXSD.Text = "Generer xsd";
            this.chXSD.UseVisualStyleBackColor = true;
            // 
            // chMerknad
            // 
            this.chMerknad.AutoSize = true;
            this.chMerknad.Checked = true;
            this.chMerknad.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chMerknad.Location = new System.Drawing.Point(12, 58);
            this.chMerknad.Name = "chMerknad";
            this.chMerknad.Size = new System.Drawing.Size(103, 17);
            this.chMerknad.TabIndex = 32;
            this.chMerknad.Text = "Skriv merknader";
            this.chMerknad.UseVisualStyleBackColor = true;
            // 
            // chIngenNorskeTegn
            // 
            this.chIngenNorskeTegn.AutoSize = true;
            this.chIngenNorskeTegn.Checked = true;
            this.chIngenNorskeTegn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chIngenNorskeTegn.Location = new System.Drawing.Point(12, 81);
            this.chIngenNorskeTegn.Name = "chIngenNorskeTegn";
            this.chIngenNorskeTegn.Size = new System.Drawing.Size(81, 17);
            this.chIngenNorskeTegn.TabIndex = 33;
            this.chIngenNorskeTegn.Text = "Erstatt æøå";
            this.chIngenNorskeTegn.UseVisualStyleBackColor = true;
            // 
            // chLokaleFiler
            // 
            this.chLokaleFiler.AutoSize = true;
            this.chLokaleFiler.Checked = true;
            this.chLokaleFiler.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chLokaleFiler.Location = new System.Drawing.Point(12, 104);
            this.chLokaleFiler.Name = "chLokaleFiler";
            this.chLokaleFiler.Size = new System.Drawing.Size(114, 17);
            this.chLokaleFiler.TabIndex = 34;
            this.chLokaleFiler.Text = "Importer lokale filer";
            this.chLokaleFiler.UseVisualStyleBackColor = true;
            // 
            // frmWsdlXsd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 153);
            this.Controls.Add(this.chLokaleFiler);
            this.Controls.Add(this.chIngenNorskeTegn);
            this.Controls.Add(this.chMerknad);
            this.Controls.Add(this.chXSD);
            this.Controls.Add(this.chWSDL);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerer);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWsdlXsd";
            this.ShowIcon = false;
            this.Text = "WSDL/XSD transformering";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerer;
        private System.Windows.Forms.CheckBox chWSDL;
        private System.Windows.Forms.CheckBox chXSD;
        private System.Windows.Forms.CheckBox chMerknad;
        private System.Windows.Forms.CheckBox chIngenNorskeTegn;
        private System.Windows.Forms.CheckBox chLokaleFiler;
    }
}