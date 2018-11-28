import Vue from "vue";
import VeeValidate from "vee-validate";
import router from "./router";
import store from "./store";
import { currency, date } from "./filters";
import { sync } from "vuex-router-sync";
import Cookie from "js-cookie";
import axios from "axios";
import "./helpers/interceptors";
import "./helpers/validation";
import App from "./components/App.vue";

Vue.use(VeeValidate);
Vue.filter("currency", currency);
Vue.filter("date", date);

// Under the hood, this method invocation is configuring a number of mutations,
// which will automatically add the route object to our store state,
// then keep it up to date whenever the current route changes.
sync(store, router);

// axios will be unable to determine the base URL path of our API requests when rendering on the server
axios.defaults.baseURL =
  process.env.NODE_ENV === "production"
    ? "https://phoneshop.azurewebsites.net"
    : "http://localhost:63870";

// Checking authentication
const auth = Cookie.get("AUTH");
if (auth) {
  store.commit("loginSuccess", JSON.parse(auth));
  axios.defaults.headers.common["Authorization"] = `Bearer ${
    store.state.auth.access_token
  }`;
}

// Create Vue instance
const app = new Vue({
  router,
  store,
  render: h => h(App)
});

export { app, router, store };
