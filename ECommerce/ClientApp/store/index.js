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
    cart: []
  }
});

// Persisting data to local storage
store.subscribe((mutation, state) => {
  localStorage.setItem("store", JSON.stringify(state));
});

export default store;
