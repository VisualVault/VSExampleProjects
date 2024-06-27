using VisualVault.Forms.Import.UI;

namespace VisualVault.Forms.Import
{
    partial class ImportFormData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportFormData));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFetchTemplates = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnFetchDashboards = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSelectExportFile = new System.Windows.Forms.Button();
            this.btnFetchDeleteTemplates = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnFetchCreateUserTemplates = new System.Windows.Forms.Button();
            this.btnCreateUserAccounts = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearErrorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.progressBar1 = new VisualVault.Forms.Import.UI.TextProgressBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.uxAuthDbAlias = new System.Windows.Forms.TextBox();
            this.uxAuthCustomerAlias = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cboProfiles = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.uxAuthStatus = new System.Windows.Forms.Label();
            this.uxAuthCmdLogin = new System.Windows.Forms.Button();
            this.uxAuthPassword = new System.Windows.Forms.TextBox();
            this.uxAuthUserID = new System.Windows.Forms.TextBox();
            this.uxAuthServerUrl = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDateTimeFormat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.chkAllowUpdate = new System.Windows.Forms.CheckBox();
            this.chkCsvLinesQuoted = new System.Windows.Forms.CheckBox();
            this.chkCsvHeadersQuoted = new System.Windows.Forms.CheckBox();
            this.txtDelimeter = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboFormTemplates = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cboFormDashboards = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtExportFilePath = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cboDeleteFormTemplates = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.label18 = new System.Windows.Forms.Label();
            this.txtCreateUserApiFilter = new System.Windows.Forms.TextBox();
            this.cboCreateUserSiteField = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cboCreateUserEmailField = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboCreateUserUserIdField = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboCreateUserFormTemplates = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.btnLoadFolders = new System.Windows.Forms.Button();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.listViewSecurityMembers = new System.Windows.Forms.ListView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog1FileOk);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1DoWork);
            // 
            // btnFetchTemplates
            // 
            this.btnFetchTemplates.Location = new System.Drawing.Point(438, 47);
            this.btnFetchTemplates.Name = "btnFetchTemplates";
            this.btnFetchTemplates.Size = new System.Drawing.Size(24, 23);
            this.btnFetchTemplates.TabIndex = 18;
            this.btnFetchTemplates.Text = "...";
            this.toolTip1.SetToolTip(this.btnFetchTemplates, "Fetch form templates");
            this.btnFetchTemplates.UseVisualStyleBackColor = true;
            this.btnFetchTemplates.Click += new System.EventHandler(this.BtnFetchTemplatesClick);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(392, 317);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(70, 23);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Start Import";
            this.toolTip1.SetToolTip(this.btnImport, "Begin Form Import Process");
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImportClick);
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(438, 99);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(24, 23);
            this.btnSelectFile.TabIndex = 10;
            this.btnSelectFile.Text = "...";
            this.toolTip1.SetToolTip(this.btnSelectFile, "Browse for CSV File");
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFileClick);
            // 
            // btnFetchDashboards
            // 
            this.btnFetchDashboards.Location = new System.Drawing.Point(409, 66);
            this.btnFetchDashboards.Name = "btnFetchDashboards";
            this.btnFetchDashboards.Size = new System.Drawing.Size(24, 23);
            this.btnFetchDashboards.TabIndex = 28;
            this.btnFetchDashboards.Text = "...";
            this.toolTip1.SetToolTip(this.btnFetchDashboards, "Fetch form templates");
            this.btnFetchDashboards.UseVisualStyleBackColor = true;
            this.btnFetchDashboards.Click += new System.EventHandler(this.BtnFetchDashboardsClick);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(333, 202);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 23);
            this.btnExport.TabIndex = 23;
            this.btnExport.Text = "Start Export";
            this.toolTip1.SetToolTip(this.btnExport, "Begin Form Import Process");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExportClick);
            // 
            // btnSelectExportFile
            // 
            this.btnSelectExportFile.Location = new System.Drawing.Point(409, 118);
            this.btnSelectExportFile.Name = "btnSelectExportFile";
            this.btnSelectExportFile.Size = new System.Drawing.Size(24, 23);
            this.btnSelectExportFile.TabIndex = 21;
            this.btnSelectExportFile.Text = "...";
            this.toolTip1.SetToolTip(this.btnSelectExportFile, "Browse for CSV File");
            this.btnSelectExportFile.UseVisualStyleBackColor = true;
            this.btnSelectExportFile.Click += new System.EventHandler(this.BtnSelectExportFileClick);
            // 
            // btnFetchDeleteTemplates
            // 
            this.btnFetchDeleteTemplates.Location = new System.Drawing.Point(430, 51);
            this.btnFetchDeleteTemplates.Name = "btnFetchDeleteTemplates";
            this.btnFetchDeleteTemplates.Size = new System.Drawing.Size(24, 23);
            this.btnFetchDeleteTemplates.TabIndex = 37;
            this.btnFetchDeleteTemplates.Text = "...";
            this.toolTip1.SetToolTip(this.btnFetchDeleteTemplates, "Fetch form templates");
            this.btnFetchDeleteTemplates.UseVisualStyleBackColor = true;
            this.btnFetchDeleteTemplates.Click += new System.EventHandler(this.btnFetchDeleteTemplates_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(309, 107);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(145, 23);
            this.btnDeleteAll.TabIndex = 34;
            this.btnDeleteAll.Text = "Delete All Form Instances";
            this.toolTip1.SetToolTip(this.btnDeleteAll, "Begin Form Import Process");
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.BtnDeleteAllClick);
            // 
            // btnFetchCreateUserTemplates
            // 
            this.btnFetchCreateUserTemplates.Location = new System.Drawing.Point(408, 47);
            this.btnFetchCreateUserTemplates.Name = "btnFetchCreateUserTemplates";
            this.btnFetchCreateUserTemplates.Size = new System.Drawing.Size(24, 23);
            this.btnFetchCreateUserTemplates.TabIndex = 41;
            this.btnFetchCreateUserTemplates.Text = "...";
            this.toolTip1.SetToolTip(this.btnFetchCreateUserTemplates, "Fetch form templates");
            this.btnFetchCreateUserTemplates.UseVisualStyleBackColor = true;
            this.btnFetchCreateUserTemplates.Click += new System.EventHandler(this.btnFetchCreateUserTemplates_Click);
            // 
            // btnCreateUserAccounts
            // 
            this.btnCreateUserAccounts.Location = new System.Drawing.Point(321, 348);
            this.btnCreateUserAccounts.Name = "btnCreateUserAccounts";
            this.btnCreateUserAccounts.Size = new System.Drawing.Size(117, 23);
            this.btnCreateUserAccounts.TabIndex = 38;
            this.btnCreateUserAccounts.Text = "Create User Accounts";
            this.toolTip1.SetToolTip(this.btnCreateUserAccounts, "Create User Accounts");
            this.btnCreateUserAccounts.UseVisualStyleBackColor = true;
            this.btnCreateUserAccounts.Click += new System.EventHandler(this.btnCreateUserAccounts_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.profilesToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.clearErrorsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(544, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "‎File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem});
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(111, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // clearErrorsToolStripMenuItem
            // 
            this.clearErrorsToolStripMenuItem.Name = "clearErrorsToolStripMenuItem";
            this.clearErrorsToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.clearErrorsToolStripMenuItem.Text = "Clear Errors";
            this.clearErrorsToolStripMenuItem.Click += new System.EventHandler(this.clearErrorsToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.progressBar1);
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2Collapsed = true;
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(544, 421);
            this.splitContainer1.SplitterDistance = 1088;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 19;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.progressBar1.Location = new System.Drawing.Point(0, 391);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(544, 30);
            this.progressBar1.TabIndex = 19;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            //this.tabControl1.Controls.Add(this.tabPage5); //hide delete forms tab
            //this.tabControl1.Controls.Add(this.tabPage6); //hide create users tab
            //this.tabControl1.Controls.Add(this.tabPage7); //hide folder security tab (not completed)
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 421);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage1.Size = new System.Drawing.Size(536, 395);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox11.BackColor = System.Drawing.Color.White;
            this.groupBox11.Controls.Add(this.lblVersion);
            this.groupBox11.Controls.Add(this.uxAuthDbAlias);
            this.groupBox11.Controls.Add(this.uxAuthCustomerAlias);
            this.groupBox11.Controls.Add(this.label11);
            this.groupBox11.Controls.Add(this.label12);
            this.groupBox11.Controls.Add(this.cboProfiles);
            this.groupBox11.Controls.Add(this.label5);
            this.groupBox11.Controls.Add(this.label20);
            this.groupBox11.Controls.Add(this.uxAuthStatus);
            this.groupBox11.Controls.Add(this.uxAuthCmdLogin);
            this.groupBox11.Controls.Add(this.uxAuthPassword);
            this.groupBox11.Controls.Add(this.uxAuthUserID);
            this.groupBox11.Controls.Add(this.uxAuthServerUrl);
            this.groupBox11.Controls.Add(this.label26);
            this.groupBox11.Controls.Add(this.label27);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Location = new System.Drawing.Point(48, 47);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(387, 263);
            this.groupBox11.TabIndex = 10;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Login to VisualVault";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(13, 246);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(48, 13);
            this.lblVersion.TabIndex = 22;
            this.lblVersion.Text = "Version: ";
            // 
            // uxAuthDbAlias
            // 
            this.uxAuthDbAlias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthDbAlias.Location = new System.Drawing.Point(70, 110);
            this.uxAuthDbAlias.Name = "uxAuthDbAlias";
            this.uxAuthDbAlias.Size = new System.Drawing.Size(300, 20);
            this.uxAuthDbAlias.TabIndex = 20;
            // 
            // uxAuthCustomerAlias
            // 
            this.uxAuthCustomerAlias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthCustomerAlias.Location = new System.Drawing.Point(70, 81);
            this.uxAuthCustomerAlias.Name = "uxAuthCustomerAlias";
            this.uxAuthCustomerAlias.Size = new System.Drawing.Size(300, 20);
            this.uxAuthCustomerAlias.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 114);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Database:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 85);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Customer:";
            // 
            // cboProfiles
            // 
            this.cboProfiles.FormattingEnabled = true;
            this.cboProfiles.Location = new System.Drawing.Point(70, 24);
            this.cboProfiles.Name = "cboProfiles";
            this.cboProfiles.Size = new System.Drawing.Size(297, 21);
            this.cboProfiles.TabIndex = 17;
            this.cboProfiles.SelectedIndexChanged += new System.EventHandler(this.CboProfilesSelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Profile:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(23, 211);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "Status:";
            // 
            // uxAuthStatus
            // 
            this.uxAuthStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.uxAuthStatus.Location = new System.Drawing.Point(67, 205);
            this.uxAuthStatus.Name = "uxAuthStatus";
            this.uxAuthStatus.Size = new System.Drawing.Size(303, 25);
            this.uxAuthStatus.TabIndex = 12;
            this.uxAuthStatus.Text = "Not Logged In";
            this.uxAuthStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxAuthCmdLogin
            // 
            this.uxAuthCmdLogin.Location = new System.Drawing.Point(292, 233);
            this.uxAuthCmdLogin.Name = "uxAuthCmdLogin";
            this.uxAuthCmdLogin.Size = new System.Drawing.Size(75, 23);
            this.uxAuthCmdLogin.TabIndex = 4;
            this.uxAuthCmdLogin.Text = "Login";
            this.uxAuthCmdLogin.UseVisualStyleBackColor = true;
            this.uxAuthCmdLogin.Click += new System.EventHandler(this.BtnLoginClick);
            // 
            // uxAuthPassword
            // 
            this.uxAuthPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthPassword.Location = new System.Drawing.Point(70, 167);
            this.uxAuthPassword.Name = "uxAuthPassword";
            this.uxAuthPassword.PasswordChar = '*';
            this.uxAuthPassword.Size = new System.Drawing.Size(300, 20);
            this.uxAuthPassword.TabIndex = 3;
            // 
            // uxAuthUserID
            // 
            this.uxAuthUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthUserID.Location = new System.Drawing.Point(70, 138);
            this.uxAuthUserID.Name = "uxAuthUserID";
            this.uxAuthUserID.Size = new System.Drawing.Size(300, 20);
            this.uxAuthUserID.TabIndex = 2;
            // 
            // uxAuthServerUrl
            // 
            this.uxAuthServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthServerUrl.Location = new System.Drawing.Point(70, 53);
            this.uxAuthServerUrl.Name = "uxAuthServerUrl";
            this.uxAuthServerUrl.Size = new System.Drawing.Size(300, 20);
            this.uxAuthServerUrl.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(5, 172);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 13);
            this.label26.TabIndex = 3;
            this.label26.Text = "Password:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(17, 143);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 13);
            this.label27.TabIndex = 2;
            this.label27.Text = "User ID:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(4, 56);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(57, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Server Url:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.txtDateTimeFormat);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.chkAllowUpdate);
            this.tabPage2.Controls.Add(this.chkCsvLinesQuoted);
            this.tabPage2.Controls.Add(this.chkCsvHeadersQuoted);
            this.tabPage2.Controls.Add(this.txtDelimeter);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.btnFetchTemplates);
            this.tabPage2.Controls.Add(this.cboFormTemplates);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.btnImport);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnSelectFile);
            this.tabPage2.Controls.Add(this.txtFilePath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage2.Size = new System.Drawing.Size(536, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import Form Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(76, 256);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(175, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "H=(0-23),h=(0-12),m=(0-59),s=(0-59)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(76, 237);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(256, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "d=(1-31), dd=(01-31), M=(1-12), MM=(01-12), yy, yyyy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(76, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 30;
            // 
            // txtDateTimeFormat
            // 
            this.txtDateTimeFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTimeFormat.Location = new System.Drawing.Point(78, 209);
            this.txtDateTimeFormat.Name = "txtDateTimeFormat";
            this.txtDateTimeFormat.Size = new System.Drawing.Size(384, 23);
            this.txtDateTimeFormat.TabIndex = 29;
            this.txtDateTimeFormat.Text = "d-MM-yyyy h:mm:ss,d/MM/yyyy,dd-MM-YYYY h:mm:ss";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(290, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Source Date-Time Formats (comma separated list of formats)";
            // 
            // chkAllowUpdate
            // 
            this.chkAllowUpdate.AutoSize = true;
            this.chkAllowUpdate.Location = new System.Drawing.Point(78, 325);
            this.chkAllowUpdate.Name = "chkAllowUpdate";
            this.chkAllowUpdate.Size = new System.Drawing.Size(309, 17);
            this.chkAllowUpdate.TabIndex = 27;
            this.chkAllowUpdate.Text = "First column contains Form Id (used to update existing forms)";
            this.chkAllowUpdate.UseVisualStyleBackColor = true;
            // 
            // chkCsvLinesQuoted
            // 
            this.chkCsvLinesQuoted.AutoSize = true;
            this.chkCsvLinesQuoted.Location = new System.Drawing.Point(78, 302);
            this.chkCsvLinesQuoted.Name = "chkCsvLinesQuoted";
            this.chkCsvLinesQuoted.Size = new System.Drawing.Size(184, 17);
            this.chkCsvLinesQuoted.TabIndex = 26;
            this.chkCsvLinesQuoted.Text = "CSV Line Item Values are Quoted";
            this.chkCsvLinesQuoted.UseVisualStyleBackColor = true;
            // 
            // chkCsvHeadersQuoted
            // 
            this.chkCsvHeadersQuoted.AutoSize = true;
            this.chkCsvHeadersQuoted.Location = new System.Drawing.Point(78, 277);
            this.chkCsvHeadersQuoted.Name = "chkCsvHeadersQuoted";
            this.chkCsvHeadersQuoted.Size = new System.Drawing.Size(176, 17);
            this.chkCsvHeadersQuoted.TabIndex = 25;
            this.chkCsvHeadersQuoted.Text = "CSV Header Values are Quoted";
            this.chkCsvHeadersQuoted.UseVisualStyleBackColor = true;
            // 
            // txtDelimeter
            // 
            this.txtDelimeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelimeter.Location = new System.Drawing.Point(78, 153);
            this.txtDelimeter.Name = "txtDelimeter";
            this.txtDelimeter.Size = new System.Drawing.Size(384, 23);
            this.txtDelimeter.TabIndex = 24;
            this.txtDelimeter.Text = ",";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Delimiter character (character that separates the field values)";
            // 
            // cboFormTemplates
            // 
            this.cboFormTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormTemplates.FormattingEnabled = true;
            this.cboFormTemplates.Location = new System.Drawing.Point(78, 47);
            this.cboFormTemplates.Name = "cboFormTemplates";
            this.cboFormTemplates.Size = new System.Drawing.Size(354, 24);
            this.cboFormTemplates.TabIndex = 16;
            this.cboFormTemplates.SelectedIndexChanged += new System.EventHandler(this.CboFormTemplatesSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(75, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Select target form template";
            this.label4.UseMnemonic = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select CSV File Path";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(78, 102);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(354, 23);
            this.txtFilePath.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnFetchDashboards);
            this.tabPage3.Controls.Add(this.cboFormDashboards);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.btnExport);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.btnSelectExportFile);
            this.tabPage3.Controls.Add(this.txtExportFilePath);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPage3.Size = new System.Drawing.Size(536, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Export Form Data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cboFormDashboards
            // 
            this.cboFormDashboards.FormattingEnabled = true;
            this.cboFormDashboards.Location = new System.Drawing.Point(106, 66);
            this.cboFormDashboards.Name = "cboFormDashboards";
            this.cboFormDashboards.Size = new System.Drawing.Size(297, 21);
            this.cboFormDashboards.TabIndex = 27;
            this.cboFormDashboards.SelectedValueChanged += new System.EventHandler(this.CboFormDashboardsSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Select form dashboard";
            this.label2.UseMnemonic = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(103, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Save to CSV File";
            // 
            // txtExportFilePath
            // 
            this.txtExportFilePath.Location = new System.Drawing.Point(106, 121);
            this.txtExportFilePath.Name = "txtExportFilePath";
            this.txtExportFilePath.Size = new System.Drawing.Size(297, 20);
            this.txtExportFilePath.TabIndex = 20;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.txtErrors);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPage4.Size = new System.Drawing.Size(536, 395);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Errors";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // txtErrors
            // 
            this.txtErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtErrors.Location = new System.Drawing.Point(1, 1);
            this.txtErrors.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.Size = new System.Drawing.Size(534, 393);
            this.txtErrors.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.btnFetchDeleteTemplates);
            this.tabPage5.Controls.Add(this.cboDeleteFormTemplates);
            this.tabPage5.Controls.Add(this.label13);
            this.tabPage5.Controls.Add(this.btnDeleteAll);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPage5.Size = new System.Drawing.Size(536, 447);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Delete Forms";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cboDeleteFormTemplates
            // 
            this.cboDeleteFormTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDeleteFormTemplates.FormattingEnabled = true;
            this.cboDeleteFormTemplates.Location = new System.Drawing.Point(70, 51);
            this.cboDeleteFormTemplates.Name = "cboDeleteFormTemplates";
            this.cboDeleteFormTemplates.Size = new System.Drawing.Size(354, 24);
            this.cboDeleteFormTemplates.TabIndex = 36;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(68, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "Select target form template";
            this.label13.UseMnemonic = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.label18);
            this.tabPage6.Controls.Add(this.txtCreateUserApiFilter);
            this.tabPage6.Controls.Add(this.cboCreateUserSiteField);
            this.tabPage6.Controls.Add(this.label17);
            this.tabPage6.Controls.Add(this.cboCreateUserEmailField);
            this.tabPage6.Controls.Add(this.label16);
            this.tabPage6.Controls.Add(this.cboCreateUserUserIdField);
            this.tabPage6.Controls.Add(this.label15);
            this.tabPage6.Controls.Add(this.btnFetchCreateUserTemplates);
            this.tabPage6.Controls.Add(this.cboCreateUserFormTemplates);
            this.tabPage6.Controls.Add(this.label14);
            this.tabPage6.Controls.Add(this.btnCreateUserAccounts);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPage6.Size = new System.Drawing.Size(536, 447);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Create Users";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(45, 82);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(97, 13);
            this.label18.TabIndex = 49;
            this.label18.Text = "Query to filter forms";
            this.label18.UseMnemonic = false;
            // 
            // txtCreateUserApiFilter
            // 
            this.txtCreateUserApiFilter.Location = new System.Drawing.Point(46, 96);
            this.txtCreateUserApiFilter.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.txtCreateUserApiFilter.Name = "txtCreateUserApiFilter";
            this.txtCreateUserApiFilter.Size = new System.Drawing.Size(353, 20);
            this.txtCreateUserApiFilter.TabIndex = 48;
            // 
            // cboCreateUserSiteField
            // 
            this.cboCreateUserSiteField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCreateUserSiteField.FormattingEnabled = true;
            this.cboCreateUserSiteField.Location = new System.Drawing.Point(48, 278);
            this.cboCreateUserSiteField.Name = "cboCreateUserSiteField";
            this.cboCreateUserSiteField.Size = new System.Drawing.Size(354, 24);
            this.cboCreateUserSiteField.TabIndex = 47;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(45, 263);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 13);
            this.label17.TabIndex = 46;
            this.label17.Text = "Select User Site Field";
            this.label17.UseMnemonic = false;
            // 
            // cboCreateUserEmailField
            // 
            this.cboCreateUserEmailField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCreateUserEmailField.FormattingEnabled = true;
            this.cboCreateUserEmailField.Location = new System.Drawing.Point(47, 210);
            this.cboCreateUserEmailField.Name = "cboCreateUserEmailField";
            this.cboCreateUserEmailField.Size = new System.Drawing.Size(354, 24);
            this.cboCreateUserEmailField.TabIndex = 45;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(44, 194);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(156, 13);
            this.label16.TabIndex = 44;
            this.label16.Text = "Select User Email Address Field";
            this.label16.UseMnemonic = false;
            // 
            // cboCreateUserUserIdField
            // 
            this.cboCreateUserUserIdField.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCreateUserUserIdField.FormattingEnabled = true;
            this.cboCreateUserUserIdField.Location = new System.Drawing.Point(47, 151);
            this.cboCreateUserUserIdField.Name = "cboCreateUserUserIdField";
            this.cboCreateUserUserIdField.Size = new System.Drawing.Size(354, 24);
            this.cboCreateUserUserIdField.TabIndex = 43;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(44, 135);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 13);
            this.label15.TabIndex = 42;
            this.label15.Text = "Select User Id Field";
            this.label15.UseMnemonic = false;
            // 
            // cboCreateUserFormTemplates
            // 
            this.cboCreateUserFormTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCreateUserFormTemplates.FormattingEnabled = true;
            this.cboCreateUserFormTemplates.Location = new System.Drawing.Point(48, 47);
            this.cboCreateUserFormTemplates.Name = "cboCreateUserFormTemplates";
            this.cboCreateUserFormTemplates.Size = new System.Drawing.Size(354, 24);
            this.cboCreateUserFormTemplates.TabIndex = 40;
            this.cboCreateUserFormTemplates.SelectedIndexChanged += new System.EventHandler(this.cboCreateUserFormTemplates_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(45, 31);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(133, 13);
            this.label14.TabIndex = 39;
            this.label14.Text = "Select target form template";
            this.label14.UseMnemonic = false;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.btnLoadFolders);
            this.tabPage7.Controls.Add(this.lblFolderPath);
            this.tabPage7.Controls.Add(this.btnSelectFolder);
            this.tabPage7.Controls.Add(this.panel1);
            this.tabPage7.Controls.Add(this.btnCancel);
            this.tabPage7.Controls.Add(this.label19);
            this.tabPage7.Controls.Add(this.lblTitle);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPage7.Size = new System.Drawing.Size(536, 447);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Folder Security";
            this.tabPage7.UseVisualStyleBackColor = true;            
            // 
            // btnLoadFolders
            // 
            this.btnLoadFolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadFolders.Location = new System.Drawing.Point(6, 40);
            this.btnLoadFolders.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnLoadFolders.Name = "btnLoadFolders";
            this.btnLoadFolders.Size = new System.Drawing.Size(96, 24);
            this.btnLoadFolders.TabIndex = 40;
            this.btnLoadFolders.Text = "Load Folders";
            this.btnLoadFolders.Click += new System.EventHandler(this.btnLoadFolders_Click);
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.Location = new System.Drawing.Point(99, 355);
            this.lblFolderPath.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(219, 23);
            this.lblFolderPath.TabIndex = 35;
            this.lblFolderPath.Text = "No Folder Selected";
            this.lblFolderPath.Click += new System.EventHandler(this.lblFolderPath_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectFolder.Location = new System.Drawing.Point(433, 350);
            this.btnSelectFolder.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(64, 23);
            this.btnSelectFolder.TabIndex = 34;
            this.btnSelectFolder.Text = "OK";
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlRight);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.TreeView1);
            this.panel1.Location = new System.Drawing.Point(6, 66);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 274);
            this.panel1.TabIndex = 36;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.listViewSecurityMembers);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(201, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(290, 274);
            this.pnlRight.TabIndex = 9;
            // 
            // listViewSecurityMembers
            // 
            this.listViewSecurityMembers.AllowColumnReorder = true;
            this.listViewSecurityMembers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSecurityMembers.Location = new System.Drawing.Point(0, 0);
            this.listViewSecurityMembers.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.listViewSecurityMembers.Name = "listViewSecurityMembers";
            this.listViewSecurityMembers.Size = new System.Drawing.Size(290, 274);
            this.listViewSecurityMembers.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listViewSecurityMembers.TabIndex = 5;
            this.listViewSecurityMembers.UseCompatibleStateImageBehavior = false;
            this.listViewSecurityMembers.View = System.Windows.Forms.View.Details;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(198, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 274);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // TreeView1
            // 
            this.TreeView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeView1.ImageIndex = 0;
            this.TreeView1.ImageList = this.imageList1;
            this.TreeView1.Location = new System.Drawing.Point(0, 0);
            this.TreeView1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.SelectedImageIndex = 1;
            this.TreeView1.Size = new System.Drawing.Size(198, 274);
            this.TreeView1.TabIndex = 7;
            this.TreeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeExpand);
            this.TreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(356, 350);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(64, 23);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 355);
            this.label19.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 23);
            this.label19.TabIndex = 38;
            this.label19.Text = "Selected Folder:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(6, 9);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(256, 23);
            this.lblTitle.TabIndex = 37;
            this.lblTitle.Text = "Add/Remove Folder Security";
            // 
            // ImportFormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 445);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(558, 372);
            this.Name = "ImportFormData";
            this.Text = "VisualVault Form Import/Export Utility";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportFormDataFormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.tabPage7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearErrorsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.GroupBox groupBox11;
        internal System.Windows.Forms.TextBox uxAuthDbAlias;
        internal System.Windows.Forms.TextBox uxAuthCustomerAlias;
        internal System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboProfiles;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Label uxAuthStatus;
        private System.Windows.Forms.Button uxAuthCmdLogin;
        internal System.Windows.Forms.TextBox uxAuthPassword;
        internal System.Windows.Forms.TextBox uxAuthUserID;
        internal System.Windows.Forms.TextBox uxAuthServerUrl;
        internal System.Windows.Forms.Label label26;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDateTimeFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox chkAllowUpdate;
        private System.Windows.Forms.CheckBox chkCsvLinesQuoted;
        private System.Windows.Forms.CheckBox chkCsvHeadersQuoted;
        private System.Windows.Forms.TextBox txtDelimeter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFetchTemplates;
        private System.Windows.Forms.ComboBox cboFormTemplates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnFetchDashboards;
        private System.Windows.Forms.ComboBox cboFormDashboards;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectExportFile;
        private System.Windows.Forms.TextBox txtExportFilePath;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txtErrors;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button btnFetchDeleteTemplates;
        private System.Windows.Forms.ComboBox cboDeleteFormTemplates;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnDeleteAll;
        private System.Windows.Forms.Label lblVersion;
        private TextProgressBar progressBar1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtCreateUserApiFilter;
        private System.Windows.Forms.ComboBox cboCreateUserSiteField;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboCreateUserEmailField;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboCreateUserUserIdField;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnFetchCreateUserTemplates;
        private System.Windows.Forms.ComboBox cboCreateUserFormTemplates;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCreateUserAccounts;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlRight;
        internal System.Windows.Forms.ListView listViewSecurityMembers;
        private System.Windows.Forms.Splitter splitter1;
        internal System.Windows.Forms.TreeView TreeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnLoadFolders;
    }
}

