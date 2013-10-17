namespace VisualVault.UserImport
{
    partial class UserImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserImport));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDeveloperSecret = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDeveloperKey = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.txtServerURL = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.uxAuthInfoNameLast = new System.Windows.Forms.Label();
            this.uxAuthStatus = new System.Windows.Forms.Label();
            this.uxAuthInfoNameFirst = new System.Windows.Forms.Label();
            this.uxAuthInfoEmail = new System.Windows.Forms.Label();
            this.uxAuthInfoAuthType = new System.Windows.Forms.Label();
            this.uxAuthInfoUserId = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cboSites = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Import users from a CSV File";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 40);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(687, 592);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox11);
            this.tabPage1.Controls.Add(this.groupBox10);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(679, 566);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox11.BackColor = System.Drawing.Color.White;
            this.groupBox11.Controls.Add(this.label5);
            this.groupBox11.Controls.Add(this.label6);
            this.groupBox11.Controls.Add(this.txtDeveloperSecret);
            this.groupBox11.Controls.Add(this.label7);
            this.groupBox11.Controls.Add(this.txtDeveloperKey);
            this.groupBox11.Controls.Add(this.label8);
            this.groupBox11.Controls.Add(this.btnLogin);
            this.groupBox11.Controls.Add(this.txtPassword);
            this.groupBox11.Controls.Add(this.txtUserID);
            this.groupBox11.Controls.Add(this.txtServerURL);
            this.groupBox11.Controls.Add(this.label26);
            this.groupBox11.Controls.Add(this.label27);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Location = new System.Drawing.Point(40, 17);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(565, 346);
            this.groupBox11.TabIndex = 14;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Login to VisualVault";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(102, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(417, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Server Url example:  http://demo.visualvault.com/app/CustomerName/DatabaseName";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(552, 46);
            this.label6.TabIndex = 9;
            this.label6.Text = resources.GetString("label6.Text");
            // 
            // txtDeveloperSecret
            // 
            this.txtDeveloperSecret.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeveloperSecret.Location = new System.Drawing.Point(105, 179);
            this.txtDeveloperSecret.Name = "txtDeveloperSecret";
            this.txtDeveloperSecret.Size = new System.Drawing.Size(454, 20);
            this.txtDeveloperSecret.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Developer Secret:";
            // 
            // txtDeveloperKey
            // 
            this.txtDeveloperKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDeveloperKey.Location = new System.Drawing.Point(105, 153);
            this.txtDeveloperKey.Name = "txtDeveloperKey";
            this.txtDeveloperKey.Size = new System.Drawing.Size(454, 20);
            this.txtDeveloperKey.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 156);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Developer Key:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(415, 278);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.uxAuthCmdLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(105, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(454, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUserID
            // 
            this.txtUserID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserID.Location = new System.Drawing.Point(105, 79);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(454, 20);
            this.txtUserID.TabIndex = 2;
            // 
            // txtServerURL
            // 
            this.txtServerURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServerURL.Location = new System.Drawing.Point(105, 53);
            this.txtServerURL.Name = "txtServerURL";
            this.txtServerURL.Size = new System.Drawing.Size(454, 20);
            this.txtServerURL.TabIndex = 1;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(7, 108);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 13);
            this.label26.TabIndex = 3;
            this.label26.Text = "Password:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(16, 82);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(46, 13);
            this.label27.TabIndex = 2;
            this.label27.Text = "User ID:";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(6, 56);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(57, 13);
            this.label29.TabIndex = 0;
            this.label29.Text = "Server Url:";
            // 
            // groupBox10
            // 
            this.groupBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox10.BackColor = System.Drawing.Color.White;
            this.groupBox10.Controls.Add(this.label20);
            this.groupBox10.Controls.Add(this.uxAuthInfoNameLast);
            this.groupBox10.Controls.Add(this.uxAuthStatus);
            this.groupBox10.Controls.Add(this.uxAuthInfoNameFirst);
            this.groupBox10.Controls.Add(this.uxAuthInfoEmail);
            this.groupBox10.Controls.Add(this.uxAuthInfoAuthType);
            this.groupBox10.Controls.Add(this.uxAuthInfoUserId);
            this.groupBox10.Controls.Add(this.label21);
            this.groupBox10.Controls.Add(this.label22);
            this.groupBox10.Controls.Add(this.label23);
            this.groupBox10.Controls.Add(this.label24);
            this.groupBox10.Controls.Add(this.label25);
            this.groupBox10.Location = new System.Drawing.Point(40, 381);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(565, 161);
            this.groupBox10.TabIndex = 11;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Authenticated User Information";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(69, 20);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(40, 13);
            this.label20.TabIndex = 11;
            this.label20.Text = "Status:";
            // 
            // uxAuthInfoNameLast
            // 
            this.uxAuthInfoNameLast.AutoSize = true;
            this.uxAuthInfoNameLast.ForeColor = System.Drawing.Color.DimGray;
            this.uxAuthInfoNameLast.Location = new System.Drawing.Point(112, 136);
            this.uxAuthInfoNameLast.Name = "uxAuthInfoNameLast";
            this.uxAuthInfoNameLast.Size = new System.Drawing.Size(0, 13);
            this.uxAuthInfoNameLast.TabIndex = 10;
            // 
            // uxAuthStatus
            // 
            this.uxAuthStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uxAuthStatus.ForeColor = System.Drawing.Color.Red;
            this.uxAuthStatus.Location = new System.Drawing.Point(112, 14);
            this.uxAuthStatus.Name = "uxAuthStatus";
            this.uxAuthStatus.Size = new System.Drawing.Size(447, 25);
            this.uxAuthStatus.TabIndex = 5;
            this.uxAuthStatus.Text = "Not Logged In";
            this.uxAuthStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uxAuthInfoNameFirst
            // 
            this.uxAuthInfoNameFirst.AutoSize = true;
            this.uxAuthInfoNameFirst.ForeColor = System.Drawing.Color.DimGray;
            this.uxAuthInfoNameFirst.Location = new System.Drawing.Point(112, 113);
            this.uxAuthInfoNameFirst.Name = "uxAuthInfoNameFirst";
            this.uxAuthInfoNameFirst.Size = new System.Drawing.Size(0, 13);
            this.uxAuthInfoNameFirst.TabIndex = 9;
            // 
            // uxAuthInfoEmail
            // 
            this.uxAuthInfoEmail.AutoSize = true;
            this.uxAuthInfoEmail.ForeColor = System.Drawing.Color.DimGray;
            this.uxAuthInfoEmail.Location = new System.Drawing.Point(112, 90);
            this.uxAuthInfoEmail.Name = "uxAuthInfoEmail";
            this.uxAuthInfoEmail.Size = new System.Drawing.Size(0, 13);
            this.uxAuthInfoEmail.TabIndex = 8;
            // 
            // uxAuthInfoAuthType
            // 
            this.uxAuthInfoAuthType.AutoSize = true;
            this.uxAuthInfoAuthType.ForeColor = System.Drawing.Color.DimGray;
            this.uxAuthInfoAuthType.Location = new System.Drawing.Point(112, 66);
            this.uxAuthInfoAuthType.Name = "uxAuthInfoAuthType";
            this.uxAuthInfoAuthType.Size = new System.Drawing.Size(0, 13);
            this.uxAuthInfoAuthType.TabIndex = 7;
            // 
            // uxAuthInfoUserId
            // 
            this.uxAuthInfoUserId.AutoSize = true;
            this.uxAuthInfoUserId.ForeColor = System.Drawing.Color.DimGray;
            this.uxAuthInfoUserId.Location = new System.Drawing.Point(112, 43);
            this.uxAuthInfoUserId.Name = "uxAuthInfoUserId";
            this.uxAuthInfoUserId.Size = new System.Drawing.Size(0, 13);
            this.uxAuthInfoUserId.TabIndex = 6;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(48, 136);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(61, 13);
            this.label21.TabIndex = 4;
            this.label21.Text = "Last Name:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(49, 113);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(60, 13);
            this.label22.TabIndex = 3;
            this.label22.Text = "First Name:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(33, 90);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(76, 13);
            this.label23.TabIndex = 2;
            this.label23.Text = "Email Address:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(4, 66);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(105, 13);
            this.label24.TabIndex = 1;
            this.label24.Text = "Authentication Type:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(63, 43);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(46, 13);
            this.label25.TabIndex = 0;
            this.label25.Text = "User ID:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cboSites);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.lstUsers);
            this.tabPage2.Controls.Add(this.btnImport);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnSelectFile);
            this.tabPage2.Controls.Add(this.txtFilePath);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(679, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Import Users";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cboSites
            // 
            this.cboSites.FormattingEnabled = true;
            this.cboSites.Location = new System.Drawing.Point(21, 34);
            this.cboSites.Name = "cboSites";
            this.cboSites.Size = new System.Drawing.Size(327, 21);
            this.cboSites.TabIndex = 16;
            this.cboSites.SelectedIndexChanged += new System.EventHandler(this.cboSites_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Select target site";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Imported User Listing";
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(19, 179);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(329, 251);
            this.lstUsers.TabIndex = 13;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(19, 122);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 12;
            this.btnImport.Text = "Import Users";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Select CSV File Path";
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(324, 84);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(24, 23);
            this.btnSelectFile.TabIndex = 10;
            this.btnSelectFile.Text = "...";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(21, 87);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(297, 20);
            this.txtFilePath.TabIndex = 9;
            // 
            // UserImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 644);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label2);
            this.Name = "UserImport";
            this.Text = "User Import";
            this.Load += new System.EventHandler(this.UserImport_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.GroupBox groupBox10;
        internal System.Windows.Forms.Label label20;
        internal System.Windows.Forms.Label uxAuthInfoNameLast;
        internal System.Windows.Forms.Label uxAuthStatus;
        internal System.Windows.Forms.Label uxAuthInfoNameFirst;
        internal System.Windows.Forms.Label uxAuthInfoEmail;
        internal System.Windows.Forms.Label uxAuthInfoAuthType;
        internal System.Windows.Forms.Label uxAuthInfoUserId;
        internal System.Windows.Forms.Label label21;
        internal System.Windows.Forms.Label label22;
        internal System.Windows.Forms.Label label23;
        internal System.Windows.Forms.Label label24;
        internal System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.ComboBox cboSites;
        internal System.Windows.Forms.GroupBox groupBox11;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDeveloperSecret;
        internal System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDeveloperKey;
        internal System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnLogin;
        internal System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.TextBox txtUserID;
        private System.Windows.Forms.TextBox txtServerURL;
        internal System.Windows.Forms.Label label26;
        internal System.Windows.Forms.Label label27;
        internal System.Windows.Forms.Label label29;
    }
}

