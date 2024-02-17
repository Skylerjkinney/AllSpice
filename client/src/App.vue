<template>
  <main>
    <ModalWrapper modalId="recipe-details-modal">
      <RecipeDetails />
    </ModalWrapper>

    <router-view />
  </main>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import ModalWrapper from './components/ModalWrapper.vue'
import RecipeDetails from './components/RecipeDetails.vue'
export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { ModalWrapper, RecipeDetails }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
