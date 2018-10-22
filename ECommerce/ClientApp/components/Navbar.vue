<template>
    <b-navbar toggleable="md" type="dark" variant="dark">
      <b-navbar-toggle target="nav_collapse"></b-navbar-toggle>
      <b-navbar-brand to="/">PhoneShop</b-navbar-brand>
      <b-collapse is-nav id="nav_collapse">
        <b-navbar-nav>
          <b-nav-item to="/products">Products</b-nav-item>
        </b-navbar-nav>
        <b-navbar-nav class="ml-auto mr-4">
          <cart-summary />
        </b-navbar-nav>
      </b-collapse>
    </b-navbar>
</template>


<script>
import CartSummary from "./cart/CartSummary.vue";

export default {
  name: "navbar",
  components: {
    CartSummary
  }
};
</script>
