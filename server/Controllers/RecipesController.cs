

namespace AllSpice.Controllers;

[ApiController]
[Route("api/recipes")]
public class RecipesController : ControllerBase
{
    private readonly IngredientsService ingredientsService;
    private readonly RecipesService recipesService;
    private readonly Auth0Provider auth;


    public RecipesController(Auth0Provider auth, RecipesService recipesService, IngredientsService ingredientsService)
    {
        this.auth = auth;
        this.recipesService = recipesService;
        this.ingredientsService = ingredientsService;
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
    [HttpGet("{recipeId}")]
    public ActionResult<Recipe> GetRecipeById(int recipeId)
    {
        try
        {
            Recipe recipe = recipesService.GetRecipeById(recipeId);
            return Ok(recipe);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
    [HttpGet("{recipeId}/ingredients")]
    public ActionResult<List<Ingredient>> GetRecipeIngredients(int recipeId)
    {
        try
        {
            List<Ingredient> ingredients = ingredientsService.GetRecipeIngredients(recipeId);
            return Ok(ingredients);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpDelete("{recipeId}")]
    [Authorize]

    public async Task<ActionResult<string>> DeleteRecipe(int recipeId)
    {
        try
        {
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            string message = recipesService.DeleteRecipe(recipeId, userInfo.Id);
            return Ok(message);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }

    [HttpPut("{recipeId}")]
    [Authorize]
    public async Task<ActionResult<Recipe>> UpdateRecipe([FromBody] Recipe updateData, int recipeId)
    {
        try
        {
            updateData.Id = recipeId;
            Account userInfo = await auth.GetUserInfoAsync<Account>(HttpContext);
            updateData.CreatorId = userInfo.Id;
            Recipe update = recipesService.UpdateRecipe(updateData, userInfo.Id);
            return Ok(update);
        }
        catch (Exception error)
        {
            return BadRequest(error.Message);
        }
    }
}