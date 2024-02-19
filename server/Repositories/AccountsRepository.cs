
namespace final.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetByEmail(string userEmail)
  {
    string sql = "SELECT * FROM accounts WHERE email = @userEmail";
    return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
  }

  internal Account GetById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Account>(sql, new { id });
  }

  internal Account Create(Account newAccount)
  {
    string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
    _db.Execute(sql, newAccount);
    return newAccount;
  }

  internal Account Edit(Account update)
  {
    string sql = @"
            UPDATE accounts
            SET 
              name = @Name,
              picture = @Picture
            WHERE id = @Id;";
    _db.Execute(sql, update);
    return update;
  }

  internal List<VaultKeepView> getVaults(string id)
  {
    string sql = @"
        SELECT
        keeps.*,
        vaultKeeps.id as vaultKeepId,
        accounts.*
        FROM keeps
        JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
        JOIN accounts ON accounts.id = keeps.creatorId
        WHERE vaultKeeps.creatorId = @id;";
    return _db.Query<VaultKeepView, Profile, VaultKeepView>(sql, (keep, profile) =>
    {
      keep.Creator = profile;
      return keep;
    }, new { id }).ToList();
  }
}

