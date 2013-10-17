using System.Web.Services;

namespace VisualVault.Examples.SingleSignOn.WebServices.Authentication
{
    /// <summary>
    /// This web service may be called after a user has authenticated with VisualVault.  
    /// The return value determines if VisualVault will complete the user authentication process.
    /// 
    /// You can also add custom property data to the VisualVault user account which can be used within
    /// the VisualVault pageviewer portal control (an iFrame).  To enable this feature log into the VisualVault
    /// web UI, navigate to a database, navigate to Admin Tools/Advanced/Outside Process Admin screen (outsideprocessadmin.aspx).
    /// Add an Outside Process, set the type to "Authentication" and set the URL to the URL of the Authenticate web service
    /// method below.  You also must go into the VisualVault web application configuration console and enable the "ExternalAuthentication" option.
    /// </summary>
    [WebService(Namespace = "http://WebService/VisualVault.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthenticationService : WebService
    {
        [WebMethod]
        public bool Authenticate(string userId, string password, string ldapPath, ref string userProperties)
        {
            return BusinessLogic.Security.Authentication.Authenticate(userId, password, ref userProperties);
        }
    }
}
