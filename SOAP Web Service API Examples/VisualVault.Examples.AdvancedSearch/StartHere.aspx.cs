using System;


namespace VisualVault.Examples.AdvancedSearch
{
    public partial class StartHere : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                lblStatusMessage.Text = "";
            }
        }

        #region Control Event Handlers

        protected void BtnAdvancedDocumentSearchClick(object sender, EventArgs e)
        {
            Response.Redirect("AdvancedDocumentSearch.aspx");
        }

        #endregion
     
    }
}