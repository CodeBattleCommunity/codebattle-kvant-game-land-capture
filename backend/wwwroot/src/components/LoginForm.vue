<template>
  <div>
    <form action="/post">
      <label><b>Username</b></label>
      <input type="text" v-model="username">
      <label><b>Password</b></label>
      <input type="password" v-model="password">
      <input type="submit" @click.prevent="login">
    </form>
  </div>
</template>

<script lang="ts">
import { State, Action, Getter } from 'vuex-class';
import { Component, Prop, Vue, Model } from 'vue-property-decorator';
const namespace: string = 'user';

@Component
export default class LoginForum extends Vue {
  @Model() private readonly username!: string;
  @Model() private readonly password!: string;

  @Getter('currentUser', { namespace }) private currentUser!: string;
  @Action('updateUser', { namespace }) private updateUser: any;
  @Action('resetUser', { namespace }) private resetUser: any;

  private login() {
    // should be replaced by real login code
    // there I just did some simple validation and use a fake login
    if ( this.username && this.password ) {
      this.updateUser(this.username);
      // save login status in localstorage
      // localStorage.setItem('login', true);
      // redirect to user page
      // this.$router.push('/user')
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>