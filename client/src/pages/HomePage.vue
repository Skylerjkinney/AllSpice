<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="home-card p-5 card align-items-center shadow rounded elevation-3">
      <router-link class="" :to="{ name: 'Recipes' }">
        <img
          src="https://images.unsplash.com/photo-1466637574441-749b8f19452f?w=600&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8N3x8aG9tZSUyMGNoZWZ8ZW58MHx8MHx8fDA%3D"
          alt="Cutting Board" class="rounded-circle">
      </router-link>
      <h1>Hello, {{ user.name }}</h1>
      <h2 class="my-5 bg-dark text-white p-3 rounded text-center">
        Welcome to HomeCook!
      </h2>
      <div class="row btn-group">
        <div class="btn col-5 me-1">
          <Login />
        </div>
        <button class="btn col-5 ms-1" @click="toggleTheme">
          <i class="mdi" :class="theme == 'light' ? 'mdi-weather-sunny' : 'mdi-weather-night'"></i>
        </button>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted, ref } from 'vue';
import { loadState, saveState } from '../utils/Store.js';
import Login from '../components/Login.vue';
import { AppState } from '../AppState';
export default {
  setup() {
    const theme = ref(loadState('theme') || 'light')
    onMounted(() => {
      document.documentElement.setAttribute('data-bs-theme', theme.value)
    })
    return {
      user: computed(() => AppState.user),
      theme,
      toggleTheme() {
        theme.value = theme.value == 'light' ? 'dark' : 'light'
        document.documentElement.setAttribute('data-bs-theme', theme.value)
        saveState('theme', theme.value)
      }
    }
  },
  components: { Login }
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 120vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}

a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 576px) {
  nav {
    height: 64px;
  }
}
</style>
