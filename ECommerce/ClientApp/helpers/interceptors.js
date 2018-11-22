import axios from "axios";
import store from "../store";
import router from "../router";

// 1st param: function to invoke if the response returns a successful HTTP response code
// 2nd param: function to invoke if an error code is returned
axios.interceptors.response.use(undefined, function(error) {
  const originalRequest = error.config;
  if (
    error.response.status === 401 &&
    !originalRequest._retry &&
    store.state.auth.refresh_token
  ) {
    originalRequest._retry = true;

    // Call refresh-token API
    const payload = {
      refresh_token: store.state.auth.refresh_token
    };
    return axios
      .post("/api/token/refresh", payload)
      .then(response => {
        const auth = response.data;
        axios.defaults.headers.common["Authorization"] = `Bearer ${
          auth.access_token
        }`;
        originalRequest.headers["Authorization"] = `Bearer ${
          auth.access_token
        }`;
        store.commit("loginSuccess", auth);
        return axios(originalRequest);
      })
      .catch(error => {
        store.commit("logout");
        router.push({ path: "/" });
        delete axios.defaults.headers.common["Authorization"];
        return Promise.reject(error);
      });
  }

  // All axios interceptor functions return promises by default
  return Promise.reject(error);
});
