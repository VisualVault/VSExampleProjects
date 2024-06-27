using System;
using VisualVault.Forms.Import.Extensions;
using VVRestApi.Common;
using VVRestApi.Vault;
//using VVRuntime;
//using VVRuntime.VisualVault;

namespace VisualVault.Forms.Import.BusinessLogic
{
    class Authentication
    {
        public class AuthenticationResult
        {
            public bool IsAuthenticated;
            public VaultApi Vault;
            public string StatusMessage = string.Empty;
        }
        
        public static AuthenticationResult AuthenticateUser(string userId, string password, string serverUrl,string customerAlias, string databaseAlias)
        {
            //var vault = VVRuntime.VisualVaultLogin.Login(serverUrl, userId, password,"","",Guid.Empty);
            var myResult = new AuthenticationResult();

            try
            {
                var clientSecrets = new ClientSecrets
                {
                    ApiKey = userId,
                    ApiSecret = password,
                    OAuthTokenEndPoint = serverUrl + @"/oauth/token",
                    BaseUrl = serverUrl,
                    CustomerAlias = customerAlias,
                    DatabaseAlias = databaseAlias,
                    ApiVersion = "1",
                    Scope = "vault"
                };

                var vault = new VaultApi(clientSecrets);

                if (!vault.ApiTokens.AccessToken.IsNullOrEmpty())
                {
                    myResult.Vault = vault;
                    myResult.IsAuthenticated = true;
                    myResult.StatusMessage = "Logged In";
                }
                else
                {
                    myResult.StatusMessage = "Login Failed";
                }
            }catch(Exception ex)
            {

            }

            return myResult;
        }
    }
}
