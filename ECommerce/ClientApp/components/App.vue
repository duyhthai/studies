<template>
  <div class="app">
      <navbar></navbar>

      <transition name="fade" mode="out-in">
        <router-view />
      </transition>

      <auth-modal :show="showAuthModal" />
  </div>
</template>


<script>
import Navbar from "./Navbar.vue";
import AuthModal from "./app/AuthModal.vue";

export default {
  name: "app",
  components: {
    Navbar,
    AuthModal
  },
  computed: {
    showAuthModal() {
      return this.$store.state.showAuthModal;
    }
  },
  beforeCreate() {
    this.$store.commit("initialise");
  }
};
</script>


<style lang="scss">
html,
body {
  height: 100vh;
}

div.app,
div.page {
  height: 100% !important;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.3s ease-in-out;
}

.fade-enter,
.fade-leave-to {
  opacity: 0;
}
</style>