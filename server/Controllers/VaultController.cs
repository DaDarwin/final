namespace final.Controllers;

[ApiController]
[Route("/api/vaults")]
public class VaultController(Auth0Provider auth, VaultService vaultService) : ControllerBase
{
    private readonly Auth0Provider auth = auth;
    private readonly VaultService vaultService = vaultService;

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault data)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            data.CreatorId = user.Id;
            return Ok(vaultService.CreateVault(data));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Vault>> GetVault(int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            return Ok(vaultService.GetVault(id, user?.Id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Vault>> UpdateVault([FromBody] Vault data, int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            data.CreatorId = user.Id;
            return Ok(vaultService.UpdateVault(data, id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteVault(int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            return Ok(vaultService.DeleteVault(id, user.Id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }


}