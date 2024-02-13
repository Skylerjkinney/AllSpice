<template>
    <div class="container">
        <section class="row">
            <div class="text-center">

            </div>
        </section>
    </div>
</template>


<script>
import { useRoute } from 'vue-router';
import { AppState } from '../AppState';
import { computed, ref, onMounted, watchEffect } from 'vue';
export default {
    setup() {
        const route = useRoute()
        watchEffect(() => {
            route.params.recipeId
        })
        return {}
    }
};
</script>


<style lang="scss" scoped></style>