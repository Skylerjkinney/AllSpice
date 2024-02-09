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

    internal string DeleteRecipe(int recipeId, string userId)
    {
        Recipe recipeToBeDeleted = repo.GetRecipeById(recipeId);
        if (recipeToBeDeleted.CreatorId != userId) throw new Exception("It seems like you are not authorized to complete this request....");

        repo.Delete(recipeId);
        return $"Recipe {recipeToBeDeleted.Id} was removed!";

    }

    internal Recipe UpdateRecipe(Recipe updateData, string userId)
    {
        Recipe recipeToUpdate = GetRecipeById(updateData.Id);
        if (recipeToUpdate.CreatorId != userId) throw new Exception("you do not own this, therefore you cannot modify it...");

        recipeToUpdate.Title = updateData.Title ?? recipeToUpdate.Title;
        recipeToUpdate.Instructions = updateData.Instructions ?? recipeToUpdate.Instructions;
        recipeToUpdate.Img = updateData.Img ?? recipeToUpdate.Img;
        recipeToUpdate.Category = updateData.Category ?? recipeToUpdate.Category;

        Recipe update = repo.UpdateRecipe(recipeToUpdate);
        return update;
    }
}