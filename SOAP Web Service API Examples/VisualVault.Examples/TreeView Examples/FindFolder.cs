using System.Windows.Forms;
using System.Linq;
using VVRuntime.VisualVault;
using VisualVault.Examples.Common;

namespace VisualVault.ExamplesCs
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FindFolder : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FindFolder()
        {
            InitializeComponent();

            txtServerURL.Text = Constants.SoapApiServerUrl;
            txtDeveloperKey.Text = Constants.DeveloperKey;
            txtDeveloperSecret.Text = Constants.DeveloperSecret;
        }

        private VVRuntime.VisualVault.Library.DocumentLibrary _library;

        private void BtnLoginClick(object sender, System.EventArgs e)
        {
            AuthenticateUser(txtServerURL.Text, txtUserID.Text, txtPassword.Text);
        }

        private void AuthenticateUser(string serverUrl, string userID, string password)
        {
            Vault vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userID, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

            if (vault != null)
            {
                _library = vault.DefaultStore.Library;

                MessageBox.Show("Login Success, enter Folder name to search for", "Login Success");
            }
            else
            {
                MessageBox.Show("Login Failed", "Login Failed");
            }
        }

        private void BtnFindFolderClick(object sender, System.EventArgs e)
        {
            if (_library != null)
            {
                VVRuntime.VisualVault.Library.Folders.Folder folder = _library.FindFolder(txtFolderName.Text);

                if (folder != null)
                {
                    MessageBox.Show("First folder found containing " + txtFolderName.Text +
                           " in its FolderName property was:" + folder.FolderPath);
                }

                VVRuntime.VisualVault.Library.Folders.FolderCollection folderCollection = _library.FindFolders(txtFolderName.Text);

                if (folderCollection != null)
                {
                    if (folderCollection.Count > 0)
                    {
                        MessageBox.Show(folderCollection.Count + " folders found containing "
                               + txtFolderName.Text + " in their FolderName property");
                    }
                }
                
                if (folderCollection != null)
                {
                    foreach (VVRuntime.VisualVault.Library.Folders.Folder f in folderCollection)
                    {
                        //do some work
                        string folderName = f.Name;
                    }
                }

                const string folderPath = @"/VisualVault/Test";

                //search folderCollection for a specific folder path
                var myFolder = from VVRuntime.VisualVault.Library.Folders.Folder f in folderCollection where f.FolderPath == folderPath select f;
            }
            else
            {
                MessageBox.Show("You are not logged in");
            }
        }
    }
}
