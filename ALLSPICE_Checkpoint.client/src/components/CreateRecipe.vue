<template>
  <form @submit.prevent="createRecipe()">
    <div class="form-floating mb-3">
      <input v-model="editable.title" type="text" class="form-control" id="recipeName" placeholder="Recipe Name..."
        minlength="1" maxlength="255" required>
      <label for="cultName">Recipe Name</label>
    </div>
    <div class="form-floating mb-3">
      <label class="form-label" for="img">Recipe Image</label>
      <input v-model="editable.img" class="form-control" type="text" id="img" minlength="5" maxlength="1000" required>
    </div>
    <div class="form-floating mb-3">
      <textarea v-model="editable.instructions" class="form-control" placeholder="Instructions for your Recipe"
        id="recipeInstruction" maxlength="70000" minlength="5" required></textarea>
      <label for="recipeInstruction">Recipe Instructions</label>
    </div>
    <div class="form-floating mb-3">
      <label for="category">Recipe Category</label>
      <select v-model="editable.category" class="form-select" name="category" id="category" required>
        <option v-for="option in optionArr" :key="option" :value="option">{{ option }}</option>
      </select>
    </div>
    <div class="text-end">
      <button class="btn btn-danger" type="submit">Submit</button>
    </div>

  </form>
</template>


<script>
import { ref } from "vue";
import Pop from "../utils/Pop.js";
import { recipeService } from "../services/RecipeService.js";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      optionArr: ['Cheese',
        'Italian',
        'Soup',
        'Mexican',
        'Specialty Coffee',
        'Halloween'
      ],

      async createRecipe() {
        try {
          await recipeService.createRecipe(editable.value);
          editable.value = {};
        } catch (error) {
          Pop.error(error.message, '[CREATE RECIPE MODAL]')
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped></style>