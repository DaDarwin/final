

namespace final.Services;

public class VaultService(VaultRepository repo)
{
    private readonly VaultRepository repo = repo;

    internal object CreateVault(Vault data)
    {
        return repo.CreateVault(data);
    }

    internal object GetVault(int id, string userId)
    {
        Vault vault = repo.GetVault(id);
        if ((vault == null) || (vault.IsPrivate && userId != vault.CreatorId))
        {
            throw new Exception($"No Vault Found With ID: {id}");
        }
        return vault;
    }
}