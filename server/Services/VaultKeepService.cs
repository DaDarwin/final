

namespace final.Services;


public class VaultKeepService(VaultKeepRepository repo, VaultService vaultService)
{
    private readonly VaultKeepRepository repo = repo;
    private readonly VaultService vaultService = vaultService;

    internal VaultKeep CreateVaultKeep(VaultKeep data, string userId)
    {
        Vault vault = vaultService.GetVault(data.VaultId, userId);
        if (vault.CreatorId != userId)
        {
            throw new Exception("Not your Vault");
        }
        return repo.CreateVaultKeep(data);
    }

    internal string DeleteVaultKeep(int id, string userId)
    {
        VaultKeep vaultKeep = repo.GetVaultKeep(id);
        Vault vault = vaultService.GetVault(vaultKeep.VaultId, userId);
        if (vault.CreatorId != userId)
        {
            throw new Exception("Not your Vault");
        }
        repo.DeleteVaultKeep(id);
        return "Vault Keep Removed";
    }
}