<template>
  <div class="container-fluid">
    <div class="row">
      <div class="card col-12 text-dark text-center spice-img d-flex justify-content-center align-items-center">
        <h1>AllSpice</h1>
        <p>Because who doesn't love food</p>
      </div>
      <div class="row justify-content-center">
        <div class="col-12 col-md-8">
          <div class="filtered-content bg-white d-flex flex-wrap justify-content-around p-3 rounded filter-buttons">
            <button class="btn btn-success" @click="filterBy = ''">Home</button>
            <button class="btn btn-success" @click="filterBy = 'creator'">My Recipes</button>
            <button class="btn btn-success" @click="filterBy = 'favorite'">Favorites</button>
          </div>
        </div>
      </div>
    </div>
    <div class="col-12 text-center mt-2">
      <form @submit.prevent="filterRecipes()">
        <label for="Recipes">Find:</label>
        <input v-model="filterBy" type="search" id="Recipes">
        <button type="submit" class="btn btn-success mdi mdi-binoculars"></button>
      </form>
    </div>
    <div class="row">
      <div class="col-md-4 col-12 p-3" v-for="recipe in recipes" :key="recipe.id">
        <RecipeCard :recipeProp="recipe" />
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref, watchEffect } from 'vue';
import Pop from '../utils/Pop.js';
import { recipeService } from '../services/RecipeService.js'
import { favoriteService } from '../services/FavoriteService.js'
import { AppState } from '../AppState.js';
import RecipeCard from '../components/RecipeCard.vue';
import { logger } from '../utils/Logger.js';

export default {
  setup() {
    const filterBy = ref("");


    async function getRecipes() {
      try {
        await recipeService.getRecipes();
      }
      catch (error) {
        Pop.error(error.message);
        logger.log(error);
      }
    }

    async function getFavorites() {
      try {
        await favoriteService.getFavorites()
      } catch (error) {
        Pop.error(error.message)
        logger.log(error)
      }
    }
    onMounted(() => {
      getRecipes();
    });

    watchEffect(() => {
      if (AppState.account.id) {
        getFavorites();
      }
    })

    return {
      filterBy,
      recipes: computed(() => {
        if (filterBy.value == "") {
          return AppState.recipes
        } else {
          return AppState.recipes.filter(recipe => recipe.category == filterBy.value)
        }
      })
    };
  },

  components: { RecipeCard }
};

</script>

<style scoped lang="scss">
.container-fluid {
  position: relative;
}

.spice-img {
  background-image: url(https://images.unsplash.com/photo-1596040033229-a9821ebd058d?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1740&q=80);
  height: 50vh;
  background-repeat: no-repeat;
  background-size: cover;
  background-position: center;
}

.filtered-content {
  position: relative;
  margin-top: -25px;

}
</style>