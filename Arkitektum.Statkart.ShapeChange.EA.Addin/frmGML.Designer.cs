namespace Kartverket.ShapeChange.EA.Addin
{
    partial class frmGML
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGML));
            this.buttonTransform = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.buttonClose = new System.Windows.Forms.Button();
            this.checkBoxCodeLists = new System.Windows.Forms.CheckBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.checkBoxFeatureCatalog = new System.Windows.Forms.CheckBox();
            this.checkBoxMakeXsd = new System.Windows.Forms.CheckBox();
            this.labelSelectTargets = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonHelp = new System.Windows.Forms.Button();
            this.tabPageLog = new System.Windows.Forms.TabPage();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.buttonLogOpenLog = new System.Windows.Forms.Button();
            this.buttonLogOpenResult = new System.Windows.Forms.Button();
            this.tabPageProjectProps = new System.Windows.Forms.TabPage();
            this.labelPropsExportCodeLists = new System.Windows.Forms.Label();
            this.textBoxPropsCodeListDirectory = new System.Windows.Forms.TextBox();
            this.textBoxPropsTargetNamespace = new System.Windows.Forms.TextBox();
            this.labelPropsExportExcel = new System.Windows.Forms.Label();
            this.labelPropsTargetNamespace = new System.Windows.Forms.Label();
            this.textBoxPropsExcelDirectory = new System.Windows.Forms.TextBox();
            this.labelPropsTagTargetNamespace = new System.Windows.Forms.Label();
            this.textBoxPropsXmlns = new System.Windows.Forms.TextBox();
            this.labelPropsXmlns = new System.Windows.Forms.Label();
            this.labelPropsTagXmlns = new System.Windows.Forms.Label();
            this.textBoxPropsXsdEncoding = new System.Windows.Forms.TextBox();
            this.labelPropsEncodingRules = new System.Windows.Forms.Label();
            this.labelPropsTagXsdEncodingRule = new System.Windows.Forms.Label();
            this.textBoxPropsVersion = new System.Windows.Forms.TextBox();
            this.labelPropsVersion = new System.Windows.Forms.Label();
            this.labelPropsTagXsdDocument = new System.Windows.Forms.Label();
            this.labelPropsTagVersion = new System.Windows.Forms.Label();
            this.textBoxPropsXsdFile = new System.Windows.Forms.TextBox();
            this.labelPropsGmlXsd = new System.Windows.Forms.Label();
            this.textBoxPropsOutputDirectory = new System.Windows.Forms.TextBox();
            this.labelPropsOutputDirectory = new System.Windows.Forms.Label();
            this.textBoxPropsFeatureCatalogueName = new System.Windows.Forms.TextBox();
            this.textBoxPropsEaProjectFile = new System.Windows.Forms.TextBox();
            this.labelPropsFeatureCatalogueName = new System.Windows.Forms.Label();
            this.labelPropsEaProjectFile = new System.Windows.Forms.Label();
            this.checkBoxGenerateEnums = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFeatureCatalogue = new System.Windows.Forms.TabPage();
            this.textBoxFeatureCatalogueFeatureTerm = new System.Windows.Forms.TextBox();
            this.labelFeatureCatalogueFeatureTerm = new System.Windows.Forms.Label();
            this.checkBoxFeatureCatalogueIncludeTitle = new System.Windows.Forms.CheckBox();
            this.checkBoxFeatureCatalogueIncludeVoidable = new System.Windows.Forms.CheckBox();
            this.textBoxFeatureCatalogueName = new System.Windows.Forms.TextBox();
            this.labelFeatureCatalogueName = new System.Windows.Forms.Label();
            this.checkBoxFeatureCatalogueIncludeDiagrams = new System.Windows.Forms.CheckBox();
            this.textBoxFeatureCatalogueDocxTemplateFilename = new System.Windows.Forms.TextBox();
            this.labelFeatureCatalogueTemplateFileName = new System.Windows.Forms.Label();
            this.textBoxFeatureCatalogueDocxTemplateDirectory = new System.Windows.Forms.TextBox();
            this.labelFeatureCatalogueTemplateDirectory = new System.Windows.Forms.Label();
            this.textBoxFeatureCatalogueVersionDate = new System.Windows.Forms.TextBox();
            this.labelFeatureCatalogueVersionDate = new System.Windows.Forms.Label();
            this.textBoxFeatureCatalogueProducer = new System.Windows.Forms.TextBox();
            this.textBoxFeatureCatalogueDescription = new System.Windows.Forms.TextBox();
            this.textBoxFeatureCatalogueExportDirectory = new System.Windows.Forms.TextBox();
            this.labelFeatureCatalogueProducer = new System.Windows.Forms.Label();
            this.labelFeatureCatalogueDescription = new System.Windows.Forms.Label();
            this.labelFeatureCatalogueExport = new System.Windows.Forms.Label();
            this.labelFeatureCatalogueFormat = new System.Windows.Forms.Label();
            this.comboBoxFeatureCatalogueFormat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabPageLog.SuspendLayout();
            this.tabPageProjectProps.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageFeatureCatalogue.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTransform
            // 
            this.buttonTransform.Location = new System.Drawing.Point(569, 18);
            this.buttonTransform.Name = "buttonTransform";
            this.buttonTransform.Size = new System.Drawing.Size(95, 23);
            this.buttonTransform.TabIndex = 11;
            this.buttonTransform.Text = "Transform";
            this.buttonTransform.UseVisualStyleBackColor = true;
            this.buttonTransform.Click += new System.EventHandler(this.ButtonTransform_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(11, 445);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(653, 23);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(569, 47);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(95, 23);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // checkBoxCodeLists
            // 
            this.checkBoxCodeLists.AutoSize = true;
            this.checkBoxCodeLists.Location = new System.Drawing.Point(15, 51);
            this.checkBoxCodeLists.Name = "checkBoxCodeLists";
            this.checkBoxCodeLists.Size = new System.Drawing.Size(137, 17);
            this.checkBoxCodeLists.TabIndex = 1;
            this.checkBoxCodeLists.Text = "Make external codelists";
            this.checkBoxCodeLists.UseVisualStyleBackColor = true;
            this.checkBoxCodeLists.CheckedChanged += new System.EventHandler(this.checkBoxCodeLists_CheckedChanged);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(569, 102);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(95, 23);
            this.buttonSettings.TabIndex = 13;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.ButtonSettings_Click);
            // 
            // checkBoxFeatureCatalog
            // 
            this.checkBoxFeatureCatalog.AutoSize = true;
            this.checkBoxFeatureCatalog.Location = new System.Drawing.Point(211, 28);
            this.checkBoxFeatureCatalog.Name = "checkBoxFeatureCatalog";
            this.checkBoxFeatureCatalog.Size = new System.Drawing.Size(236, 17);
            this.checkBoxFeatureCatalog.TabIndex = 4;
            this.checkBoxFeatureCatalog.Text = "Generate documentation (FeatureCatalogue)";
            this.checkBoxFeatureCatalog.UseVisualStyleBackColor = true;
            // 
            // checkBoxMakeXsd
            // 
            this.checkBoxMakeXsd.AutoSize = true;
            this.checkBoxMakeXsd.Location = new System.Drawing.Point(15, 28);
            this.checkBoxMakeXsd.Name = "checkBoxMakeXsd";
            this.checkBoxMakeXsd.Size = new System.Drawing.Size(146, 17);
            this.checkBoxMakeXsd.TabIndex = 0;
            this.checkBoxMakeXsd.Text = "Make GML Schema (xsd)";
            this.checkBoxMakeXsd.UseVisualStyleBackColor = true;
            // 
            // labelSelectTargets
            // 
            this.labelSelectTargets.AutoSize = true;
            this.labelSelectTargets.Location = new System.Drawing.Point(8, 12);
            this.labelSelectTargets.Name = "labelSelectTargets";
            this.labelSelectTargets.Size = new System.Drawing.Size(78, 13);
            this.labelSelectTargets.TabIndex = 21;
            this.labelSelectTargets.Text = "Select targets :";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(569, 412);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(95, 23);
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
            this.tabPageLog.Size = new System.Drawing.Size(544, 295);
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
            this.textBoxLog.Size = new System.Drawing.Size(531, 278);
            this.textBoxLog.TabIndex = 0;
            // 
            // buttonLogOpenLog
            // 
            this.buttonLogOpenLog.Location = new System.Drawing.Point(922, 314);
            this.buttonLogOpenLog.Name = "buttonLogOpenLog";
            this.buttonLogOpenLog.Size = new System.Drawing.Size(104, 23);
            this.buttonLogOpenLog.TabIndex = 201;
            this.buttonLogOpenLog.Text = "Open logfile";
            this.buttonLogOpenLog.UseVisualStyleBackColor = true;
            this.buttonLogOpenLog.Click += new System.EventHandler(this.ButtonLog_Click);
            // 
            // buttonLogOpenResult
            // 
            this.buttonLogOpenResult.Location = new System.Drawing.Point(811, 314);
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
            this.tabPageProjectProps.Controls.Add(this.labelPropsExportCodeLists);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsCodeListDirectory);
            this.tabPageProjectProps.Controls.Add(this.labelPropsExportExcel);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsExcelDirectory);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTagXsdDocument);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsXsdFile);
            this.tabPageProjectProps.Controls.Add(this.labelPropsGmlXsd);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsOutputDirectory);
            this.tabPageProjectProps.Controls.Add(this.labelPropsOutputDirectory);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsFeatureCatalogueName);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsEaProjectFile);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsTargetNamespace);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsVersion);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsXmlns);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsXsdEncoding);
            this.tabPageProjectProps.Controls.Add(this.labelPropsFeatureCatalogueName);
            this.tabPageProjectProps.Controls.Add(this.labelPropsTagXsdEncodingRule);
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
            this.tabPageProjectProps.Size = new System.Drawing.Size(544, 295);
            this.tabPageProjectProps.TabIndex = 0;
            this.tabPageProjectProps.Text = "Project properties";
            this.tabPageProjectProps.UseVisualStyleBackColor = true;
            // 
            // labelPropsExportCodeLists
            // 
            this.labelPropsExportCodeLists.AutoSize = true;
            this.labelPropsExportCodeLists.Location = new System.Drawing.Point(7, 235);
            this.labelPropsExportCodeLists.Name = "labelPropsExportCodeLists";
            this.labelPropsExportCodeLists.Size = new System.Drawing.Size(81, 13);
            this.labelPropsExportCodeLists.TabIndex = 117;
            this.labelPropsExportCodeLists.Text = "Export codelists";
            this.labelPropsExportCodeLists.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxPropsCodeListDirectory
            // 
            this.textBoxPropsCodeListDirectory.Enabled = false;
            this.textBoxPropsCodeListDirectory.Location = new System.Drawing.Point(94, 232);
            this.textBoxPropsCodeListDirectory.Name = "textBoxPropsCodeListDirectory";
            this.textBoxPropsCodeListDirectory.Size = new System.Drawing.Size(415, 20);
            this.textBoxPropsCodeListDirectory.TabIndex = 118;
            // 
            // textBoxPropsTargetNamespace
            // 
            this.textBoxPropsTargetNamespace.Location = new System.Drawing.Point(94, 101);
            this.textBoxPropsTargetNamespace.Name = "textBoxPropsTargetNamespace";
            this.textBoxPropsTargetNamespace.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsTargetNamespace.TabIndex = 108;
            this.textBoxPropsTargetNamespace.Leave += new System.EventHandler(this.textBoxPropsTargetNamespace_Leave);
            // 
            // labelPropsExportExcel
            // 
            this.labelPropsExportExcel.AutoSize = true;
            this.labelPropsExportExcel.Location = new System.Drawing.Point(22, 260);
            this.labelPropsExportExcel.Name = "labelPropsExportExcel";
            this.labelPropsExportExcel.Size = new System.Drawing.Size(66, 13);
            this.labelPropsExportExcel.TabIndex = 119;
            this.labelPropsExportExcel.Text = "Export Excel";
            this.labelPropsExportExcel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsTargetNamespace
            // 
            this.labelPropsTargetNamespace.AutoSize = true;
            this.labelPropsTargetNamespace.Location = new System.Drawing.Point(24, 104);
            this.labelPropsTargetNamespace.Name = "labelPropsTargetNamespace";
            this.labelPropsTargetNamespace.Size = new System.Drawing.Size(64, 13);
            this.labelPropsTargetNamespace.TabIndex = 107;
            this.labelPropsTargetNamespace.Text = "Namespace";
            this.labelPropsTargetNamespace.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxPropsExcelDirectory
            // 
            this.textBoxPropsExcelDirectory.Enabled = false;
            this.textBoxPropsExcelDirectory.Location = new System.Drawing.Point(94, 257);
            this.textBoxPropsExcelDirectory.Name = "textBoxPropsExcelDirectory";
            this.textBoxPropsExcelDirectory.Size = new System.Drawing.Size(415, 20);
            this.textBoxPropsExcelDirectory.TabIndex = 120;
            // 
            // labelPropsTagTargetNamespace
            // 
            this.labelPropsTagTargetNamespace.AutoSize = true;
            this.labelPropsTagTargetNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagTargetNamespace.Location = new System.Drawing.Point(397, 104);
            this.labelPropsTagTargetNamespace.Name = "labelPropsTagTargetNamespace";
            this.labelPropsTagTargetNamespace.Size = new System.Drawing.Size(112, 13);
            this.labelPropsTagTargetNamespace.TabIndex = 999;
            this.labelPropsTagTargetNamespace.Text = "tag: targetNamespace";
            // 
            // textBoxPropsXmlns
            // 
            this.textBoxPropsXmlns.Location = new System.Drawing.Point(94, 127);
            this.textBoxPropsXmlns.Name = "textBoxPropsXmlns";
            this.textBoxPropsXmlns.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsXmlns.TabIndex = 110;
            this.textBoxPropsXmlns.Leave += new System.EventHandler(this.textBoxPropsXmlns_Leave);
            // 
            // labelPropsXmlns
            // 
            this.labelPropsXmlns.AutoSize = true;
            this.labelPropsXmlns.Location = new System.Drawing.Point(55, 130);
            this.labelPropsXmlns.Name = "labelPropsXmlns";
            this.labelPropsXmlns.Size = new System.Drawing.Size(33, 13);
            this.labelPropsXmlns.TabIndex = 109;
            this.labelPropsXmlns.Text = "xmlns";
            this.labelPropsXmlns.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsTagXmlns
            // 
            this.labelPropsTagXmlns.AutoSize = true;
            this.labelPropsTagXmlns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagXmlns.Location = new System.Drawing.Point(397, 130);
            this.labelPropsTagXmlns.Name = "labelPropsTagXmlns";
            this.labelPropsTagXmlns.Size = new System.Drawing.Size(54, 13);
            this.labelPropsTagXmlns.TabIndex = 999;
            this.labelPropsTagXmlns.Text = "tag: xmlns";
            // 
            // textBoxPropsXsdEncoding
            // 
            this.textBoxPropsXsdEncoding.Enabled = false;
            this.textBoxPropsXsdEncoding.Location = new System.Drawing.Point(94, 179);
            this.textBoxPropsXsdEncoding.Name = "textBoxPropsXsdEncoding";
            this.textBoxPropsXsdEncoding.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsXsdEncoding.TabIndex = 114;
            // 
            // labelPropsEncodingRules
            // 
            this.labelPropsEncodingRules.AutoSize = true;
            this.labelPropsEncodingRules.Location = new System.Drawing.Point(11, 182);
            this.labelPropsEncodingRules.Name = "labelPropsEncodingRules";
            this.labelPropsEncodingRules.Size = new System.Drawing.Size(77, 13);
            this.labelPropsEncodingRules.TabIndex = 113;
            this.labelPropsEncodingRules.Text = "Encoding rules";
            this.labelPropsEncodingRules.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsTagXsdEncodingRule
            // 
            this.labelPropsTagXsdEncodingRule.AutoSize = true;
            this.labelPropsTagXsdEncodingRule.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagXsdEncodingRule.Location = new System.Drawing.Point(397, 182);
            this.labelPropsTagXsdEncodingRule.Name = "labelPropsTagXsdEncodingRule";
            this.labelPropsTagXsdEncodingRule.Size = new System.Drawing.Size(111, 13);
            this.labelPropsTagXsdEncodingRule.TabIndex = 999;
            this.labelPropsTagXsdEncodingRule.Text = "tag: xsdEncodingRule";
            // 
            // textBoxPropsVersion
            // 
            this.textBoxPropsVersion.Location = new System.Drawing.Point(94, 153);
            this.textBoxPropsVersion.Name = "textBoxPropsVersion";
            this.textBoxPropsVersion.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsVersion.TabIndex = 112;
            this.textBoxPropsVersion.Leave += new System.EventHandler(this.textBoxPropsVersion_Leave);
            // 
            // labelPropsVersion
            // 
            this.labelPropsVersion.AutoSize = true;
            this.labelPropsVersion.Location = new System.Drawing.Point(46, 156);
            this.labelPropsVersion.Name = "labelPropsVersion";
            this.labelPropsVersion.Size = new System.Drawing.Size(42, 13);
            this.labelPropsVersion.TabIndex = 111;
            this.labelPropsVersion.Text = "Version";
            this.labelPropsVersion.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPropsTagXsdDocument
            // 
            this.labelPropsTagXsdDocument.AutoSize = true;
            this.labelPropsTagXsdDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagXsdDocument.Location = new System.Drawing.Point(397, 208);
            this.labelPropsTagXsdDocument.Name = "labelPropsTagXsdDocument";
            this.labelPropsTagXsdDocument.Size = new System.Drawing.Size(93, 13);
            this.labelPropsTagXsdDocument.TabIndex = 999;
            this.labelPropsTagXsdDocument.Text = "tag: xsdDocument";
            // 
            // labelPropsTagVersion
            // 
            this.labelPropsTagVersion.AutoSize = true;
            this.labelPropsTagVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPropsTagVersion.Location = new System.Drawing.Point(397, 156);
            this.labelPropsTagVersion.Name = "labelPropsTagVersion";
            this.labelPropsTagVersion.Size = new System.Drawing.Size(62, 13);
            this.labelPropsTagVersion.TabIndex = 999;
            this.labelPropsTagVersion.Text = "tag: version";
            // 
            // textBoxPropsXsdFile
            // 
            this.textBoxPropsXsdFile.Location = new System.Drawing.Point(94, 205);
            this.textBoxPropsXsdFile.Name = "textBoxPropsXsdFile";
            this.textBoxPropsXsdFile.Size = new System.Drawing.Size(294, 20);
            this.textBoxPropsXsdFile.TabIndex = 116;
            this.textBoxPropsXsdFile.Leave += new System.EventHandler(this.textBoxPropsXsdFile_Leave);
            // 
            // labelPropsGmlXsd
            // 
            this.labelPropsGmlXsd.AutoSize = true;
            this.labelPropsGmlXsd.Location = new System.Drawing.Point(31, 208);
            this.labelPropsGmlXsd.Name = "labelPropsGmlXsd";
            this.labelPropsGmlXsd.Size = new System.Drawing.Size(57, 13);
            this.labelPropsGmlXsd.TabIndex = 115;
            this.labelPropsGmlXsd.Text = "GML (Xsd)";
            this.labelPropsGmlXsd.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxPropsOutputDirectory
            // 
            this.textBoxPropsOutputDirectory.Enabled = false;
            this.textBoxPropsOutputDirectory.Location = new System.Drawing.Point(94, 69);
            this.textBoxPropsOutputDirectory.Name = "textBoxPropsOutputDirectory";
            this.textBoxPropsOutputDirectory.Size = new System.Drawing.Size(415, 20);
            this.textBoxPropsOutputDirectory.TabIndex = 106;
            // 
            // labelPropsOutputDirectory
            // 
            this.labelPropsOutputDirectory.AutoSize = true;
            this.labelPropsOutputDirectory.Location = new System.Drawing.Point(6, 72);
            this.labelPropsOutputDirectory.Name = "labelPropsOutputDirectory";
            this.labelPropsOutputDirectory.Size = new System.Drawing.Size(82, 13);
            this.labelPropsOutputDirectory.TabIndex = 105;
            this.labelPropsOutputDirectory.Text = "Output directory";
            this.labelPropsOutputDirectory.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.textBoxPropsEaProjectFile.Location = new System.Drawing.Point(94, 10);
            this.textBoxPropsEaProjectFile.Name = "textBoxPropsEaProjectFile";
            this.textBoxPropsEaProjectFile.Size = new System.Drawing.Size(415, 20);
            this.textBoxPropsEaProjectFile.TabIndex = 102;
            // 
            // labelPropsFeatureCatalogueName
            // 
            this.labelPropsFeatureCatalogueName.AutoSize = true;
            this.labelPropsFeatureCatalogueName.Location = new System.Drawing.Point(9, 40);
            this.labelPropsFeatureCatalogueName.Name = "labelPropsFeatureCatalogueName";
            this.labelPropsFeatureCatalogueName.Size = new System.Drawing.Size(79, 13);
            this.labelPropsFeatureCatalogueName.TabIndex = 103;
            this.labelPropsFeatureCatalogueName.Text = "Package name";
            this.labelPropsFeatureCatalogueName.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // checkBoxGenerateEnums
            // 
            this.checkBoxGenerateEnums.AutoSize = true;
            this.checkBoxGenerateEnums.Enabled = false;
            this.checkBoxGenerateEnums.Location = new System.Drawing.Point(24, 74);
            this.checkBoxGenerateEnums.Name = "checkBoxGenerateEnums";
            this.checkBoxGenerateEnums.Size = new System.Drawing.Size(199, 17);
            this.checkBoxGenerateEnums.TabIndex = 2;
            this.checkBoxGenerateEnums.Text = "Encode enumerations as dictionaries";
            this.checkBoxGenerateEnums.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageProjectProps);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Controls.Add(this.tabPageFeatureCatalogue);
            this.tabControl.Location = new System.Drawing.Point(11, 118);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(552, 321);
            this.tabControl.TabIndex = 10;
            // 
            // tabPageFeatureCatalogue
            // 
            this.tabPageFeatureCatalogue.Controls.Add(this.textBoxFeatureCatalogueFeatureTerm);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueFeatureTerm);
            this.tabPageFeatureCatalogue.Controls.Add(this.checkBoxFeatureCatalogueIncludeTitle);
            this.tabPageFeatureCatalogue.Controls.Add(this.checkBoxFeatureCatalogueIncludeVoidable);
            this.tabPageFeatureCatalogue.Controls.Add(this.textBoxFeatureCatalogueName);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueName);
            this.tabPageFeatureCatalogue.Controls.Add(this.checkBoxFeatureCatalogueIncludeDiagrams);
            this.tabPageFeatureCatalogue.Controls.Add(this.textBoxFeatureCatalogueDocxTemplateFilename);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueTemplateFileName);
            this.tabPageFeatureCatalogue.Controls.Add(this.textBoxFeatureCatalogueDocxTemplateDirectory);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueTemplateDirectory);
            this.tabPageFeatureCatalogue.Controls.Add(this.textBoxFeatureCatalogueVersionDate);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueVersionDate);
            this.tabPageFeatureCatalogue.Controls.Add(this.textBoxFeatureCatalogueProducer);
            this.tabPageFeatureCatalogue.Controls.Add(this.textBoxFeatureCatalogueDescription);
            this.tabPageFeatureCatalogue.Controls.Add(this.textBoxFeatureCatalogueExportDirectory);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueProducer);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueDescription);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueExport);
            this.tabPageFeatureCatalogue.Controls.Add(this.labelFeatureCatalogueFormat);
            this.tabPageFeatureCatalogue.Controls.Add(this.comboBoxFeatureCatalogueFormat);
            this.tabPageFeatureCatalogue.Location = new System.Drawing.Point(4, 22);
            this.tabPageFeatureCatalogue.Name = "tabPageFeatureCatalogue";
            this.tabPageFeatureCatalogue.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFeatureCatalogue.Size = new System.Drawing.Size(544, 295);
            this.tabPageFeatureCatalogue.TabIndex = 2;
            this.tabPageFeatureCatalogue.Text = "FeatureCatalogue";
            this.tabPageFeatureCatalogue.UseVisualStyleBackColor = true;
            // 
            // textBoxFeatureCatalogueFeatureTerm
            // 
            this.textBoxFeatureCatalogueFeatureTerm.Location = new System.Drawing.Point(125, 296);
            this.textBoxFeatureCatalogueFeatureTerm.Name = "textBoxFeatureCatalogueFeatureTerm";
            this.textBoxFeatureCatalogueFeatureTerm.Size = new System.Drawing.Size(379, 20);
            this.textBoxFeatureCatalogueFeatureTerm.TabIndex = 320;
            // 
            // labelFeatureCatalogueFeatureTerm
            // 
            this.labelFeatureCatalogueFeatureTerm.AutoSize = true;
            this.labelFeatureCatalogueFeatureTerm.Location = new System.Drawing.Point(55, 296);
            this.labelFeatureCatalogueFeatureTerm.Name = "labelFeatureCatalogueFeatureTerm";
            this.labelFeatureCatalogueFeatureTerm.Size = new System.Drawing.Size(66, 13);
            this.labelFeatureCatalogueFeatureTerm.TabIndex = 319;
            this.labelFeatureCatalogueFeatureTerm.Text = "Feature term";
            this.labelFeatureCatalogueFeatureTerm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxFeatureCatalogueIncludeTitle
            // 
            this.checkBoxFeatureCatalogueIncludeTitle.AutoSize = true;
            this.checkBoxFeatureCatalogueIncludeTitle.Location = new System.Drawing.Point(125, 273);
            this.checkBoxFeatureCatalogueIncludeTitle.Name = "checkBoxFeatureCatalogueIncludeTitle";
            this.checkBoxFeatureCatalogueIncludeTitle.Size = new System.Drawing.Size(80, 17);
            this.checkBoxFeatureCatalogueIncludeTitle.TabIndex = 318;
            this.checkBoxFeatureCatalogueIncludeTitle.Text = "Include title";
            this.checkBoxFeatureCatalogueIncludeTitle.UseVisualStyleBackColor = true;
            // 
            // checkBoxFeatureCatalogueIncludeVoidable
            // 
            this.checkBoxFeatureCatalogueIncludeVoidable.AutoSize = true;
            this.checkBoxFeatureCatalogueIncludeVoidable.Location = new System.Drawing.Point(125, 250);
            this.checkBoxFeatureCatalogueIncludeVoidable.Name = "checkBoxFeatureCatalogueIncludeVoidable";
            this.checkBoxFeatureCatalogueIncludeVoidable.Size = new System.Drawing.Size(104, 17);
            this.checkBoxFeatureCatalogueIncludeVoidable.TabIndex = 317;
            this.checkBoxFeatureCatalogueIncludeVoidable.Text = "Include voidable";
            this.checkBoxFeatureCatalogueIncludeVoidable.UseVisualStyleBackColor = true;
            // 
            // textBoxFeatureCatalogueName
            // 
            this.textBoxFeatureCatalogueName.Enabled = false;
            this.textBoxFeatureCatalogueName.Location = new System.Drawing.Point(125, 45);
            this.textBoxFeatureCatalogueName.Name = "textBoxFeatureCatalogueName";
            this.textBoxFeatureCatalogueName.Size = new System.Drawing.Size(379, 20);
            this.textBoxFeatureCatalogueName.TabIndex = 303;
            // 
            // labelFeatureCatalogueName
            // 
            this.labelFeatureCatalogueName.AutoSize = true;
            this.labelFeatureCatalogueName.Location = new System.Drawing.Point(86, 47);
            this.labelFeatureCatalogueName.Name = "labelFeatureCatalogueName";
            this.labelFeatureCatalogueName.Size = new System.Drawing.Size(35, 13);
            this.labelFeatureCatalogueName.TabIndex = 302;
            this.labelFeatureCatalogueName.Text = "Name";
            this.labelFeatureCatalogueName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBoxFeatureCatalogueIncludeDiagrams
            // 
            this.checkBoxFeatureCatalogueIncludeDiagrams.AutoSize = true;
            this.checkBoxFeatureCatalogueIncludeDiagrams.Checked = true;
            this.checkBoxFeatureCatalogueIncludeDiagrams.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxFeatureCatalogueIncludeDiagrams.Location = new System.Drawing.Point(125, 227);
            this.checkBoxFeatureCatalogueIncludeDiagrams.Name = "checkBoxFeatureCatalogueIncludeDiagrams";
            this.checkBoxFeatureCatalogueIncludeDiagrams.Size = new System.Drawing.Size(106, 17);
            this.checkBoxFeatureCatalogueIncludeDiagrams.TabIndex = 316;
            this.checkBoxFeatureCatalogueIncludeDiagrams.Text = "Include diagrams";
            this.checkBoxFeatureCatalogueIncludeDiagrams.UseVisualStyleBackColor = true;
            // 
            // textBoxFeatureCatalogueDocxTemplateFilename
            // 
            this.textBoxFeatureCatalogueDocxTemplateFilename.Location = new System.Drawing.Point(125, 201);
            this.textBoxFeatureCatalogueDocxTemplateFilename.Name = "textBoxFeatureCatalogueDocxTemplateFilename";
            this.textBoxFeatureCatalogueDocxTemplateFilename.Size = new System.Drawing.Size(379, 20);
            this.textBoxFeatureCatalogueDocxTemplateFilename.TabIndex = 315;
            // 
            // labelFeatureCatalogueTemplateFileName
            // 
            this.labelFeatureCatalogueTemplateFileName.AutoSize = true;
            this.labelFeatureCatalogueTemplateFileName.Location = new System.Drawing.Point(39, 203);
            this.labelFeatureCatalogueTemplateFileName.Name = "labelFeatureCatalogueTemplateFileName";
            this.labelFeatureCatalogueTemplateFileName.Size = new System.Drawing.Size(81, 13);
            this.labelFeatureCatalogueTemplateFileName.TabIndex = 314;
            this.labelFeatureCatalogueTemplateFileName.Text = "Templ. filename";
            this.labelFeatureCatalogueTemplateFileName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxFeatureCatalogueDocxTemplateDirectory
            // 
            this.textBoxFeatureCatalogueDocxTemplateDirectory.Location = new System.Drawing.Point(125, 175);
            this.textBoxFeatureCatalogueDocxTemplateDirectory.Name = "textBoxFeatureCatalogueDocxTemplateDirectory";
            this.textBoxFeatureCatalogueDocxTemplateDirectory.Size = new System.Drawing.Size(379, 20);
            this.textBoxFeatureCatalogueDocxTemplateDirectory.TabIndex = 313;
            // 
            // labelFeatureCatalogueTemplateDirectory
            // 
            this.labelFeatureCatalogueTemplateDirectory.AutoSize = true;
            this.labelFeatureCatalogueTemplateDirectory.Location = new System.Drawing.Point(39, 177);
            this.labelFeatureCatalogueTemplateDirectory.Name = "labelFeatureCatalogueTemplateDirectory";
            this.labelFeatureCatalogueTemplateDirectory.Size = new System.Drawing.Size(82, 13);
            this.labelFeatureCatalogueTemplateDirectory.TabIndex = 312;
            this.labelFeatureCatalogueTemplateDirectory.Text = "Templ. directory";
            this.labelFeatureCatalogueTemplateDirectory.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxFeatureCatalogueVersionDate
            // 
            this.textBoxFeatureCatalogueVersionDate.Location = new System.Drawing.Point(125, 149);
            this.textBoxFeatureCatalogueVersionDate.Name = "textBoxFeatureCatalogueVersionDate";
            this.textBoxFeatureCatalogueVersionDate.Size = new System.Drawing.Size(379, 20);
            this.textBoxFeatureCatalogueVersionDate.TabIndex = 311;
            // 
            // labelFeatureCatalogueVersionDate
            // 
            this.labelFeatureCatalogueVersionDate.AutoSize = true;
            this.labelFeatureCatalogueVersionDate.Location = new System.Drawing.Point(55, 151);
            this.labelFeatureCatalogueVersionDate.Name = "labelFeatureCatalogueVersionDate";
            this.labelFeatureCatalogueVersionDate.Size = new System.Drawing.Size(66, 13);
            this.labelFeatureCatalogueVersionDate.TabIndex = 310;
            this.labelFeatureCatalogueVersionDate.Text = "Version date";
            this.labelFeatureCatalogueVersionDate.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxFeatureCatalogueProducer
            // 
            this.textBoxFeatureCatalogueProducer.Location = new System.Drawing.Point(125, 123);
            this.textBoxFeatureCatalogueProducer.Name = "textBoxFeatureCatalogueProducer";
            this.textBoxFeatureCatalogueProducer.Size = new System.Drawing.Size(379, 20);
            this.textBoxFeatureCatalogueProducer.TabIndex = 309;
            // 
            // textBoxFeatureCatalogueDescription
            // 
            this.textBoxFeatureCatalogueDescription.Location = new System.Drawing.Point(125, 97);
            this.textBoxFeatureCatalogueDescription.Name = "textBoxFeatureCatalogueDescription";
            this.textBoxFeatureCatalogueDescription.Size = new System.Drawing.Size(379, 20);
            this.textBoxFeatureCatalogueDescription.TabIndex = 307;
            // 
            // textBoxFeatureCatalogueExportDirectory
            // 
            this.textBoxFeatureCatalogueExportDirectory.Enabled = false;
            this.textBoxFeatureCatalogueExportDirectory.Location = new System.Drawing.Point(125, 71);
            this.textBoxFeatureCatalogueExportDirectory.Name = "textBoxFeatureCatalogueExportDirectory";
            this.textBoxFeatureCatalogueExportDirectory.Size = new System.Drawing.Size(379, 20);
            this.textBoxFeatureCatalogueExportDirectory.TabIndex = 305;
            // 
            // labelFeatureCatalogueProducer
            // 
            this.labelFeatureCatalogueProducer.AutoSize = true;
            this.labelFeatureCatalogueProducer.Location = new System.Drawing.Point(71, 125);
            this.labelFeatureCatalogueProducer.Name = "labelFeatureCatalogueProducer";
            this.labelFeatureCatalogueProducer.Size = new System.Drawing.Size(50, 13);
            this.labelFeatureCatalogueProducer.TabIndex = 308;
            this.labelFeatureCatalogueProducer.Text = "Producer";
            this.labelFeatureCatalogueProducer.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelFeatureCatalogueDescription
            // 
            this.labelFeatureCatalogueDescription.AutoSize = true;
            this.labelFeatureCatalogueDescription.Location = new System.Drawing.Point(61, 99);
            this.labelFeatureCatalogueDescription.Name = "labelFeatureCatalogueDescription";
            this.labelFeatureCatalogueDescription.Size = new System.Drawing.Size(60, 13);
            this.labelFeatureCatalogueDescription.TabIndex = 306;
            this.labelFeatureCatalogueDescription.Text = "Description";
            this.labelFeatureCatalogueDescription.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelFeatureCatalogueExport
            // 
            this.labelFeatureCatalogueExport.AutoSize = true;
            this.labelFeatureCatalogueExport.Location = new System.Drawing.Point(1, 74);
            this.labelFeatureCatalogueExport.Name = "labelFeatureCatalogueExport";
            this.labelFeatureCatalogueExport.Size = new System.Drawing.Size(120, 13);
            this.labelFeatureCatalogueExport.TabIndex = 304;
            this.labelFeatureCatalogueExport.Text = "Export featurecatalogue";
            this.labelFeatureCatalogueExport.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelFeatureCatalogueFormat
            // 
            this.labelFeatureCatalogueFormat.AutoSize = true;
            this.labelFeatureCatalogueFormat.Location = new System.Drawing.Point(82, 21);
            this.labelFeatureCatalogueFormat.Name = "labelFeatureCatalogueFormat";
            this.labelFeatureCatalogueFormat.Size = new System.Drawing.Size(39, 13);
            this.labelFeatureCatalogueFormat.TabIndex = 300;
            this.labelFeatureCatalogueFormat.Text = "Format";
            this.labelFeatureCatalogueFormat.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // comboBoxFeatureCatalogueFormat
            // 
            this.comboBoxFeatureCatalogueFormat.FormattingEnabled = true;
            this.comboBoxFeatureCatalogueFormat.Items.AddRange(new object[] {
            "HTML",
            "DOCX",
            "DOCX-COMPACT",
            "FRAMEHTML"});
            this.comboBoxFeatureCatalogueFormat.Location = new System.Drawing.Point(125, 18);
            this.comboBoxFeatureCatalogueFormat.Name = "comboBoxFeatureCatalogueFormat";
            this.comboBoxFeatureCatalogueFormat.Size = new System.Drawing.Size(121, 21);
            this.comboBoxFeatureCatalogueFormat.TabIndex = 301;
            this.comboBoxFeatureCatalogueFormat.Text = "HTML";
            // 
            // frmGML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(670, 480);
            this.Controls.Add(this.checkBoxGenerateEnums);
            this.Controls.Add(this.buttonHelp);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.labelSelectTargets);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.checkBoxFeatureCatalog);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonTransform);
            this.Controls.Add(this.checkBoxMakeXsd);
            this.Controls.Add(this.checkBoxCodeLists);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGML";
            this.Text = "ShapeChange Add-In";
            this.Load += new System.EventHandler(this.FormGML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.tabPageProjectProps.ResumeLayout(false);
            this.tabPageProjectProps.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageFeatureCatalogue.ResumeLayout(false);
            this.tabPageFeatureCatalogue.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonTransform;
        private System.Windows.Forms.Button buttonHelp;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.CheckBox checkBoxCodeLists;
        private System.Windows.Forms.CheckBox checkBoxFeatureCatalog;
        private System.Windows.Forms.CheckBox checkBoxGenerateEnums;
        private System.Windows.Forms.CheckBox checkBoxMakeXsd;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label labelSelectTargets;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFeatureCatalogue;
        private System.Windows.Forms.TabPage tabPageLog;
        private System.Windows.Forms.TabPage tabPageProjectProps;
        private System.Windows.Forms.Label labelPropsEaProjectFile;
        private System.Windows.Forms.Label labelPropsExportCodeLists;
        private System.Windows.Forms.Label labelPropsExportExcel;
        private System.Windows.Forms.Label labelPropsExportGml;
        private System.Windows.Forms.Label labelPropsFeatureCatalogueName;
        private System.Windows.Forms.Label labelPropsOutputDirectory;
        private System.Windows.Forms.TextBox textBoxPropsCodeListDirectory;
        private System.Windows.Forms.TextBox textBoxPropsEaProjectFile;
        private System.Windows.Forms.TextBox textBoxPropsExcelDirectory;
        private System.Windows.Forms.TextBox textBoxPropsFeatureCatalogueName;
        private System.Windows.Forms.TextBox textBoxPropsOutputDirectory;

        // Log tab
        private System.Windows.Forms.Button buttonLogOpenLog;
        private System.Windows.Forms.Button buttonLogOpenResult;
        private System.Windows.Forms.TextBox textBoxLog;

        // Feature Catalogue tab
        private System.Windows.Forms.CheckBox checkBoxFeatureCatalogueIncludeDiagrams;
        private System.Windows.Forms.CheckBox checkBoxFeatureCatalogueIncludeTitle;
        private System.Windows.Forms.CheckBox checkBoxFeatureCatalogueIncludeVoidable;
        private System.Windows.Forms.ComboBox comboBoxFeatureCatalogueFormat;
        private System.Windows.Forms.Label labelFeatureCatalogueDescription;
        private System.Windows.Forms.Label labelFeatureCatalogueExport;
        private System.Windows.Forms.Label labelFeatureCatalogueFeatureTerm;
        private System.Windows.Forms.Label labelFeatureCatalogueFormat;
        private System.Windows.Forms.Label labelFeatureCatalogueName;
        private System.Windows.Forms.Label labelFeatureCatalogueProducer;
        private System.Windows.Forms.Label labelFeatureCatalogueTemplateDirectory;
        private System.Windows.Forms.Label labelFeatureCatalogueTemplateFileName;
        private System.Windows.Forms.Label labelFeatureCatalogueVersionDate;
        private System.Windows.Forms.TextBox textBoxFeatureCatalogueDescription;
        private System.Windows.Forms.TextBox textBoxFeatureCatalogueDocxTemplateDirectory;
        private System.Windows.Forms.TextBox textBoxFeatureCatalogueDocxTemplateFilename;
        private System.Windows.Forms.TextBox textBoxFeatureCatalogueExportDirectory;
        private System.Windows.Forms.TextBox textBoxFeatureCatalogueFeatureTerm;
        private System.Windows.Forms.TextBox textBoxFeatureCatalogueName;
        private System.Windows.Forms.TextBox textBoxFeatureCatalogueProducer;
        private System.Windows.Forms.TextBox textBoxFeatureCatalogueVersionDate;
        private System.Windows.Forms.TextBox textBoxPropsTargetNamespace;
        private System.Windows.Forms.Label labelPropsTargetNamespace;
        private System.Windows.Forms.Label labelPropsTagTargetNamespace;
        private System.Windows.Forms.TextBox textBoxPropsXmlns;
        private System.Windows.Forms.Label labelPropsXmlns;
        private System.Windows.Forms.Label labelPropsTagXmlns;
        private System.Windows.Forms.TextBox textBoxPropsXsdEncoding;
        private System.Windows.Forms.Label labelPropsEncodingRules;
        private System.Windows.Forms.Label labelPropsTagXsdEncodingRule;
        private System.Windows.Forms.TextBox textBoxPropsVersion;
        private System.Windows.Forms.Label labelPropsVersion;
        private System.Windows.Forms.Label labelPropsTagXsdDocument;
        private System.Windows.Forms.Label labelPropsTagVersion;
        private System.Windows.Forms.TextBox textBoxPropsXsdFile;
        private System.Windows.Forms.Label labelPropsGmlXsd;
    }
}