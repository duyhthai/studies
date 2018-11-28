import Vue from "vue";
import router from "./router";
import store from "./store";
import BootstrapVue from "bootstrap-vue";
import VueToastr from "@deveodk/vue-toastr";
import "@deveodk/vue-toastr/dist/@deveodk/vue-toastr.css";
import VeeValidate from "vee-validate";

// helpers
import "./helpers/validation";
import "./helpers/interceptors";

Vue.use(BootstrapVue);
Vue.use(VueToastr, { defaultPosition: "toast-top-right" });
Vue.use(VeeValidate);

// filters
import { currency, date } from "./filters";
Vue.filter("currency", currency);
Vue.filter("date", date);

// Load data from localStorage
const cartItems = localStorage.getItem("cart");
if (cartItems) {
  store.commit("setCartItems", JSON.parse(cartItems));
}

new Vue({
  el: "#app-root",
  router: router,
  store,
  render: h => h(require("./components/App.vue"))
});
