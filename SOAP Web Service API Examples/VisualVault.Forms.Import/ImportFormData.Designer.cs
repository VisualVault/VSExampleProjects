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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblVersion = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
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
            this.btnFetchTemplates = new System.Windows.Forms.Button();
            this.cboFormTemplates = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnFetchDashboards = new System.Windows.Forms.Button();
            this.cboFormDashboards = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSelectExportFile = new System.Windows.Forms.Button();
            this.txtExportFilePath = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
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
            this.progressBar1 = new VisualVault.Forms.Import.UI.TextProgressBar();
            this.chkExportRelatedDocs = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 33);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 512);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lblVersion);
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(717, 483);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(57, 322);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(64, 17);
            this.lblVersion.TabIndex = 11;
            this.lblVersion.Text = "Version: ";
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox11.BackColor = System.Drawing.Color.White;
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
            this.groupBox11.Location = new System.Drawing.Point(61, 47);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox11.Size = new System.Drawing.Size(516, 272);
            this.groupBox11.TabIndex = 10;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Login to VisualVault";
            // 
            // cboProfiles
            // 
            this.cboProfiles.FormattingEnabled = true;
            this.cboProfiles.Location = new System.Drawing.Point(93, 30);
            this.cboProfiles.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboProfiles.Name = "cboProfiles";
            this.cboProfiles.Size = new System.Drawing.Size(395, 24);
            this.cboProfiles.TabIndex = 17;
            this.cboProfiles.SelectedIndexChanged += new System.EventHandler(this.CboProfilesSelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 39);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Profile:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(31, 202);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 17);
            this.label20.TabIndex = 13;
            this.label20.Text = "Status:";
            // 
            // uxAuthStatus
            // 
            this.uxAuthStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.uxAuthStatus.Location = new System.Drawing.Point(89, 194);
            this.uxAuthStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.uxAuthStatus.Name = "uxAuthStatus";
            this.uxAuthStatus.Size = new System.Drawing.Size(404, 31);
            this.uxAuthStatus.TabIndex = 12;
            this.uxAuthStatus.Text = "Not Logged In";
            this.uxAuthStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxAuthCmdLogin
            // 
            this.uxAuthCmdLogin.Location = new System.Drawing.Point(389, 229);
            this.uxAuthCmdLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxAuthCmdLogin.Name = "uxAuthCmdLogin";
            this.uxAuthCmdLogin.Size = new System.Drawing.Size(100, 28);
            this.uxAuthCmdLogin.TabIndex = 4;
            this.uxAuthCmdLogin.Text = "Login";
            this.uxAuthCmdLogin.UseVisualStyleBackColor = true;
            this.uxAuthCmdLogin.Click += new System.EventHandler(this.BtnLoginClick);
            // 
            // uxAuthPassword
            // 
            this.uxAuthPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthPassword.Location = new System.Drawing.Point(93, 156);
            this.uxAuthPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxAuthPassword.Name = "uxAuthPassword";
            this.uxAuthPassword.PasswordChar = '*';
            this.uxAuthPassword.Size = new System.Drawing.Size(399, 22);
            this.uxAuthPassword.TabIndex = 3;
            // 
            // uxAuthUserID
            // 
            this.uxAuthUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthUserID.Location = new System.Drawing.Point(93, 114);
            this.uxAuthUserID.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxAuthUserID.Name = "uxAuthUserID";
            this.uxAuthUserID.Size = new System.Drawing.Size(399, 22);
            this.uxAuthUserID.TabIndex = 2;
            // 
            // uxAuthServerUrl
            // 
            this.uxAuthServerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthServerUrl.Location = new System.Drawing.Point(93, 73);
            this.uxAuthServerUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.uxAuthServerUrl.Name = "uxAuthServerUrl";
            this.uxAuthServerUrl.Size = new System.Drawing.Size(399, 22);
            this.uxAuthServerUrl.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(11, 160);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 17);
            this.label26.TabIndex = 3;
            this.label26.Text = "Password:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(23, 118);
            this.label27.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(59, 17);
            this.label27.TabIndex = 2;
            this.label27.Text = "User ID:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(9, 76);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(76, 17);
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
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(717, 483);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import Form Data";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(101, 315);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(244, 17);
            this.label10.TabIndex = 32;
            this.label10.Text = "H=(0-23),h=(0-12),m=(0-59),s=(0-59)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(101, 292);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(351, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "d=(1-31), dd=(01-31), M=(1-12), MM=(01-12), yy, yyyy";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(101, 287);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 30;
            // 
            // txtDateTimeFormat
            // 
            this.txtDateTimeFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDateTimeFormat.Location = new System.Drawing.Point(104, 257);
            this.txtDateTimeFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDateTimeFormat.Name = "txtDateTimeFormat";
            this.txtDateTimeFormat.Size = new System.Drawing.Size(511, 26);
            this.txtDateTimeFormat.TabIndex = 29;
            this.txtDateTimeFormat.Text = "d-MM-yyyy h:mm:ss,d/MM/yyyy,dd-MM-YYYY h:mm:ss";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(100, 238);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(393, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "Source Date-Time Formats (comma separated list of formats)";
            // 
            // chkAllowUpdate
            // 
            this.chkAllowUpdate.AutoSize = true;
            this.chkAllowUpdate.Location = new System.Drawing.Point(104, 418);
            this.chkAllowUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkAllowUpdate.Name = "chkAllowUpdate";
            this.chkAllowUpdate.Size = new System.Drawing.Size(413, 21);
            this.chkAllowUpdate.TabIndex = 27;
            this.chkAllowUpdate.Text = "First column contains Form Id (used to update existing forms)";
            this.chkAllowUpdate.UseVisualStyleBackColor = true;
            // 
            // chkCsvLinesQuoted
            // 
            this.chkCsvLinesQuoted.AutoSize = true;
            this.chkCsvLinesQuoted.Location = new System.Drawing.Point(104, 389);
            this.chkCsvLinesQuoted.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCsvLinesQuoted.Name = "chkCsvLinesQuoted";
            this.chkCsvLinesQuoted.Size = new System.Drawing.Size(241, 21);
            this.chkCsvLinesQuoted.TabIndex = 26;
            this.chkCsvLinesQuoted.Text = "CSV Line Item Values are Quoted";
            this.chkCsvLinesQuoted.UseVisualStyleBackColor = true;
            // 
            // chkCsvHeadersQuoted
            // 
            this.chkCsvHeadersQuoted.AutoSize = true;
            this.chkCsvHeadersQuoted.Location = new System.Drawing.Point(104, 359);
            this.chkCsvHeadersQuoted.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCsvHeadersQuoted.Name = "chkCsvHeadersQuoted";
            this.chkCsvHeadersQuoted.Size = new System.Drawing.Size(231, 21);
            this.chkCsvHeadersQuoted.TabIndex = 25;
            this.chkCsvHeadersQuoted.Text = "CSV Header Values are Quoted";
            this.chkCsvHeadersQuoted.UseVisualStyleBackColor = true;
            // 
            // txtDelimeter
            // 
            this.txtDelimeter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelimeter.Location = new System.Drawing.Point(104, 188);
            this.txtDelimeter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDelimeter.Name = "txtDelimeter";
            this.txtDelimeter.Size = new System.Drawing.Size(511, 26);
            this.txtDelimeter.TabIndex = 24;
            this.txtDelimeter.Text = ",";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 169);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(395, 17);
            this.label3.TabIndex = 23;
            this.label3.Text = "Delimiter character (character that separates the field values)";
            // 
            // btnFetchTemplates
            // 
            this.btnFetchTemplates.Location = new System.Drawing.Point(584, 58);
            this.btnFetchTemplates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFetchTemplates.Name = "btnFetchTemplates";
            this.btnFetchTemplates.Size = new System.Drawing.Size(32, 28);
            this.btnFetchTemplates.TabIndex = 18;
            this.btnFetchTemplates.Text = "...";
            this.toolTip1.SetToolTip(this.btnFetchTemplates, "Fetch form templates");
            this.btnFetchTemplates.UseVisualStyleBackColor = true;
            this.btnFetchTemplates.Click += new System.EventHandler(this.BtnFetchTemplatesClick);
            // 
            // cboFormTemplates
            // 
            this.cboFormTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFormTemplates.FormattingEnabled = true;
            this.cboFormTemplates.Location = new System.Drawing.Point(104, 58);
            this.cboFormTemplates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboFormTemplates.Name = "cboFormTemplates";
            this.cboFormTemplates.Size = new System.Drawing.Size(471, 28);
            this.cboFormTemplates.TabIndex = 16;
            this.cboFormTemplates.SelectedIndexChanged += new System.EventHandler(this.CboFormTemplatesSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 38);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(178, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Select target form template";
            this.label4.UseMnemonic = false;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(572, 444);
            this.btnImport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(133, 28);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Start Import";
            this.toolTip1.SetToolTip(this.btnImport, "Begin Form Import Process");
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.BtnImportClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select CSV File Path";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(584, 122);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(32, 28);
            this.btnSelectFile.TabIndex = 10;
            this.btnSelectFile.Text = "...";
            this.toolTip1.SetToolTip(this.btnSelectFile, "Browse for CSV File");
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.BtnSelectFileClick);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilePath.Location = new System.Drawing.Point(104, 126);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(471, 26);
            this.txtFilePath.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkExportRelatedDocs);
            this.tabPage3.Controls.Add(this.btnFetchDashboards);
            this.tabPage3.Controls.Add(this.cboFormDashboards);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.btnExport);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.btnSelectExportFile);
            this.tabPage3.Controls.Add(this.txtExportFilePath);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(717, 483);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Export Form Data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnFetchDashboards
            // 
            this.btnFetchDashboards.Location = new System.Drawing.Point(545, 81);
            this.btnFetchDashboards.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFetchDashboards.Name = "btnFetchDashboards";
            this.btnFetchDashboards.Size = new System.Drawing.Size(32, 28);
            this.btnFetchDashboards.TabIndex = 28;
            this.btnFetchDashboards.Text = "...";
            this.toolTip1.SetToolTip(this.btnFetchDashboards, "Fetch form templates");
            this.btnFetchDashboards.UseVisualStyleBackColor = true;
            this.btnFetchDashboards.Click += new System.EventHandler(this.BtnFetchDashboardsClick);
            // 
            // cboFormDashboards
            // 
            this.cboFormDashboards.FormattingEnabled = true;
            this.cboFormDashboards.Location = new System.Drawing.Point(141, 81);
            this.cboFormDashboards.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboFormDashboards.Name = "cboFormDashboards";
            this.cboFormDashboards.Size = new System.Drawing.Size(395, 24);
            this.cboFormDashboards.TabIndex = 27;
            this.cboFormDashboards.SelectedIndexChanged += new System.EventHandler(this.CboFormDashboardsSelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(137, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Select form dashboard";
            this.label2.UseMnemonic = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(571, 444);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(133, 28);
            this.btnExport.TabIndex = 23;
            this.btnExport.Text = "Start Export";
            this.toolTip1.SetToolTip(this.btnExport, "Begin Form Import Process");
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.BtnExportClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(137, 127);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Save to CSV File";
            // 
            // btnSelectExportFile
            // 
            this.btnSelectExportFile.Location = new System.Drawing.Point(545, 145);
            this.btnSelectExportFile.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSelectExportFile.Name = "btnSelectExportFile";
            this.btnSelectExportFile.Size = new System.Drawing.Size(32, 28);
            this.btnSelectExportFile.TabIndex = 21;
            this.btnSelectExportFile.Text = "...";
            this.toolTip1.SetToolTip(this.btnSelectExportFile, "Browse for CSV File");
            this.btnSelectExportFile.UseVisualStyleBackColor = true;
            this.btnSelectExportFile.Click += new System.EventHandler(this.BtnSelectExportFileClick);
            // 
            // txtExportFilePath
            // 
            this.txtExportFilePath.Location = new System.Drawing.Point(141, 149);
            this.txtExportFilePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExportFilePath.Name = "txtExportFilePath";
            this.txtExportFilePath.Size = new System.Drawing.Size(395, 22);
            this.txtExportFilePath.TabIndex = 20;
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
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog1FileOk);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.profilesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(725, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "‎File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
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
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.profilesToolStripMenuItem.Text = "Profiles";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(126, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(129, 24);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(119, 24);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.progressBar1.Location = new System.Drawing.Point(0, 553);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(725, 28);
            this.progressBar1.TabIndex = 17;
            // 
            // chkExportRelatedDocs
            // 
            this.chkExportRelatedDocs.AutoSize = true;
            this.chkExportRelatedDocs.Location = new System.Drawing.Point(141, 207);
            this.chkExportRelatedDocs.Name = "chkExportRelatedDocs";
            this.chkExportRelatedDocs.Size = new System.Drawing.Size(198, 21);
            this.chkExportRelatedDocs.TabIndex = 29;
            this.chkExportRelatedDocs.Text = "Export Related Documents";
            this.chkExportRelatedDocs.UseVisualStyleBackColor = true;
            // 
            // ImportFormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(725, 581);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ImportFormData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisualVault Form Import/Export Utility";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportFormDataFormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button uxAuthCmdLogin;
        internal System.Windows.Forms.TextBox uxAuthPassword;
        internal System.Windows.Forms.TextBox uxAuthUserID;
        internal System.Windows.Forms.TextBox uxAuthServerUrl;
        internal System.Windows.Forms.Label label26;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cboFormTemplates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private TextProgressBar progressBar1;
        private System.Windows.Forms.Button btnFetchTemplates;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Label uxAuthStatus;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnFetchDashboards;
        private System.Windows.Forms.ComboBox cboFormDashboards;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSelectExportFile;
        private System.Windows.Forms.TextBox txtExportFilePath;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ComboBox cboProfiles;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkCsvLinesQuoted;
        private System.Windows.Forms.CheckBox chkCsvHeadersQuoted;
        private System.Windows.Forms.TextBox txtDelimeter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkAllowUpdate;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDateTimeFormat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkExportRelatedDocs;
    }
}

