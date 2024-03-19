<template>
    <div v-if="activeRecipe" class="text-center">
        <h1>{{ activeRecipe.title }}</h1>
        <h3>{{ activeRecipe.category }}</h3>
        <p>{{ activeRecipe.instructions }}</p>
        <h5>{{ activeRecipe.creator.name }}</h5>
    </div>
    <div v-if="activeIngredients.length">
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
import { ingredientsService } from '../services/IngredientsService.js'
import Pop from '../utils/Pop';

export default {

    setup() {
        onMounted(() => {
            getRecipeIngredients()
        }
        )
        async function getRecipeIngredients() {
            try {
                await ingredientsService.getRecipeIngredients(activeRecipe.id)
            } catch (error) {
                Pop.error(error)
            }
        }
        return {
            activeRecipe: computed(() => AppState.activeRecipe),
            activeIngredients: computed(() => AppState.activeIngredients)
        }
    }
};
</script>


<style lang="scss" scoped></style>