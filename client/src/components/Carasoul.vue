<template>
    <div id="carouselExampleFade" class="carousel slide carousel-fade">
        <div class="carousel-inner">
            <div class="carousel-item active bg-dark">
                <img src="https://images.unsplash.com/photo-1466637574441-749b8f19452f?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8aG9tZSUyMGNoZWZ8ZW58MHx8MHx8fDA%3D"
                    class="d-grid w-100" alt="Progress to find ur meal bud">
            </div>
            <div v-for="recipe in recipes" class="carousel-item img-fluid bg-dark">
                <img :src="recipe.img" class="d-grid w-100" :alt="recipe.title">
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>
</template>


<script>
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import { Recipe } from '../models/Recipe.js';
export default {
    props: { recipes: { type: Array, required: true } },
    setup(props) {
        return {}
    }
};
</script>


<style lang="scss" scoped>
img {
    height: 60vh;
    width: 100%;
    object-fit: contain;
    object-position: center;
}
</style>