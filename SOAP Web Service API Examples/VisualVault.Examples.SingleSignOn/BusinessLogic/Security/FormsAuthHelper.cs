using System;
using System.Web;
using System.Web.Security;

namespace VisualVault.Examples.SingleSignOn.BusinessLogic.Security
{
    public class FormsAuthHelper
    {
        /// <summary>
        /// Return a user principal object which contains the roles (Ldap group names) 
        /// stored in the forms authentication ticket created by VisualVault and a User Name
        /// with the VisualVault multi-tenant user Guid value removed.
        /// </summary>
        /// <returns></returns>
        public static UserPrincipalWithRoles GetUserPricipalWithRoles()
        {
            UserPrincipalWithRoles userPrincipalWithRoles = null;

            string[] roles = GetUserRolesFromAuthCookie();

            //Change the User Name because VisualVault uses a colon delimited array for identity.Name
            string[] vvUserName = HttpContext.Current.User.Identity.Name.Split(new[] { ":::" }, StringSplitOptions.None);

            string newUserName = vvUserName[0];

            if (vvUserName.Length > 0)
            {
                newUserName = vvUserName[1];
            }

            var newIdentity = new System.Security.Principal.GenericIdentity(newUserName, "Forms");

            //Create a new user principal which contains the roles
            userPrincipalWithRoles = new UserPrincipalWithRoles(newIdentity, roles);

            return userPrincipalWithRoles;
        }

        /// <summary>
        /// Returns roles names stored in the forms authentication ticket
        /// </summary>
        /// <returns></returns>
        public static string[] GetUserRolesFromAuthCookie()
        {
            string[] roles = new string[] { };

            var userPrincipal = HttpContext.Current.User;

            if (userPrincipal != null && userPrincipal.Identity.IsAuthenticated)
            {
                var formsIdentity = (FormsIdentity)userPrincipal.Identity;

                var formsAuthenticationTicket = (formsIdentity.Ticket);

                if (!FormsAuthentication.CookiesSupported)
                {
                    //Get ticket from Url and decrypt
                    formsAuthenticationTicket = FormsAuthentication.Decrypt(formsIdentity.Ticket.Name);
                }

                if (formsAuthenticationTicket != null)
                    if (!string.IsNullOrEmpty(formsAuthenticationTicket.UserData))
                    {
                        //UserData string uses a triple colon delimeter between values and roles will always be the first value
                        string[] userData = formsAuthenticationTicket.UserData.Split(new[] { ":::" }, StringSplitOptions.None);

                        //Roles are a pipe delimited string
                        string[] roleDistinguishedNames = userData[0].Split('|');

                        //Return only the Ldap group names unless you need the fully qualified ldap path
                        int count = roleDistinguishedNames.Length;

                        roles = new string[count];

                        for (int i = 0; i < count; i++)
                        {
                            roles[i] = roleDistinguishedNames[i].Split(',')[0].ToLower().Replace("cn=", "");
                        }
                    }
            }

            return roles;
        }
        
    }
}