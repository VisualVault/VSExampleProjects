using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualVault.Forms.Import.Entities.Profiles;
using VVRestApi.Vault;
using VVRestApi.Vault.Library;

namespace VisualVault.Forms.Import.BusinessLogic
{
    public class FolderService
    {
        private readonly VaultApi _vaultApi;
        private Profile _profile;

        public FolderService(VaultApi vault, Profile profile)
        {
            _vaultApi = vault;
            _profile = profile;
        }

        public int ApplySecurityToFolder(Guid folderId,List<SecurityMemberApplyAction> securityActions,bool includeAllSubfolders)
        {
            int folderCount = _vaultApi.Folders.UpdateSecurityMembers(folderId, securityActions, includeAllSubfolders);

            return folderCount;
        }
    }
}
