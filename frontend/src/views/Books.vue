<script setup>
import TableBooks from '@/components/TableBooks.vue';
import CreateBook from '@/components/CreateBook.vue';
import { useBooksStore } from '@/store/books';
import { onMounted, ref } from 'vue';

const store = useBooksStore()

onMounted(() => {
  store.getBooks()
})

</script>


<template>
  <div>
    <h2 class="text-h4">Books Page</h2>
    <v-divider class="my-3"></v-divider>
    <div class="d-flex align-center justify-space-between mb-3">
      <h3 class="text-h6">Lista de Libros registrados</h3>
      <create-book />
    </div>

    <table-books />
    
  </div>
</template>
