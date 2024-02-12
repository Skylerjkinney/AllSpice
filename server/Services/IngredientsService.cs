using System.Runtime.CompilerServices;

namespace AllSpice.Services;

public class IngredientsService(IngredientsRepository repo)
{
    private readonly IngredientsRepository repo = repo;

    internal Ingredient CreateIngredient(Ingredient ingredientData)
    {
        Ingredient ingredient = repo.Create(ingredientData);
        return ingredient;
    }

    internal List<Ingredient> GetRecipeIngredients(int recipeId)
    {
        List<Ingredient> ingredients = repo.GetRecipeIngredients(recipeId);
        return ingredients;
    }

    internal string DeleteIngredient(int ingredientId, string userId)
    {
        Ingredient ingredientToDelete = repo.GetById(ingredientId);
        if (ingredientToDelete.CreatorId != userId) throw new Exception("Not your picture to delete");

        repo.Delete(ingredientId);
        return $"ingredient {ingredientToDelete.Id} was removed";
    }
}