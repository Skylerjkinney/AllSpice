using MySqlConnector;

namespace AllSpice.Repositories;

public class FavoritesRepository(IDbConnection db)
{
    private readonly IDbConnection db = db;

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        string sql = @"
        INSERT INTO favorites
        (accountId, recipeId)
        VALUES
        (@accountId, @recipeId);

        SELECT
        favorites.*,
        recipes.*
        FROM favorites
        JOIN recipes ON favorites.recipeId = @recipeId
        WHERE favorites.id = LAST_INSERT_ID()
        ";
        Favorite favorite = db.Query<Favorite, Recipe, Favorite>(sql, (favorite, recipe) =>
        {
            favorite.AccountId = recipe.CreatorId;
            return favorite;
        }, favoriteData).FirstOrDefault();
        return favorite;
    }
    internal List<FavoriteRecipe> GetFavorites(string userId)
    {
        string sql = @"
        SELECT
        recipes.*,
        favorites.*,
        FROM favorites
        JOIN recipes ON recipes.id = favorites.recipeId
        WHERE favorites.accountId = @userId
        ";
        List<FavoriteRecipe> favorite = db.Query<FavoriteRecipe, Favorite, FavoriteRecipe>(sql, (favoriteRecipe, favorite) =>
        {
            favoriteRecipe.FavoriteId = favorite.Id;
            return favoriteRecipe;
        }, new { userId }).ToList();
        return favorite;
    }

    internal void DeleteFavorite(string favoriteId)
    {
        string sql = @"
        DELETE FROM favorites
        WHERE id = @favoriteId
        ";
        db.Execute(sql, new { favoriteId });
    }
}