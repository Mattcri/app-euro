<script setup>
import { onMounted, ref } from 'vue'
import { useAuthorsStore } from '@/store/authors'

const store = useAuthorsStore()
const imgURL = 'https://eurocorp.cl/wp-content/uploads/2022/01/cropped-favicon-32x32.png'
const drawer = ref(true)
const rail = ref(false)

const navItems = [
  { icon: 'mdi-home-city', text: 'Inicio', value: 'Inicio', link: '/'  },
  { icon: 'mdi-account-group-outline', text: 'Autores', value: 'Autores', link: '/authors'  },
  { icon: 'mdi-book-open-page-variant-outline', text: 'Libros', value: 'Libros', link: '/books'  }

]

onMounted(() => {
  store.getAuthors()
})

</script>

<template>
  <v-app>
    <v-navigation-drawer v-model="drawer" :rail="rail" permanent @click="rail = false">
      <v-list-item :prepend-avatar="imgURL" title="Eurocorp" nav>
        <template v-slot:append>
          <v-btn icon="mdi-chevron-left" variant="text" @click.stop="rail = !rail"></v-btn>
        </template>
      </v-list-item>

      <v-divider></v-divider>

      <v-list density="compact" nav>
        <v-list-item v-for="(nav, index) in navItems"
          :key="index" 
          :prepend-icon="nav.icon" 
          :title="nav.text" 
          :value="nav.value" 
          :to="nav.link"
          color="light-blue-darken-4"
          >
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-main>
      <v-container>
        <router-view />
      </v-container>
    </v-main>
  </v-app>
</template>


