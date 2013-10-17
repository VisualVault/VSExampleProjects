using System;
using System.Windows.Forms;
using VisualVault.Examples.Common;
using VisualVault.ExamplesCs.TreeView_Examples;

namespace VisualVault.ExamplesCs.Document_MetaData
{
    ///<summary>
    ///
    ///</summary>
    public partial class DocumentMetaData : Form
    {
        private VVRuntime.VisualVault.Library.DocumentLibrary _library;
        private VVRuntime.VisualVault.Vault _vault;
        private Guid _selectedFolderID;
        
        public DocumentMetaData()
        {
            InitializeComponent();

            if (treeView1 != null) treeView1.BeforeExpand += TreeView1BeforeExpand;

            if (treeView1 != null) treeView1.BeforeSelect += TreeView1BeforeSelect;

            txtServerURL.Text = Constants.SoapApiServerUrl;
            txtUserID.Text = Constants.UserId;
            txtPassword.Text = Constants.Password;
            txtDeveloperKey.Text = Constants.DeveloperKey;
            txtDeveloperSecret.Text = Constants.DeveloperSecret;
        }

        private void BtnGetFoldersClick(object sender, EventArgs e)
        {
            InitializeTreeview();
        }

        private void AuthenticateUser(string serverUrl, string userID, string password)
        {
            _vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userID, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

            if (_vault != null)
            {
                _library = _vault.DefaultStore.Library;

                tabControl1.SelectTab(1);
            }else
            {
                MessageBox.Show("Login Failed", "Login Failed");
            }
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
                    node = (VvTreeNode)treeView1.Nodes[0];

                    //select the first folder in the tree
                    if (node != null)
                    {
                        treeView1.SelectedNode = node;
                        _selectedFolderID = _vault.DefaultStore.Library.GetFolder(node.NodeID).FolderID;
                    }
                }
            }
        }

        void TreeView1BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            var node = (VvTreeNode)e.Node;

            if (node != null)
            {
                _selectedFolderID = node.NodeID;

                if (_library != null) _library.GetFolder(_selectedFolderID);
            }
        }

        void TreeView1BeforeExpand(object sender, TreeViewCancelEventArgs e)
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

        private void BtnLoginClick(object sender, EventArgs e)
        {
            AuthenticateUser(txtServerURL.Text, txtUserID.Text, txtPassword.Text);
        }

        private void BtnGetFolderIndexFieldsClick(object sender, EventArgs e)
        {
            if (_vault != null)
            {
                if (_selectedFolderID != Guid.Empty)
                {
                    //get the folder's index field list
                    var folder = _library.GetFolder(_selectedFolderID);

                    var indexFields = folder.GetFolderIndexFields();
                    
                    lstFolderIndexFields.DisplayMember = "Name";
                    lstFolderIndexFields.DataSource = indexFields;
                    
                    Application.DoEvents();
                }
                else
                {
                    MessageBox.Show("Please select a target folder");
                }
            }
            else
            {
                MessageBox.Show("Please login");
            }
        }

    }
}