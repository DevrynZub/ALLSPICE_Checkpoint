import { AppState } from "../AppState.js"
import { Ingredient } from "../models/Ingredient.js"
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

  async createRecipe(recipeData) {
    logger.log(recipeData)
    const res = await api.post('api/recipes', recipeData)
    const newRecipe = new Recipe(res.data)
    AppState.recipes.push(newRecipe)
  }

  async getIngredientsByRecipeId(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    const ingredients = res.data.map(i => new Ingredient(i))
    AppState.ingredients = ingredients
  }

  async editRecipe(recipeData, recipeId) {
    const foundRecipe = AppState.recipes.findIndex(f => f.id == recipeId)
    const res = await api.put(`api/recipes/${recipeId}`, recipeData);
    const recipe = new Recipe(res.data)
    AppState.activeRecipe = recipe
    AppState.recipes.splice(foundRecipe, 1, recipe)
  }


}

export const recipeService = new RecipeService()