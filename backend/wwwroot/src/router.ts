import Vue from "vue";
import Router from "vue-router";
import HomeView from "./views/Home.vue";
import LoginView from "./views/Login.vue";

Vue.use(Router);

export default new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    { path: "/", name: "home", component: HomeView },
    { path: "/login", name: "login", component: LoginView },
    { path: "/user", name: "user",
      component: () => import(/* webpackChunkName: "userview" */ "./views/User.vue") },
    { path: "/rules", name: "rules",
      component: () => import(/* webpackChunkName: "rulesview" */ "./views/Rules.vue") },
    { path: "/leaderboard", name: "leaderboard",
      component: () => import(/* webpackChunkName: "leaderboardview" */ "./views/Leaderboard.vue") },
    { path: "/registration", name: "registration",
      component: () => import(/* webpackChunkName: "registrationview" */ "./views/Registration.vue") },
    { path: "/maps", name: "maps",
      component: () => import(/* webpackChunkName: "mapsview" */ "./views/Maps.vue") },
    { path: "/game", name: "game",
      component: () => import(/* webpackChunkName: "gameview" */ "./views/Game.vue") },
    {
      path: "/counter",
      name: "counter",
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () =>
        import(/* webpackChunkName: "counter" */ "./views/Counter.vue")
    },
    {
      path: "/fetch-data",
      name: "fetch-data",
      component: () =>
        import(/* webpackChunkName: "fetch-data" */ "./views/FetchData.vue")
    }
  ]
});
