

namespace AllSpice.Controllers;

[ApiController]
[Route("api/ingredients")]

public class IngredientsController : ControllerBase
{

    private readonly IngredientsService ingredientsService;
    private readonly Auth0Provider auth;
    public IngredientsController(IngredientsService ingredientsService, Auth0Provider auth)
    {
        this.ingredientsService = ingredientsService;
        this.auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Ingredient>> CreateIngredient([FromBody] Ingredient ingredientData)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            ingredientData.CreatorId = userInfo.Id;
            Ingredient ingredient = ingredientsService.CreateIngredient(ingredientData);
            return Ok(ingredient);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

}