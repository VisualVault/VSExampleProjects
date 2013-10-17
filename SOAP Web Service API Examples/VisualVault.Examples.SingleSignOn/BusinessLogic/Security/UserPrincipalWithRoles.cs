using System.Security.Principal;

namespace VisualVault.Examples.SingleSignOn.BusinessLogic.Security
{
    /// <summary>
    /// Derived from GenericPrincipal with public roles property (useful for displaying roles user belongs to)
    /// </summary>
    public class UserPrincipalWithRoles : GenericPrincipal
    {
        public UserPrincipalWithRoles(IIdentity identity, string[] roles) : base(identity, roles)
        {
            Roles = roles;
        }

        public string[] Roles { get; private set; }
    }
}