import { createApp } from 'vue'
import { createPinia } from 'pinia'
import './style.css'
import App from './App.vue'
import router from './router'
import vuetify from './plugins/vuetify'
import { loadFonts } from './plugins/webfontloader'

const pinia = createPinia()
const app = createApp(App)

loadFonts()

app.use(vuetify)
app.use(pinia)
app.use(router)

app.mount('#app')
