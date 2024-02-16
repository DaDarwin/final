namespace final.Controllers;

[ApiController]
[Route("/api/profiles")]
public class ProfileController(Auth0Provider auth, ProfileService profileService) : ControllerBase
{
    private readonly Auth0Provider auth = auth;
    private readonly ProfileService profileService = profileService;


    [HttpGet("{id}")]
    ActionResult<Profile> GetProfile(int id)
    {
        try
        {
            return Ok(profileService.GetProfile(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}/keeps")]
    ActionResult<List<Keep>> GetProfileKeeps(int id)
    {
        try
        {
            return Ok(profileService.GetProfileKeeps(id));

        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}/vaults")]
    async Task<ActionResult<List<Vault>>> GetProfileVaults(int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            return Ok(profileService.GetProfileVaults(id, user?.Id));

        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}