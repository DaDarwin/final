

namespace final.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editData.Name?.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture?.Length > 0 ? editData.Picture : original.Picture;
    return _repo.Edit(original);
  }

  internal List<Vault> GetVaults(string id)
  {
    return _repo.GetVaults(id);
  }

  internal Account EditAccount(Account data)
  {
    Account account = _repo.GetById(data.Id);
    account.Name = data.Name ?? account.Name;
    account.Picture = data.Picture ?? account.Picture;
    account.CoverImg = data.CoverImg ?? account.CoverImg;
    return _repo.Edit(account);
  }
}
