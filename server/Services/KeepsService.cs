


namespace final.Services;

public class KeepsService(KeepsRepository repo)
{
    private readonly KeepsRepository repo = repo;

    internal Keep CreateKeep(Keep data)
    {
        return repo.CreateKeep(data);
    }

    internal string DeleteKeep(int id, string userId)
    {
        Keep keep = this.GetKeep(id);
        if (keep.CreatorId != userId)
        {
            throw new Exception("Not Your's Bud");
        }
        repo.DeleteKeep(id);
        return $"{keep.Name} was Deleted";
    }

    internal Keep GetKeep(int id)
    {
        Keep keep = repo.GetKeep(id);
        if (keep?.Name == null)
        {
            throw new Exception($"No Keep With Id: {id}");
        }

        return keep;
    }

    internal List<Keep> GetKeeps()
    {
        return repo.GetKeeps();
    }

    internal Keep UpdateKeep(Keep data, int id)
    {
        Keep keep = this.GetKeep(id);
        if (keep.CreatorId != data.CreatorId)
        {
            throw new Exception("Not Your's Bud");
        }
        keep.Name = data.Name ?? keep.Name;
        keep.Description = data.Description ?? keep.Description;
        keep.Img = data.Img ?? keep.Img;
        return repo.UpdateKeep(keep);

    }

    internal Keep IncrementKeepViews(int id)
    {
        Keep keep = this.GetKeep(id);
        keep.Views += 1;
        return repo.UpdateKeep(keep);
    }
}

