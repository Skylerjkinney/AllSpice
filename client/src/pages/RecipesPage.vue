<template>
  <div class="container-fluid">
    <section class="row p-2 my-2">
      <button class="col btn btn-outline-light" :class="{ 'bg-primary': filterBy == '' }"
        @click="filterBy = ''">all</button>
      <button class="col btn btn-outline-light" :class="{ 'bg-primary': filterBy == 'cheese' }"
        @click="filterBy = 'cheese'">Cheese</button>
      <button class="col btn btn-outline-light" :class="{ 'bg-primary': filterBy == 'italian' }"
        @click="filterBy = 'italian'">Italian</button>
      <button class="col btn btn-outline-light" :class="{ 'bg-primary': filterBy == 'soup' }"
        @click="filterBy = 'soup'">Soup</button>
      <button class="col btn btn-outline-light" :class="{ 'bg-primary': filterBy == 'mexican' }"
        @click="filterBy = 'mexican'">Mexican</button>
      <button class="col btn btn-outline-light" :class="{ 'bg-primary': filterBy == 'specialty coffee' }"
        @click="filterBy = 'specialty coffee'">Specialty Coffee</button>
    </section>
    <section class="row justify-content-center align-items-center">
      <div class="col-8">
        <Carasoul :recipes="recipes" />
      </div>
    </section>
  </div>
</template>


<script>
import { computed, onMounted, ref } from 'vue';
import Pop from '../utils/Pop';
import { AppState } from '../AppState';
import { recipesService } from '../services/RecipesService.js';
import Carasoul from '../components/Carasoul.vue';
import ModalWrapper from '../components/ModalWrapper.vue';
import RecipeForm from '../components/RecipeForm.vue';

export default {
  setup() {
    onMounted(() => {
      getAllRecipes()
    });
    const filterBy = ref('');
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    return {
      filterBy,
      recipes: computed(() => {
        if (filterBy.value) {
          return AppState.recipes.filter(recipe => recipe.category == filterBy.value);
        }
        else {
          return AppState.recipes;
        }
      }),
    };
  },
  components: { Carasoul }
}
</script>
