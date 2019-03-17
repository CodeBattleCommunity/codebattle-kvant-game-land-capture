import { GetterTree } from 'vuex';
import { UserState } from './types';
import { RootState } from '../types';

export const getters: GetterTree<UserState, RootState> = {
    currentUser(state): string {
        return state.name;
    },
    currentToken(state): string {
        return state.token;
    },
};
