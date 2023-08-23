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

  async removeIngredient(ingredientId) {
    const ingredientIndex = AppState.ingredients.findIndex(i => i.id == ingredientId)
    const res = await api.delete(`api/ingredients/${ingredientId}`)
    logger.log('You removed {ingredientId}', res.data)
    AppState.ingredients.splice(ingredientIndex, 1)
  }

}

export const ingredientService = new IngredientService()