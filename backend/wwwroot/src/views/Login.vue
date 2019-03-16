<template>
  <v-container fluid>
    <v-slide-y-transition mode="out-in">  
      <v-layout column align-center>
        <LoginForm></LoginForm>
      </v-layout>
    </v-slide-y-transition>
  </v-container>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
import LoginForm from '@/components/LoginForm.vue'; // @ is an alias to /src

@Component({
  components: {
    LoginForm,
  },
})
export default class LoginPage extends Vue {}
</script>
