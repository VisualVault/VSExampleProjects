using System;
using VVRuntime.VisualVault;
using VVRuntime.VisualVault.Library;
using VisualVault.Examples.Common;

namespace VisualVault.UserImport
{
    class Authentication
    {
        public class AuthenticationResult
        {
            public bool IsAuthenticated;
            public Vault Vault;
            public DocumentLibrary Library;
            public string StatusMessage = string.Empty;
        }

        public static AuthenticationResult AuthenticateUser(string userId, string password, string serverUrl)
        {
            var vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userId, password, Constants.DeveloperKey, Constants.DeveloperSecret, Constants.ProductId);

            var myResult = new AuthenticationResult();

            if (vault !=null)
            {
                myResult.Vault = vault;
            }

            if (myResult.Vault != null)
            {
                if (myResult.Vault.CurrentUser != null)
                    if (myResult.Vault.CurrentUser.GetCurrentUsID() != Guid.Empty)
                    {
                        myResult.Library = myResult.Vault.DefaultStore.Library;
                        myResult.IsAuthenticated = true;

                        myResult.StatusMessage = "Logged In";
                    }
                    else
                    {
                        // for older builds of VV that will give back a vault object but not a user when the product is not licensed
                        myResult.Vault = null;
                        myResult.IsAuthenticated = false;

                        myResult.StatusMessage = "Login Failed. Check the licensing requirements.";
                    }
            }
            else
            {
                myResult.StatusMessage = "Login Failed. Check the user name, the password, and/or the licensing requirements.";
            }

            return myResult;
        }
    }
}
