namespace Kartverket.ShapeChange.EA.Addin
{
    partial class FrmJsonSchema
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmJsonSchema));
            this.buttonTransform = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonHelp = new System.Windows.Forms.Button();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonLogOpenLog = new System.Windows.Forms.Button();
            this.buttonLogOpenResult = new System.Windows.Forms.Button();
            this.tabPageProjectProps = new System.Windows.Forms.TabPage();
            this.comboBoxPropsSchemaVersion = new System.Windows.Forms.ComboBox();
            this.labelPropsTagSchemaVersion = new System.Windows.Forms.Label();
            this.labelPropsSchemaVersion = new System.Windows.Forms.Label();
            this.labelPropsTagSchemaName = new System.Windows.Forms.Label();
            this.textBoxPropsSchemaName = new System.Windows.Forms.TextBox();
            this.textBoxPropsJsonDirectory = new System.Windows.Forms.TextBox();
            this.labelPropsSchemaName = new System.Windows.Forms.Label();
            this.labelPropsExportJson = new System.Windows.Forms.Label();
            this.textBoxPropsFeatureCatalogueName = new System.Windows.Forms.TextBox();
            this.textBoxPropsEaProjectFile = new System.Windows.Forms.TextBox();
            this.textBoxPropsTargetNamespace = new System.Windows.Forms.TextBox();
            this.textBoxPropsVersion = new System.Windows.Forms.TextBox();
            this.textBoxPropsXmlns = new System.Windows.Forms.TextBox();
            this.textBoxPropsJsonEncoding = new System.Windows.Forms.TextBox();
            this.labelPropsFeatureCatalogueName = new System.Windows.Forms.Label();
            this.labelPropsTagJsonEncodingRule = new System.Windows.Forms.Label();
            this.labelPropsTagXmlns = new System.Windows.Forms.Label();
            this.labelPropsTagVersion = new System.Windows.Forms.Label();
            this.labelPropsTagTargetNamespace = new System.Windows.Forms.Label();
            this.labelPropsEaProjectFile = new System.Windows.Forms.Label();
            this.labelPropsEncodingRules = new System.Windows.Forms.Label();
            this.labelPropsTargetNamespace = new System.Windows.Forms.Label();
            this.labelPropsXmlns = new System.Windows.Forms.Label();
            this.labelPropsVersion = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabPageLog.SuspendLayout();
            this.tabPageProjectProps.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTransform
            // 
            this.buttonTransform.Location = new System.Drawing.Point(541, 12);
            this.buttonTransform.Name = "buttonTransform";
            this.buttonTransform.Size = new System.Drawing.Size(93, 23);
            this.buttonTransform.TabIndex = 11;
            this.buttonTransform.Text = "Transform";
            this.buttonTransform.UseVisualStyleBackColor = true;
            this.buttonTransform.Click += new System.EventHandler(this.ButtonTransform_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(11, 384);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(622, 23);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(541, 41);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(93, 23);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(541, 96);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(93, 23);
            this.buttonSettings.TabIndex = 13;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(541, 355);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(93, 23);
            this.buttonHelp.TabIndex = 14;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.UseVisualStyleBackColor = true;
            this.buttonHelp.Click += new System.EventHandler(this.ButtonHelp_Click);
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.textBoxLog);
            this.tabPageLog.Controls.Add(this.buttonLogOpenLog);
            this.tabPageLog.Controls.Add(this.buttonLogOpenResult);
            this.tabPageLog.Location = new System.Drawing.Point(4, 22);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLog.Size = new System.Drawing.Size(515, 340);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "Log";
            this.tabPageLog.UseVisualStyleBackColor = true;
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(7, 10);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(502, 298);
            this.textBoxLog.TabIndex = 0;
            // 
            // buttonLogOpenLog
            // 
            this.buttonLogOpenLog.Location = new System.Drawing.Point(404, 314);
            this.buttonLogOpenLog.Name = "buttonLogOpenLog";
            this.buttonLogOpenLog.Size = new System.Drawing.Size(104, 23);
            this.buttonLogOpenLog.TabIndex = 201;
            this.buttonLogOpenLog.Text = "Open logfile";
            this.buttonLogOpenLog.UseVisualStyleBackColor = true;
            this.buttonLogOpenLog.Click += new System.EventHandler(this.ButtonLog_Click);
            // 
            // buttonLogOpenResult
            // 
            this.buttonLogOpenResult.Location = new System.Drawing.Point(293, 314);
            this.buttonLogOpenResult.Name = "buttonLogOpenResult";
            this.buttonLogOpenResult.Size = new System.Drawing.Size(104, 23);
            this.buttonLogOpenResult.TabIndex = 200;
            this.buttonLogOpenResult.Text = "Open result";
            this.buttonLogOpenResult.UseVisualStyleBackColor = true;
            this.buttonLogOpenResult.Visible = false;
            this.buttonLogOpenResult.Click += new System.EventHandler(this.ButtonResult_Click);
            // 
            // tabPageProjectProps
            // 
            this.tabPageProjectProps.Controls.Add(this.comboBoxPropsSchemaVersion);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTagSchemaVersion);
            this.tabPageProjectProps.Controls.Add(this.labelPropsSchemaVersion);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTagSchemaName);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsSchemaName);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsJsonDirectory);
            this.tabPageProjectProps.Controls.Add(this.labelPropsSchemaName);
            this.tabPageProjectProps.Controls.Add(this.labelPropsExportJson);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsFeatureCatalogueName);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsEaProjectFile);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsTargetNamespace);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsVersion);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsXmlns);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsJsonEncoding);
            this.tabPageProjectProps.Controls.Add(this.labelPropsFeatureCatalogueName);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTagJsonEncodingRule);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTagXmlns);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTagVersion);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTagTargetNamespace);
            this.tabPageProjectProps.Controls.Add(this.labelPropsEaProjectFile);
            this.tabPageProjectProps.Controls.Add(this.labelPropsEncodingRules);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTargetNamespace);
            this.tabPageProjectProps.Controls.Add(this.labelPropsXmlns);
            this.tabPageProjectProps.Controls.Add(this.labelPropsVersion);
            this.tabPageProjectProps.Location = new System.Drawing.Point(4, 22);
            this.tabPageProjectProps.Name = "tabPageProjectProps";
            this.tabPageProjectProps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjectProps.Size = new System.Drawing.Size(515, 340);
            this.tabPageProjectProps.TabIndex = 0;
            this.tabPageProjectProps.Text = "Project properties";
            this.tabPageProjectProps.UseVisualStyleBackColor = true;
            // 
            // comboBoxPropsSchemaVersion
            // 
            this.comboBoxPropsSchemaVersion.FormattingEnabled = true;
            this.comboBoxPropsSchemaVersion.Items.AddRange(new object[] {
            "2019-09",
            "draft-07",
            "OpenApi30"});
            this.comboBoxPropsSchemaVersion.Location = new System.Drawing.Point(94, 212);
            this.comboBoxPropsSchemaVersion.Name = "comboBoxPropsSchemaVersion";
            this.comboBoxPropsSchemaVersion.Size = new System.Drawing.Size(294, 21);
            this.comboBoxPropsSchemaVersion.TabIndex = 118;
            // 
            // labelPropsTagSchemaVersion
            // 
            this.labelPropsTagSchemaVersion.AutoSize = true;
            this.labelPropsTagSchemaVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagSchemaVersion.Location = new System.Drawing.Point(397, 215);
            this.labelPropsTagSchemaVersion.Name = "labelPropsTagSchemaVersion";
            this.labelPropsTagSchemaVersion.Size = new System.Drawing.Size(121, 13);
            this.labelPropsTagSchemaVersion.TabIndex = 999;
            this.labelPropsTagSchemaVersion.Text = "tag: jsonSchemaVersion";
            // 
            // labelPropsSchemaVersion
            // 
            this.labelPropsSchemaVersion.AutoSize = true;
            this.labelPropsSchemaVersion.Location = new System.Drawing.Point(5, 215);
            this.labelPropsSchemaVersion.Name = "labelPropsSchemaVersion";
            this.labelPropsSchemaVersion.Size = new System.Drawing.Size(83, 13);
            this.labelPropsSchemaVersion.TabIndex = 117;
            this.labelPropsSchemaVersion.Text = "Schema version";
            this.labelPropsSchemaVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsTagSchemaName
            // 
            this.labelPropsTagSchemaName.AutoSize = true;
            this.labelPropsTagSchemaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagSchemaName.Location = new System.Drawing.Point(397, 190);
            this.labelPropsTagSchemaName.Name = "labelPropsTagSchemaName";
            this.labelPropsTagSchemaName.Size = new System.Drawing.Size(96, 13);
            this.labelPropsTagSchemaName.TabIndex = 999;
            this.labelPropsTagSchemaName.Text = "tag: jsonDocument";
            // 
            // textBoxPropsSchemaName
            // 
            this.textBoxPropsSchemaName.Enabled = false;
            this.textBoxPropsSchemaName.Location = new System.Drawing.Point(94, 187);
            this.textBoxPropsSchemaName.Name = "textBoxPropsSchemaName";
            this.textBoxPropsSchemaName.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsSchemaName.TabIndex = 116;
            // 
            // textBoxPropsJsonDirectory
            // 
            this.textBoxPropsJsonDirectory.Enabled = false;
            this.textBoxPropsJsonDirectory.Location = new System.Drawing.Point(94, 162);
            this.textBoxPropsJsonDirectory.Name = "textBoxPropsJsonDirectory";
            this.textBoxPropsJsonDirectory.Size = new System.Drawing.Size(411, 20);
            this.textBoxPropsJsonDirectory.TabIndex = 114;
            // 
            // labelPropsSchemaName
            // 
            this.labelPropsSchemaName.AutoSize = true;
            this.labelPropsSchemaName.Location = new System.Drawing.Point(13, 190);
            this.labelPropsSchemaName.Name = "labelPropsSchemaName";
            this.labelPropsSchemaName.Size = new System.Drawing.Size(75, 13);
            this.labelPropsSchemaName.TabIndex = 115;
            this.labelPropsSchemaName.Text = "Schema name";
            this.labelPropsSchemaName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsExportJson
            // 
            this.labelPropsExportJson.AutoSize = true;
            this.labelPropsExportJson.Location = new System.Drawing.Point(20, 165);
            this.labelPropsExportJson.Name = "labelPropsExportJson";
            this.labelPropsExportJson.Size = new System.Drawing.Size(68, 13);
            this.labelPropsExportJson.TabIndex = 113;
            this.labelPropsExportJson.Text = "Export JSON";
            this.labelPropsExportJson.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxPropsFeatureCatalogueName
            // 
            this.textBoxPropsFeatureCatalogueName.AccessibleDescription = "ApplicationSchema Name";
            this.textBoxPropsFeatureCatalogueName.AccessibleName = "TextBox";
            this.textBoxPropsFeatureCatalogueName.Enabled = false;
            this.textBoxPropsFeatureCatalogueName.Location = new System.Drawing.Point(94, 37);
            this.textBoxPropsFeatureCatalogueName.Name = "textBoxPropsFeatureCatalogueName";
            this.textBoxPropsFeatureCatalogueName.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsFeatureCatalogueName.TabIndex = 104;
            // 
            // textBoxPropsEaProjectFile
            // 
            this.textBoxPropsEaProjectFile.AccessibleDescription = "Enterprise Architect Project File";
            this.textBoxPropsEaProjectFile.Enabled = false;
            this.textBoxPropsEaProjectFile.Location = new System.Drawing.Point(94, 9);
            this.textBoxPropsEaProjectFile.Name = "textBoxPropsEaProjectFile";
            this.textBoxPropsEaProjectFile.Size = new System.Drawing.Size(413, 20);
            this.textBoxPropsEaProjectFile.TabIndex = 102;
            // 
            // textBoxPropsTargetNamespace
            // 
            this.textBoxPropsTargetNamespace.Enabled = false;
            this.textBoxPropsTargetNamespace.Location = new System.Drawing.Point(94, 62);
            this.textBoxPropsTargetNamespace.Name = "textBoxPropsTargetNamespace";
            this.textBoxPropsTargetNamespace.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsTargetNamespace.TabIndex = 106;
            // 
            // textBoxPropsVersion
            // 
            this.textBoxPropsVersion.Enabled = false;
            this.textBoxPropsVersion.Location = new System.Drawing.Point(94, 112);
            this.textBoxPropsVersion.Name = "textBoxPropsVersion";
            this.textBoxPropsVersion.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsVersion.TabIndex = 110;
            // 
            // textBoxPropsXmlns
            // 
            this.textBoxPropsXmlns.Enabled = false;
            this.textBoxPropsXmlns.Location = new System.Drawing.Point(94, 87);
            this.textBoxPropsXmlns.Name = "textBoxPropsXmlns";
            this.textBoxPropsXmlns.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsXmlns.TabIndex = 108;
            // 
            // textBoxPropsJsonEncoding
            // 
            this.textBoxPropsJsonEncoding.Enabled = false;
            this.textBoxPropsJsonEncoding.Location = new System.Drawing.Point(94, 137);
            this.textBoxPropsJsonEncoding.Name = "textBoxPropsJsonEncoding";
            this.textBoxPropsJsonEncoding.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsJsonEncoding.TabIndex = 112;
            // 
            // labelPropsFeatureCatalogueName
            // 
            this.labelPropsFeatureCatalogueName.AutoSize = true;
            this.labelPropsFeatureCatalogueName.Location = new System.Drawing.Point(53, 40);
            this.labelPropsFeatureCatalogueName.Name = "labelPropsFeatureCatalogueName";
            this.labelPropsFeatureCatalogueName.Size = new System.Drawing.Size(35, 13);
            this.labelPropsFeatureCatalogueName.TabIndex = 103;
            this.labelPropsFeatureCatalogueName.Text = "Name";
            this.labelPropsFeatureCatalogueName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsTagJsonEncodingRule
            // 
            this.labelPropsTagJsonEncodingRule.AutoSize = true;
            this.labelPropsTagJsonEncodingRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagJsonEncodingRule.Location = new System.Drawing.Point(397, 140);
            this.labelPropsTagJsonEncodingRule.Name = "labelPropsTagJsonEncodingRule";
            this.labelPropsTagJsonEncodingRule.Size = new System.Drawing.Size(114, 13);
            this.labelPropsTagJsonEncodingRule.TabIndex = 999;
            this.labelPropsTagJsonEncodingRule.Text = "tag: jsonEncodingRule";
            // 
            // labelPropsTagXmlns
            // 
            this.labelPropsTagXmlns.AutoSize = true;
            this.labelPropsTagXmlns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagXmlns.Location = new System.Drawing.Point(397, 90);
            this.labelPropsTagXmlns.Name = "labelPropsTagXmlns";
            this.labelPropsTagXmlns.Size = new System.Drawing.Size(54, 13);
            this.labelPropsTagXmlns.TabIndex = 999;
            this.labelPropsTagXmlns.Text = "tag: xmlns";
            // 
            // labelPropsTagVersion
            // 
            this.labelPropsTagVersion.AutoSize = true;
            this.labelPropsTagVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagVersion.Location = new System.Drawing.Point(397, 115);
            this.labelPropsTagVersion.Name = "labelPropsTagVersion";
            this.labelPropsTagVersion.Size = new System.Drawing.Size(62, 13);
            this.labelPropsTagVersion.TabIndex = 999;
            this.labelPropsTagVersion.Text = "tag: version";
            // 
            // labelPropsTagTargetNamespace
            // 
            this.labelPropsTagTargetNamespace.AutoSize = true;
            this.labelPropsTagTargetNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagTargetNamespace.Location = new System.Drawing.Point(397, 65);
            this.labelPropsTagTargetNamespace.Name = "labelPropsTagTargetNamespace";
            this.labelPropsTagTargetNamespace.Size = new System.Drawing.Size(112, 13);
            this.labelPropsTagTargetNamespace.TabIndex = 999;
            this.labelPropsTagTargetNamespace.Text = "tag: targetNamespace";
            // 
            // labelPropsEaProjectFile
            // 
            this.labelPropsEaProjectFile.AutoSize = true;
            this.labelPropsEaProjectFile.Location = new System.Drawing.Point(16, 12);
            this.labelPropsEaProjectFile.Name = "labelPropsEaProjectFile";
            this.labelPropsEaProjectFile.Size = new System.Drawing.Size(72, 13);
            this.labelPropsEaProjectFile.TabIndex = 101;
            this.labelPropsEaProjectFile.Text = "EA project file";
            this.labelPropsEaProjectFile.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsEncodingRules
            // 
            this.labelPropsEncodingRules.AutoSize = true;
            this.labelPropsEncodingRules.Location = new System.Drawing.Point(11, 140);
            this.labelPropsEncodingRules.Name = "labelPropsEncodingRules";
            this.labelPropsEncodingRules.Size = new System.Drawing.Size(77, 13);
            this.labelPropsEncodingRules.TabIndex = 111;
            this.labelPropsEncodingRules.Text = "Encoding rules";
            this.labelPropsEncodingRules.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsTargetNamespace
            // 
            this.labelPropsTargetNamespace.AutoSize = true;
            this.labelPropsTargetNamespace.Location = new System.Drawing.Point(24, 65);
            this.labelPropsTargetNamespace.Name = "labelPropsTargetNamespace";
            this.labelPropsTargetNamespace.Size = new System.Drawing.Size(64, 13);
            this.labelPropsTargetNamespace.TabIndex = 105;
            this.labelPropsTargetNamespace.Text = "Namespace";
            this.labelPropsTargetNamespace.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsXmlns
            // 
            this.labelPropsXmlns.AutoSize = true;
            this.labelPropsXmlns.Location = new System.Drawing.Point(55, 90);
            this.labelPropsXmlns.Name = "labelPropsXmlns";
            this.labelPropsXmlns.Size = new System.Drawing.Size(33, 13);
            this.labelPropsXmlns.TabIndex = 107;
            this.labelPropsXmlns.Text = "xmlns";
            this.labelPropsXmlns.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsVersion
            // 
            this.labelPropsVersion.AutoSize = true;
            this.labelPropsVersion.Location = new System.Drawing.Point(46, 115);
            this.labelPropsVersion.Name = "labelPropsVersion";
            this.labelPropsVersion.Size = new System.Drawing.Size(42, 13);
            this.labelPropsVersion.TabIndex = 109;
            this.labelPropsVersion.Text = "Version";
            this.labelPropsVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageProjectProps);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Location = new System.Drawing.Point(11, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(523, 366);
            this.tabControl.TabIndex = 10;
            // 
            // FrmJson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(642, 414);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonTransform);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmJson";
            this.Text = "Generate JSON-schema";
            this.Load += new System.EventHandler(this.FormGML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.tabPageProjectProps.ResumeLayout(false);
            this.tabPageProjectProps.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonTransform;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageProjectProps;

        // Project Properties tab
        private System.Windows.Forms.Label labelPropsEaProjectFile;
        private System.Windows.Forms.Label labelPropsEncodingRules;
        private System.Windows.Forms.Label labelPropsSchemaVersion;
        private System.Windows.Forms.Label labelPropsExportJson;
        private System.Windows.Forms.Label labelPropsFeatureCatalogueName;
        private System.Windows.Forms.Label labelPropsSchemaName;
        private System.Windows.Forms.Label labelPropsTagTargetNamespace;
        private System.Windows.Forms.Label labelPropsTagVersion;
        private System.Windows.Forms.Label labelPropsTagXmlns;
        private System.Windows.Forms.Label labelPropsTagSchemaName;
        private System.Windows.Forms.Label labelPropsTagJsonEncodingRule;
        private System.Windows.Forms.Label labelPropsTargetNamespace;
        private System.Windows.Forms.Label labelPropsVersion;
        private System.Windows.Forms.Label labelPropsXmlns;
        private System.Windows.Forms.TextBox textBoxPropsEaProjectFile;
        private System.Windows.Forms.TextBox textBoxPropsJsonEncoding;
        private System.Windows.Forms.TextBox textBoxPropsFeatureCatalogueName;
        private System.Windows.Forms.TextBox textBoxPropsTargetNamespace;
        private System.Windows.Forms.TextBox textBoxPropsVersion;
        private System.Windows.Forms.TextBox textBoxPropsXmlns;
        private System.Windows.Forms.TextBox textBoxPropsJsonDirectory;
        private System.Windows.Forms.TextBox textBoxPropsSchemaName;

        // Log tab
        private System.Windows.Forms.Button buttonLogOpenLog;
        private System.Windows.Forms.Button buttonLogOpenResult;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label labelPropsTagSchemaVersion;
        private System.Windows.Forms.ComboBox comboBoxPropsSchemaVersion;
    }
}