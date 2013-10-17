using System;
using System.Web;
using VisualVault.Examples.SingleSignOn.BusinessLogic.Security;

namespace VisualVault.Examples.SingleSignOn
{
    public class Global : HttpApplication
    {
        /// <summary>
        /// Called on each request when application acquires session state.  The first time this method is callled
        /// Session will be null and IsAuthenticated should be false.  Second request will have session and if
        /// user successfully logs into VisualVault IsAuthenticated will be true for subsequent requests.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //Get a UserPrincipalWithRoles object which contains roles from the VisualVault forms authentication 
                //cookie.  This is a GenericPrincipal type with public Roles property and transformed user name / role names.
                var userPrincipalWithRoles = FormsAuthHelper.GetUserPricipalWithRoles();

                if (userPrincipalWithRoles != null)
                {
                    //Replace the current user principal with the new one so it will flow through the request path.  
                    //userPrincipleWithRoles contains the roles stored in the forms authentication cookie by VisualVault
                    //and exposes the roles array as a public property
                    HttpContext.Current.User = userPrincipalWithRoles;
                }
            }
        }
    }
}