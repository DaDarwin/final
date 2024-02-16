
namespace final.Services;

public class ProfileService(ProfileRepository repo)
{
    private readonly ProfileRepository repo = repo;

    internal Profile GetProfile(int id)
    {
        Profile profile = repo.GetProfile(id);
        if (profile == null)
        {
            throw new Exception($"No Profile with Id: {id}");
        }
        return profile;
    }

    internal List<Keep> GetProfileKeeps(int id)
    {
        this.GetProfile(id);
        return repo.GetProfileKeeps(id);
    }

    internal List<Vault> GetProfileVaults(int id, string user)
    {
        this.GetProfile(id);
        List<Vault> vaults = repo.GetProfileVaults(id);

        return vaults.FindAll(vault => vault.IsPrivate == false || vault.CreatorId == user);
    }
}