import { MutationTree } from "vuex";
import { UserState } from "./types";

export const mutations: MutationTree<UserState> = {
  username(state, name) {
    state.username = name;
  },
  reset(state) {
    state.username = "";
  }
};
