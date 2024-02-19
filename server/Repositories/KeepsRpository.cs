




namespace final.Repositories;

public class KeepsRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal Keep CreateKeep(Keep data)
    {
        string sql = @"
        INSERT INTO
        keeps
        (name, description, img, creatorId)
        VALUES
        (@name, @description, @img, @creatorId);
        
        SELECT
        keeps.*,
        COUNT(vaultKeeps.id) as kept,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        WHERE keeps.id = LAST_INSERT_ID()
        GROUP BY (keeps.id)
        ;";
        return db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }, data).FirstOrDefault();
    }

    internal void DeleteKeep(int id)
    {

        string sql = @"
        DELETE FROM keeps
        WHERE id = @id;";
        db.Execute(sql, new { id });
    }

    internal Keep GetKeep(int id)
    {
        string sql = @"
        SELECT
        keeps.*,
        COUNT(vaultKeeps.id) as kept,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        WHERE keeps.id = @id;";
        return db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }, new { id }).FirstOrDefault();
    }

    internal List<Keep> GetKeeps()
    {
        string sql = @"
        SELECT
        keeps.*,
        COUNT(vaultKeeps.id) as kept,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        GROUP BY (keeps.id);";
        return db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }).ToList();
    }

    internal Keep UpdateKeep(Keep data)
    {
        string sql = @"
        UPDATE keeps SET
        name = @name,
        description = @description,
        img = @img,
        views = @views
        WHERE id = @id;
        
        SELECT
        keeps.*,
        COUNT(vaultKeeps.id) as kept,
        accounts.*
        FROM keeps
        JOIN accounts ON accounts.id = keeps.creatorId
        LEFT JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        WHERE keeps.id = @id;";

        return db.Query<Keep, Profile, Keep>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }, data).FirstOrDefault();
    }
}