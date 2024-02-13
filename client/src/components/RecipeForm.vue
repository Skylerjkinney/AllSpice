<template>
    <form @submit.prevent="createRecipe()" class="row my-3">
        <div class="col-md-4">
            <label for="insert-image">Recipe Preview </label>
            <img v-if="cultData.img" class="img-fluid" :src="recipeData.img" alt="Preview">
        </div>
        <div class="col-md-4">
            <label for="insert-image">Recipe Image</label>
            <input v-model="recipeData.img" class="form-control" type="url" required maxlength="500" name="insert-image"
                id="insert-image">
        </div>
        <div class="col-md-4">
            <label for="create-recipe-title">Recipe Title</label>
            <input v-model="recipeData.name" class="form-control" type="text" minlength="3" maxlength="25" required
                name="create-recipe-title" id="create-recipe-name">
        </div>
        <div class="col-md-4">
            <label for="create-recipe-description">Recipe Description</label>
            <input v-model="recipeData.name" class="form-control" type="text" minlength="25" required maxlength="500"
                name="create-recipe-name" id="create-recipe-name">
        </div>
        <div class="col-12 text-end">
            <button class="btn btn-primary" type="submit">Create Recipe</button>
        </div>
    </form>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { logger } from '../utils/Logger';
import Pop from '../utils/Pop';
export default {
    setup() {
        const recipeData = ref({})
        return {
            recipeData,
            async createRecipe() {
                try {
                    logger.log('Baking Recipe', recipeData.value)
                    await recipeService.createRecipe(recipeData.value)
                    Pop.success('Recipe fresh out of oven 👍')
                } catch (error) {
                    Pop.error(error)
                }
            }
        }
    }
};
</script>


<style lang="scss" scoped></style>