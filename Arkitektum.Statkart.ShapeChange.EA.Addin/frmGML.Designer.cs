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
            this.btnGML = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.chKodelister = new System.Windows.Forms.CheckBox();
            this.btnSettings = new System.Windows.Forms.Button();
            this.chfeatureCatalog = new System.Windows.Forms.CheckBox();
            this.chMakeXsd = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnHelp = new System.Windows.Forms.Button();
            this.tpLogg = new System.Windows.Forms.TabPage();
            this.txtLogg = new System.Windows.Forms.TextBox();
            this.btnLogg = new System.Windows.Forms.Button();
            this.btnResult = new System.Windows.Forms.Button();
            this.tpOppsett = new System.Windows.Forms.TabPage();
            this.txtShapechangeJar = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.chEnums = new System.Windows.Forms.CheckBox();
            this.chOCLConstraints = new System.Windows.Forms.CheckBox();
            this.chSchematron = new System.Windows.Forms.CheckBox();
            this.chDok = new System.Windows.Forms.CheckBox();
            this.txtExcelKatalog = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtKodelisterkatalog = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXsdfil = new System.Windows.Forms.TextBox();
            this.txtXsdKatalog = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFCName = new System.Windows.Forms.TextBox();
            this.txtEapfil = new System.Windows.Forms.TextBox();
            this.txtTargetNamespace = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtXmlns = new System.Windows.Forms.TextBox();
            this.txtEncoding = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpFC = new System.Windows.Forms.TabPage();
            this.txtFeatureTerm = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.chIncludeTitle = new System.Windows.Forms.CheckBox();
            this.chIncludeVoidable = new System.Windows.Forms.CheckBox();
            this.txtFCName2 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.chIncludeDiagrams = new System.Windows.Forms.CheckBox();
            this.txtDocxTemplFilename = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.txtDocxTemplDir = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.txtVersionDate = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.txtFCProducer = new System.Windows.Forms.TextBox();
            this.txtFCNote = new System.Windows.Forms.TextBox();
            this.txtFCKatalog = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cbFormat = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tpLogg.SuspendLayout();
            this.tpOppsett.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpFC.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGML
            // 
            this.btnGML.Location = new System.Drawing.Point(721, 15);
            this.btnGML.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGML.Name = "btnGML";
            this.btnGML.Size = new System.Drawing.Size(124, 28);
            this.btnGML.TabIndex = 0;
            this.btnGML.Text = "Transform";
            this.btnGML.UseVisualStyleBackColor = true;
            this.btnGML.Click += new System.EventHandler(this.btnGML_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 608);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(829, 28);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(721, 50);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 28);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(721, 87);
            this.btnTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(124, 28);
            this.btnTest.TabIndex = 18;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // chKodelister
            // 
            this.chKodelister.AutoSize = true;
            this.chKodelister.Location = new System.Drawing.Point(20, 63);
            this.chKodelister.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chKodelister.Name = "chKodelister";
            this.chKodelister.Size = new System.Drawing.Size(177, 21);
            this.chKodelister.TabIndex = 20;
            this.chKodelister.Text = "Make external codelists";
            this.chKodelister.UseVisualStyleBackColor = true;
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(721, 118);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(124, 28);
            this.btnSettings.TabIndex = 24;
            this.btnSettings.Text = "Settings";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // chfeatureCatalog
            // 
            this.chfeatureCatalog.AutoSize = true;
            this.chfeatureCatalog.Location = new System.Drawing.Point(223, 34);
            this.chfeatureCatalog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chfeatureCatalog.Name = "chfeatureCatalog";
            this.chfeatureCatalog.Size = new System.Drawing.Size(314, 21);
            this.chfeatureCatalog.TabIndex = 23;
            this.chfeatureCatalog.Text = "Generate documentation (FeatureCatalogue)";
            this.chfeatureCatalog.UseVisualStyleBackColor = true;
            this.chfeatureCatalog.CheckedChanged += new System.EventHandler(this.chfeatureCatalog_CheckedChanged);
            // 
            // chMakeXsd
            // 
            this.chMakeXsd.AutoSize = true;
            this.chMakeXsd.Checked = true;
            this.chMakeXsd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chMakeXsd.Location = new System.Drawing.Point(20, 34);
            this.chMakeXsd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chMakeXsd.Name = "chMakeXsd";
            this.chMakeXsd.Size = new System.Drawing.Size(188, 21);
            this.chMakeXsd.TabIndex = 21;
            this.chMakeXsd.Text = "Make GML Schema (xsd)";
            this.chMakeXsd.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 15);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(103, 17);
            this.label9.TabIndex = 21;
            this.label9.Text = "Select targets :";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(721, 567);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(124, 28);
            this.btnHelp.TabIndex = 26;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // tpLogg
            // 
            this.tpLogg.Controls.Add(this.txtLogg);
            this.tpLogg.Controls.Add(this.btnLogg);
            this.tpLogg.Controls.Add(this.btnResult);
            this.tpLogg.Location = new System.Drawing.Point(4, 25);
            this.tpLogg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpLogg.Name = "tpLogg";
            this.tpLogg.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpLogg.Size = new System.Drawing.Size(689, 421);
            this.tpLogg.TabIndex = 1;
            this.tpLogg.Text = "Logg";
            this.tpLogg.UseVisualStyleBackColor = true;
            // 
            // txtLogg
            // 
            this.txtLogg.Location = new System.Drawing.Point(9, 12);
            this.txtLogg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtLogg.Multiline = true;
            this.txtLogg.Name = "txtLogg";
            this.txtLogg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogg.Size = new System.Drawing.Size(668, 366);
            this.txtLogg.TabIndex = 0;
            // 
            // btnLogg
            // 
            this.btnLogg.Location = new System.Drawing.Point(539, 386);
            this.btnLogg.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogg.Name = "btnLogg";
            this.btnLogg.Size = new System.Drawing.Size(139, 28);
            this.btnLogg.TabIndex = 23;
            this.btnLogg.Text = "Open logfile";
            this.btnLogg.UseVisualStyleBackColor = true;
            this.btnLogg.Click += new System.EventHandler(this.btnLogg_Click);
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(391, 386);
            this.btnResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(139, 28);
            this.btnResult.TabIndex = 22;
            this.btnResult.Text = "Open result";
            this.btnResult.UseVisualStyleBackColor = true;
            this.btnResult.Visible = false;
            this.btnResult.Click += new System.EventHandler(this.btnResult_Click);
            // 
            // tpOppsett
            // 
            this.tpOppsett.Controls.Add(this.txtShapechangeJar);
            this.tpOppsett.Controls.Add(this.label26);
            this.tpOppsett.Controls.Add(this.chEnums);
            this.tpOppsett.Controls.Add(this.chOCLConstraints);
            this.tpOppsett.Controls.Add(this.chSchematron);
            this.tpOppsett.Controls.Add(this.chDok);
            this.tpOppsett.Controls.Add(this.txtExcelKatalog);
            this.tpOppsett.Controls.Add(this.label15);
            this.tpOppsett.Controls.Add(this.txtKodelisterkatalog);
            this.tpOppsett.Controls.Add(this.label14);
            this.tpOppsett.Controls.Add(this.label4);
            this.tpOppsett.Controls.Add(this.txtXsdfil);
            this.tpOppsett.Controls.Add(this.txtXsdKatalog);
            this.tpOppsett.Controls.Add(this.label3);
            this.tpOppsett.Controls.Add(this.label1);
            this.tpOppsett.Controls.Add(this.txtFCName);
            this.tpOppsett.Controls.Add(this.txtEapfil);
            this.tpOppsett.Controls.Add(this.txtTargetNamespace);
            this.tpOppsett.Controls.Add(this.txtVersion);
            this.tpOppsett.Controls.Add(this.txtXmlns);
            this.tpOppsett.Controls.Add(this.txtEncoding);
            this.tpOppsett.Controls.Add(this.label17);
            this.tpOppsett.Controls.Add(this.label13);
            this.tpOppsett.Controls.Add(this.label12);
            this.tpOppsett.Controls.Add(this.label11);
            this.tpOppsett.Controls.Add(this.label10);
            this.tpOppsett.Controls.Add(this.label2);
            this.tpOppsett.Controls.Add(this.label8);
            this.tpOppsett.Controls.Add(this.label5);
            this.tpOppsett.Controls.Add(this.label7);
            this.tpOppsett.Controls.Add(this.label6);
            this.tpOppsett.Location = new System.Drawing.Point(4, 25);
            this.tpOppsett.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpOppsett.Name = "tpOppsett";
            this.tpOppsett.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpOppsett.Size = new System.Drawing.Size(689, 421);
            this.tpOppsett.TabIndex = 0;
            this.tpOppsett.Text = "Project properties";
            this.tpOppsett.UseVisualStyleBackColor = true;
            // 
            // txtShapechangeJar
            // 
            this.txtShapechangeJar.Location = new System.Drawing.Point(119, 325);
            this.txtShapechangeJar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtShapechangeJar.Name = "txtShapechangeJar";
            this.txtShapechangeJar.Size = new System.Drawing.Size(547, 22);
            this.txtShapechangeJar.TabIndex = 56;
            this.txtShapechangeJar.TextChanged += new System.EventHandler(this.TxtShapechangeJar_TextChanged);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(4, 325);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(116, 17);
            this.label26.TabIndex = 57;
            this.label26.Text = "Shapechange jar";
            // 
            // chEnums
            // 
            this.chEnums.AutoSize = true;
            this.chEnums.Location = new System.Drawing.Point(243, 194);
            this.chEnums.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chEnums.Name = "chEnums";
            this.chEnums.Size = new System.Drawing.Size(204, 21);
            this.chEnums.TabIndex = 49;
            this.chEnums.Text = "Generer som Enumerations";
            this.chEnums.UseVisualStyleBackColor = true;
            this.chEnums.Visible = false;
            // 
            // chOCLConstraints
            // 
            this.chOCLConstraints.AutoSize = true;
            this.chOCLConstraints.Location = new System.Drawing.Point(133, 194);
            this.chOCLConstraints.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chOCLConstraints.Name = "chOCLConstraints";
            this.chOCLConstraints.Size = new System.Drawing.Size(190, 21);
            this.chOCLConstraints.TabIndex = 48;
            this.chOCLConstraints.Text = "Sjekk for OCL constraints";
            this.chOCLConstraints.UseVisualStyleBackColor = true;
            this.chOCLConstraints.Visible = false;
            // 
            // chSchematron
            // 
            this.chSchematron.AutoSize = true;
            this.chSchematron.Location = new System.Drawing.Point(133, 223);
            this.chSchematron.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chSchematron.Name = "chSchematron";
            this.chSchematron.Size = new System.Drawing.Size(423, 21);
            this.chSchematron.TabIndex = 47;
            this.chSchematron.Text = "Mapping mellom OCL constraints og schematron (schematron)";
            this.chSchematron.UseVisualStyleBackColor = true;
            this.chSchematron.Visible = false;
            // 
            // chDok
            // 
            this.chDok.AutoSize = true;
            this.chDok.Checked = true;
            this.chDok.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chDok.Location = new System.Drawing.Point(133, 166);
            this.chDok.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chDok.Name = "chDok";
            this.chDok.Size = new System.Drawing.Size(351, 21);
            this.chDok.TabIndex = 46;
            this.chDok.Text = "Ta med kommentarer i xsd (includeDocumentation)";
            this.chDok.UseVisualStyleBackColor = true;
            this.chDok.Visible = false;
            // 
            // txtExcelKatalog
            // 
            this.txtExcelKatalog.Enabled = false;
            this.txtExcelKatalog.Location = new System.Drawing.Point(119, 293);
            this.txtExcelKatalog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExcelKatalog.Name = "txtExcelKatalog";
            this.txtExcelKatalog.Size = new System.Drawing.Size(547, 22);
            this.txtExcelKatalog.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 293);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 17);
            this.label15.TabIndex = 39;
            this.label15.Text = "Export Excel";
            // 
            // txtKodelisterkatalog
            // 
            this.txtKodelisterkatalog.Enabled = false;
            this.txtKodelisterkatalog.Location = new System.Drawing.Point(119, 263);
            this.txtKodelisterkatalog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtKodelisterkatalog.Name = "txtKodelisterkatalog";
            this.txtKodelisterkatalog.Size = new System.Drawing.Size(547, 22);
            this.txtKodelisterkatalog.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 263);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 17);
            this.label14.TabIndex = 37;
            this.label14.Text = "Export codelists";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(551, 238);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 17);
            this.label4.TabIndex = 35;
            this.label4.Text = "tag: xsdDocument";
            // 
            // txtXsdfil
            // 
            this.txtXsdfil.Enabled = false;
            this.txtXsdfil.Location = new System.Drawing.Point(119, 233);
            this.txtXsdfil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXsdfil.Name = "txtXsdfil";
            this.txtXsdfil.Size = new System.Drawing.Size(391, 22);
            this.txtXsdfil.TabIndex = 33;
            // 
            // txtXsdKatalog
            // 
            this.txtXsdKatalog.Enabled = false;
            this.txtXsdKatalog.Location = new System.Drawing.Point(119, 201);
            this.txtXsdKatalog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXsdKatalog.Name = "txtXsdKatalog";
            this.txtXsdKatalog.Size = new System.Drawing.Size(547, 22);
            this.txtXsdKatalog.TabIndex = 31;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 238);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 34;
            this.label3.Text = "GML (Xsd)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 201);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 32;
            this.label1.Text = "Export GML";
            // 
            // txtFCName
            // 
            this.txtFCName.Enabled = false;
            this.txtFCName.Location = new System.Drawing.Point(120, 46);
            this.txtFCName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFCName.Name = "txtFCName";
            this.txtFCName.Size = new System.Drawing.Size(391, 22);
            this.txtFCName.TabIndex = 29;
            // 
            // txtEapfil
            // 
            this.txtEapfil.Enabled = false;
            this.txtEapfil.Location = new System.Drawing.Point(119, 11);
            this.txtEapfil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEapfil.Name = "txtEapfil";
            this.txtEapfil.Size = new System.Drawing.Size(559, 22);
            this.txtEapfil.TabIndex = 3;
            // 
            // txtTargetNamespace
            // 
            this.txtTargetNamespace.Enabled = false;
            this.txtTargetNamespace.Location = new System.Drawing.Point(120, 75);
            this.txtTargetNamespace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTargetNamespace.Name = "txtTargetNamespace";
            this.txtTargetNamespace.Size = new System.Drawing.Size(391, 22);
            this.txtTargetNamespace.TabIndex = 10;
            // 
            // txtVersion
            // 
            this.txtVersion.Enabled = false;
            this.txtVersion.Location = new System.Drawing.Point(120, 139);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(391, 22);
            this.txtVersion.TabIndex = 11;
            // 
            // txtXmlns
            // 
            this.txtXmlns.Enabled = false;
            this.txtXmlns.Location = new System.Drawing.Point(120, 107);
            this.txtXmlns.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtXmlns.Name = "txtXmlns";
            this.txtXmlns.Size = new System.Drawing.Size(391, 22);
            this.txtXmlns.TabIndex = 12;
            // 
            // txtEncoding
            // 
            this.txtEncoding.Enabled = false;
            this.txtEncoding.Location = new System.Drawing.Point(120, 171);
            this.txtEncoding.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEncoding.Name = "txtEncoding";
            this.txtEncoding.Size = new System.Drawing.Size(391, 22);
            this.txtEncoding.TabIndex = 13;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 46);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 17);
            this.label17.TabIndex = 30;
            this.label17.Text = "Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(531, 175);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(145, 17);
            this.label13.TabIndex = 28;
            this.label13.Text = "tag: xsdEncodingRule";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(531, 111);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 17);
            this.label12.TabIndex = 27;
            this.label12.Text = "tag: xmlns";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(531, 143);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 17);
            this.label11.TabIndex = 26;
            this.label11.Text = "tag: version";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(531, 79);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(148, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "tag: targetNamespace";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "EA project file";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 171);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Encoding rules";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 79);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Namespace";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 107);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "xmlns";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 139);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Version";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpOppsett);
            this.tabControl1.Controls.Add(this.tpLogg);
            this.tabControl1.Controls.Add(this.tpFC);
            this.tabControl1.Location = new System.Drawing.Point(15, 145);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(697, 450);
            this.tabControl1.TabIndex = 25;
            // 
            // tpFC
            // 
            this.tpFC.Controls.Add(this.txtFeatureTerm);
            this.tpFC.Controls.Add(this.label25);
            this.tpFC.Controls.Add(this.chIncludeTitle);
            this.tpFC.Controls.Add(this.chIncludeVoidable);
            this.tpFC.Controls.Add(this.txtFCName2);
            this.tpFC.Controls.Add(this.label24);
            this.tpFC.Controls.Add(this.chIncludeDiagrams);
            this.tpFC.Controls.Add(this.txtDocxTemplFilename);
            this.tpFC.Controls.Add(this.label23);
            this.tpFC.Controls.Add(this.txtDocxTemplDir);
            this.tpFC.Controls.Add(this.label22);
            this.tpFC.Controls.Add(this.txtVersionDate);
            this.tpFC.Controls.Add(this.label21);
            this.tpFC.Controls.Add(this.txtFCProducer);
            this.tpFC.Controls.Add(this.txtFCNote);
            this.tpFC.Controls.Add(this.txtFCKatalog);
            this.tpFC.Controls.Add(this.label19);
            this.tpFC.Controls.Add(this.label18);
            this.tpFC.Controls.Add(this.label16);
            this.tpFC.Controls.Add(this.label20);
            this.tpFC.Controls.Add(this.cbFormat);
            this.tpFC.Location = new System.Drawing.Point(4, 25);
            this.tpFC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpFC.Name = "tpFC";
            this.tpFC.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tpFC.Size = new System.Drawing.Size(689, 421);
            this.tpFC.TabIndex = 2;
            this.tpFC.Text = "FeatureCatalogue";
            this.tpFC.UseVisualStyleBackColor = true;
            this.tpFC.Click += new System.EventHandler(this.tpFC_Click);
            // 
            // txtFeatureTerm
            // 
            this.txtFeatureTerm.Location = new System.Drawing.Point(116, 364);
            this.txtFeatureTerm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFeatureTerm.Name = "txtFeatureTerm";
            this.txtFeatureTerm.Size = new System.Drawing.Size(547, 22);
            this.txtFeatureTerm.TabIndex = 63;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(7, 364);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(89, 17);
            this.label25.TabIndex = 64;
            this.label25.Text = "Feature term";
            // 
            // chIncludeTitle
            // 
            this.chIncludeTitle.AutoSize = true;
            this.chIncludeTitle.Location = new System.Drawing.Point(116, 336);
            this.chIncludeTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chIncludeTitle.Name = "chIncludeTitle";
            this.chIncludeTitle.Size = new System.Drawing.Size(101, 21);
            this.chIncludeTitle.TabIndex = 62;
            this.chIncludeTitle.Text = "Include title";
            this.chIncludeTitle.UseVisualStyleBackColor = true;
            // 
            // chIncludeVoidable
            // 
            this.chIncludeVoidable.AutoSize = true;
            this.chIncludeVoidable.Location = new System.Drawing.Point(116, 308);
            this.chIncludeVoidable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chIncludeVoidable.Name = "chIncludeVoidable";
            this.chIncludeVoidable.Size = new System.Drawing.Size(132, 21);
            this.chIncludeVoidable.TabIndex = 61;
            this.chIncludeVoidable.Text = "Include voidable";
            this.chIncludeVoidable.UseVisualStyleBackColor = true;
            // 
            // txtFCName2
            // 
            this.txtFCName2.Enabled = false;
            this.txtFCName2.Location = new System.Drawing.Point(116, 55);
            this.txtFCName2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFCName2.Name = "txtFCName2";
            this.txtFCName2.Size = new System.Drawing.Size(547, 22);
            this.txtFCName2.TabIndex = 59;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(9, 55);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(45, 17);
            this.label24.TabIndex = 60;
            this.label24.Text = "Name";
            // 
            // chIncludeDiagrams
            // 
            this.chIncludeDiagrams.AutoSize = true;
            this.chIncludeDiagrams.Checked = true;
            this.chIncludeDiagrams.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chIncludeDiagrams.Location = new System.Drawing.Point(116, 279);
            this.chIncludeDiagrams.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chIncludeDiagrams.Name = "chIncludeDiagrams";
            this.chIncludeDiagrams.Size = new System.Drawing.Size(137, 21);
            this.chIncludeDiagrams.TabIndex = 58;
            this.chIncludeDiagrams.Text = "Include diagrams";
            this.chIncludeDiagrams.UseVisualStyleBackColor = true;
            // 
            // txtDocxTemplFilename
            // 
            this.txtDocxTemplFilename.Location = new System.Drawing.Point(116, 247);
            this.txtDocxTemplFilename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDocxTemplFilename.Name = "txtDocxTemplFilename";
            this.txtDocxTemplFilename.Size = new System.Drawing.Size(547, 22);
            this.txtDocxTemplFilename.TabIndex = 56;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(7, 247);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(108, 17);
            this.label23.TabIndex = 57;
            this.label23.Text = "Templ. filename";
            // 
            // txtDocxTemplDir
            // 
            this.txtDocxTemplDir.Location = new System.Drawing.Point(116, 215);
            this.txtDocxTemplDir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDocxTemplDir.Name = "txtDocxTemplDir";
            this.txtDocxTemplDir.Size = new System.Drawing.Size(547, 22);
            this.txtDocxTemplDir.TabIndex = 54;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(7, 215);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(110, 17);
            this.label22.TabIndex = 55;
            this.label22.Text = "Templ. directory";
            // 
            // txtVersionDate
            // 
            this.txtVersionDate.Location = new System.Drawing.Point(116, 183);
            this.txtVersionDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVersionDate.Name = "txtVersionDate";
            this.txtVersionDate.Size = new System.Drawing.Size(547, 22);
            this.txtVersionDate.TabIndex = 52;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 183);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(88, 17);
            this.label21.TabIndex = 53;
            this.label21.Text = "Version date";
            // 
            // txtFCProducer
            // 
            this.txtFCProducer.Location = new System.Drawing.Point(116, 151);
            this.txtFCProducer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFCProducer.Name = "txtFCProducer";
            this.txtFCProducer.Size = new System.Drawing.Size(547, 22);
            this.txtFCProducer.TabIndex = 50;
            this.txtFCProducer.TextChanged += new System.EventHandler(this.txtFCProducer_TextChanged);
            // 
            // txtFCNote
            // 
            this.txtFCNote.Location = new System.Drawing.Point(116, 119);
            this.txtFCNote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFCNote.Name = "txtFCNote";
            this.txtFCNote.Size = new System.Drawing.Size(547, 22);
            this.txtFCNote.TabIndex = 48;
            // 
            // txtFCKatalog
            // 
            this.txtFCKatalog.Enabled = false;
            this.txtFCKatalog.Location = new System.Drawing.Point(116, 87);
            this.txtFCKatalog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFCKatalog.Name = "txtFCKatalog";
            this.txtFCKatalog.Size = new System.Drawing.Size(547, 22);
            this.txtFCKatalog.TabIndex = 46;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 151);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(66, 17);
            this.label19.TabIndex = 51;
            this.label19.Text = "Producer";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 119);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(79, 17);
            this.label18.TabIndex = 49;
            this.label18.Text = "Description";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 87);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(143, 17);
            this.label16.TabIndex = 47;
            this.label16.Text = "Export featurecatalog";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(9, 26);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 17);
            this.label20.TabIndex = 30;
            this.label20.Text = "Format";
            // 
            // cbFormat
            // 
            this.cbFormat.FormattingEnabled = true;
            this.cbFormat.Items.AddRange(new object[] {
            "HTML",
            "DOCX",
            "DOCX-COMPACT",
            "FRAMEHTML"});
            this.cbFormat.Location = new System.Drawing.Point(116, 22);
            this.cbFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbFormat.Name = "cbFormat";
            this.cbFormat.Size = new System.Drawing.Size(160, 24);
            this.cbFormat.TabIndex = 29;
            this.cbFormat.Text = "HTML";
            // 
            // frmGML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 654);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.chfeatureCatalog);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnGML);
            this.Controls.Add(this.chMakeXsd);
            this.Controls.Add(this.chKodelister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGML";
            this.Text = "ShapeChange Add-In";
            this.Load += new System.EventHandler(this.frmGML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tpLogg.ResumeLayout(false);
            this.tpLogg.PerformLayout();
            this.tpOppsett.ResumeLayout(false);
            this.tpOppsett.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpFC.ResumeLayout(false);
            this.tpFC.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGML;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox chKodelister;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.CheckBox chMakeXsd;
        private System.Windows.Forms.CheckBox chfeatureCatalog;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpOppsett;
        private System.Windows.Forms.CheckBox chEnums;
        private System.Windows.Forms.CheckBox chOCLConstraints;
        private System.Windows.Forms.CheckBox chSchematron;
        private System.Windows.Forms.CheckBox chDok;
        private System.Windows.Forms.TextBox txtExcelKatalog;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtKodelisterkatalog;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtXsdfil;
        private System.Windows.Forms.TextBox txtXsdKatalog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFCName;
        private System.Windows.Forms.TextBox txtEapfil;
        private System.Windows.Forms.TextBox txtTargetNamespace;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtXmlns;
        private System.Windows.Forms.TextBox txtEncoding;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tpLogg;
        private System.Windows.Forms.TextBox txtLogg;
        private System.Windows.Forms.Button btnLogg;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.ComboBox cbFormat;
        private System.Windows.Forms.TabPage tpFC;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtFCProducer;
        private System.Windows.Forms.TextBox txtFCNote;
        private System.Windows.Forms.TextBox txtFCKatalog;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtVersionDate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtDocxTemplDir;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox chIncludeDiagrams;
        private System.Windows.Forms.TextBox txtDocxTemplFilename;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox txtFCName2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtFeatureTerm;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.CheckBox chIncludeTitle;
        private System.Windows.Forms.CheckBox chIncludeVoidable;
        private System.Windows.Forms.TextBox txtShapechangeJar;
        private System.Windows.Forms.Label label26;
    }
}