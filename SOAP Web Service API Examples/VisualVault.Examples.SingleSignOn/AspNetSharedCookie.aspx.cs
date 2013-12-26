using System;
using System.Web;

namespace VisualVault.Examples.SingleSignOn
{
    public partial class AspNetSharedCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGetUserInfoClick(object sender, EventArgs e)
        {
            GetUserInfo();
        }

        private void GetUserInfo()
        {
            //show IsAuthenticated
            lblUserStatus.Text = string.Format("IsAuthenticated: {0}", HttpContext.Current.User.Identity.IsAuthenticated);

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //display user name
                lblUserId.Text = string.Format("User Name: {0}", HttpContext.Current.User.Identity.Name);
            }

        }
    }
}