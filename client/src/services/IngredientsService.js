import { AppState } from "../AppState.js"
import { RecipeIngredient } from "../models/Recipe.js"
import { api } from "./AxiosService.js"


class IngredientsService {
    async getRecipeIngredients(recipeId) {
        const response = await api.get(`api/recipes/${recipeId}/ingredients`)
        logger.log("getting ingredients", response.data)
        const ingredients = response.data.map(ingredient => RecipeIngredient(ingredient))
        AppState.activeIngredients = ingredients
    }
}

export const ingredientsService = new IngredientsService()