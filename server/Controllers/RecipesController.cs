using Microsoft.AspNetCore.Http.HttpResults;

namespace AllSpice.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{

    private readonly RecipesService recipesService;
    private readonly Auth0Provider auth;

    public RecipesController(Auth0Provider auth, RecipesService recipesService)
    {
        this.auth = auth;
        this.recipesService = recipesService;
    }

    [HttpGet]
    public ActionResult<List<Recipe>> GetAllRecipes()
    {
        try
        {
            List<Recipe> recipes = recipesService.GetAllRecipes();
            return Ok(recipes);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Recipe>> CreateRecipe([FromBody] Recipe recipeData)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            recipeData.CreatorId = userInfo.Id;
            Recipe recipe = recipesService.CreateRecipe(recipeData);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}