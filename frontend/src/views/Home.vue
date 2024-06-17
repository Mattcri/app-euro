<script setup>
import { useAuthorsStore } from '@/store/authors'
import { onMounted, ref, computed } from 'vue'
import Searcher from "@/components/Searcher.vue"

const store = useAuthorsStore()
const searchQuery = ref('')

onMounted(() => {
  store.getAuthors()
})

const searchResults = computed(() => store.searchInfo(searchQuery.value))
const lastSearch = computed(() => store.firtsAuthors || [])

</script>

<template>
  <h2 class="mb-3">Home</h2>
  <v-divider></v-divider>
  <p class="my-3">Ingresa una búsqueda por nombre, rut, ciudad o título del libro</p>
  <searcher :lastSearch="lastSearch" v-model="searchQuery" />
  <v-divider class="my-2 my-md-6"></v-divider>

  <div v-if="searchResults.length > 0">
    <v-row>
      <v-col v-for="author in searchResults" :key="author.authorId" cols="12" md="6" lg="4" class="mb-4">
        <v-card>
          <v-card-title>{{ author.name }}</v-card-title>
          <v-card-subtitle>{{ author.city }}</v-card-subtitle>
          <v-card-text>
            <p>RUT: {{ author.rut }}</p>
            <p>Email: {{ author.email }}</p>
            <p>Libros:</p>
            <ul>
              <li v-for="book in author.books" :key="book.bookId">{{ book.title }}</li>
            </ul>
          </v-card-text>
        </v-card>
      </v-col>
    </v-row>
  </div>
  <div v-else>
    <p>No se han encontrado resultados de la búsqueda</p>
  </div>


</template>

<style>

</style>