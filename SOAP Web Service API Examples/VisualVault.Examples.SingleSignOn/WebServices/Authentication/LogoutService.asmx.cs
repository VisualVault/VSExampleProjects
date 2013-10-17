using System;
using System.Web.Services;
using VisualVault.Examples.SingleSignOn.BusinessLogic.Security;

namespace VisualVault.Examples.SingleSignOn.WebServices.Authentication
{
    /// <summary>
    /// This web service can be called after a user has been logged out of VisualVault (includes session timeout).  
    /// To enable this feature log into the VisualVault web UI, navigate to a database, navigate to 
    /// Admin Tools/Advanced/Outside Process Admin screen (outsideprocessadmin.aspx).
    /// Add an Outside Process, set the type to "SessionEnd" and set the URL to the URL of the SessionEnded web service
    /// method below. You also must go into the VisualVault web application configuration console and enable the "ExternalAuthentication" option.
    /// </summary>
    [WebService(Namespace = "http://WebService/VisualVault.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LogoutService : WebService
    {

        [WebMethod]
        public bool SessionEnded(string userId, Guid usId, string ldapInfo, string userProperties)
        {
            return Logout.EndUserSession(userId, usId, ldapInfo, userProperties);
        }
    }
}
