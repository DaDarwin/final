
namespace final.Repositories;

public class ProfileRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal Profile GetProfile(int id)
    {
        string sql = @"
        SELECT 
        *
        FROM
        accounts
        WHERE accounts.id = @id;";
        return db.Query<Profile>(sql, new { id }).FirstOrDefault();
    }

    internal List<Keep> GetProfileKeeps(int id)
    {
        string sql = @"
        SELECT
        *
        FROM 
        keeps
        WHERE keeps.creatorId = @id;";
        return db.Query<Keep>(sql, new { id }).ToList();
    }

    internal List<Vault> GetProfileVaults(int id)
    {
        string sql = @"
        SELECT
        *
        FROM
        vaults
        WHERE vaults.creatorId = @id;";
        return db.Query<Vault>(sql, new { id }).ToList();
    }
}