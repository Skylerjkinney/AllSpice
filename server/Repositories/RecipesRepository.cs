using AllSpice.interfaces;

namespace AllSpice.Repositories;

public class RecipesRepository(IDbConnection db) : IRepository<Recipe>
{
    private readonly IDbConnection db = db;


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
        recipes.*,
        accounts.*
        FROM recipes
        JOIN accounts ON recipes.creatorId = accounts.id
        WHERE recipes.id = @recipeId;
        ";
        Recipe recipe = db.Query<Recipe, Account, Recipe>(sql, (recipe, account) =>
        {
            recipe.Creator = account;
            return recipe;
        }, new { recipeId }).FirstOrDefault();
        return recipe;
    }

    public void Delete(int recipeId)
    {
        string sql = @"
        DELETE FROM recipes
        WHERE recipes.id = @recipeId;
        ";

        db.Execute(sql, new { recipeId });
    }

    internal Recipe UpdateRecipe(Recipe updateData)
    {
        string sql = @"
        UPDATE recipes SET
        title = @title,
        instructions = @instructions,
        img = @img,
        category = @category
        WHERE id = @id;

        SELECT
        *
        FROM recipes
        WHERE id = @id;
        ";
        Recipe recipe = db.Query<Recipe>(sql, updateData).FirstOrDefault();
        return recipe;
    }
}