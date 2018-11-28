import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

import * as actions from "./actions";
import * as mutations from "./mutations";
import * as getters from "./getters";

const store = new Vuex.Store({
  // With strict mode on, if we try to mutate the store state
  // outside of a mutation, an error will be thrown.
  // However, don't leave this on in production
  // as the performance hit can be quite high!
  strict: true,

  actions,
  mutations,
  getters,
  state: {
    auth: null,
    showAuthModal: false,
    loading: false,
    cart: [],
    products: [],
    filters: [],
    product: null,
    orders: []
  }
});

// Invoked each time a mutation is committed to the store
store.subscribe((mutation, state) => {
  const cartMutations = [
    "addProductToCart",
    "updateProductQuantity",
    "removeProductFromCart",
    "setProductQuantity",
    "clearCartItems"
  ];

  // Persist the cart into local storage
  if (cartMutations.indexOf(mutation.type) >= 0) {
    localStorage.setItem("cart", JSON.stringify(state.cart));
  }
});

export default store;
