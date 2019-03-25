<template>
  <v-app>
    <v-navigation-drawer
      persistent
      :mini-variant="false"
      :clipped="true"
      v-model="drawer"
      enable-resize-watcher
      fixed
      app
    >
      <v-list>
        <v-list-tile value="true" v-for="(item, i) in items" :key="i" :to="item.link">
          <v-list-tile-action>
            <v-icon v-html="item.icon"></v-icon>
          </v-list-tile-action>
          <v-list-tile-content>
            <v-list-tile-title v-text="item.title"></v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-navigation-drawer>

    <v-toolbar app :clipped-left="true">
      <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
      <v-toolbar-title v-text="title"></v-toolbar-title>
      <v-spacer></v-spacer>
    </v-toolbar>

    <v-content>
      <router-view/>
    </v-content>

    <v-footer app>
      <span>&nbsp;Kvantorium & dpankratov.ru&nbsp;&copy;&nbsp;2019</span>
    </v-footer>
  </v-app>
</template>

<script lang="ts">
import HelloWorld from "@/components/HelloWorld.vue";
import { Component, Vue } from "vue-property-decorator";

@Component({
  components: { HelloWorld }
})
export default class App extends Vue {
  private drawer: boolean = true;
  private right: boolean = true;
  private title: string = "CodeBattle: PointWar";
  private items = [
    { title: "Основная", icon: "home", link: "/" },
    { title: "Счетчик", icon: "touch_app", link: "/counter" },
    { title: "Пример запроса сервера", icon: "get_app", link: "/fetch-data" },
    { title: "О нас", icon: "face", link: "/about" }
  ];
}
</script>
