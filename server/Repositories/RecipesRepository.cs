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

    public Recipe Create(Recipe createData)
    {
        string sql = @"
        INSERT INTO recipes
        (title, instructions, img, category, creatorId)
        VALUES
        (@title, @instructions, @img, @category, @creatorId);

        SELECT
            recipes.*,
            accounts.*
            FROM recipes
            JOIN accounts ON recipes.creatorId = accounts.id
            WHERE recipes.id = LAST_INSERT_ID();
        ";

        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        },
            createData).FirstOrDefault();
        return recipe;
    }

    internal Recipe GetRecipeById(int recipeId)
    {
        string sql = @"
        SELECT
        *
        FROM recipes
        WHERE id = @recipeId;
        ";
        Recipe recipe = db.Query<Recipe>(sql, new { recipeId }).FirstOrDefault();
        return recipe;
    }
}