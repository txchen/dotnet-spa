import Vue from 'vue'
import VueResource from 'vue-resource'
import App from './App.vue'

Vue.use(VueResource)

window.myvue = new Vue({
  el: 'body',
  components: { App }
})
