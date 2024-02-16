



namespace final.Repositories;

public class VaultRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal Vault CreateVault(Vault data)
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

    internal void DeleteVault(int id)
    {
        string sql = @"
        DELETE FROM vaults
        WHERE id = @id;";
        db.Execute(sql, new { id });
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

    internal List<VaultKeepView> GetVaultKeeps(int id)
    {
        string sql = @"
        SELECT
        keeps.*,
        vaultKeeps.id as vaultKeepId,
        accounts.*
        FROM keeps
        JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE vaultKeeps.vaultId = @id;";
        return db.Query<VaultKeepView, Profile, VaultKeepView>(sql, (keep, profile) =>
        {
            keep.Creator = profile;
            return keep;
        }, new { id }).ToList();

    }

    internal Vault UpdateVault(Vault data)
    {
        string sql = @"
        UPDATE vaults SET
        name = @name,
        description = @description,
        img = @img,
        isPrivate = @isPrivate
        WHERE id = @id;
        
        SELECT
        vaults.*,
        accounts.*
        FROM vaults
        JOIN accounts ON accounts.id = vaults.creatorId
        WHERE vaults.id = @id;";
        return db.Query<Vault, Profile, Vault>(sql, (vault, profile) =>
        {
            vault.Creator = profile;
            return vault;
        }, data).FirstOrDefault();
    }
}