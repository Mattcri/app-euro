<script setup>
import { useAuthorsStore } from '@/store/authors'
import { onMounted, ref, computed } from 'vue'
import Searcher from "@/components/Searcher.vue"

const store = useAuthorsStore()
const searchQuery = ref('')

const searchResults = computed(() => store.searchInfo(searchQuery.value))

</script>

<template>
  <h2 class="text-h4 mb-3">Home</h2>
  <v-divider></v-divider>
  <p class="my-4">Ingresa una búsqueda por nombre, rut, ciudad o título del libro</p>
  <searcher v-model="searchQuery" />
  <v-divider class="my-3 my-md-7"></v-divider>

  <div v-if="searchResults.length > 0">
    <v-row>
      <v-col v-for="author in searchResults" :key="author.authorId" cols="12" md="6" lg="4" class="mb-4">
        <v-card
          color="blue-darken-2"
          variant="outlined"
          :title="author.name"
        >
          <template v-slot:prepend>
              <v-icon color="blue-darken-4" icon="mdi-account-circle" size="x-large"></v-icon>
            </template>
          <v-card-subtitle>Ciudad: {{ author.city }}</v-card-subtitle>
          <v-divider class="mt-3 mx-3"></v-divider>
          <v-card-text>
            <p class="text-body-1" style="color: #000000de;"><span class="font-weight-medium">RUT:</span> {{ author.rut }}</p>
            <p class="text-body-1" style="color: #000000de;"><span class="font-weight-medium">Email:</span> {{ author.email }}</p>
            <p class="text-body-1 font-weight-medium" style="color: #000000de;">Libros:</p>
            <v-list class="py-1">
              <v-list-item 
                v-for="book in author.books" 
                :key="book.bookId"
                :value="book.title"
                color="primary"
                rounded="lg"
              >
                <template v-slot:prepend>
                  <v-icon color="blue-darken-4" icon="mdi-book-open-outline"></v-icon>
                </template>
                <v-list-item-title v-text="book.title"></v-list-item-title>
              </v-list-item>
            </v-list>
            
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