<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-layout column align-center>
        <UserInfo></UserInfo>
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import UserInfo from "@/components/UserInfo.vue"; // @ is an alias to /src

@Component({
  components: {
    UserInfo
  }
})
export default class UserView extends Vue {}
</script>
