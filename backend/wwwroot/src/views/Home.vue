<template>
  <v-container fluid>
    <v-layout column align-center>
      <img src="@/assets/logo.png" alt="Vuetify.js" class="mb-5">
      <HelloWorld quote="Учись играя" author="Денис Панкратов" />
    </v-layout>
    <v-slide-y-transition mode="out-in">
      <v-layout column>
        <h1 class="headline">Захват территории</h1>
        <p>Добро пожаловать в игру </p>
        <ul>
          <li>Надо бы логотип придумать :) </li>
        </ul>
        

        <h3 class="headline mt-3">Правила:</h3>
        <ul>
          <li>
            <strong>Основное правило</strong>. Например <em>Это</em> или <em>Это</em> - это закон.</li>
          <li>
            <strong>Если вы разоаботчик</strong>. Запускаемся в режиме разработки вот с таким кодом
            <code>тут размещается код</code> тут тоже какой-то текст</li>
        </ul>

        <h3 class="headline mt-3">Список готовых клиентов:</h3>
        <ul>
          <li>
            <a href="https://vuejs.org" target="_blank"> Vue.js</a> - первый клиент</li>
          <li>
            <a href="https://vuetifyjs.com" target="_blank">Vuetify</a> - второй клиент</li>
        </ul>
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import HelloWorld from '@/components/HelloWorld.vue'; // @ is an alias to /src

@Component({
  components: {
    HelloWorld,
  },
})
export default class Home extends Vue {}
</script>
