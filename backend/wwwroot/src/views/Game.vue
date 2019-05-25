<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">
      <v-layout column align-center>
        Game
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
export default class GameView extends Vue {}
</script>
