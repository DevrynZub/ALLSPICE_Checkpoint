import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class IngredientService {

  async getIngredientsByRecipe(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    logger.log('This are ingredients', res.data)
    const ingredients = res.data.map(ingredient => new Ingredient(ingredient))
    AppState.ingredients = ingredients
    logger.log('[Got my ingredients]', AppState.ingredients)
  }

}

export const ingredientService = new IngredientService()