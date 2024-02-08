namespace AllSpice.Services;

public class RecipesService(RecipesRepository repo)
{
    private readonly RecipesRepository repo = repo;

    internal List<Recipe> GetAllRecipes()

    {
        List<Recipe> recipes = repo.GetAll();
        return recipes;
    }
}