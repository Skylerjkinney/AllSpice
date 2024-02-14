import { AppState } from "../AppState"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"

class RecipesService {
    async getAllRecipes() {
        const response = await api.get('api/recipes')
        logger.log('getting recipes', response.data)
        let newRecipes = response.data.map(recipe => new Recipe(recipe))
        AppState.recipes = newRecipes
    }
}
export const recipesService = new RecipesService()