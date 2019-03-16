import Vue from 'vue';
import Vuex, { StoreOptions } from 'vuex';
import { RootState } from './types';
import { counter } from './counter/index';
import { user } from './user/index';

Vue.use(Vuex);

// Vuex structure based on https://codeburst.io/vuex-and-typescript-3427ba78cfa8

const store: StoreOptions<RootState> = {
  state: {
    version: '0.0.1', // a simple property
  },
  modules: {
    counter,
    user,
  },
};

export default new Vuex.Store<RootState>(store);
