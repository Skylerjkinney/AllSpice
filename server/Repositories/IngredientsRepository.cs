

using AllSpice.interfaces;

namespace AllSpice.Repositories;

public class IngredientsRepository(IDbConnection db) : IRepository<Ingredient>
{
    private readonly IDbConnection db = db;
    public Ingredient Create(Ingredient ingredientData)
    {
        string sql = @"
            INSERT INTO ingredients
            (name, quantity, recipeId)
            VALUES
            (@name, @quantity, @recipeId);

            SELECT
            ingredients.*
            FROM ingredients
            WHERE ingredients.id = LAST_INSERT_ID();
            ";

        Ingredient ingredient = db.Query<Ingredient>(sql, ingredientData).FirstOrDefault();
        return ingredient;
    }
}