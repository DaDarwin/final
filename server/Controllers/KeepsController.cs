namespace final.Controllers;

[ApiController]
[Route("/api/keeps")]
public class KeepsController(Auth0Provider auth, KeepsService keepsService) : ControllerBase
{
    private readonly Auth0Provider auth = auth;
    private readonly KeepsService keepsService = keepsService;

    [HttpGet]
    public ActionResult<List<Keep>> GetKeeps()
    {
        try
        {
            return Ok(keepsService.GetKeeps());
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Keep> GetKeep(int id)
    {
        try
        {
            return Ok(keepsService.GetKeep(id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep data)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            data.CreatorId = user.Id;
            return Ok(keepsService.CreateKeep(data));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpPut("{id}")]
    [Authorize]
    public async Task<ActionResult<Keep>> UpdateKeep([FromBody] Keep data, int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            data.CreatorId = user.Id;
            return Ok(keepsService.UpdateKeep(data, id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteKeep(int id)
    {
        try
        {
            Account user = await auth.GetUserInfoAsync<Account>(HttpContext);
            return Ok(keepsService.DeleteKeep(id, user.Id));
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}