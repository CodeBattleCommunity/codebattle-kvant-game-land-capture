import { ActionTree } from 'vuex';
import axios from 'axios';
import { UserState } from './types';
import { RootState } from '../types';

export const actions: ActionTree<UserState, RootState> = {
  updateUser(store, name): any {
    store.commit('username', name);
  },
  resetUser({ commit }): any {
    commit('reset');
  },
  updateToken(store, token): any {
    store.commit('token', token);
  },
  resetToken({ commit }): any {
    commit('resetToken');
  },
};
