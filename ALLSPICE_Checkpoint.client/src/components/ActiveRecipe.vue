<template>
  <div class="container-fluid">
    <div class="row">
      <div class="col-md-6 col-12 d-flex ps-0">
        <img class="img-fluid rounded-start" :src="recipe.img" alt="uh oh">
      </div>
      <div class="col-md-6 col-12">
        <div class="row">
          <div class="col-12 fs-3">
            <p>Recipe Name: {{ recipe.title }}</p>
            <p class="category rounded px-1">{{ recipe.category }}</p>
            <p>{{ recipe.ingredients }}</p>
            <h2>Instructions:</h2>
            <h4>{{ recipe.instructions }}</h4>
            <div v-if="favorite == null">
              <i @click="createFavorite(recipe.id)"
                class="fs-2 mdi mdi-thumb-up like selectable text-success rounded-bottom"></i>
            </div>
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
      favorite: computed(() => {
        const result = AppState.favorites.find(f => f.recipeId == AppState.activeRecipe.id)
        let int = 2 + 2
        return result
      }),


      async createFavorite(recipeId) {
        try {
          const favoriteData = { recipeId }
          await favoriteService.createFavorite(favoriteData)
        } catch (error) {
          Pop.error(error.message)
          logger.log(error)
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

.like {
  position: relative;
  top: 0em;
  left: -2em;
  background-color: gray;
  opacity: 80%;

}

.category {
  background-color: gray;
  color: white;
}


.instructions {
  max-width: 40vh;
}
</style>
