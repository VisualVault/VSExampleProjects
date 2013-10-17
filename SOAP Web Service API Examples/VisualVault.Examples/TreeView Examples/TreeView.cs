using System;
using VisualVault.Examples.Common;
using VisualVault.ExamplesCs.TreeView_Examples;
using System.Windows.Forms;

namespace VisualVault.ExamplesCs
{
    ///<summary>
    ///
    ///</summary>
    public partial class TreeView : Form
    {
        private VVRuntime.VisualVault.Library.DocumentLibrary _library;
        private VVRuntime.VisualVault.Vault _vault;
        private VVRuntime.VisualVault.Library.Folders.Folder _selectedFolder;
        private Guid _selectedFolderID;

        ///<summary>
        ///
        ///</summary>
        public TreeView()
        {
            InitializeComponent();

            if (treeView1 != null) treeView1.BeforeExpand += treeView1_BeforeExpand;

            if (treeView1 != null) treeView1.BeforeSelect += treeView1_BeforeSelect;

            txtServerURL.Text = Constants.SoapApiServerUrl;
            txtDeveloperKey.Text = Constants.DeveloperKey;
            txtDeveloperSecret.Text = Constants.DeveloperSecret;
            txtUserID.Text = Constants.UserId;
            txtPassword.Text = Constants.Password;
        }

        /// <summary>
        /// 
        /// </summary>
        public VVRuntime.VisualVault.Library.Folders.Folder SelectedFolder
        {
            get { return _selectedFolder; }
        }

        private void InitializeTreeview()
        {
            if (_vault != null)
            {
                var folderCollection = _vault.DefaultStore.Library.GetTopLevelFolders();

                VvTreeNode node;
                foreach (VVRuntime.VisualVault.Library.Folders.Folder folder in folderCollection)
                {
                    node = new VvTreeNode(folder.FolderID, folder.Name);
                    node.Nodes.Add(new VvTreeNode(Guid.Empty, ""));
                    treeView1.Nodes.Add(node);
                }

                if (treeView1.GetNodeCount(false) > 0)
                {
                    node = (VvTreeNode) treeView1.Nodes[0];

                    //select the first folder in the tree
                    if (node != null)
                    {
                        treeView1.SelectedNode = node;
                        _selectedFolderID = _vault.DefaultStore.Library.GetFolder(node.NodeID).FolderID;
                    }
                }
            }
        }

        void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var node = (VvTreeNode)e.Node;

            if (node != null)
            {
                _selectedFolderID = node.NodeID;

                _selectedFolder = _library.GetFolder(_selectedFolderID);
            }
        }

        void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            var node = (VvTreeNode)e.Node;

            if (node.GetNodeCount(true) == 1)
            {
                VvTreeNode childnode = (VvTreeNode)node.Nodes[0];

                //if node has an empty ID it has not been initialized
                if (Guid.Empty.Equals(childnode.NodeID))
                {
                    node.Nodes.Remove(childnode);

                    Guid folderID = node.NodeID;

                    VVRuntime.VisualVault.Library.Folders.FolderCollection folderCollection = _vault.DefaultStore.Library.GetChildFolders(folderID);

                    foreach (VVRuntime.VisualVault.Library.Folders.Folder folder in folderCollection)
                    {
                        VvTreeNode newnode = new VvTreeNode(folder.FolderID, folder.Name);

                        newnode.Nodes.Add(new VvTreeNode(Guid.Empty, ""));

                        node.Nodes.Add(newnode);
                    }
                }
            }
        }

        private void AuthenticateUser(string serverUrl, string userID, string password)
        {
            _vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userID, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

             if (_vault != null)
            {
                _library = _vault.DefaultStore.Library;
                
                tabControl1.SelectTab(1);
            }
            else
            {
                MessageBox.Show("Login Failed", "Login Failed");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            AuthenticateUser(txtServerURL.Text, txtUserID.Text, txtPassword.Text);
        }

        private void btnGetFolders_Click(object sender, EventArgs e)
        {
            InitializeTreeview();
        }
        
    }
}
