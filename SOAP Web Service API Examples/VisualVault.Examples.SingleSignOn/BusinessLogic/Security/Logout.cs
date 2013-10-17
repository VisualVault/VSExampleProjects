using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace VisualVault.Examples.SingleSignOn.BusinessLogic.Security
{
    public class Logout
    {
        /// <summary>
        /// Notify another application of VisualVault Session End
        /// </summary>
        /// <param name="userId">VisualVault User Id whose session has ended</param>
        /// <param name="usId">UsID (primary key) of the user whose session has ended</param>
        /// <param name="ldapInfo">Ldap path for user</param>
        /// <param name="userProperties">JSON encoded string of custom user properties set during authentication</param>
        /// <returns></returns>
        internal static bool EndUserSession(string userId, Guid usId, string ldapInfo, string userProperties)
        {
            bool success = true;
            

            IDictionary<string, object> context = new Dictionary<string, object>
                                                      {
                                                          { "userId", userId },
                                                          { "usId",usId},
                                                          { "ldapInfo", ldapInfo},
                                                          {"userProperties",userProperties}
                                                      };

            try
            {
                //if(Logging.IsVerboseLoggingEnabled())
                //{
                //    Logging.LogMessage("EndUserSession Called",TraceEventType.Information,context);
                //}

                //Get the session info key value pair passed in from VisualVault
                //This value was set in the Authenticate class and can contain custom data
                //from another applicaiton.
                //
                //userProperties is a JSON encoded string
                List<UserKeyValuePair> list = HandleUserProperties(userProperties);

                //search for cookie name just for testing
                //UserKeyValuePair valuePair = list.Find(pair => pair.Key == "cName");

                //search for sessioninfo key set during authentication
                UserKeyValuePair valuePair = list.Find(pair => pair.Key == "sessioninfo");

                if (valuePair != null)
                {
                    //if sessioninfo key found you could invoke another application's web service to end user session
                    string sessionInfo = valuePair.Value;
                }
                else
                {
                    //if (Logging.IsVerboseLoggingEnabled())
                    //{
                    //    Logging.LogMessage("Null valuePair after parsing user properties in EndUserSession", TraceEventType.Error, context);
                    //}
                }
            }
            catch (Exception ex)
            {
                //Logging.LogException("Exception in EndUserSession.", ex, context);

                success = false;
            }

            return success;
        }
        
        /// <summary>
        /// Deserializes JSON object containing custom user data
        /// </summary>
        /// <param name="userProperties">JSON object string of user properties to be persisted in the user profile data</param>
        private static List<UserKeyValuePair> HandleUserProperties(string userProperties)
        {
            List<UserKeyValuePair> list;

            try
            {
                //initialize the JSON serializer
                var serializer = new JavaScriptSerializer();

                //deserialize the userproperties that were passed in from the web service call
                list = serializer.Deserialize<List<UserKeyValuePair>>(userProperties);
            }
            catch (Exception ex)
            {
                IDictionary<string, object> context = new Dictionary<string, object> {{"userProperties", userProperties}};

                //Logging.LogException("Exception in HandleUserProperties.", ex, context);
                
                list = null;
            }

            return list;
        }
    }
}