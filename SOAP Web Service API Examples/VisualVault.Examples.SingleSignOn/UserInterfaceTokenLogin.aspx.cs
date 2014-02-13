using System;
using System.Drawing;
using System.Web.Configuration;
using VVRuntime.VisualVault;
using VisualVault.Examples.Common;

namespace VisualVault.Examples.SingleSignOn
{
    public partial class UserInterfaceTokenLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //populate input fields with default values stored in web.config
            if (string.IsNullOrEmpty(txtImpersonatedUserId.Text))
            {
                var impersonatedUserId = WebConfigurationManager.AppSettings["ImpersonatedUserId"];

                txtImpersonatedUserId.Text = impersonatedUserId;
            }

            if (string.IsNullOrEmpty(txtVisualVaultUrl.Text))
            {
                var vaultUiUrl = WebConfigurationManager.AppSettings["VaultUiURL"];
                txtVisualVaultUrl.Text = vaultUiUrl;
            }

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

        protected void BtnBuildTokenLoginUrl(object sender, EventArgs e)
        {
            //launch Vault Url by impersonating a named user
            LaunchVaultUrl("vvlogin.aspx");
        }

        private void LaunchVaultUrl(string pageName, Vault vault = null)
        {
            try
            {
                if (vault == null)
                {
                    vault = AuthenticateWithVault("");
                }

                if (vault != null)
                {
                    var impersonatedUserId = txtImpersonatedUserId.Text;

                    var user = vault.Sites.GetUser(impersonatedUserId);

                    if (user != null)
                    {
                        var loginToken = user.GetLoginToken();

                        var vaultUiUrl = txtVisualVaultUrl.Text;

                        if (pageName.Length > 0)
                        {
                            if (!vaultUiUrl.EndsWith(@"/"))
                            {
                                vaultUiUrl += @"/";
                            }

                            vaultUiUrl += pageName;
                        }

                        var s = "?";

                        if (vaultUiUrl.IndexOf("?", StringComparison.Ordinal) >= 0)
                        {
                            s = "&";
                        }

                        var tokenLoginURl = string.Format("{0}{1}token={2}", vaultUiUrl, s, loginToken);

                        txtTokenLoginUrl.Text = tokenLoginURl;
                    }

                }
            }
            catch (Exception ex)
            {
                DisplayMessage(string.Format("Error {0}", ex.Message), true);
            }
        }

        private Vault AuthenticateWithVault(string impersonatedUserId)
        {
            var vaultApiUrl = WebConfigurationManager.AppSettings["VaultApiUrl"];
            var adminUserID = txtAdminUserId.Text;
            var adminPassword = txtAdminPassword.Text;

            //login to VV Server
            var vault = impersonatedUserId.Length > 0 ? VVRuntime.VisualVaultLogin.LoginImpersonate(vaultApiUrl, adminUserID, adminPassword, impersonatedUserId, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId) : VVRuntime.VisualVaultLogin.Login(vaultApiUrl, adminUserID, adminPassword, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

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
    }
}