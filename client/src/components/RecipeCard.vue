<template>
    <router-link :to="{ path: `/recipeDetails/${recipe.id}` }">
        <div class="card m-2 bg-info selectable">
            <img :src="recipe.image" :alt="recipe.title">
        </div>
        <div class="bg-danger">
            <h3 class="text-center"> {{ recipe.title }} </h3>
        </div>
    </router-link>
</template>


<script>
import { Recipe } from '../models/Recipe.js';
export default {
    props: { recipe: { type: Recipe, required: true } },
    setup() {
        return {
        }
    }
};
</script>


<style lang="scss" scoped>
img {
    height: 20vh;
    object-fit: cover;
    object-position: center;
}
</style>