namespace Kartverket.ShapeChange.EA.Addin
{
    partial class frmSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSettings));
            this.label1 = new System.Windows.Forms.Label();
            this.txtJava = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbReportlevel = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProxyHost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProxyPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Java 11 runtime";
            // 
            // txtJava
            // 
            this.txtJava.Location = new System.Drawing.Point(21, 37);
            this.txtJava.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtJava.Name = "txtJava";
            this.txtJava.Size = new System.Drawing.Size(368, 22);
            this.txtJava.TabIndex = 1;
            this.txtJava.TextChanged += new System.EventHandler(this.TxtJava_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(420, 33);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 28);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Lagre";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbReportlevel
            // 
            this.cbReportlevel.FormattingEnabled = true;
            this.cbReportlevel.Items.AddRange(new object[] {
            "INFO",
            "DEBUG"});
            this.cbReportlevel.Location = new System.Drawing.Point(21, 94);
            this.cbReportlevel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbReportlevel.Name = "cbReportlevel";
            this.cbReportlevel.Size = new System.Drawing.Size(160, 24);
            this.cbReportlevel.TabIndex = 3;
            this.cbReportlevel.SelectedIndexChanged += new System.EventHandler(this.CbReportlevel_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 70);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Log report level";
            // 
            // txtProxyHost
            // 
            this.txtProxyHost.Location = new System.Drawing.Point(25, 159);
            this.txtProxyHost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProxyHost.Name = "txtProxyHost";
            this.txtProxyHost.Size = new System.Drawing.Size(368, 22);
            this.txtProxyHost.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Proxy host";
            // 
            // txtProxyPort
            // 
            this.txtProxyPort.Location = new System.Drawing.Point(25, 219);
            this.txtProxyPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProxyPort.Name = "txtProxyPort";
            this.txtProxyPort.Size = new System.Drawing.Size(101, 22);
            this.txtProxyPort.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 198);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Proxy port";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 258);
            this.Controls.Add(this.txtProxyPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProxyHost);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbReportlevel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtJava);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Innstillinger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJava;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbReportlevel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProxyHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProxyPort;
        private System.Windows.Forms.Label label4;
    }
}