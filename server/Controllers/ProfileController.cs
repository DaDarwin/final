namespace final.Controllers;

[ApiController]
[Route("/api/profiles")]
public class ProfileController(Auth0Provider auth, ProfileService profileService) : ControllerBase
{
    private readonly Auth0Provider auth = auth;
    private readonly ProfileService profileService = profileService;


    [HttpGet("{id}")]
    public ActionResult<Profile> GetProfile(string id)
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
    public ActionResult<List<Keep>> GetProfileKeeps(string id)
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
    public async Task<ActionResult<List<Vault>>> GetProfileVaults(string id)
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