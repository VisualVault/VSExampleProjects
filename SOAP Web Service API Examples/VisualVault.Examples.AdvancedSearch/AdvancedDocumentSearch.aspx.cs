using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Library.Documents;
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
    public partial class AdvancedDocumentSearch : System.Web.UI.Page
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

        public string GridSortExpression
        {
            get
            {
                if (ViewState["GridSortExpression"] != null)
                {
                    return (string)(ViewState["GridSortExpression"]);
                }

                return string.Empty;
            }
            set
            {
                if (ViewState["GridSortExpression"] != null)
                {
                    (ViewState["GridSortExpression"]) = value;
                }
                else
                {
                    ViewState.Add("GridSortExpression", value);
                }
            }
        }

        public string GridSortDirection
        {
            get
            {
                if (ViewState["GridSortDirection"] != null)
                {
                    return (string)(ViewState["GridSortDirection"]);
                }

                return string.Empty;
            }
            set
            {
                if (ViewState["GridSortDirection"] != null)
                {
                    (ViewState["GridSortDirection"]) = value;
                }
                else
                {
                    ViewState.Add("GridSortDirection", value);
                }
            }
        }

        public bool ImpersonateUser
        {
            get
            {
                if (ViewState["ImpersonateUser"] != null)
                {
                    return (bool)(ViewState["ImpersonateUser"]);
                }

                return false;
            }
            set
            {
                if (ViewState["ImpersonateUser"] != null)
                {
                    (ViewState["ImpersonateUser"]) = value;
                }
                else
                {
                    ViewState.Add("ImpersonateUser", value);
                }
            }
        }

        #endregion

        #region Control Event Handlers

        protected void BtnSearchClick(object sender, EventArgs e)
        {
            ImpersonateUser = false;

            LoadGrid();
        }

        protected void BtnImpersonatedSearchClick(object sender, EventArgs e)
        {
            ImpersonateUser = true;

            LoadGrid();
        }

        protected void GridViewSorting(object sender, GridViewSortEventArgs e)
        {
            if (e.SortExpression == GridSortExpression)
            {
                //if user clicked same column as the previous request then reverse the sort direction
                GridSortDirection = GridSortDirection == "asc" ? "desc" : "asc";
            }
            else
            {
                GridSortDirection = "asc";
            }

            //save the sort expression in viewstate
            GridSortExpression = e.SortExpression;

            LoadGrid();
        }

        #endregion

        #region Methods

        public IDictionary<string, string> GetSearchFields()
        {
            var searchFields = new Dictionary<string, string>();

            //you could make this dynamic (iterate through all controls and get name/value pairs if value.length>0

            if (txtInvoiceNumber.Text.Length > 0) searchFields.Add("Invoice", txtInvoiceNumber.Text);
            if (txtDocType.Text.Length > 0) searchFields.Add("Doc Type", txtDocType.Text);
            if (txtCompanyName.Text.Length > 0) searchFields.Add("Company Name", txtCompanyName.Text);
            if (txtCertNo.Text.Length > 0) searchFields.Add("Cert No", txtCertNo.Text);

            return searchFields;
        }

        private Vault AuthenticateWithVault()
        {
            Vault vault;

            var vaultApiUrl = WebConfigurationManager.AppSettings["VaultApiUrl"];
            var vVUserId = WebConfigurationManager.AppSettings["vVUserID"];
            var vVPassword = WebConfigurationManager.AppSettings["vVPassword"];

            if (ImpersonateUser)
            {
                //Login to VisualVault API and impersonate the user who is 
                //currently logged into VisualVault

                vault = VVRuntime.VisualVaultLogin.LoginImpersonate(vaultApiUrl, vVUserId, vVPassword, HttpContext.Current.User.Identity.Name, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

            }
            else
            {
                //Login using the admin credentials stored in the web.config file.
                //for a production environment you can encrypt these credentials in the config file
                //and decrypt them here before calling Login.

                vault = VVRuntime.VisualVaultLogin.Login(vaultApiUrl, vVUserId, vVPassword, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);
            }

            if (vault != null)
            {
                //cache the vault object for 20 minutes from the last accessed time (20 minute sliding expiration)
                Cache.Insert(vaultApiUrl, vault, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 20, 0));
            }
            else
            {
                DisplayMessage(string.Format("Unable to connect to server located at {0}", vaultApiUrl), true);
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

        private void LoadGrid()
        {
            //Get search results from server
            var documentList = GetDocumentList();

            //bind to gridView
            if (documentList != null)
            {
                if (!string.IsNullOrEmpty(GridSortExpression))
                {
                    if (!string.IsNullOrEmpty(GridSortDirection))
                    {
                        if (GridSortDirection.ToLower() == "asc")
                        {
                            documentList.ApplySort(GridSortExpression, ListSortDirection.Ascending);
                        }
                        else
                        {
                            documentList.ApplySort(GridSortExpression, ListSortDirection.Descending);
                        }
                    }
                }

                gvSearchResults.AutoGenerateColumns = false;
                gvSearchResults.DataSource = documentList;
                gvSearchResults.DataBind();
            }

        }

        DocumentBindingListCollection GetDocumentList()
        {
            var searchFields = GetSearchFields();

            //create a cache key which will change if the search criteria entered by the user changes
            var cacheKey = searchFields.Aggregate("", (current, searchField) => current + searchField);

            //attempt to get the documentBindingList from cache
            var documentBindingList = (DocumentBindingListCollection)Cache[cacheKey];

            if (documentBindingList == null)
            {
                //authenticate with server
                var vault = AuthenticateWithVault();

                if (searchFields.Count > 0)
                {
                    var search = new DocumentSearch(vault);

                    var searchGroupId = search.LibrarySearch.CreateNewSearchGroup(SearchLogicalOperatorType.AndOperator);

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

                    var folderIds = new List<string>
                                        {
                                            TopLevelFolderId.IsGuid()
                                                ? TopLevelFolderId
                                                : vault.DefaultStore.Library.DocumentLibraryID.ToString()
                                        };

                    //execute search
                    documentBindingList = search.SearchFiles(folderIds, searchParameters, true);

                    //cache the document list for 20 minutes from the last accessed time (20 minute sliding expiration)
                    Cache.Insert(cacheKey, documentBindingList, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, 0, 20, 0));
                }
            }

            return documentBindingList;
        }

        #endregion
    }
}
