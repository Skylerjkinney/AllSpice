namespace AllSpice.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
  private readonly AccountService _accountService;
  private readonly FavoriteService _favoriteService;
  private readonly Auth0Provider _auth0Provider;

  public AccountController(AccountService accountService, Auth0Provider auth0Provider, FavoriteService favoriteService)
  {
    _accountService = accountService;
    _auth0Provider = auth0Provider;
    _favoriteService = favoriteService;
  }

  [HttpGet]
  [Authorize]
  public async Task<ActionResult<Account>> Get()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      return Ok(_accountService.GetOrCreateProfile(userInfo));
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }
  [HttpGet("favorites")]
  [Authorize]
  public async Task<ActionResult<Account>> GetAccountFavorites()
  {
    try
    {
      Account userInfo = await _auth0Provider.GetUserInfoAsync<Account>(HttpContext);
      List<FavoriteRecipe> favoriteRecipes = _favoriteService.GetFavorites(userInfo.Id);
      return Ok(favoriteRecipes);
    }
    catch (Exception error)
    {
      return BadRequest(error.Message);
    }
  }
}
