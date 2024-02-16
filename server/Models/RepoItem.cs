namespace final.Models;

public abstract class RepoItem<T>
{
    public T Id { get; set; }

    public DateTime DateCreated { get; set; }
    public DateTime DateUpdated { get; set; }


}