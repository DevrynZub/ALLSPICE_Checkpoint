<template>
  <div @click="setActiveRecipe(recipeProp), getIngredientsByRecipe(recipeProp.id)" data-bs-toggle="modal"
    data-bs-target="#recipeDetails" class="recipe-card">
    <div class="recipe-image" :style="{ backgroundImage: 'url(' + recipeProp.img + ')' }">
    </div>
    <div class="recipe-info">
      <h4 class="recipe-category">{{ recipeProp.category }}</h4>
      <h3 class="recipe-title">{{ recipeProp.title }}</h3>
    </div>

  </div>
</template>

<script>
import { Recipe } from "../models/Recipe.js";
import { recipeService } from "../services/RecipeService.js";
import { ingredientService } from "../services/IngredientService.js";
import { logger } from "../utils/Logger.js";
import Pop from "../utils/Pop.js";
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  props: {
    recipeProp: { type: Recipe, required: true }
  },
  setup() {

    return {

      recipes: computed(() => AppState.recipes),

      setActiveRecipe(recipe) {
        try {
          recipeService.setActiveRecipe(recipe)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      },
      async getIngredientsByRecipe(recipeId) {
        try {
          await ingredientService.getIngredientsByRecipe(recipeId)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      }


    }
  }
}
</script>


<style scoped>
.recipe-card {
  cursor: pointer;
  display: flex;
  flex-direction: column;
  align-items: center;
  background-color: #f5f5f5;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  transition: transform 0.2s, box-shadow 0.2s;
}

.recipe-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.recipe-image {
  width: 100%;
  height: 200px;
  background-size: cover;
  background-position: center;
  border-radius: 8px 8px 0 0;
  position: relative;
}

.like-icon {
  position: absolute;
  top: 10px;
  right: 10px;
  font-size: 24px;
  color: #00a86b;
  transition: color 0.2s;
}

.like-icon.liked {
  color: #ff5a5f;
}

.recipe-info {
  padding: 16px;
  text-align: center;
}

.recipe-category {
  color: #888;
  margin-bottom: 8px;
  font-size: 14px;
}

.recipe-title {
  color: #333;
  margin: 0;
  font-size: 18px;
  font-weight: bold;
}
</style>






