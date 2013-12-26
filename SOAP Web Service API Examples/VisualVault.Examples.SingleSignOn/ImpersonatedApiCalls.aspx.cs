using System;
using System.Drawing;
using System.Web.Configuration;
using VVRuntime.Common.Extensions;
using VVRuntime.VisualVault;
using VisualVault.Examples.Common;

namespace VisualVault.Examples.SingleSignOn
{
    public partial class ImpersonatedApiCalls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGetFormTemplatesList(object sender, EventArgs e)
        {
            try
            {
                var impersonatedUserId = WebConfigurationManager.AppSettings["ImpersonatedUserId"];

                var vault = AuthenticateWithVault(impersonatedUserId);

                if (vault != null)
                {
                    PopulateFormTemplates(vault);
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(string.Format("Error {0}", ex.Message), true);
            }
        }

        protected void BtnSubmitForm(object sender, EventArgs e)
        {
            try
            {
                var impersonatedUserId = WebConfigurationManager.AppSettings["ImpersonatedUserId"];

                var vault = AuthenticateWithVault(impersonatedUserId);

                if (vault != null)
                {
                    //If a form is selected in the form template drop down list
                    //redirect to the form fill in URL.
                    if (ddlFormTemplates.SelectedItem != null)
                    {
                        var formTemplateId = ddlFormTemplates.SelectedValue;

                        if (formTemplateId.IsGuid())
                        {
                            //launch Vault Url to fill in the form
                            var formFillInUrl = string.Format("Formviewer.aspx?formid={0}&hidemenu=true", formTemplateId);

                            LaunchVaultUrl(formFillInUrl, vault);
                        }
                    }
                    else
                    {
                        DisplayMessage("No form template selected", false);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(string.Format("Error {0}", ex.Message), true);
            }

        }

        protected void BtnGetFormDashboards(object sender, EventArgs e)
        {
            try
            {
                var impersonatedUserId = WebConfigurationManager.AppSettings["ImpersonatedUserId"];

                var vault = AuthenticateWithVault(impersonatedUserId);

                if (vault != null)
                {
                    PopulateFormDashboards(vault);
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(string.Format("Error {0}", ex.Message), true);
            }
        }

        protected void BtnDisplayDashboard(object sender, EventArgs e)
        {
            try
            {
                var impersonatedUserId = WebConfigurationManager.AppSettings["ImpersonatedUserId"];

                var vault = AuthenticateWithVault(impersonatedUserId);

                if (vault != null)
                {
                    //If a form is selected in the form template drop down list
                    //redirect to the form fill in URL.
                    if (ddlFormDashboards.SelectedItem != null)
                    {
                        var formDashboardId = ddlFormDashboards.SelectedValue;

                        if (formDashboardId.IsGuid())
                        {
                            //launch Vault Url to fill in the form
                            var formDashboardUrl = string.Format("FormDataDetails.aspx?ReportID={0}&hidemenu=true&Mode=ReadOnly", formDashboardId);

                            LaunchVaultUrl(formDashboardUrl, vault);
                        }
                    }
                    else
                    {
                        DisplayMessage("No form template selected", false);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(string.Format("Error {0}", ex.Message), true);
            }
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
                    var impersonatedUserId = WebConfigurationManager.AppSettings["ImpersonatedUserId"];

                    var user = vault.Sites.GetUser(impersonatedUserId);

                    if (user != null)
                    {
                        var loginToken = user.GetLoginToken();

                        var vaultUiUrl = WebConfigurationManager.AppSettings["VaultUiURL"];

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

                        var redirectUrl = string.Format("{0}{1}token={2}", vaultUiUrl, s, loginToken);

                        Response.Redirect(redirectUrl);
                    }

                }
            }
            catch (Exception ex)
            {
                DisplayMessage(string.Format("Error {0}", ex.Message), true);
            }
        }

        private static Vault AuthenticateWithVault(string impersonatedUserId)
        {
            var vaultApiUrl = WebConfigurationManager.AppSettings["VaultApiUrl"];
            var vVUserId = WebConfigurationManager.AppSettings["vVUserID"];
            var vVPassword = WebConfigurationManager.AppSettings["vVPassword"];

            //login to VV Server
            var vault = impersonatedUserId.Length > 0 ? VVRuntime.VisualVaultLogin.LoginImpersonate(vaultApiUrl, vVUserId, vVPassword, impersonatedUserId, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId) : VVRuntime.VisualVaultLogin.Login(vaultApiUrl, vVUserId, vVPassword, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

            return vault;
        }

        private void PopulateFormTemplates(Vault vault)
        {
            var formTemplateCollection = vault.Forms.GetFormTemplates();

            if (formTemplateCollection != null)
            {
                ddlFormTemplates.DataSource = formTemplateCollection;
                ddlFormTemplates.DataTextField = "FormTemplateName";
                ddlFormTemplates.DataValueField = "FormTemplateID";
                ddlFormTemplates.DataBind();
            }
        }

        private void PopulateFormDashboards(Vault vault)
        {
            var formDashboardCollection = vault.Forms.GetFormDashboards();

            if (formDashboardCollection != null)
            {
                ddlFormDashboards.DataSource = formDashboardCollection;
                ddlFormDashboards.DataTextField = "FormDashboardName";
                ddlFormDashboards.DataValueField = "FormDashboardID";
                ddlFormDashboards.DataBind();
            }
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