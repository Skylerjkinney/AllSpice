<template>
    <div>
        RECIPE DETAILS YEA
    </div>
    <h1 v-if="recipe">{{ recipe.name }}</h1>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipe } from '../models/Recipe';
export default {
    props: { recipe: { type: Recipe, required: true } },
    setup() {
        return {}
    }
};
</script>


<style lang="scss" scoped></style>