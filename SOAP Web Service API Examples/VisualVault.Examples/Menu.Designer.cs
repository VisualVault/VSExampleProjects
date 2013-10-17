namespace VisualVault.ExamplesCs
{
    partial class Menu
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
            this.btnDocumentCheckIn = new System.Windows.Forms.Button();
            this.btnAuthenticate = new System.Windows.Forms.Button();
            this.btnDocumentSearch = new System.Windows.Forms.Button();
            this.btnTreeView = new System.Windows.Forms.Button();
            this.btnFindFolder = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDocumentCheckIn
            // 
            this.btnDocumentCheckIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDocumentCheckIn.Location = new System.Drawing.Point(132, 123);
            this.btnDocumentCheckIn.Name = "btnDocumentCheckIn";
            this.btnDocumentCheckIn.Size = new System.Drawing.Size(225, 23);
            this.btnDocumentCheckIn.TabIndex = 0;
            this.btnDocumentCheckIn.Text = "Document Check In";
            this.btnDocumentCheckIn.UseVisualStyleBackColor = true;
            this.btnDocumentCheckIn.Click += new System.EventHandler(this.BtnCheckInClick);
            // 
            // btnAuthenticate
            // 
            this.btnAuthenticate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAuthenticate.Location = new System.Drawing.Point(132, 80);
            this.btnAuthenticate.Name = "btnAuthenticate";
            this.btnAuthenticate.Size = new System.Drawing.Size(225, 23);
            this.btnAuthenticate.TabIndex = 2;
            this.btnAuthenticate.Text = "Authenticate with VisualVault Server";
            this.btnAuthenticate.UseVisualStyleBackColor = true;
            this.btnAuthenticate.Click += new System.EventHandler(this.BtnAuthenticateClick);
            // 
            // btnDocumentSearch
            // 
            this.btnDocumentSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDocumentSearch.Location = new System.Drawing.Point(132, 166);
            this.btnDocumentSearch.Name = "btnDocumentSearch";
            this.btnDocumentSearch.Size = new System.Drawing.Size(225, 23);
            this.btnDocumentSearch.TabIndex = 3;
            this.btnDocumentSearch.Text = "Document Search";
            this.btnDocumentSearch.UseVisualStyleBackColor = true;
            this.btnDocumentSearch.Click += new System.EventHandler(this.BtnDocumentSearchClick);
            // 
            // btnTreeView
            // 
            this.btnTreeView.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTreeView.Location = new System.Drawing.Point(132, 209);
            this.btnTreeView.Name = "btnTreeView";
            this.btnTreeView.Size = new System.Drawing.Size(225, 23);
            this.btnTreeView.TabIndex = 4;
            this.btnTreeView.Text = "VisualVault Folders - Treeview Example";
            this.btnTreeView.UseVisualStyleBackColor = true;
            this.btnTreeView.Click += new System.EventHandler(this.BtnTreeViewClick);
            // 
            // btnFindFolder
            // 
            this.btnFindFolder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnFindFolder.Location = new System.Drawing.Point(132, 252);
            this.btnFindFolder.Name = "btnFindFolder";
            this.btnFindFolder.Size = new System.Drawing.Size(225, 23);
            this.btnFindFolder.TabIndex = 5;
            this.btnFindFolder.Text = "VisualVault Folders - Find Folder";
            this.btnFindFolder.UseVisualStyleBackColor = true;
            this.btnFindFolder.Click += new System.EventHandler(this.BtnFindFolderClick);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckIn.Location = new System.Drawing.Point(132, 297);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(225, 23);
            this.btnCheckIn.TabIndex = 6;
            this.btnCheckIn.Text = "Meta-Data Examples (document index fields)\r\n";
            this.btnCheckIn.UseVisualStyleBackColor = true;
            this.btnCheckIn.Click += new System.EventHandler(this.Button1Click1);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(528, 388);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnFindFolder);
            this.Controls.Add(this.btnTreeView);
            this.Controls.Add(this.btnDocumentSearch);
            this.Controls.Add(this.btnAuthenticate);
            this.Controls.Add(this.btnDocumentCheckIn);
            this.Name = "Menu";
            this.Text = "VisualVault SDK Examples";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDocumentCheckIn;
        private System.Windows.Forms.Button btnAuthenticate;
        private System.Windows.Forms.Button btnDocumentSearch;
        private System.Windows.Forms.Button btnTreeView;
        private System.Windows.Forms.Button btnFindFolder;
        private System.Windows.Forms.Button btnCheckIn;
    }
}