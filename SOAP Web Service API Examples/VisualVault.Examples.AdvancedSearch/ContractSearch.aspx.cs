using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web;
using System.Web.Configuration;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Library.Search;
using VisualVault.Examples.AdvancedSearch.DataAccess;
using VisualVault.Examples.AdvancedSearch.Extensions;
using VisualVault.Examples.Common;


namespace VisualVault.Examples.AdvancedSearch
{
    /// <summary>
    /// This page demonstrates the following:
    /// 
    /// Log into VisualVault API as an admin user with credentials stored in web.config
    /// Log into VisualVault API and impersonate the user who is currently logged into the VisualVault UI
    /// Execute a custom Document search and display the results
    /// </summary>
    public partial class ContractSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TopLevelFolderId = WebConfigurationManager.AppSettings["TopLevelFolderId"];

            if (IsPostBack)
            {
                lblStatusMessage.Text = "";
            }
        }

        #region Properties

        private string TopLevelFolderId { get; set; }

        #endregion

        #region Control Event Handlers

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            //Authenticate either the admin user or the authenticated user depending upon the 
            //ImpersonateAuthenticatedUser web.config setting

            bool impersonateUser = WebConfigurationManager.AppSettings["ImpersonateAuthenticatedUser"].ToBool();
            
            var vault = AuthenticateWithVault(impersonateUser);

            if (vault != null)
            {
                LoadGrid(vault);
            }
        }
        

        #endregion

        #region Methods

        public IDictionary<string, string> GetSearchFields()
        {
            var searchFields = new Dictionary<string, string>();

            //you could make this dynamic (iterate through all controls and get name/value pairs if value.length>0

            if (txtMtn.Text.Length > 0) searchFields.Add("MTN", txtMtn.Text);
            if (txtEsn.Text.Length > 0) searchFields.Add("ESN", txtEsn.Text);
            if (cboSigned.Text.Length > 0) searchFields.Add("Signed", cboSigned.Text);
            if (txtAgentId.Text.Length > 0) searchFields.Add("Agent ID", txtAgentId.Text);
            if (txtAccountNumber.Text.Length > 0) searchFields.Add("Account Number", txtAccountNumber.Text);

            return searchFields;
        }

        private Vault AuthenticateWithVault(bool impersonateAuthenticatedUser)
        {
            Vault vault;

            string vaultApiUrl = WebConfigurationManager.AppSettings["VaultApiUrl"];
            string vVUserId = WebConfigurationManager.AppSettings["vVUserID"];
            string vVPassword = WebConfigurationManager.AppSettings["vVPassword"];

            //login to VV Server

            if (impersonateAuthenticatedUser)
            {
                //Login to VisualVault API and impersonate the user who is 
                //currently logged into VisualVault

                vault = VVRuntime.VisualVaultLogin.LoginImpersonate(vaultApiUrl, vVUserId, vVPassword, HttpContext.Current.User.Identity.Name,Constants.DeveloperKey,Constants.DeveloperSecret,Constants.ProductId);
   
            }else
            {
                //Login using the admin credentials stored in the web.config file.
                //for a production environment you can encrypt these credentials in the config file
                //and decrypt them here before calling Login.

                vault = VVRuntime.VisualVaultLogin.Login(vaultApiUrl, vVUserId, vVPassword, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId); 
            }
            
            if (vault == null)
            {
                DisplayMessage(string.Format("{0} unable to authenticate with server {1}", HttpContext.Current.User.Identity.Name, vaultApiUrl), true);
            }

            return vault;
        }

        private void DisplayMessage(string message, bool isError)
        {
            lblStatusMessage.Text = message;

            if (isError)
            {
                lblStatusMessage.ForeColor = Color.Red;
                lblStatusMessage.Font.Bold = true;
            }
            else
            {
                lblStatusMessage.ForeColor = Color.Black;
                lblStatusMessage.Font.Bold = true;
            }
        }

        private void LoadGrid(Vault vault)
        {
            //setup search

            var searchFields = GetSearchFields();

            if (searchFields.Count > 0)
            {
                var search = new DataAccess.DocumentSearch(vault);

                Guid searchGroupId = search.LibrarySearch.CreateNewSearchGroup(SearchLogicalOperatorType.AndOperator);

                var searchParameters = new List<SearchParameterItem>();

                foreach (var searchField in searchFields)
                {

                    searchParameters.Add(new SearchParameterItem
                    {
                        LogicalOperatorType = SearchLogicalOperatorType.AndOperator,
                        OperatorType = SearchOperatorType.Contain,
                        SearchField = searchField.Key,
                        SearchPhrase = searchField.Value,
                        SearchGroupId = searchGroupId
                    });
                }

                var folderIds = new List<string>();

                if (TopLevelFolderId.IsGuid())
                {
                    folderIds.Add(TopLevelFolderId);
                }
                else
                {
                    folderIds.Add(vault.DefaultStore.Library.DocumentLibraryID.ToString());
                }

                //execute search
                var documentList = search.SearchFiles(folderIds, searchParameters, true);

                //bind to grid view
                if (documentList != null)
                {
                    gvSearchResults.AutoGenerateColumns = false;
                    gvSearchResults.DataSource = documentList;
                    gvSearchResults.DataBind();
                }
            }
        }

        #endregion
        
    }
}
