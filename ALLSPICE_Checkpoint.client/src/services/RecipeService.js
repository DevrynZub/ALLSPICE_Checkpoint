import { AppState } from "../AppState.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"


class RecipeService {


  async getRecipes() {
    const res = await api.get('api/recipes')
    const recipes = res.data.map(recipe => new Recipe(recipe))
    AppState.recipes = recipes
    logger.log('[These are the recipes]', AppState.recipes)
  }

  setActiveRecipe(recipe) {
    AppState.activeRecipe = recipe
    logger.log("This is my active recipe", AppState.activeRecipe)
  }


}

export const recipeService = new RecipeService()