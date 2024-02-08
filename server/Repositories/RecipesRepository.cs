using AllSpice.interfaces;

namespace AllSpice.Repositories;

public class RecipesRepository(IDbConnection db) : IRepository<Recipe>
{
    private readonly IDbConnection db = db;

    private Recipe populateCreator(Recipe recipe, Account account)
    {
        recipe.Creator = account;
        return recipe;
    }

    public List<Recipe> GetAll()
    {
        string sql = @"
        SELECT
            recipes.*,
            accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id;
        ";

        List<Recipe> recipes = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }).ToList();
        return recipes;
    }
}