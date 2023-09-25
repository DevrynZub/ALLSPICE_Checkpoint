<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-6 col-12 d-flex ps-0">
        <img class="img-fluid rounded-start active-card" :src="recipe.img" alt="uh oh">
      </div>
      <div class="col-md-6 col-12">
        <div class="row">
          <div class="col-12 fs-3">
            <p class="recipe-name">Recipe Name: {{ recipe.title }}</p>
            <p class="category rounded px-1">{{ recipe.category }}</p>
            <p>{{ recipe.ingredients }}</p>
            <h2>Instructions:</h2>
            <h4 class="instructions">{{ recipe.instructions }}</h4>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>



<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";
import Pop from "../utils/Pop.js";
import { logger } from "../utils/Logger.js";
import { favoriteService } from "../services/FavoriteService.js";
import { recipeService } from "../services/RecipeService.js"

export default {
  setup() {



    return {

      recipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients),
      isFavorite: computed(() => {
        let fav = AppState.favorites?.find(f => f?.recipeId == AppState.recipes?.id)
        if (fav?.accountId == AppState.account?.id) {
          return fav
        } return null
      }),


      async createFavorite() {
        try {
          const activeRecipe = AppState.activeRecipe
          const recipeId = AppState.activeRecipe.id
          const formData = { recipeId: recipeId }
          // const accountId = AppState.account.id
          await favoriteService.createFavorite(formData)
          Pop.toast(`${activeRecipe.title} has been added to your favorites!`)
        }
        catch (error) {
          return Pop.error(error.message)
        }
      },
      async removeFavorite(favoriteId) {
        try {
          await favoriteService.removeFavorite(favoriteId)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      },
      async removeRecipe() {
        try {
          const recipeId = AppState.activeRecipe
          await recipeService.removeRecipe(recipeId)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.img {
  max-height: 60vh;
}

.active-card-img {
  border: 2px solid #007bff;
  border-radius: 10px;
  margin: 10px;
  max-height: 60vh;
  width: 100%;
}

.recipe-name {
  font-weight: bold;
  font-size: 1.5rem;
}

.like {
  position: relative;
  top: -7.1em;
  left: 16em;
  opacity: 80%;
}

.category {
  color: white;
  background-color: #007bff;
  /* Change the background color for category */
  padding: 3px 8px;
  /* Add padding to the category label */
  border-radius: 5px;
  /* Rounded corners for category label */
}

.instructions {
  max-width: 40vh;
}
</style>