namespace MsOrmCodeGen.Client
{
    partial class Manager
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manager));
			this.btnFileBrowseCode = new System.Windows.Forms.Button();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.lbSelectFile = new System.Windows.Forms.Label();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.tbObjectCodeFilePath = new System.Windows.Forms.TextBox();
			this.folderBrowserDialogDestination = new System.Windows.Forms.OpenFileDialog();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.cbTemplates = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbNameSpace = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.tbLinqXmlMappingFilePath = new System.Windows.Forms.TextBox();
			this.btnFileBrowseXml = new System.Windows.Forms.Button();
			this.fileBrowserDialogXmlDestination = new System.Windows.Forms.OpenFileDialog();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.pcProgressIndicator = new System.Windows.Forms.PictureBox();
			this.tbOutput = new System.Windows.Forms.TextBox();
			this.tcMain = new System.Windows.Forms.TabControl();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.lbEntities = new System.Windows.Forms.ListBox();
			this.lbConnectionString = new System.Windows.Forms.Label();
			this.tbServer = new System.Windows.Forms.TextBox();
			this.tbDatabase = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbUsername = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.cbConfigurationStores = new System.Windows.Forms.ComboBox();
			this.cbSaveAsNew = new System.Windows.Forms.CheckBox();
			this.lbLoadConfigurations = new System.Windows.Forms.Label();
			this.btnDelete = new System.Windows.Forms.Button();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.tbEntityMappingDestination = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.efFilesDestinationDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.btnEFFilesDestination = new System.Windows.Forms.Button();
			this.cbEntityProviders = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.menuStrip1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pcProgressIndicator)).BeginInit();
			this.tcMain.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnFileBrowseCode
			// 
			this.btnFileBrowseCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileBrowseCode.Location = new System.Drawing.Point(733, 34);
			this.btnFileBrowseCode.Name = "btnFileBrowseCode";
			this.btnFileBrowseCode.Size = new System.Drawing.Size(75, 23);
			this.btnFileBrowseCode.TabIndex = 4;
			this.btnFileBrowseCode.Text = "Browse";
			this.btnFileBrowseCode.UseVisualStyleBackColor = true;
			this.btnFileBrowseCode.Click += new System.EventHandler(this.btnFileBrowseCode_Click);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(820, 24);
			this.menuStrip1.TabIndex = 11;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// lbSelectFile
			// 
			this.lbSelectFile.AutoSize = true;
			this.lbSelectFile.Location = new System.Drawing.Point(341, 36);
			this.lbSelectFile.Name = "lbSelectFile";
			this.lbSelectFile.Size = new System.Drawing.Size(88, 13);
			this.lbSelectFile.TabIndex = 14;
			this.lbSelectFile.Text = "Code Destination";
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			// 
			// tbObjectCodeFilePath
			// 
			this.tbObjectCodeFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbObjectCodeFilePath.Location = new System.Drawing.Point(435, 34);
			this.tbObjectCodeFilePath.Name = "tbObjectCodeFilePath";
			this.tbObjectCodeFilePath.Size = new System.Drawing.Size(292, 20);
			this.tbObjectCodeFilePath.TabIndex = 3;
			this.tbObjectCodeFilePath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbObjectCodeFilePath_KeyUp);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGenerate.Location = new System.Drawing.Point(729, 162);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(75, 23);
			this.btnGenerate.TabIndex = 16;
			this.btnGenerate.TabStop = false;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.UseVisualStyleBackColor = true;
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// cbTemplates
			// 
			this.cbTemplates.FormattingEnabled = true;
			this.cbTemplates.Location = new System.Drawing.Point(435, 125);
			this.cbTemplates.Name = "cbTemplates";
			this.cbTemplates.Size = new System.Drawing.Size(164, 21);
			this.cbTemplates.TabIndex = 19;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(349, 126);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 13);
			this.label2.TabIndex = 20;
			this.label2.Text = "Code Template";
			// 
			// tbNameSpace
			// 
			this.tbNameSpace.Location = new System.Drawing.Point(435, 156);
			this.tbNameSpace.Name = "tbNameSpace";
			this.tbNameSpace.Size = new System.Drawing.Size(164, 20);
			this.tbNameSpace.TabIndex = 25;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(364, 159);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 26;
			this.label1.Text = "Namespace";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(328, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(103, 13);
			this.label3.TabIndex = 27;
			this.label3.Text = "Linq Xml Destination";
			// 
			// tbLinqXmlMappingFilePath
			// 
			this.tbLinqXmlMappingFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbLinqXmlMappingFilePath.Location = new System.Drawing.Point(435, 64);
			this.tbLinqXmlMappingFilePath.Name = "tbLinqXmlMappingFilePath";
			this.tbLinqXmlMappingFilePath.Size = new System.Drawing.Size(292, 20);
			this.tbLinqXmlMappingFilePath.TabIndex = 28;
			this.tbLinqXmlMappingFilePath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbLinqXmlMappingFilePath_KeyUp);
			// 
			// btnFileBrowseXml
			// 
			this.btnFileBrowseXml.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFileBrowseXml.Location = new System.Drawing.Point(733, 64);
			this.btnFileBrowseXml.Name = "btnFileBrowseXml";
			this.btnFileBrowseXml.Size = new System.Drawing.Size(75, 23);
			this.btnFileBrowseXml.TabIndex = 29;
			this.btnFileBrowseXml.Text = "Browse";
			this.btnFileBrowseXml.UseVisualStyleBackColor = true;
			this.btnFileBrowseXml.Click += new System.EventHandler(this.btnFileBrowseXml_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.pcProgressIndicator);
			this.tabPage1.Controls.Add(this.tbOutput);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(788, 258);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// pcProgressIndicator
			// 
			this.pcProgressIndicator.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.pcProgressIndicator.Image = ((System.Drawing.Image)(resources.GetObject("pcProgressIndicator.Image")));
			this.pcProgressIndicator.Location = new System.Drawing.Point(328, 109);
			this.pcProgressIndicator.Name = "pcProgressIndicator";
			this.pcProgressIndicator.Size = new System.Drawing.Size(100, 50);
			this.pcProgressIndicator.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pcProgressIndicator.TabIndex = 7;
			this.pcProgressIndicator.TabStop = false;
			this.pcProgressIndicator.Visible = false;
			// 
			// tbOutput
			// 
			this.tbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbOutput.Location = new System.Drawing.Point(-3, 0);
			this.tbOutput.Multiline = true;
			this.tbOutput.Name = "tbOutput";
			this.tbOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.tbOutput.Size = new System.Drawing.Size(788, 258);
			this.tbOutput.TabIndex = 6;
			// 
			// tcMain
			// 
			this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tcMain.Controls.Add(this.tabPage1);
			this.tcMain.Controls.Add(this.tabPage2);
			this.tcMain.Location = new System.Drawing.Point(12, 207);
			this.tcMain.Name = "tcMain";
			this.tcMain.SelectedIndex = 0;
			this.tcMain.Size = new System.Drawing.Size(796, 284);
			this.tcMain.TabIndex = 15;
			this.tcMain.Tag = "Log";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.lbEntities);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(788, 258);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// lbEntities
			// 
			this.lbEntities.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.lbEntities.FormattingEnabled = true;
			this.lbEntities.IntegralHeight = false;
			this.lbEntities.Location = new System.Drawing.Point(0, -2);
			this.lbEntities.Name = "lbEntities";
			this.lbEntities.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbEntities.Size = new System.Drawing.Size(788, 262);
			this.lbEntities.TabIndex = 6;
			// 
			// lbConnectionString
			// 
			this.lbConnectionString.AutoSize = true;
			this.lbConnectionString.Location = new System.Drawing.Point(49, 41);
			this.lbConnectionString.Name = "lbConnectionString";
			this.lbConnectionString.Size = new System.Drawing.Size(38, 13);
			this.lbConnectionString.TabIndex = 30;
			this.lbConnectionString.Text = "Server";
			// 
			// tbServer
			// 
			this.tbServer.Location = new System.Drawing.Point(93, 36);
			this.tbServer.Name = "tbServer";
			this.tbServer.Size = new System.Drawing.Size(164, 20);
			this.tbServer.TabIndex = 26;
			this.tbServer.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbServer_KeyUp);
			// 
			// tbDatabase
			// 
			this.tbDatabase.Location = new System.Drawing.Point(93, 64);
			this.tbDatabase.Name = "tbDatabase";
			this.tbDatabase.Size = new System.Drawing.Size(164, 20);
			this.tbDatabase.TabIndex = 27;
			this.tbDatabase.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbDatabase_KeyUp);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(34, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(53, 13);
			this.label4.TabIndex = 31;
			this.label4.Text = "Database";
			// 
			// tbUsername
			// 
			this.tbUsername.Location = new System.Drawing.Point(93, 95);
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.Size = new System.Drawing.Size(164, 20);
			this.tbUsername.TabIndex = 27;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(32, 97);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 31;
			this.label5.Text = "Username";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(34, 129);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(53, 13);
			this.label6.TabIndex = 32;
			this.label6.Text = "Password";
			// 
			// tbPassword
			// 
			this.tbPassword.Location = new System.Drawing.Point(93, 126);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(164, 20);
			this.tbPassword.TabIndex = 28;
			// 
			// cbConfigurationStores
			// 
			this.cbConfigurationStores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.cbConfigurationStores.FormattingEnabled = true;
			this.cbConfigurationStores.Location = new System.Drawing.Point(644, 5);
			this.cbConfigurationStores.Name = "cbConfigurationStores";
			this.cbConfigurationStores.Size = new System.Drawing.Size(164, 21);
			this.cbConfigurationStores.TabIndex = 20;
			this.cbConfigurationStores.SelectedIndexChanged += new System.EventHandler(this.cbConfigurationStores_SelectedIndexChanged);
			// 
			// cbSaveAsNew
			// 
			this.cbSaveAsNew.AutoSize = true;
			this.cbSaveAsNew.Location = new System.Drawing.Point(331, 193);
			this.cbSaveAsNew.Name = "cbSaveAsNew";
			this.cbSaveAsNew.Size = new System.Drawing.Size(147, 17);
			this.cbSaveAsNew.TabIndex = 33;
			this.cbSaveAsNew.Text = "Create New Configuration";
			this.cbSaveAsNew.UseVisualStyleBackColor = true;
			// 
			// lbLoadConfigurations
			// 
			this.lbLoadConfigurations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lbLoadConfigurations.AutoSize = true;
			this.lbLoadConfigurations.Location = new System.Drawing.Point(524, 8);
			this.lbLoadConfigurations.Name = "lbLoadConfigurations";
			this.lbLoadConfigurations.Size = new System.Drawing.Size(108, 13);
			this.lbLoadConfigurations.TabIndex = 34;
			this.lbLoadConfigurations.Text = "Saved Configurations";
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(484, 189);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(115, 23);
			this.btnDelete.TabIndex = 35;
			this.btnDelete.Text = "Delete Configuration";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "MsOrmCodeGen";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// tbEntityMappingDestination
			// 
			this.tbEntityMappingDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.tbEntityMappingDestination.Location = new System.Drawing.Point(435, 95);
			this.tbEntityMappingDestination.Name = "tbEntityMappingDestination";
			this.tbEntityMappingDestination.Size = new System.Drawing.Size(292, 20);
			this.tbEntityMappingDestination.TabIndex = 36;
			this.tbEntityMappingDestination.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbEntityMappingDestination_KeyUp);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(328, 97);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(100, 13);
			this.label7.TabIndex = 37;
			this.label7.Text = "EF Files Destination";
			// 
			// btnEFFilesDestination
			// 
			this.btnEFFilesDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEFFilesDestination.Location = new System.Drawing.Point(733, 93);
			this.btnEFFilesDestination.Name = "btnEFFilesDestination";
			this.btnEFFilesDestination.Size = new System.Drawing.Size(75, 23);
			this.btnEFFilesDestination.TabIndex = 38;
			this.btnEFFilesDestination.Text = "Browse";
			this.btnEFFilesDestination.UseVisualStyleBackColor = true;
			this.btnEFFilesDestination.Click += new System.EventHandler(this.btnEFFilesDestination_Click);
			// 
			// cbEntityProviders
			// 
			this.cbEntityProviders.FormattingEnabled = true;
			this.cbEntityProviders.Location = new System.Drawing.Point(93, 156);
			this.cbEntityProviders.Name = "cbEntityProviders";
			this.cbEntityProviders.Size = new System.Drawing.Size(164, 21);
			this.cbEntityProviders.TabIndex = 39;
			this.cbEntityProviders.SelectedIndexChanged += new System.EventHandler(this.cbEntityProviders_SelectedIndexChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 159);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 13);
			this.label8.TabIndex = 40;
			this.label8.Text = "Entity Provider";
			// 
			// Manager
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(820, 503);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.cbEntityProviders);
			this.Controls.Add(this.btnEFFilesDestination);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.tbEntityMappingDestination);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.lbLoadConfigurations);
			this.Controls.Add(this.cbSaveAsNew);
			this.Controls.Add(this.cbConfigurationStores);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbUsername);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbDatabase);
			this.Controls.Add(this.tbServer);
			this.Controls.Add(this.lbConnectionString);
			this.Controls.Add(this.btnFileBrowseXml);
			this.Controls.Add(this.tbLinqXmlMappingFilePath);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbNameSpace);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbTemplates);
			this.Controls.Add(this.btnGenerate);
			this.Controls.Add(this.menuStrip1);
			this.Controls.Add(this.tcMain);
			this.Controls.Add(this.lbSelectFile);
			this.Controls.Add(this.btnFileBrowseCode);
			this.Controls.Add(this.tbObjectCodeFilePath);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "Manager";
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
			this.Text = "MsOrmCodeGen";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Manager_FormClosing);
			this.Resize += new System.EventHandler(this.Manager_Resize);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pcProgressIndicator)).EndInit();
			this.tcMain.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.TextBox tbObjectCodeFilePath;
		private System.Windows.Forms.Button btnFileBrowseCode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Label lbSelectFile;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ComboBox cbTemplates;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbNameSpace;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbLinqXmlMappingFilePath;
		private System.Windows.Forms.Button btnFileBrowseXml;
		private System.Windows.Forms.OpenFileDialog folderBrowserDialogDestination;
		private System.Windows.Forms.OpenFileDialog fileBrowserDialogXmlDestination;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox tbOutput;
		private System.Windows.Forms.TabControl tcMain;
		private System.Windows.Forms.Label lbConnectionString;
		private System.Windows.Forms.TextBox tbServer;
		private System.Windows.Forms.TextBox tbDatabase;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbUsername;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.ComboBox cbConfigurationStores;
		private System.Windows.Forms.CheckBox cbSaveAsNew;
		private System.Windows.Forms.Label lbLoadConfigurations;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.TextBox tbEntityMappingDestination;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.FolderBrowserDialog efFilesDestinationDialog;
		private System.Windows.Forms.Button btnEFFilesDestination;
		private System.Windows.Forms.ComboBox cbEntityProviders;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.ListBox lbEntities;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.PictureBox pcProgressIndicator;


    }
}


