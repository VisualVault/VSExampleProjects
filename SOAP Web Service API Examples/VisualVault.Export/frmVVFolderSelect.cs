using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Library.Documents;
using VVRuntime.VisualVault.Library.Folders;
using VisualVault.Examples.Common;


namespace VisualVault.Examples.Export
{
    /// <summary>
    /// Summary description for frmVVFolderSelect.
    /// </summary>
    public class FrmVvFolderSelect : Form
    {
        internal TreeView TreeView1;
        private Button btnCancel;
        private Button btnSelectFolder;
        private IContainer components;
        private ImageList imageList1;
        private Label label1;
        private Label lblFolderPath;
        private Label lblTitle;
        internal ListView lvDocuments;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel pnlRight;
        private Splitter splitter1;

        public FrmVvFolderSelect()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            _selectedFolderId = Guid.Empty;
        }

        public FrmVvFolderSelect(Guid selectedFolderId)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            _selectedFolderId = selectedFolderId;
        }

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

        private void frmVVFolderSelect_Load(object sender, EventArgs e)
        {
            Authenticate();

            if (Vault != null)
            {
                InitializeTreeview();
                InitializeDocumentsListView();
                // Set the minimum size the ListView control can be sized to.
                splitter1.MinExtra = 100;
                // Set the minimum size the TreeView control can be sized to.
                splitter1.MinSize = 75;
                // Set the ListView control to fill the remaining space on the form.
                lvDocuments.Dock = DockStyle.Fill;


                try
                {
                    Location = new Point(Location.X + 80, Location.Y + 80);
                }
                catch (Exception ex)
                {
                    string exMessage = ex.Message;
                }
            }
            else
            {
                MessageBox.Show("You are not logged in");
                Close();
            }
        }
        
        private void Authenticate()
        {
            try
            {
                if (Vault == null)
                {
                    Vault = VVRuntime.VisualVaultLogin.Login(_vvServerUrl, _vvServerUserId, _vvServerPassword,Constants.DeveloperKey,Constants.DeveloperSecret,Constants.ProductId);
                }

                if (Vault == null)
                {
                    MessageBox.Show(
                        "Login to VisualVault failed.  Check the server URL, User ID, and Password used for connecting to VisualVault.  Close this window and set the UserID and Password.",
                        "Error", MessageBoxButtons.OK);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void InitializeTreeview()
        {
            if (Vault != null)
            {
                FolderCollection folderCollection = Vault.DefaultStore.Library.GetTopLevelFolders();
                VvTreeNode node;
                foreach (Folder folder in folderCollection)
                {
                    node = new VvTreeNode(folder.FolderID, folder.Name);
                    node.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
                    TreeView1.Nodes.Add(node);
                }

                if (TreeView1.GetNodeCount(false) > 0)
                {
                    //if selected folder ID was passed in then try and find that folder in the tree
                    //and selected it

                    if (_selectedFolderId.Equals(Guid.Empty))
                    {
                        node = (VvTreeNode)TreeView1.Nodes[0];
                        if (node != null)
                        {
                            TreeView1.SelectedNode = node;
                            LoadChildTreeNodes(node);
                            _selectedFolder = Vault.DefaultStore.Library.GetFolder(node.NodeID);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("You are not logged in to the Target VisualVault Server", "Error", MessageBoxButtons.OK);
            }
        }
        
        private void InitializeDocumentsListView()
        {
            lvDocuments.Columns.Clear();
            lvDocuments.View = View.Details;
            lvDocuments.LabelEdit = false;
            lvDocuments.AllowColumnReorder = true;
            lvDocuments.CheckBoxes = false;
            lvDocuments.FullRowSelect = true;
            lvDocuments.GridLines = false;
            lvDocuments.Sorting = SortOrder.Ascending;
            lvDocuments.Columns.Add("DocID", 122, HorizontalAlignment.Right);
            lvDocuments.Columns.Add("Description", 150, HorizontalAlignment.Left);
            lvDocuments.Columns.Add("Rev", 40, HorizontalAlignment.Left);
        }
        
        private void LoadChildTreeNodes(VvTreeNode node)
        {
            VvTreeNode childnode;
            if (node.GetNodeCount(true) == 1)
            {
                childnode = (VvTreeNode)node.Nodes[0];
                if (Guid.Empty.Equals(childnode.NodeID))
                {
                    node.Nodes.Remove(childnode);
                }
            }
            FolderCollection fldrColl = Vault.DefaultStore.Library.GetChildFolders(node.NodeID);
            foreach (Folder folder in fldrColl)
            {
                childnode = new VvTreeNode(folder.FolderID, folder.Name);
                childnode.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
                node.Nodes.Add(childnode);
            }
            node.Expand();
        }
        
        private void BindDocumentsListView(bool withFolderPath)
        {
            lvDocuments.Items.Clear();
            foreach (Document doc in _docColl)
            {
                var lvi = new MyListViewItem(doc.DhID, doc.DocID) { Checked = false };
                lvi.SubItems.Add(doc.Description);
                lvi.SubItems.Add(doc.Revision);
                lvi.SubItems.Add(doc.Filename);
                lvi.SubItems.Add(doc.DocumentState.ToString());
                if (withFolderPath)
                {
                    lvi.SubItems.Add(doc.FolderPath);
                }
                lvDocuments.Items.Add(lvi);
                if (_selectedDocument != null)
                {
                    if (doc.DocID.ToLower() == _selectedDocument.DocID.ToLower())
                    {
                        lvi.Selected = true;
                        lvi.BackColor = SystemColors.Highlight;
                        lvi.ForeColor = SystemColors.HighlightText;
                    }
                }
            }
        }
        
        private void TreeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = (VvTreeNode)e.Node;
            if (node.GetNodeCount(true) == 1)
            {
                var childnode = (VvTreeNode)node.Nodes[0];
                if (Guid.Empty.Equals(childnode.NodeID))
                {
                    node.Nodes.Remove(childnode);
                    Guid folderId1 = node.NodeID;
                    FolderCollection folderCollection = Vault.DefaultStore.Library.GetChildFolders(folderId1);
                    foreach (Folder folder in folderCollection)
                    {
                        var newnode = new VvTreeNode(folder.FolderID, folder.Name);
                        newnode.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
                        node.Nodes.Add(newnode);
                    }
                }
            }
        }

        private void TreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                Application.DoEvents();
                var node = (VvTreeNode)e.Node;
                if (node != null && Vault != null)
                {
                    _selectedFolderId = node.NodeID;
                    _selectedFolder = Vault.DefaultStore.Library.GetFolder(_selectedFolderId);
                    lvDocuments.Items.Clear();
                    Application.DoEvents();
                    if (_selectedFolder != null)
                    {
                        UpdateSelectedFolderInfo();
                        _docColl = _selectedFolder.GetDocuments();

                        Application.DoEvents();
                        BindDocumentsListView(false);
                    }
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void UpdateSelectedFolderInfo()
        {
            if (_selectedFolder == null)
            {
                lblFolderPath.Text = "No folder selected";
            }
            else
            {
                lblFolderPath.Text = _selectedFolder.FolderPath;
            }
        }
        
        private void lvDocuments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDocuments.SelectedItems.Count > 0)
            {
                var lvi = (MyListViewItem)lvDocuments.SelectedItems[0];
                Guid dhId = lvi.ListViewItemID;
                _selectedDocument = Vault.DefaultStore.Library.GetDocument(dhId);
                if (_selectedDocument != null)
                {
                    //UpdateSelectedDocumentInfo();
                }
            }
        }
        
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            var resources = new System.Resources.ResourceManager(typeof(FrmVvFolderSelect));
            this.lvDocuments = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.TreeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvDocuments
            // 
            this.lvDocuments.AllowColumnReorder = true;
            this.lvDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDocuments.Location = new System.Drawing.Point(0, 0);
            this.lvDocuments.Name = "lvDocuments";
            this.lvDocuments.Size = new System.Drawing.Size(301, 308);
            this.lvDocuments.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvDocuments.TabIndex = 5;
            this.lvDocuments.View = System.Windows.Forms.View.Details;
            this.lvDocuments.SelectedIndexChanged += new System.EventHandler(this.lvDocuments_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 352);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 1);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F,
                                                                System.Drawing.FontStyle.Regular,
                                                                System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btnSelectFolder.Location = new System.Drawing.Point(415, 360);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(66, 23);
            this.btnSelectFolder.TabIndex = 27;
            this.btnSelectFolder.Text = "OK";
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.Location = new System.Drawing.Point(104, 368);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(224, 23);
            this.lblFolderPath.TabIndex = 28;
            this.lblFolderPath.Text = "No Folder Selected";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlRight);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.TreeView1);
            this.panel1.Location = new System.Drawing.Point(0, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(504, 308);
            this.panel1.TabIndex = 29;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.lvDocuments);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(203, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(301, 308);
            this.pnlRight.TabIndex = 9;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(200, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 308);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // TreeView1
            // 
            this.TreeView1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TreeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.TreeView1.ImageList = this.imageList1;
            this.TreeView1.Location = new System.Drawing.Point(0, 0);
            this.TreeView1.Name = "TreeView1";
            this.TreeView1.SelectedImageIndex = 1;
            this.TreeView1.Size = new System.Drawing.Size(200, 308);
            this.TreeView1.TabIndex = 7;
            this.TreeView1.BeforeSelect +=
                new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeSelect);
            this.TreeView1.BeforeExpand +=
                new System.Windows.Forms.TreeViewCancelEventHandler(this.TreeView1_BeforeExpand);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth24Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.ImageStream =
                ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold,
                                                         System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(0, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(250, 23);
            this.lblTitle.TabIndex = 30;
            this.lblTitle.Text = "Select target VisualVault folder";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold,
                                                       System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 368);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 31;
            this.label1.Text = "Selected Folder:";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular,
                                                          System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(336, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 23);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmVVFolderSelect
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(492, 390);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblFolderPath);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmVvFolderSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select VisualVault Folder";
            this.Load += new System.EventHandler(this.frmVVFolderSelect_Load);
            this.panel1.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        #region Member Variables

        private DocumentCollection _docColl;
        private Document _selectedDocument;
        private Folder _selectedFolder;
        private Guid _selectedFolderId;
        private string _vvServerPassword;
        private string _vvServerUrl;
        private string _vvServerUserId;

        #endregion

        #region Properties

        public Vault Vault { get; set; }

        public string VvServerUrl
        {
            get { return _vvServerUrl; }
            set { _vvServerUrl = value; }
        }

        public string VvServerUserId
        {
            get { return _vvServerUserId; }
            set { _vvServerUserId = value; }
        }

        public string VvServerPassword
        {
            get { return _vvServerPassword; }
            set { _vvServerPassword = value; }
        }

        public Guid FolderID
        {
            get { return _selectedFolderId; }
        }

        public string FolderPath
        {
            get
            {
                if (_selectedFolder != null)
                {
                    return _selectedFolder.FolderPath;
                }
                return "";
            }
        }

        #endregion
    }

    public class SelectedFolderEventArgs : EventArgs
    {
        // Stores the new value.
        private readonly Guid _folderId;
        private readonly string _folderPath;

        public SelectedFolderEventArgs(Guid folderId, string folderPath)
        {
            _folderId = folderId;
            _folderPath = folderPath;
        }


        public Guid FolderId
        {
            get { return _folderId; }
        }

        public string FolderPath
        {
            get { return _folderPath; }
        }
    }

    public delegate void FolderSelected(object sender, SelectedFolderEventArgs e);
}