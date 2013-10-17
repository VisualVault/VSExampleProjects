using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualVault.Examples.Export
{
    public partial class FrmVvExport
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVvExport));
            this.Tab1 = new System.Windows.Forms.TabControl();
            this.TabLogin = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTargetServerURL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTargetAuthStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTargetPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTargetUserID = new System.Windows.Forms.TextBox();
            this.btnTargetLogin = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtServerURL = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblAuthStatus = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.TabExport = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDocumentFilter = new System.Windows.Forms.TextBox();
            this.chkExportAllRevisions = new System.Windows.Forms.CheckBox();
            this.btnSelectFsTargetFolder = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.lblFsTargetFolderPath = new System.Windows.Forms.Label();
            this.chkPreservePath = new System.Windows.Forms.CheckBox();
            this._btnExportAll = new System.Windows.Forms.Button();
            this.btnExportSelected = new System.Windows.Forms.Button();
            this.chkFsRecursive = new System.Windows.Forms.CheckBox();
            this.chkUseDocID = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkLookForExistingDocs = new System.Windows.Forms.CheckBox();
            this.chkCopyRecordRetention = new System.Windows.Forms.CheckBox();
            this.chkCopyNamingConventions = new System.Windows.Forms.CheckBox();
            this.chkUnReleased = new System.Windows.Forms.CheckBox();
            this.btnSelectTargetFolder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTargetFolderPath = new System.Windows.Forms.Label();
            this.btnExportSelectedToURL = new System.Windows.Forms.Button();
            this.btnExportAllToURL = new System.Windows.Forms.Button();
            this.chkIncludeIndexFields = new System.Windows.Forms.CheckBox();
            this.chkFolderRecursive = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lvDocuments = new System.Windows.Forms.ListView();
            this.btnGetFolders = new System.Windows.Forms.Button();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.tabErrorLog = new System.Windows.Forms.TabPage();
            this.btnRefreshErrorLog = new System.Windows.Forms.Button();
            this.buttonClearErrorLog = new System.Windows.Forms.Button();
            this.dgErrors = new System.Windows.Forms.DataGrid();
            this.label25 = new System.Windows.Forms.Label();
            this.lblProgress = new System.Windows.Forms.Label();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblRunningTotals = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDeveloperSecret = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDeveloperKey = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Tab1.SuspendLayout();
            this.TabLogin.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.TabExport.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabErrorLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgErrors)).BeginInit();
            this.SuspendLayout();
            // 
            // Tab1
            // 
            this.Tab1.Controls.Add(this.TabLogin);
            this.Tab1.Controls.Add(this.TabExport);
            this.Tab1.Controls.Add(this.tabErrorLog);
            this.Tab1.Location = new System.Drawing.Point(0, 0);
            this.Tab1.Name = "Tab1";
            this.Tab1.SelectedIndex = 0;
            this.Tab1.Size = new System.Drawing.Size(792, 616);
            this.Tab1.TabIndex = 11;
            // 
            // TabLogin
            // 
            this.TabLogin.BackColor = System.Drawing.Color.White;
            this.TabLogin.Controls.Add(this.label10);
            this.TabLogin.Controls.Add(this.txtDeveloperSecret);
            this.TabLogin.Controls.Add(this.label11);
            this.TabLogin.Controls.Add(this.txtDeveloperKey);
            this.TabLogin.Controls.Add(this.label12);
            this.TabLogin.Controls.Add(this.groupBox2);
            this.TabLogin.Controls.Add(this.GroupBox1);
            this.TabLogin.Location = new System.Drawing.Point(4, 22);
            this.TabLogin.Name = "TabLogin";
            this.TabLogin.Size = new System.Drawing.Size(784, 590);
            this.TabLogin.TabIndex = 0;
            this.TabLogin.Text = "Log In";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.txtTargetServerURL);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblTargetAuthStatus);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtTargetPassword);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTargetUserID);
            this.groupBox2.Controls.Add(this.btnTargetLogin);
            this.groupBox2.Location = new System.Drawing.Point(436, 55);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 208);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Login to Target VisualVault Server (optional)";
            // 
            // txtTargetServerURL
            // 
            this.txtTargetServerURL.Location = new System.Drawing.Point(88, 40);
            this.txtTargetServerURL.Name = "txtTargetServerURL";
            this.txtTargetServerURL.Size = new System.Drawing.Size(184, 20);
            this.txtTargetServerURL.TabIndex = 0;
            this.txtTargetServerURL.Text = "https://";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(88, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "example: http://localhost/visualvault/";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Server URL";
            // 
            // lblTargetAuthStatus
            // 
            this.lblTargetAuthStatus.ForeColor = System.Drawing.Color.Red;
            this.lblTargetAuthStatus.Location = new System.Drawing.Point(8, 176);
            this.lblTargetAuthStatus.Name = "lblTargetAuthStatus";
            this.lblTargetAuthStatus.Size = new System.Drawing.Size(280, 16);
            this.lblTargetAuthStatus.TabIndex = 5;
            this.lblTargetAuthStatus.Text = "Not Logged In";
            this.lblTargetAuthStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // txtTargetPassword
            // 
            this.txtTargetPassword.Location = new System.Drawing.Point(88, 104);
            this.txtTargetPassword.Name = "txtTargetPassword";
            this.txtTargetPassword.PasswordChar = '*';
            this.txtTargetPassword.Size = new System.Drawing.Size(184, 20);
            this.txtTargetPassword.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 2;
            this.label6.Text = "User ID";
            // 
            // txtTargetUserID
            // 
            this.txtTargetUserID.Location = new System.Drawing.Point(88, 72);
            this.txtTargetUserID.Name = "txtTargetUserID";
            this.txtTargetUserID.Size = new System.Drawing.Size(184, 20);
            this.txtTargetUserID.TabIndex = 1;
            // 
            // btnTargetLogin
            // 
            this.btnTargetLogin.Location = new System.Drawing.Point(208, 136);
            this.btnTargetLogin.Name = "btnTargetLogin";
            this.btnTargetLogin.Size = new System.Drawing.Size(64, 24);
            this.btnTargetLogin.TabIndex = 3;
            this.btnTargetLogin.Text = "Login";
            this.btnTargetLogin.Click += new System.EventHandler(this.btnTargetLogin_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.White;
            this.GroupBox1.Controls.Add(this.txtServerURL);
            this.GroupBox1.Controls.Add(this.label31);
            this.GroupBox1.Controls.Add(this.label20);
            this.GroupBox1.Controls.Add(this.lblAuthStatus);
            this.GroupBox1.Controls.Add(this.Label1);
            this.GroupBox1.Controls.Add(this.txtPassword);
            this.GroupBox1.Controls.Add(this.lblUserID);
            this.GroupBox1.Controls.Add(this.txtUserID);
            this.GroupBox1.Controls.Add(this.btnLogin);
            this.GroupBox1.Location = new System.Drawing.Point(52, 55);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(296, 208);
            this.GroupBox1.TabIndex = 1;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Login to Source VisualVault Server";
            // 
            // txtServerURL
            // 
            this.txtServerURL.Location = new System.Drawing.Point(88, 40);
            this.txtServerURL.Name = "txtServerURL";
            this.txtServerURL.Size = new System.Drawing.Size(184, 20);
            this.txtServerURL.TabIndex = 0;
            this.txtServerURL.Text = "https://";
            // 
            // label31
            // 
            this.label31.Location = new System.Drawing.Point(88, 24);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(192, 23);
            this.label31.TabIndex = 11;
            this.label31.Text = "example: http://localhost/visualvault/";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(16, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 23);
            this.label20.TabIndex = 10;
            this.label20.Text = "Server URL";
            // 
            // lblAuthStatus
            // 
            this.lblAuthStatus.ForeColor = System.Drawing.Color.Red;
            this.lblAuthStatus.Location = new System.Drawing.Point(8, 176);
            this.lblAuthStatus.Name = "lblAuthStatus";
            this.lblAuthStatus.Size = new System.Drawing.Size(280, 16);
            this.lblAuthStatus.TabIndex = 5;
            this.lblAuthStatus.Text = "Not Logged In";
            this.lblAuthStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(16, 104);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(56, 23);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(88, 104);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(184, 20);
            this.txtPassword.TabIndex = 2;
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(16, 72);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(56, 23);
            this.lblUserID.TabIndex = 2;
            this.lblUserID.Text = "User ID";
            // 
            // txtUserID
            // 
            this.txtUserID.Location = new System.Drawing.Point(88, 72);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(184, 20);
            this.txtUserID.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(208, 136);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(64, 24);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // TabExport
            // 
            this.TabExport.BackColor = System.Drawing.SystemColors.ControlLight;
            this.TabExport.Controls.Add(this.tabControl1);
            this.TabExport.Controls.Add(this.label4);
            this.TabExport.Controls.Add(this.lvDocuments);
            this.TabExport.Controls.Add(this.btnGetFolders);
            this.TabExport.Controls.Add(this.TreeView1);
            this.TabExport.Controls.Add(this.lblFolderPath);
            this.TabExport.Location = new System.Drawing.Point(4, 22);
            this.TabExport.Name = "TabExport";
            this.TabExport.Size = new System.Drawing.Size(784, 590);
            this.TabExport.TabIndex = 1;
            this.TabExport.Text = "Document Export";
            this.TabExport.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 351);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(765, 232);
            this.tabControl1.TabIndex = 23;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtDocumentFilter);
            this.tabPage1.Controls.Add(this.chkExportAllRevisions);
            this.tabPage1.Controls.Add(this.btnSelectFsTargetFolder);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.lblFsTargetFolderPath);
            this.tabPage1.Controls.Add(this.chkPreservePath);
            this.tabPage1.Controls.Add(this._btnExportAll);
            this.tabPage1.Controls.Add(this.btnExportSelected);
            this.tabPage1.Controls.Add(this.chkFsRecursive);
            this.tabPage1.Controls.Add(this.chkUseDocID);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(757, 206);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Export to File System";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "Document Filter:";
            // 
            // txtDocumentFilter
            // 
            this.txtDocumentFilter.Location = new System.Drawing.Point(16, 146);
            this.txtDocumentFilter.Name = "txtDocumentFilter";
            this.txtDocumentFilter.Size = new System.Drawing.Size(303, 20);
            this.txtDocumentFilter.TabIndex = 42;
            // 
            // chkExportAllRevisions
            // 
            this.chkExportAllRevisions.AutoSize = true;
            this.chkExportAllRevisions.Location = new System.Drawing.Point(578, 90);
            this.chkExportAllRevisions.Name = "chkExportAllRevisions";
            this.chkExportAllRevisions.Size = new System.Drawing.Size(119, 17);
            this.chkExportAllRevisions.TabIndex = 41;
            this.chkExportAllRevisions.Text = "Export All Revisions";
            this.chkExportAllRevisions.UseVisualStyleBackColor = true;
            // 
            // btnSelectFsTargetFolder
            // 
            this.btnSelectFsTargetFolder.Location = new System.Drawing.Point(120, 40);
            this.btnSelectFsTargetFolder.Name = "btnSelectFsTargetFolder";
            this.btnSelectFsTargetFolder.Size = new System.Drawing.Size(24, 23);
            this.btnSelectFsTargetFolder.TabIndex = 40;
            this.btnSelectFsTargetFolder.Text = "...";
            this.btnSelectFsTargetFolder.Click += new System.EventHandler(this.btnSelectFsTargetFolder_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 39;
            this.label8.Text = "Select Target Folder:";
            // 
            // lblFsTargetFolderPath
            // 
            this.lblFsTargetFolderPath.ForeColor = System.Drawing.Color.DimGray;
            this.lblFsTargetFolderPath.Location = new System.Drawing.Point(150, 45);
            this.lblFsTargetFolderPath.Name = "lblFsTargetFolderPath";
            this.lblFsTargetFolderPath.Size = new System.Drawing.Size(547, 16);
            this.lblFsTargetFolderPath.TabIndex = 38;
            // 
            // chkPreservePath
            // 
            this.chkPreservePath.Checked = true;
            this.chkPreservePath.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreservePath.Location = new System.Drawing.Point(196, 90);
            this.chkPreservePath.Name = "chkPreservePath";
            this.chkPreservePath.Size = new System.Drawing.Size(136, 16);
            this.chkPreservePath.TabIndex = 37;
            this.chkPreservePath.Text = "Preserve Folder Path";
            // 
            // _btnExportAll
            // 
            this._btnExportAll.Location = new System.Drawing.Point(458, 179);
            this._btnExportAll.Name = "_btnExportAll";
            this._btnExportAll.Size = new System.Drawing.Size(135, 23);
            this._btnExportAll.TabIndex = 33;
            this._btnExportAll.Text = "Export Selected Folder";
            this._btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnExportSelected
            // 
            this.btnExportSelected.Location = new System.Drawing.Point(599, 179);
            this.btnExportSelected.Name = "btnExportSelected";
            this.btnExportSelected.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExportSelected.Size = new System.Drawing.Size(152, 23);
            this.btnExportSelected.TabIndex = 34;
            this.btnExportSelected.Text = "Export Selected Documents";
            this.btnExportSelected.Click += new System.EventHandler(this.btnExportSelected_Click);
            // 
            // chkFsRecursive
            // 
            this.chkFsRecursive.Checked = true;
            this.chkFsRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFsRecursive.Location = new System.Drawing.Point(19, 90);
            this.chkFsRecursive.Name = "chkFsRecursive";
            this.chkFsRecursive.Size = new System.Drawing.Size(144, 16);
            this.chkFsRecursive.TabIndex = 35;
            this.chkFsRecursive.Text = "Include All Subfolders";
            // 
            // chkUseDocID
            // 
            this.chkUseDocID.Checked = true;
            this.chkUseDocID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseDocID.Location = new System.Drawing.Point(365, 90);
            this.chkUseDocID.Name = "chkUseDocID";
            this.chkUseDocID.Size = new System.Drawing.Size(180, 16);
            this.chkUseDocID.TabIndex = 36;
            this.chkUseDocID.Text = "Use Document ID for file name";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkLookForExistingDocs);
            this.tabPage2.Controls.Add(this.chkCopyRecordRetention);
            this.tabPage2.Controls.Add(this.chkCopyNamingConventions);
            this.tabPage2.Controls.Add(this.chkUnReleased);
            this.tabPage2.Controls.Add(this.btnSelectTargetFolder);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.lblTargetFolderPath);
            this.tabPage2.Controls.Add(this.btnExportSelectedToURL);
            this.tabPage2.Controls.Add(this.btnExportAllToURL);
            this.tabPage2.Controls.Add(this.chkIncludeIndexFields);
            this.tabPage2.Controls.Add(this.chkFolderRecursive);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(757, 206);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Export to Vault";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkLookForExistingDocs
            // 
            this.chkLookForExistingDocs.Checked = true;
            this.chkLookForExistingDocs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLookForExistingDocs.Location = new System.Drawing.Point(178, 138);
            this.chkLookForExistingDocs.Name = "chkLookForExistingDocs";
            this.chkLookForExistingDocs.Size = new System.Drawing.Size(328, 18);
            this.chkLookForExistingDocs.TabIndex = 40;
            this.chkLookForExistingDocs.Text = "Check for existing documents and skip if found";
            // 
            // chkCopyRecordRetention
            // 
            this.chkCopyRecordRetention.Location = new System.Drawing.Point(513, 90);
            this.chkCopyRecordRetention.Name = "chkCopyRecordRetention";
            this.chkCopyRecordRetention.Size = new System.Drawing.Size(232, 16);
            this.chkCopyRecordRetention.TabIndex = 39;
            this.chkCopyRecordRetention.Text = "Copy source folder record retention rules";
            // 
            // chkCopyNamingConventions
            // 
            this.chkCopyNamingConventions.Checked = true;
            this.chkCopyNamingConventions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCopyNamingConventions.Location = new System.Drawing.Point(285, 90);
            this.chkCopyNamingConventions.Name = "chkCopyNamingConventions";
            this.chkCopyNamingConventions.Size = new System.Drawing.Size(224, 16);
            this.chkCopyNamingConventions.TabIndex = 38;
            this.chkCopyNamingConventions.Text = "Copy source folder naming conventions";
            // 
            // chkUnReleased
            // 
            this.chkUnReleased.Location = new System.Drawing.Point(16, 138);
            this.chkUnReleased.Name = "chkUnReleased";
            this.chkUnReleased.Size = new System.Drawing.Size(152, 16);
            this.chkUnReleased.TabIndex = 35;
            this.chkUnReleased.Text = "Check in as Un-Released";
            // 
            // btnSelectTargetFolder
            // 
            this.btnSelectTargetFolder.BackColor = System.Drawing.Color.Transparent;
            this.btnSelectTargetFolder.Location = new System.Drawing.Point(117, 40);
            this.btnSelectTargetFolder.Name = "btnSelectTargetFolder";
            this.btnSelectTargetFolder.Size = new System.Drawing.Size(24, 23);
            this.btnSelectTargetFolder.TabIndex = 34;
            this.btnSelectTargetFolder.Text = "...";
            this.btnSelectTargetFolder.UseVisualStyleBackColor = false;
            this.btnSelectTargetFolder.Click += new System.EventHandler(this.btnSelectTargetFolder_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(13, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 16);
            this.label7.TabIndex = 33;
            this.label7.Text = "Select Target Folder:";
            // 
            // lblTargetFolderPath
            // 
            this.lblTargetFolderPath.ForeColor = System.Drawing.Color.DimGray;
            this.lblTargetFolderPath.Location = new System.Drawing.Point(147, 47);
            this.lblTargetFolderPath.Name = "lblTargetFolderPath";
            this.lblTargetFolderPath.Size = new System.Drawing.Size(582, 16);
            this.lblTargetFolderPath.TabIndex = 32;
            // 
            // btnExportSelectedToURL
            // 
            this.btnExportSelectedToURL.Location = new System.Drawing.Point(600, 179);
            this.btnExportSelectedToURL.Name = "btnExportSelectedToURL";
            this.btnExportSelectedToURL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnExportSelectedToURL.Size = new System.Drawing.Size(151, 23);
            this.btnExportSelectedToURL.TabIndex = 31;
            this.btnExportSelectedToURL.Text = "Export Selected Documents";
            this.btnExportSelectedToURL.Click += new System.EventHandler(this.BtnExportSelectedToUrlClick);
            // 
            // btnExportAllToURL
            // 
            this.btnExportAllToURL.BackColor = System.Drawing.Color.Transparent;
            this.btnExportAllToURL.Location = new System.Drawing.Point(458, 179);
            this.btnExportAllToURL.Name = "btnExportAllToURL";
            this.btnExportAllToURL.Size = new System.Drawing.Size(128, 23);
            this.btnExportAllToURL.TabIndex = 30;
            this.btnExportAllToURL.Text = "Export Selected Folder";
            this.btnExportAllToURL.UseVisualStyleBackColor = false;
            this.btnExportAllToURL.Click += new System.EventHandler(this.BtnExportAllToUrlClick);
            // 
            // chkIncludeIndexFields
            // 
            this.chkIncludeIndexFields.Checked = true;
            this.chkIncludeIndexFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludeIndexFields.Location = new System.Drawing.Point(153, 90);
            this.chkIncludeIndexFields.Name = "chkIncludeIndexFields";
            this.chkIncludeIndexFields.Size = new System.Drawing.Size(128, 16);
            this.chkIncludeIndexFields.TabIndex = 36;
            this.chkIncludeIndexFields.Text = "Include Index Fields";
            // 
            // chkFolderRecursive
            // 
            this.chkFolderRecursive.Checked = true;
            this.chkFolderRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFolderRecursive.Location = new System.Drawing.Point(16, 90);
            this.chkFolderRecursive.Name = "chkFolderRecursive";
            this.chkFolderRecursive.Size = new System.Drawing.Size(144, 16);
            this.chkFolderRecursive.TabIndex = 37;
            this.chkFolderRecursive.Text = "Include All Subfolders";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Source Folder:";
            // 
            // lvDocuments
            // 
            this.lvDocuments.Location = new System.Drawing.Point(304, 48);
            this.lvDocuments.Name = "lvDocuments";
            this.lvDocuments.Size = new System.Drawing.Size(472, 255);
            this.lvDocuments.TabIndex = 4;
            this.lvDocuments.UseCompatibleStateImageBehavior = false;
            this.lvDocuments.SelectedIndexChanged += new System.EventHandler(this.LvDocumentsSelectedIndexChanged);
            // 
            // btnGetFolders
            // 
            this.btnGetFolders.BackColor = System.Drawing.SystemColors.Control;
            this.btnGetFolders.Location = new System.Drawing.Point(8, 16);
            this.btnGetFolders.Name = "btnGetFolders";
            this.btnGetFolders.Size = new System.Drawing.Size(136, 24);
            this.btnGetFolders.TabIndex = 3;
            this.btnGetFolders.Text = "Refresh Source Folders";
            this.btnGetFolders.UseVisualStyleBackColor = false;
            this.btnGetFolders.Click += new System.EventHandler(this.btnGetFolders_Click);
            // 
            // TreeView1
            // 
            this.TreeView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TreeView1.Location = new System.Drawing.Point(8, 48);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.Size = new System.Drawing.Size(288, 255);
            this.TreeView1.TabIndex = 2;
            this.TreeView1.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1BeforeExpand);
            this.TreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1BeforeSelect);
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.ForeColor = System.Drawing.Color.DimGray;
            this.lblFolderPath.Location = new System.Drawing.Point(88, 314);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(336, 16);
            this.lblFolderPath.TabIndex = 3;
            // 
            // tabErrorLog
            // 
            this.tabErrorLog.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tabErrorLog.Controls.Add(this.btnRefreshErrorLog);
            this.tabErrorLog.Controls.Add(this.buttonClearErrorLog);
            this.tabErrorLog.Controls.Add(this.dgErrors);
            this.tabErrorLog.Controls.Add(this.label25);
            this.tabErrorLog.Location = new System.Drawing.Point(4, 22);
            this.tabErrorLog.Name = "tabErrorLog";
            this.tabErrorLog.Size = new System.Drawing.Size(784, 590);
            this.tabErrorLog.TabIndex = 2;
            this.tabErrorLog.Text = "Error Log";
            // 
            // btnRefreshErrorLog
            // 
            this.btnRefreshErrorLog.Location = new System.Drawing.Point(568, 8);
            this.btnRefreshErrorLog.Name = "btnRefreshErrorLog";
            this.btnRefreshErrorLog.Size = new System.Drawing.Size(72, 23);
            this.btnRefreshErrorLog.TabIndex = 31;
            this.btnRefreshErrorLog.Text = "Refresh";
            this.btnRefreshErrorLog.Click += new System.EventHandler(this.btnRefreshErrorLog_Click);
            // 
            // buttonClearErrorLog
            // 
            this.buttonClearErrorLog.Location = new System.Drawing.Point(660, 7);
            this.buttonClearErrorLog.Name = "buttonClearErrorLog";
            this.buttonClearErrorLog.Size = new System.Drawing.Size(112, 23);
            this.buttonClearErrorLog.TabIndex = 30;
            this.buttonClearErrorLog.Text = "Clear Error Log";
            this.buttonClearErrorLog.Click += new System.EventHandler(this.buttonClearErrorLog_Click);
            // 
            // dgErrors
            // 
            this.dgErrors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgErrors.CaptionVisible = false;
            this.dgErrors.DataMember = "";
            this.dgErrors.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgErrors.Location = new System.Drawing.Point(4, 39);
            this.dgErrors.Name = "dgErrors";
            this.dgErrors.Size = new System.Drawing.Size(776, 480);
            this.dgErrors.TabIndex = 28;
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(9, 14);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(199, 23);
            this.label25.TabIndex = 29;
            this.label25.Text = "Errors logged during Export";
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(4, 650);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(776, 32);
            this.lblProgress.TabIndex = 16;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(0, 714);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(784, 16);
            this.pbProgress.TabIndex = 15;
            this.pbProgress.Visible = false;
            // 
            // lblRunningTotals
            // 
            this.lblRunningTotals.Location = new System.Drawing.Point(4, 630);
            this.lblRunningTotals.Name = "lblRunningTotals";
            this.lblRunningTotals.Size = new System.Drawing.Size(776, 16);
            this.lblRunningTotals.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(97, 380);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(552, 46);
            this.label10.TabIndex = 14;
            this.label10.Text = resources.GetString("label10.Text");
            // 
            // txtDeveloperSecret
            // 
            this.txtDeveloperSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeveloperSecret.Location = new System.Drawing.Point(195, 338);
            this.txtDeveloperSecret.Name = "txtDeveloperSecret";
            this.txtDeveloperSecret.Size = new System.Drawing.Size(454, 20);
            this.txtDeveloperSecret.TabIndex = 13;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(96, 341);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "Developer Secret:";
            // 
            // txtDeveloperKey
            // 
            this.txtDeveloperKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeveloperKey.Location = new System.Drawing.Point(195, 312);
            this.txtDeveloperKey.Name = "txtDeveloperKey";
            this.txtDeveloperKey.Size = new System.Drawing.Size(454, 20);
            this.txtDeveloperKey.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(96, 315);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Developer Key:";
            // 
            // FrmVvExport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(792, 733);
            this.Controls.Add(this.lblRunningTotals);
            this.Controls.Add(this.Tab1);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblProgress);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVvExport";
            this.Text = "VisualVault Export";
            this.Load += new System.EventHandler(this.FrmVvExportLoad);
            this.Tab1.ResumeLayout(false);
            this.TabLogin.ResumeLayout(false);
            this.TabLogin.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.TabExport.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabErrorLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgErrors)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal GroupBox GroupBox1;
        internal Label Label1;
        internal TabControl Tab1;
        internal TabPage TabExport;
        internal TabPage TabLogin;
        internal TreeView TreeView1;
        internal Button btnGetFolders;
        internal Button btnLogin;
        private Button btnRefreshErrorLog;
        internal Button btnTargetLogin;
        private Button buttonClearErrorLog;
        internal DataGrid dgErrors;
        private FolderBrowserDialog folderBrowserDialog1;
        internal GroupBox groupBox2;
        private Label label2;
        internal Label label20;
        private Label label25;
        internal Label label3;
        private Label label31;
        private Label label4;
        internal Label label5;
        internal Label label6;
        internal Label lblAuthStatus;
        internal Label lblFolderPath;
        private Label lblProgress;
        private Label lblRunningTotals;
        internal Label lblTargetAuthStatus;
        internal Label lblUserID;
        internal ListView lvDocuments;
        internal ProgressBar pbProgress;
        private TabPage tabErrorLog;
        internal TextBox txtPassword;
        internal TextBox txtServerURL;
        internal TextBox txtTargetPassword;
        internal TextBox txtTargetServerURL;
        internal TextBox txtTargetUserID;
        internal TextBox txtUserID;
        private ToolTip toolTip1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label9;
        private TextBox txtDocumentFilter;
        private CheckBox chkExportAllRevisions;
        private Button btnSelectFsTargetFolder;
        private Label label8;
        internal Label lblFsTargetFolderPath;
        private CheckBox chkPreservePath;
        private Button _btnExportAll;
        private Button btnExportSelected;
        private CheckBox chkFsRecursive;
        private CheckBox chkUseDocID;
        private TabPage tabPage2;
        private CheckBox chkLookForExistingDocs;
        private CheckBox chkCopyRecordRetention;
        private CheckBox chkCopyNamingConventions;
        private CheckBox chkUnReleased;
        private Button btnSelectTargetFolder;
        private Label label7;
        internal Label lblTargetFolderPath;
        private Button btnExportSelectedToURL;
        private Button btnExportAllToURL;
        private CheckBox chkIncludeIndexFields;
        private CheckBox chkFolderRecursive;
        private IContainer components;
        internal Label label10;
        private TextBox txtDeveloperSecret;
        internal Label label11;
        private TextBox txtDeveloperKey;
        internal Label label12;

       
    }
}
