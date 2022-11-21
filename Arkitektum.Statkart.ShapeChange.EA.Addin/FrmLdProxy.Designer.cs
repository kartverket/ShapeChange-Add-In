namespace Kartverket.ShapeChange.EA.Addin
{
    partial class FrmLdProxy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLdProxy));
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLdProxyServiceLabel = new System.Windows.Forms.TextBox();
            this.labelLdProxyServiceLabel = new System.Windows.Forms.Label();
            this.groupBoxCoordinates = new System.Windows.Forms.GroupBox();
            this.labelLdProxyTagEpsgCode = new System.Windows.Forms.Label();
            this.comboBoxLdProxyAxisOrder = new System.Windows.Forms.ComboBox();
            this.labelLdProxyAxisOrder = new System.Windows.Forms.Label();
            this.textBoxLdProxyEpsgCode = new System.Windows.Forms.TextBox();
            this.labelLdProxyEpsgCode = new System.Windows.Forms.Label();
            this.groupBoxLdProxyDatabase = new System.Windows.Forms.GroupBox();
            this.textBoxLdProxyDbObjectId = new System.Windows.Forms.TextBox();
            this.labelLdProxyDbObjectId = new System.Windows.Forms.Label();
            this.textBoxLdProxyDbPrimaryKey = new System.Windows.Forms.TextBox();
            this.labelLdProxyDbPrimaryKey = new System.Windows.Forms.Label();
            this.labelLdProxyDbPassword = new System.Windows.Forms.Label();
            this.textBoxLdProxyDbPassword = new System.Windows.Forms.TextBox();
            this.textBoxLdProxyDbUser = new System.Windows.Forms.TextBox();
            this.labelLdProxyDbUser = new System.Windows.Forms.Label();
            this.textBoxLdProxyDbHost = new System.Windows.Forms.TextBox();
            this.labelLdProxyDbHost = new System.Windows.Forms.Label();
            this.textBoxLdproxyDbName = new System.Windows.Forms.TextBox();
            this.labelLdproxyDbName = new System.Windows.Forms.Label();
            this.textBoxPropsOutputDirectory = new System.Windows.Forms.TextBox();
            this.labelPropsOutputDirectory = new System.Windows.Forms.Label();
            this.textBoxPropsFeatureCatalogueName = new System.Windows.Forms.TextBox();
            this.textBoxPropsEaProjectFile = new System.Windows.Forms.TextBox();
            this.labelPropsFeatureCatalogueName = new System.Windows.Forms.Label();
            this.labelPropsEaProjectFile = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.tabPageLog.SuspendLayout();
            this.tabPageProjectProps.SuspendLayout();
            this.groupBoxCoordinates.SuspendLayout();
            this.groupBoxLdProxyDatabase.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonTransform
            // 
            this.buttonTransform.Location = new System.Drawing.Point(862, 18);
            this.buttonTransform.Name = "buttonTransform";
            this.buttonTransform.Size = new System.Drawing.Size(95, 23);
            this.buttonTransform.TabIndex = 11;
            this.buttonTransform.Text = "Transform";
            this.buttonTransform.UseVisualStyleBackColor = true;
            this.buttonTransform.Click += new System.EventHandler(this.ButtonTransform_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 443);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(941, 23);
            this.progressBar.TabIndex = 1;
            this.progressBar.Visible = false;
            // 
            // buttonClose
            // 
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonClose.Location = new System.Drawing.Point(862, 47);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(95, 23);
            this.buttonClose.TabIndex = 12;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.Location = new System.Drawing.Point(862, 102);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(95, 23);
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
            this.buttonHelp.Location = new System.Drawing.Point(862, 410);
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
            this.tabPageLog.Size = new System.Drawing.Size(833, 399);
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
            this.textBoxLog.Size = new System.Drawing.Size(735, 298);
            this.textBoxLog.TabIndex = 0;
            // 
            // buttonLogOpenLog
            // 
            this.buttonLogOpenLog.Location = new System.Drawing.Point(638, 314);
            this.buttonLogOpenLog.Name = "buttonLogOpenLog";
            this.buttonLogOpenLog.Size = new System.Drawing.Size(104, 23);
            this.buttonLogOpenLog.TabIndex = 201;
            this.buttonLogOpenLog.Text = "Open logfile";
            this.buttonLogOpenLog.UseVisualStyleBackColor = true;
            this.buttonLogOpenLog.Click += new System.EventHandler(this.ButtonLog_Click);
            // 
            // buttonLogOpenResult
            // 
            this.buttonLogOpenResult.Location = new System.Drawing.Point(527, 314);
            this.buttonLogOpenResult.Name = "buttonLogOpenResult";
            this.buttonLogOpenResult.Size = new System.Drawing.Size(104, 23);
            this.buttonLogOpenResult.TabIndex = 200;
            this.buttonLogOpenResult.Text = "Open result";
            this.buttonLogOpenResult.UseVisualStyleBackColor = true;
            this.buttonLogOpenResult.Visible = false;
            // 
            // tabPageProjectProps
            // 
            this.tabPageProjectProps.Controls.Add(this.label1);
            this.tabPageProjectProps.Controls.Add(this.textBoxLdProxyServiceLabel);
            this.tabPageProjectProps.Controls.Add(this.labelLdProxyServiceLabel);
            this.tabPageProjectProps.Controls.Add(this.groupBoxCoordinates);
            this.tabPageProjectProps.Controls.Add(this.groupBoxLdProxyDatabase);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsOutputDirectory);
            this.tabPageProjectProps.Controls.Add(this.labelPropsOutputDirectory);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsFeatureCatalogueName);
            this.tabPageProjectProps.Controls.Add(this.textBoxPropsEaProjectFile);
            this.tabPageProjectProps.Controls.Add(this.labelPropsFeatureCatalogueName);
            this.tabPageProjectProps.Controls.Add(this.labelPropsEaProjectFile);
            this.tabPageProjectProps.Location = new System.Drawing.Point(4, 22);
            this.tabPageProjectProps.Name = "tabPageProjectProps";
            this.tabPageProjectProps.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProjectProps.Size = new System.Drawing.Size(833, 399);
            this.tabPageProjectProps.TabIndex = 0;
            this.tabPageProjectProps.Text = "Properties";
            this.tabPageProjectProps.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 13);
            this.label1.TabIndex = 1005;
            this.label1.Text = "tag: SOSI_presentasjonsnavn";
            // 
            // textBoxLdProxyServiceLabel
            // 
            this.textBoxLdProxyServiceLabel.Location = new System.Drawing.Point(96, 101);
            this.textBoxLdProxyServiceLabel.Name = "textBoxLdProxyServiceLabel";
            this.textBoxLdProxyServiceLabel.Size = new System.Drawing.Size(297, 20);
            this.textBoxLdProxyServiceLabel.TabIndex = 1002;
            this.textBoxLdProxyServiceLabel.Leave += new System.EventHandler(this.TextBoxLdProxyServiceLabel_Leave);
            // 
            // labelLdProxyServiceLabel
            // 
            this.labelLdProxyServiceLabel.AutoSize = true;
            this.labelLdProxyServiceLabel.Location = new System.Drawing.Point(14, 104);
            this.labelLdProxyServiceLabel.Name = "labelLdProxyServiceLabel";
            this.labelLdProxyServiceLabel.Size = new System.Drawing.Size(74, 13);
            this.labelLdProxyServiceLabel.TabIndex = 1003;
            this.labelLdProxyServiceLabel.Text = "Service Name";
            this.labelLdProxyServiceLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBoxCoordinates
            // 
            this.groupBoxCoordinates.Controls.Add(this.labelLdProxyTagEpsgCode);
            this.groupBoxCoordinates.Controls.Add(this.comboBoxLdProxyAxisOrder);
            this.groupBoxCoordinates.Controls.Add(this.labelLdProxyAxisOrder);
            this.groupBoxCoordinates.Controls.Add(this.textBoxLdProxyEpsgCode);
            this.groupBoxCoordinates.Controls.Add(this.labelLdProxyEpsgCode);
            this.groupBoxCoordinates.Location = new System.Drawing.Point(12, 149);
            this.groupBoxCoordinates.Name = "groupBoxCoordinates";
            this.groupBoxCoordinates.Size = new System.Drawing.Size(372, 74);
            this.groupBoxCoordinates.TabIndex = 1004;
            this.groupBoxCoordinates.TabStop = false;
            this.groupBoxCoordinates.Text = "Coordinate system";
            // 
            // labelLdProxyTagEpsgCode
            // 
            this.labelLdProxyTagEpsgCode.AutoSize = true;
            this.labelLdProxyTagEpsgCode.Location = new System.Drawing.Point(293, 24);
            this.labelLdProxyTagEpsgCode.Name = "labelLdProxyTagEpsgCode";
            this.labelLdProxyTagEpsgCode.Size = new System.Drawing.Size(76, 13);
            this.labelLdProxyTagEpsgCode.TabIndex = 999;
            this.labelLdProxyTagEpsgCode.Text = "tag: epsgCode";
            // 
            // comboBoxLdProxyAxisOrder
            // 
            this.comboBoxLdProxyAxisOrder.FormattingEnabled = true;
            this.comboBoxLdProxyAxisOrder.Items.AddRange(new object[] {
            "LON_LAT",
            "LAT_LON"});
            this.comboBoxLdProxyAxisOrder.Location = new System.Drawing.Point(84, 46);
            this.comboBoxLdProxyAxisOrder.Name = "comboBoxLdProxyAxisOrder";
            this.comboBoxLdProxyAxisOrder.Size = new System.Drawing.Size(190, 21);
            this.comboBoxLdProxyAxisOrder.TabIndex = 404;
            this.comboBoxLdProxyAxisOrder.Text = "LON_LAT";
            // 
            // labelLdProxyAxisOrder
            // 
            this.labelLdProxyAxisOrder.AutoSize = true;
            this.labelLdProxyAxisOrder.Location = new System.Drawing.Point(25, 50);
            this.labelLdProxyAxisOrder.Name = "labelLdProxyAxisOrder";
            this.labelLdProxyAxisOrder.Size = new System.Drawing.Size(53, 13);
            this.labelLdProxyAxisOrder.TabIndex = 403;
            this.labelLdProxyAxisOrder.Text = "Axis order";
            // 
            // textBoxLdProxyEpsgCode
            // 
            this.textBoxLdProxyEpsgCode.Location = new System.Drawing.Point(84, 21);
            this.textBoxLdProxyEpsgCode.Name = "textBoxLdProxyEpsgCode";
            this.textBoxLdProxyEpsgCode.Size = new System.Drawing.Size(190, 20);
            this.textBoxLdProxyEpsgCode.TabIndex = 402;
            this.textBoxLdProxyEpsgCode.Leave += new System.EventHandler(this.TextBoxLdProxyEpsgCode_Leave);
            // 
            // labelLdProxyEpsgCode
            // 
            this.labelLdProxyEpsgCode.AutoSize = true;
            this.labelLdProxyEpsgCode.Location = new System.Drawing.Point(15, 24);
            this.labelLdProxyEpsgCode.Name = "labelLdProxyEpsgCode";
            this.labelLdProxyEpsgCode.Size = new System.Drawing.Size(63, 13);
            this.labelLdProxyEpsgCode.TabIndex = 401;
            this.labelLdProxyEpsgCode.Text = "EPSG code";
            // 
            // groupBoxLdProxyDatabase
            // 
            this.groupBoxLdProxyDatabase.Controls.Add(this.textBoxLdProxyDbObjectId);
            this.groupBoxLdProxyDatabase.Controls.Add(this.labelLdProxyDbObjectId);
            this.groupBoxLdProxyDatabase.Controls.Add(this.textBoxLdProxyDbPrimaryKey);
            this.groupBoxLdProxyDatabase.Controls.Add(this.labelLdProxyDbPrimaryKey);
            this.groupBoxLdProxyDatabase.Controls.Add(this.labelLdProxyDbPassword);
            this.groupBoxLdProxyDatabase.Controls.Add(this.textBoxLdProxyDbPassword);
            this.groupBoxLdProxyDatabase.Controls.Add(this.textBoxLdProxyDbUser);
            this.groupBoxLdProxyDatabase.Controls.Add(this.labelLdProxyDbUser);
            this.groupBoxLdProxyDatabase.Controls.Add(this.textBoxLdProxyDbHost);
            this.groupBoxLdProxyDatabase.Controls.Add(this.labelLdProxyDbHost);
            this.groupBoxLdProxyDatabase.Controls.Add(this.textBoxLdproxyDbName);
            this.groupBoxLdProxyDatabase.Controls.Add(this.labelLdproxyDbName);
            this.groupBoxLdProxyDatabase.Location = new System.Drawing.Point(390, 149);
            this.groupBoxLdProxyDatabase.Name = "groupBoxLdProxyDatabase";
            this.groupBoxLdProxyDatabase.Size = new System.Drawing.Size(298, 189);
            this.groupBoxLdProxyDatabase.TabIndex = 1001;
            this.groupBoxLdProxyDatabase.TabStop = false;
            this.groupBoxLdProxyDatabase.Text = "Database settings";
            // 
            // textBoxLdProxyDbObjectId
            // 
            this.textBoxLdProxyDbObjectId.Location = new System.Drawing.Point(91, 148);
            this.textBoxLdProxyDbObjectId.Name = "textBoxLdProxyDbObjectId";
            this.textBoxLdProxyDbObjectId.Size = new System.Drawing.Size(190, 20);
            this.textBoxLdProxyDbObjectId.TabIndex = 212;
            this.textBoxLdProxyDbObjectId.Text = "lokalid";
            // 
            // labelLdProxyDbObjectId
            // 
            this.labelLdProxyDbObjectId.AutoSize = true;
            this.labelLdProxyDbObjectId.Location = new System.Drawing.Point(33, 151);
            this.labelLdProxyDbObjectId.Name = "labelLdProxyDbObjectId";
            this.labelLdProxyDbObjectId.Size = new System.Drawing.Size(52, 13);
            this.labelLdProxyDbObjectId.TabIndex = 211;
            this.labelLdProxyDbObjectId.Text = "Object ID";
            this.labelLdProxyDbObjectId.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxLdProxyDbPrimaryKey
            // 
            this.textBoxLdProxyDbPrimaryKey.Location = new System.Drawing.Point(91, 122);
            this.textBoxLdProxyDbPrimaryKey.Name = "textBoxLdProxyDbPrimaryKey";
            this.textBoxLdProxyDbPrimaryKey.Size = new System.Drawing.Size(190, 20);
            this.textBoxLdProxyDbPrimaryKey.TabIndex = 416;
            this.textBoxLdProxyDbPrimaryKey.Text = "objid";
            // 
            // labelLdProxyDbPrimaryKey
            // 
            this.labelLdProxyDbPrimaryKey.AutoSize = true;
            this.labelLdProxyDbPrimaryKey.Location = new System.Drawing.Point(23, 125);
            this.labelLdProxyDbPrimaryKey.Name = "labelLdProxyDbPrimaryKey";
            this.labelLdProxyDbPrimaryKey.Size = new System.Drawing.Size(62, 13);
            this.labelLdProxyDbPrimaryKey.TabIndex = 415;
            this.labelLdProxyDbPrimaryKey.Text = "Primary Key";
            this.labelLdProxyDbPrimaryKey.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelLdProxyDbPassword
            // 
            this.labelLdProxyDbPassword.AutoSize = true;
            this.labelLdProxyDbPassword.Location = new System.Drawing.Point(32, 99);
            this.labelLdProxyDbPassword.Name = "labelLdProxyDbPassword";
            this.labelLdProxyDbPassword.Size = new System.Drawing.Size(53, 13);
            this.labelLdProxyDbPassword.TabIndex = 413;
            this.labelLdProxyDbPassword.Text = "Password";
            this.labelLdProxyDbPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxLdProxyDbPassword
            // 
            this.textBoxLdProxyDbPassword.Location = new System.Drawing.Point(91, 96);
            this.textBoxLdProxyDbPassword.Name = "textBoxLdProxyDbPassword";
            this.textBoxLdProxyDbPassword.Size = new System.Drawing.Size(190, 20);
            this.textBoxLdProxyDbPassword.TabIndex = 414;
            // 
            // textBoxLdProxyDbUser
            // 
            this.textBoxLdProxyDbUser.Location = new System.Drawing.Point(91, 70);
            this.textBoxLdProxyDbUser.Name = "textBoxLdProxyDbUser";
            this.textBoxLdProxyDbUser.Size = new System.Drawing.Size(190, 20);
            this.textBoxLdProxyDbUser.TabIndex = 412;
            this.textBoxLdProxyDbUser.Text = "postgres";
            // 
            // labelLdProxyDbUser
            // 
            this.labelLdProxyDbUser.AutoSize = true;
            this.labelLdProxyDbUser.Location = new System.Drawing.Point(56, 73);
            this.labelLdProxyDbUser.Name = "labelLdProxyDbUser";
            this.labelLdProxyDbUser.Size = new System.Drawing.Size(29, 13);
            this.labelLdProxyDbUser.TabIndex = 411;
            this.labelLdProxyDbUser.Text = "User";
            this.labelLdProxyDbUser.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxLdProxyDbHost
            // 
            this.textBoxLdProxyDbHost.Location = new System.Drawing.Point(91, 18);
            this.textBoxLdProxyDbHost.Name = "textBoxLdProxyDbHost";
            this.textBoxLdProxyDbHost.Size = new System.Drawing.Size(190, 20);
            this.textBoxLdProxyDbHost.TabIndex = 406;
            this.textBoxLdProxyDbHost.Text = "localhost";
            // 
            // labelLdProxyDbHost
            // 
            this.labelLdProxyDbHost.AutoSize = true;
            this.labelLdProxyDbHost.Location = new System.Drawing.Point(30, 21);
            this.labelLdProxyDbHost.Name = "labelLdProxyDbHost";
            this.labelLdProxyDbHost.Size = new System.Drawing.Size(55, 13);
            this.labelLdProxyDbHost.TabIndex = 405;
            this.labelLdProxyDbHost.Text = "Hostname";
            this.labelLdProxyDbHost.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxLdproxyDbName
            // 
            this.textBoxLdproxyDbName.Location = new System.Drawing.Point(91, 44);
            this.textBoxLdproxyDbName.Name = "textBoxLdproxyDbName";
            this.textBoxLdproxyDbName.Size = new System.Drawing.Size(190, 20);
            this.textBoxLdproxyDbName.TabIndex = 410;
            // 
            // labelLdproxyDbName
            // 
            this.labelLdproxyDbName.AutoSize = true;
            this.labelLdproxyDbName.Location = new System.Drawing.Point(32, 47);
            this.labelLdproxyDbName.Name = "labelLdproxyDbName";
            this.labelLdproxyDbName.Size = new System.Drawing.Size(53, 13);
            this.labelLdproxyDbName.TabIndex = 409;
            this.labelLdproxyDbName.Text = "Database";
            this.labelLdproxyDbName.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBoxPropsOutputDirectory
            // 
            this.textBoxPropsOutputDirectory.Enabled = false;
            this.textBoxPropsOutputDirectory.Location = new System.Drawing.Point(96, 69);
            this.textBoxPropsOutputDirectory.Name = "textBoxPropsOutputDirectory";
            this.textBoxPropsOutputDirectory.Size = new System.Drawing.Size(728, 20);
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
            this.textBoxPropsFeatureCatalogueName.Location = new System.Drawing.Point(96, 37);
            this.textBoxPropsFeatureCatalogueName.Name = "textBoxPropsFeatureCatalogueName";
            this.textBoxPropsFeatureCatalogueName.Size = new System.Drawing.Size(297, 20);
            this.textBoxPropsFeatureCatalogueName.TabIndex = 104;
            // 
            // textBoxPropsEaProjectFile
            // 
            this.textBoxPropsEaProjectFile.AccessibleDescription = "Enterprise Architect Project File";
            this.textBoxPropsEaProjectFile.Enabled = false;
            this.textBoxPropsEaProjectFile.Location = new System.Drawing.Point(96, 9);
            this.textBoxPropsEaProjectFile.Name = "textBoxPropsEaProjectFile";
            this.textBoxPropsEaProjectFile.Size = new System.Drawing.Size(728, 20);
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageProjectProps);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(841, 425);
            this.tabControl.TabIndex = 10;
            // 
            // FrmLdProxy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonClose;
            this.ClientSize = new System.Drawing.Size(966, 475);
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
            this.Name = "FrmLdProxy";
            this.Text = "ShapeChange Add-In - LdProxy";
            this.Load += new System.EventHandler(this.FormGML_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.tabPageLog.ResumeLayout(false);
            this.tabPageLog.PerformLayout();
            this.tabPageProjectProps.ResumeLayout(false);
            this.tabPageProjectProps.PerformLayout();
            this.groupBoxCoordinates.ResumeLayout(false);
            this.groupBoxCoordinates.PerformLayout();
            this.groupBoxLdProxyDatabase.ResumeLayout(false);
            this.groupBoxLdProxyDatabase.PerformLayout();
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
        private System.Windows.Forms.Label labelPropsEaProjectFile;
        private System.Windows.Forms.Label labelPropsOutputDirectory;
        private System.Windows.Forms.Label labelPropsFeatureCatalogueName;
        private System.Windows.Forms.TextBox textBoxPropsEaProjectFile;
        private System.Windows.Forms.TextBox textBoxPropsFeatureCatalogueName;
        private System.Windows.Forms.TextBox textBoxPropsOutputDirectory;

        // Log tab
        private System.Windows.Forms.Button buttonLogOpenLog;
        private System.Windows.Forms.Button buttonLogOpenResult;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxLdProxyServiceLabel;
        private System.Windows.Forms.Label labelLdProxyServiceLabel;
        private System.Windows.Forms.GroupBox groupBoxCoordinates;
        private System.Windows.Forms.Label labelLdProxyTagEpsgCode;
        private System.Windows.Forms.ComboBox comboBoxLdProxyAxisOrder;
        private System.Windows.Forms.Label labelLdProxyAxisOrder;
        private System.Windows.Forms.TextBox textBoxLdProxyEpsgCode;
        private System.Windows.Forms.Label labelLdProxyEpsgCode;
        private System.Windows.Forms.GroupBox groupBoxLdProxyDatabase;
        private System.Windows.Forms.TextBox textBoxLdProxyDbPrimaryKey;
        private System.Windows.Forms.Label labelLdProxyDbPrimaryKey;
        private System.Windows.Forms.Label labelLdProxyDbPassword;
        private System.Windows.Forms.TextBox textBoxLdProxyDbPassword;
        private System.Windows.Forms.TextBox textBoxLdProxyDbUser;
        private System.Windows.Forms.Label labelLdProxyDbUser;
        private System.Windows.Forms.TextBox textBoxLdProxyDbHost;
        private System.Windows.Forms.Label labelLdProxyDbHost;
        private System.Windows.Forms.TextBox textBoxLdproxyDbName;
        private System.Windows.Forms.Label labelLdproxyDbName;
        private System.Windows.Forms.TextBox textBoxLdProxyDbObjectId;
        private System.Windows.Forms.Label labelLdProxyDbObjectId;
    }
}