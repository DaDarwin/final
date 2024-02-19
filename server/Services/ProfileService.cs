
namespace final.Services;

public class ProfileService(ProfileRepository repo)
{
    private readonly ProfileRepository repo = repo;

    internal Profile GetProfile(string id)
    {
        Profile profile = repo.GetProfile(id);
        if (profile == null)
        {
            throw new Exception($"No Profile with Id: {id}");
        }
        return profile;
    }

    internal List<Keep> GetProfileKeeps(string id)
    {
        this.GetProfile(id);
        return repo.GetProfileKeeps(id);
    }

    internal List<Vault> GetProfileVaults(string id, string user)
    {
        this.GetProfile(id);
        List<Vault> vaults = repo.GetProfileVaults(id);

        return vaults.FindAll(vault => vault.IsPrivate == false || vault.CreatorId == user);
    }
}