using Microsoft.VisualBasic;

namespace AllSpice.Services;

public class FavoriteService(FavoritesRepository repo)
{
    private readonly FavoritesRepository repo = repo;

    internal Favorite CreateFavorite(Favorite favoriteData)
    {
        Favorite favorite = repo.CreateFavorite(favoriteData);
        return favorite;
    }
    internal List<FavoriteRecipe> GetFavorites(string userId)
    {
        List<FavoriteRecipe> favorite = repo.GetFavorites(userId);
        return favorite;
    }

    internal string DeleteFavorite(string favoriteId)
    {
        repo.DeleteFavorite(favoriteId);
        return "Unfavored, Milord.";
    }
}