import { ActionTree } from "vuex";
import axios from "axios";
import { UserState } from "./types";
import { RootState } from "../types";

export const actions: ActionTree<UserState, RootState> = {
  update(store, name): any {
    store.commit("username", name);
  },
  reset({ commit }): any {
    commit("reset");
  }
};
