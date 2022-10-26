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
            this.labelJavaRuntimeExecutablePath = new System.Windows.Forms.Label();
            this.textBoxJavaRuntimeExecutablePath = new System.Windows.Forms.TextBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxLogReportLevel = new System.Windows.Forms.ComboBox();
            this.labelLogReportLevel = new System.Windows.Forms.Label();
            this.textBoxProxyHost = new System.Windows.Forms.TextBox();
            this.labelProxyHost = new System.Windows.Forms.Label();
            this.textBoxProxyPort = new System.Windows.Forms.TextBox();
            this.labelProxyPort = new System.Windows.Forms.Label();
            this.textBoxShapeChangeJarPath = new System.Windows.Forms.TextBox();
            this.labelShapeChangeJarPath = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelJavaRuntimeExecutablePath
            // 
            this.labelJavaRuntimeExecutablePath.AutoSize = true;
            this.labelJavaRuntimeExecutablePath.Location = new System.Drawing.Point(13, 13);
            this.labelJavaRuntimeExecutablePath.Name = "labelJavaRuntimeExecutablePath";
            this.labelJavaRuntimeExecutablePath.Size = new System.Drawing.Size(106, 13);
            this.labelJavaRuntimeExecutablePath.TabIndex = 1;
            this.labelJavaRuntimeExecutablePath.Text = "Java 11 runtime path";
            // 
            // textBoxJavaRuntimeExecutablePath
            // 
            this.textBoxJavaRuntimeExecutablePath.Location = new System.Drawing.Point(16, 30);
            this.textBoxJavaRuntimeExecutablePath.Name = "textBoxJavaRuntimeExecutablePath";
            this.textBoxJavaRuntimeExecutablePath.Size = new System.Drawing.Size(277, 20);
            this.textBoxJavaRuntimeExecutablePath.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(315, 27);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxLogReportLevel
            // 
            this.comboBoxLogReportLevel.FormattingEnabled = true;
            this.comboBoxLogReportLevel.Items.AddRange(new object[] {
            "INFO",
            "DEBUG"});
            this.comboBoxLogReportLevel.Location = new System.Drawing.Point(16, 118);
            this.comboBoxLogReportLevel.Name = "comboBoxLogReportLevel";
            this.comboBoxLogReportLevel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxLogReportLevel.TabIndex = 4;
            // 
            // labelLogReportLevel
            // 
            this.labelLogReportLevel.AutoSize = true;
            this.labelLogReportLevel.Location = new System.Drawing.Point(13, 99);
            this.labelLogReportLevel.Name = "labelLogReportLevel";
            this.labelLogReportLevel.Size = new System.Drawing.Size(80, 13);
            this.labelLogReportLevel.TabIndex = 3;
            this.labelLogReportLevel.Text = "Log report level";
            // 
            // textBoxProxyHost
            // 
            this.textBoxProxyHost.Location = new System.Drawing.Point(16, 171);
            this.textBoxProxyHost.Name = "textBoxProxyHost";
            this.textBoxProxyHost.Size = new System.Drawing.Size(277, 20);
            this.textBoxProxyHost.TabIndex = 6;
            // 
            // labelProxyHost
            // 
            this.labelProxyHost.AutoSize = true;
            this.labelProxyHost.Location = new System.Drawing.Point(13, 154);
            this.labelProxyHost.Name = "labelProxyHost";
            this.labelProxyHost.Size = new System.Drawing.Size(56, 13);
            this.labelProxyHost.TabIndex = 5;
            this.labelProxyHost.Text = "Proxy host";
            // 
            // textBoxProxyPort
            // 
            this.textBoxProxyPort.Location = new System.Drawing.Point(16, 220);
            this.textBoxProxyPort.Name = "textBoxProxyPort";
            this.textBoxProxyPort.Size = new System.Drawing.Size(77, 20);
            this.textBoxProxyPort.TabIndex = 8;
            // 
            // labelProxyPort
            // 
            this.labelProxyPort.AutoSize = true;
            this.labelProxyPort.Location = new System.Drawing.Point(13, 203);
            this.labelProxyPort.Name = "labelProxyPort";
            this.labelProxyPort.Size = new System.Drawing.Size(54, 13);
            this.labelProxyPort.TabIndex = 7;
            this.labelProxyPort.Text = "Proxy port";
            // 
            // textBoxShapeChangeJarPath
            // 
            this.textBoxShapeChangeJarPath.Location = new System.Drawing.Point(16, 73);
            this.textBoxShapeChangeJarPath.Name = "textBoxShapeChangeJarPath";
            this.textBoxShapeChangeJarPath.Size = new System.Drawing.Size(277, 20);
            this.textBoxShapeChangeJarPath.TabIndex = 10;
            // 
            // labelShapeChangeJarPath
            // 
            this.labelShapeChangeJarPath.AutoSize = true;
            this.labelShapeChangeJarPath.Location = new System.Drawing.Point(13, 56);
            this.labelShapeChangeJarPath.Name = "labelShapeChangeJarPath";
            this.labelShapeChangeJarPath.Size = new System.Drawing.Size(113, 13);
            this.labelShapeChangeJarPath.TabIndex = 9;
            this.labelShapeChangeJarPath.Text = "ShapeChange.jar path";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 269);
            this.Controls.Add(this.textBoxShapeChangeJarPath);
            this.Controls.Add(this.labelShapeChangeJarPath);
            this.Controls.Add(this.textBoxProxyPort);
            this.Controls.Add(this.labelProxyPort);
            this.Controls.Add(this.textBoxProxyHost);
            this.Controls.Add(this.labelProxyHost);
            this.Controls.Add(this.labelLogReportLevel);
            this.Controls.Add(this.comboBoxLogReportLevel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxJavaRuntimeExecutablePath);
            this.Controls.Add(this.labelJavaRuntimeExecutablePath);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxLogReportLevel;
        private System.Windows.Forms.Label labelJavaRuntimeExecutablePath;
        private System.Windows.Forms.Label labelLogReportLevel;
        private System.Windows.Forms.Label labelProxyHost;
        private System.Windows.Forms.Label labelProxyPort;
        private System.Windows.Forms.Label labelShapeChangeJarPath;
        private System.Windows.Forms.TextBox textBoxJavaRuntimeExecutablePath;
        private System.Windows.Forms.TextBox textBoxProxyHost;
        private System.Windows.Forms.TextBox textBoxProxyPort;
        private System.Windows.Forms.TextBox textBoxShapeChangeJarPath;
    }
}