
namespace AllSpice.Controllers;

[ApiController]
[Route("api/favorites")]
public class FavoritesController : ControllerBase
{
    private readonly FavoriteService favoriteService;
    private readonly Auth0Provider auth;

    public FavoritesController(FavoriteService favoriteService, Auth0Provider auth)
    {
        this.favoriteService = favoriteService;
        this.auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Favorite>> CreateFavorite([FromBody] Favorite favoriteData)
    {

        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            favoriteData.AccountId = userInfo.Id;
            Favorite favorite = favoriteService.CreateFavorite(favoriteData);
            return Ok(favorite);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{favoriteId}")]
    [Authorize]
    public async Task<ActionResult<string>> DeleteFavorite(string favoriteId)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = favoriteService.DeleteFavorite(favoriteId);
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}

