namespace AllSpice.Services;

public class RecipesService(RecipesRepository repo)
{
    private readonly RecipesRepository repo = repo;

    internal List<Recipe> GetAllRecipes()

    {
        List<Recipe> recipes = repo.GetAll();
        return recipes;
    }
    internal Recipe CreateRecipe(Recipe recipeData)
    {
        Recipe recipe = repo.Create(recipeData);
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        Recipe recipe = repo.GetRecipeById(recipeId);
        if (recipe == null) throw new Exception($"no recipe at id: {recipeId}");
        return recipe;
    }
}