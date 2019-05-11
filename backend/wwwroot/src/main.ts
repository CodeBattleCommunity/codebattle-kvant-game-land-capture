import "@babel/polyfill";
import Vue from "vue";
import "./plugins/axios";
import "./plugins/vuetify";
import App from "./App.vue";
import router from "./router";
import store from "@/store/index";
import "./registerServiceWorker";

Vue.config.productionTip = false;

new Vue({
  components: { App },
  router,
  store,
  render: h => h(App)
}).$mount("#app");
