namespace Kartverket.ShapeChange.EA.Addin
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.labelAddInCreator = new System.Windows.Forms.Label();
            this.labelShapeChangeCreator = new System.Windows.Forms.Label();
            this.linkLabelShapeChangeCreator = new System.Windows.Forms.LinkLabel();
            this.linkLabelAddInCreator = new System.Windows.Forms.LinkLabel();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelOriginalDeveloper = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelAddInCreator
            // 
            this.labelAddInCreator.AutoSize = true;
            this.labelAddInCreator.Location = new System.Drawing.Point(24, 31);
            this.labelAddInCreator.Name = "labelAddInCreator";
            this.labelAddInCreator.Size = new System.Drawing.Size(91, 13);
            this.labelAddInCreator.TabIndex = 0;
            this.labelAddInCreator.Text = "EA Add-In creator";
            // 
            // labelShapeChangeCreator
            // 
            this.labelShapeChangeCreator.AutoSize = true;
            this.labelShapeChangeCreator.Location = new System.Drawing.Point(24, 52);
            this.labelShapeChangeCreator.Name = "labelShapeChangeCreator";
            this.labelShapeChangeCreator.Size = new System.Drawing.Size(111, 13);
            this.labelShapeChangeCreator.TabIndex = 1;
            this.labelShapeChangeCreator.Text = "ShapeChange creator";
            // 
            // linkLabelShapeChangeCreator
            // 
            this.linkLabelShapeChangeCreator.AutoSize = true;
            this.linkLabelShapeChangeCreator.Location = new System.Drawing.Point(197, 52);
            this.linkLabelShapeChangeCreator.Name = "linkLabelShapeChangeCreator";
            this.linkLabelShapeChangeCreator.Size = new System.Drawing.Size(190, 13);
            this.linkLabelShapeChangeCreator.TabIndex = 2;
            this.linkLabelShapeChangeCreator.TabStop = true;
            this.linkLabelShapeChangeCreator.Text = "http://www.interactive-instruments.de/";
            this.linkLabelShapeChangeCreator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShapeChangeCreator_LinkClicked);
            // 
            // linkLabelAddInCreator
            // 
            this.linkLabelAddInCreator.AutoSize = true;
            this.linkLabelAddInCreator.Location = new System.Drawing.Point(180, 31);
            this.linkLabelAddInCreator.Name = "linkLabelAddInCreator";
            this.linkLabelAddInCreator.Size = new System.Drawing.Size(198, 13);
            this.linkLabelAddInCreator.TabIndex = 3;
            this.linkLabelAddInCreator.TabStop = true;
            this.linkLabelAddInCreator.Text = "Standardiseringssekretariatet, Kartverket";
            this.linkLabelAddInCreator.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAddInCreator_LinkClicked);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Location = new System.Drawing.Point(24, 8);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(45, 13);
            this.labelVersion.TabIndex = 6;
            this.labelVersion.Text = "Version ";
            // 
            // labelOriginalDeveloper
            // 
            this.labelOriginalDeveloper.AutoSize = true;
            this.labelOriginalDeveloper.Location = new System.Drawing.Point(24, 85);
            this.labelOriginalDeveloper.Name = "labelOriginalDeveloper";
            this.labelOriginalDeveloper.Size = new System.Drawing.Size(343, 13);
            this.labelOriginalDeveloper.TabIndex = 7;
            this.labelOriginalDeveloper.Text = "ShapeChange Add-In for EA was originally developed by Arkitektum AS";
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(474, 121);
            this.Controls.Add(this.labelOriginalDeveloper);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.linkLabelAddInCreator);
            this.Controls.Add(this.linkLabelShapeChangeCreator);
            this.Controls.Add(this.labelShapeChangeCreator);
            this.Controls.Add(this.labelAddInCreator);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.Text = "About ShapeChange Add-In";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelAddInCreator;
        private System.Windows.Forms.Label labelShapeChangeCreator;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelOriginalDeveloper;
        private System.Windows.Forms.LinkLabel linkLabelShapeChangeCreator;
        private System.Windows.Forms.LinkLabel linkLabelAddInCreator;
    }
}