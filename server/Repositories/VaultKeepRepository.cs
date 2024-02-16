
namespace final.Repositories;

public class VaultKeepRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal VaultKeep CreateVaultKeep(VaultKeep data)
    {
        string sql = @"
        INSERT INTO
        vaultKeeps
        (vaultId, keepId, creatorId)
        VALUES
        (@vaultId, @keepId, @creatorId);
        
        SELECT
        * 
        FROM vaultKeeps
        WHERE id = LAST_INSERT_ID()";
        return db.Query<VaultKeep>(sql, data).FirstOrDefault();
    }

    internal void DeleteVaultKeep(int id)
    {
        string sql = @"
        DELETE FROM
        vaultKeeps
        WHERE vaultKeeps.id = @id;";
        db.Execute(sql, new { id });
    }

    internal VaultKeep GetVaultKeep(int id)
    {
        string sql = @"
        SELECT
        *
        FROM
        vaultKeeps
        WHERE vaultKeeps.id = @id;";
        return db.Query<VaultKeep>(sql, new { id }).FirstOrDefault();
    }
}