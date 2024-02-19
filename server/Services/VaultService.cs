


namespace final.Services;

public class VaultService(VaultRepository repo)
{
    private readonly VaultRepository repo = repo;

    internal Vault CreateVault(Vault data)
    {
        return repo.CreateVault(data);
    }

    internal string DeleteVault(int id, string userId)
    {
        Vault vault = this.GetVault(id, userId);
        if (vault.CreatorId != userId)
        {
            throw new Exception("Not Your's");
        }
        repo.DeleteVault(id);
        return $"{vault.Name} has been Deleted";
    }

    internal Vault GetVault(int id, string userId)
    {
        Vault vault = repo.GetVault(id);
        if ((vault == null) || (vault.IsPrivate && userId != vault.CreatorId))
        {
            throw new Exception($"No Vault Found With ID: {id}");
        }
        return vault;
    }

    internal List<VaultKeepView> GetVaultKeeps(int id, string userId)
    {
        this.GetVault(id, userId);
        return repo.GetVaultKeeps(id);
    }

    internal Vault UpdateVault(Vault data, int id)
    {
        Vault vault = this.GetVault(id, data.CreatorId);
        if (vault.CreatorId != data.CreatorId)
        {
            throw new Exception("Not Your's Bud");
        }
        vault.Name = data.Name ?? vault.Name;
        vault.Description = data.Description ?? vault.Description;
        vault.Img = data.Img ?? vault.Img;
        if (data.IsPrivate) vault.IsPrivate = true;
        else vault.IsPrivate = false;// No idea if this works
        return repo.UpdateVault(vault);

    }
}