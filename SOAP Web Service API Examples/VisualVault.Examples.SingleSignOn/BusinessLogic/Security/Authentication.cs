using System;
using System.Collections.Generic;
using System.Web.Configuration;
using System.Web.Script.Serialization;

namespace VisualVault.Examples.SingleSignOn.BusinessLogic.Security
{
    public class Authentication
    {
        internal static bool Authenticate(string userId, string password, ref string userProperties)
        {
            bool success;

            try
            {
                //You can return a JSON string with key/value pairs which will be stored with the VisualVault user object
                //allows you to store custom values with the VisualVault user object and retrieve these values from
                //within the VisualVault PageViewer control.  For example, get a login token from another application
                //and use the token with the PageViewer control like this: http://myserver/website/mypage.aspx?sessioninfo=[sessioninfo]
                //where [sessioninfo] is a value you stored as a key value pair when visualVault called your authentication web service.
                var sourcelist = new List<KeyValuePair<string, string>>
                                     {
                                         new KeyValuePair<string, string>("sessioninfo","some value")
                                     };

                var serializer = new JavaScriptSerializer();

                //Convert key value list into JSON format
                //This results in a JSON formatted string:
                //"[{"Key":"sessionid","Value":"12345"},{"Key":"sessioninfo","Value":"678910"}]";

                userProperties = serializer.Serialize(sourcelist);

                success = true;


            }
            catch (Exception ex)
            {
                IDictionary<string, object> context = new Dictionary<string, object> { { "userProperties", userProperties } };

                //Logging.LogException("Exception in Authentication.Authenticate.", ex, context);

                success = false;
            }

            //force authentication to be successful? (used for testing)
            bool forceAuthentication = bool.Parse(WebConfigurationManager.AppSettings["ForceAuthentication"] ?? "false");

            if (forceAuthentication)
            {
                success = true;
            }

            return success;
        }
        
    }
}