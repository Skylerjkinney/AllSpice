

using AllSpice.interfaces;

namespace AllSpice.Repositories;

public class IngredientsRepository(IDbConnection db) : IRepository<Ingredient>
{
    private readonly IDbConnection db = db;
    public Ingredient Create(Ingredient ingredientData)
    {
        string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId, creatorId)
            VALUES
            (@name, @quantity, @recipeId, @creatorId);

            SELECT
            ingredients.*
            FROM ingredients
            WHERE ingredients.id = LAST_INSERT_ID();
            ";

        Ingredient ingredient = db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
        return ingredient;
    }

    internal List<Ingredient> GetRecipeIngredients(int recipeId)
    {
        string sql = @"
        SELECT
        ingredients.*,
        accounts.*
        FROM ingredients
        JOIN accounts ON ingredients.creatorId = accounts.id
        WHERE ingredients.recipeId = @recipeId;
        ";
        List<Ingredient> ingredients = db.Query<Ingredient, Account, Ingredient>(sql, (ingredient, account) =>
        {
            ingredient.CreatorId = account.Id;
            return ingredient;
        }, new { recipeId }).ToList();
        return ingredients;
    }
}