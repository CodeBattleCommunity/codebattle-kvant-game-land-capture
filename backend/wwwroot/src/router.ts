import Vue from 'vue';
import Router from 'vue-router';
import HomePage from './views/Home.vue';
import LoginPage from './views/LoginPage.vue';
import UserPage from './views/UserPage.vue';

Vue.use(Router);

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: HomePage,
    },
    {
      path: '/login',
      name: 'login',
      component: LoginPage,
    },
    {
      path: '/user',
      name: 'user',
      component: UserPage,
    },
    {
      path: '/counter',
      name: 'counter',
      // route level code-splitting
      // this generates a separate chunk (about.[hash].js) for this route
      // which is lazy-loaded when the route is visited.
      component: () => import(/* webpackChunkName: "counter" */ './views/Counter.vue'),
    },
    {
      path: '/fetch-data',
      name: 'fetch-data',
      component: () => import(/* webpackChunkName: "fetch-data" */ './views/FetchData.vue'),
    },
  ],
});
