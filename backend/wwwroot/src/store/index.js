import Vue from 'vue';
import Vuex from 'vuex';
import { counter } from './counter/index';
Vue.use(Vuex);
// Vuex structure based on https://codeburst.io/vuex-and-typescript-3427ba78cfa8
const store = {
    state: {
        version: '1.0.0',
    },
    modules: {
        counter,
    },
};
export default new Vuex.Store(store);
//# sourceMappingURL=index.js.map