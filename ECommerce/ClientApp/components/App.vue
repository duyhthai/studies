<template>
<div class="app">
    <navbar></navbar>

    <router-view />
</div>
</template>


<script>
    import Navbar from "./Navbar.vue";

    export default {
        name: "app",
        components: {
          Navbar
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
</style>