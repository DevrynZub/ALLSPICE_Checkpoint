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
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from "vue";
import { AppState } from "../AppState.js";

export default {
  setup() {



    return {

      recipe: computed(() => AppState.activeRecipe),
      ingredients: computed(() => AppState.ingredients)
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
