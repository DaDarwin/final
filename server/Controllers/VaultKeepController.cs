namespace final.Controllers;

[ApiController]
[Route("/api/vaultkeeps")]
public class VaultKeepController(Auth0Provider auth, VaultKeepService vaultKeepService) : ControllerBase
{
    private readonly Auth0Provider auth = auth;
    private readonly VaultKeepService vaultKeepService = vaultKeepService;

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep data)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            data.CreatorId = user.Id;
            return Ok(vaultKeepService.CreateVaultKeep(data, user.Id));

        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteVaultKeep(int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            return Ok(vaultKeepService.DeleteVaultKeep(id, user.Id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}
