using System;
using System.Drawing;
using System.Web.Configuration;
using VVRuntime.VisualVault;
using VisualVault.Examples.Common;

namespace VisualVault.Examples.SingleSignOn
{
    public partial class ExternalWebApp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtVisualVaultApiUrl.Text))
            {
                var vaultUiUrl = WebConfigurationManager.AppSettings["VaultApiUrl"];
                txtVisualVaultApiUrl.Text = vaultUiUrl;
            }

            if (string.IsNullOrEmpty(txtAdminUserId.Text))
            {
                var adminUserID = WebConfigurationManager.AppSettings["vVUserID"];
                txtAdminUserId.Text = adminUserID;
            }

            if (string.IsNullOrEmpty(txtAdminPassword.Text))
            {
                var adminPassword = WebConfigurationManager.AppSettings["vVPassword"];
                txtAdminPassword.Text = adminPassword;
            }
        }

        protected void btnTokenTestOnClick(object sender, EventArgs e)
        {
            var ssoUserId = Request.QueryString["userId"];

            var loginToken = Request.QueryString["token"];

            if (!string.IsNullOrEmpty(ssoUserId) && !string.IsNullOrEmpty(loginToken))
            {
                var vaultApiUrl = txtVisualVaultApiUrl.Text;

                //admin User Id must be VaultAccess or VaultAdmins group member in the database being authenticated with
                var adminUserId = txtAdminUserId.Text;
                var adminPassword = txtAdminPassword.Text;

                Vault vault = VVRuntime.VisualVaultLogin.LoginImpersonate(vaultApiUrl, adminUserId, adminPassword, ssoUserId, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

                if (vault != null)
                {
                    VVRuntime.VisualVault.Security.User userAccount = vault.Sites.GetUser(ssoUserId);

                    if (userAccount != null)
                    {
                        if (userAccount.GetLoginToken() == loginToken)
                        {
                            //login token is valid
                            lblTestResults.ForeColor = Color.Green;
                            lblTestResults.Text = string.Format("Login token is valid. Authenticated User Id is: {0}", userAccount.UserID);
                        }else
                        {
                            lblTestResults.ForeColor = Color.Red;
                            lblTestResults.Text = string.Format("Invalid login token for User Id: {0}", userAccount.UserID);
                        }
                    }else
                    {
                        lblTestResults.ForeColor = Color.Red;
                        lblTestResults.Text = string.Format("Invalid User Id or Admin user has no access: {0}", ssoUserId);
                    }
                }else
                {
                    lblTestResults.ForeColor = Color.Red;
                    lblTestResults.Text = "Admin login to VisualVault failed";
                }
            }
        }
    }
}