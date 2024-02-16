

namespace final.Repositories;

public class VaultRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal object CreateVault(Vault data)
    {
        string sql = @"
        INSERT INTO vaults
        (name, description, img, isPrivate, creatorId)
        Values
        (@name, @description, @img, @isPrivate, @creatorId);
        
        SELECT 
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorID
        WHERE vaults.id = LAST_INSERT_ID();";
        return db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
        {
            vault.Creator = profile;
            return vault;
        }, data).FirstOrDefault();
    }

    internal Vault GetVault(int id)
    {
        string sql = @"
        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorID
        WHERE vaults.id = @id; ";
        return db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
        {
            vault.Creator = profile;
            return vault;
        }, new { id }).FirstOrDefault();
    }
}