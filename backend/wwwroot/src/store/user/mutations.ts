import { MutationTree } from 'vuex';
import { UserState } from './types';

export const mutations: MutationTree<UserState> = {
  username(state, name) {
    state.name = name;
  },
  reset(state) {
    state.name = 'anonymous';
  },
  token(state, token) {
    state.token = token;
  },
  resetToken(state) {
    state.token = '';
  },
};
