<template>
    <div id="carouselExampleFade" class="carousel slide carousel-fade">
        <div class="carousel-inner">
            <!-- <div class="carousel-item active cover-img rounded">
                <img src="https://images.unsplash.com/photo-1466637574441-749b8f19452f?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8aG9tZSUyMGNoZWZ8ZW58MHx8MHx8fDA%3D"
                    class="d-grid w-100 rounded border" alt="Progress to find ur meal bud">
            </div> -->
            <div class="carousel-item" :class="i == 0 ? 'active' : ''" v-for="(recipe, i) in recipes">
                <div>
                    <!-- //NOTE look into changing transition time on text -->
                    <h1 class="text-center fade">{{ recipe.title }}</h1>
                    <div @click="setActiveRecipe(recipe.id)" class="cover-img rounded" data-bs-toggle="modal"
                        data-bs-target="#recipe-details-modal" :style="{ background: `url(${recipe.img})` }">
                        <img :src="recipe.img" class="d-grid w-100 rounded border" :alt="recipe.title">
                    </div>
                </div>
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
import { recipesService } from '../services/RecipesService';
export default {
    props: { recipes: { type: Array, required: true } },
    setup(props) {
        return {
            setActiveRecipe(recipeId) {
                console.log('papa?')
                recipesService.setActiveRecipe(recipeId)
            }
        }
    }
};
</script>


<style lang="scss" scoped>
.cover-img {
    background-position: center;
    background-size: cover;

    img {
        width: 100%;
        height: 80vh;
        object-fit: contain;
        object-position: center;
        backdrop-filter: blur(20px);
    }
}

.fade {
    opacity: 0;
    transition: all .25s linear;
}

.active {
    .fade {
        opacity: 1;
    }
}
</style>