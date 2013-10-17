using System;
using System.Windows.Forms;
using VisualVault.Examples.Common;

namespace VisualVault.ExamplesCs.Document_Search
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Search : Form
    {
        private VVRuntime.VisualVault.Library.DocumentLibrary _library;
        private Guid _defaultStoreID;
        private VVRuntime.VisualVault.Vault _vault;

        public Search()
        {
            InitializeComponent();

            txtServerURL.Text = Constants.SoapApiServerUrl;
            txtDeveloperKey.Text = Constants.DeveloperKey;
            txtDeveloperSecret.Text = Constants.DeveloperSecret;
            txtUserID.Text = Constants.UserId;
            txtPassword.Text = Constants.Password;
        }

        private void BtnLoginClick(object sender, EventArgs e)
        {
            AuthenticateUser(txtServerURL.Text, txtUserID.Text, txtPassword.Text);
        }

        private void AuthenticateUser(string serverUrl, string userID, string password)
        {
            _vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userID, password,Constants.DeveloperKey,Constants.DeveloperSecret,Constants.ProductId);

            if (_vault != null)
            {
                _library = _vault.DefaultStore.Library;
                _defaultStoreID = _vault.DefaultStoreID;

                tabControl1.SelectTab(1);
            }
            else
            {
                MessageBox.Show("Login Failed", "Login Failed");
            }
        }

        private string buildDocumentLink(VVRuntime.VisualVault.Library.Documents.Document document)
        {
            return string.Format("{0}ViewFile.aspx?DlId={1}", _vault.VaultConfiguration.RoutedContentBase, document.DlID);
        }

        private void BtnSimpleSearchClick(object sender, EventArgs e)
        {
            if (_library != null)
            {
                if (txtSimpleSearch.Text.Length > 0)
                {
                    var documents = _library.SearchForDocuments(txtSimpleSearch.Text);

                    foreach (VVRuntime.VisualVault.Library.Documents.Document document in documents)
                    {
                        System.Diagnostics.Debug.WriteLine(buildDocumentLink(document));
                    }
                    
                    var documentList = new BindingSource { DataSource = documents };

                    dgvSimpleSearch.DataSource = documentList;

                }
            }
        }

        private void BtnAdvancedSearchClick(object sender, EventArgs e)
        {
            if (_library != null & txtFieldName.Text.Length > 0 & txtSearchPhrase2.Text.Length > 0)
            {
                // this searches all folders
                // to search a single folder (and optionally its subfolders) use a VisualVault folder's ID
                // rather than using the store ID
                Guid folderId = _defaultStoreID;
                const bool includeSubfolders = true;

                string fieldName = txtFieldName.Text;
                string searchPhrase = txtSearchPhrase2.Text;

                var mySearch = _library.NewSearch();
                mySearch.AddSearchFolder(folderId, includeSubfolders);

                var myGroupID = mySearch.CreateNewSearchGroup(VVRuntime.VisualVault.Library.Search.SearchLogicalOperatorType.AndOperator);
                mySearch.AddSearchParameter(fieldName, VVRuntime.VisualVault.Library.Search.SearchOperatorType.Contain, searchPhrase, VVRuntime.VisualVault.Library.Search.SearchLogicalOperatorType.OrOperator, myGroupID);

                var documents = _library.SearchForDocuments(mySearch);

                if (documents != null)
                {
                    var documentList = new BindingSource { DataSource = documents };

                    dgvAdvancedSearch.DataSource = documentList;
                }
            }
        }
    }

}


