<script setup>
import { useAuthorsStore } from '@/store/authors';
import { useBooksStore } from '@/store/books';
import { computed, ref } from 'vue';

const storeAuthors = useAuthorsStore()
const storeBooks = useBooksStore()

const tableInfo = computed(() => storeBooks.getOnlyBooksTable)
const authorsInfo = computed(() => storeAuthors.getNameAndIdAuthor)

const headers = [
  { title: 'Título libro', key: 'title' },
  { title: 'Autor', key: 'authorName' },
  { title: 'Género', key: 'genderBook' },
  { title: 'Año', key: 'year' },
  { title: 'N° de páginas', key: 'numPages' },
  { title: 'Acciones', key: 'actions', sortable: false },
]
const dialogUpdate = ref(false)
const dialogDelete = ref(false)
const editedIndex = ref(-1)
const editedItem = ref({
  title: '',
  year: '',
  genderBook: '',
  numPages: '',
  authorId: '',
})
const defaultItem = ref({
  title: '',
  year: '',
  genderBook: '',
  numPages: '',
  authorId: '',
})
let bookIdSelected = ref('')

function editItemModal(item) {
  editedIndex.value = tableInfo.value.indexOf(item);
  editedItem.value = Object.assign({}, item);
  bookIdSelected.value = item.bookId
  console.log(bookIdSelected)
  dialogUpdate.value = true;
}

function deleteItem(item) {
  editedIndex.value = tableInfo.value.indexOf(item);
  editedItem.value = Object.assign({}, item);
  bookIdSelected.value = item.bookId
  dialogDelete.value = true;
}

function deleteItemConfirm() {
  storeBooks.deleteBook(bookIdSelected.value);
  closeDelete();
}

function close() {
  dialogUpdate.value = false;
  editedItem.value = Object.assign({}, defaultItem.value);
  editedIndex.value = -1;
  bookIdSelected.value = ''
}

function closeDelete() {
  dialogDelete.value = false;
  editedItem.value = Object.assign({}, defaultItem.value);
  editedIndex.value = -1;
  bookIdSelected.value = ''
}

function save() {
  if (bookIdSelected.value !== '') {
    storeBooks.updateBook(bookIdSelected.value, editedItem.value)
  }
  close()
}


</script>

<template>
  <v-data-table 
    :headers="headers"
    :items="tableInfo"
    :sort-by="[{ key: 'title', order: 'asc' }]"
  >
    <template v-slot:item.actions="{ item }">
      <v-icon class="me-2" color="blue-grey-darken-2" size="large" @click="editItemModal(item)">
        mdi-pencil
      </v-icon>
      <v-icon size="large" color="red-darken-1" @click="deleteItem(item)">
        mdi-delete
      </v-icon>
    </template>

  </v-data-table>

  <!-- Dialog para editar autor -->
  <v-dialog v-model="dialogUpdate" max-width="600px">
    <v-card>
      <v-card-title>
        <span class="headline">Editar registro del libro</span>
      </v-card-title>
      <v-card-text>
        <v-row dense>
          <v-col cols="12" sm="6" >
            <v-text-field v-model="editedItem.title" label="Título"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" >
            <v-text-field v-model="editedItem.year" label="Año publicación"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" >
            <v-text-field v-model="editedItem.genderBook" label="Género literario"></v-text-field>
          </v-col>
          <v-col cols="12" sm="6" >
            <v-text-field v-model="editedItem.numPages" label="N° de páginas"></v-text-field>
          </v-col>
          <v-col cols="12" sm="12" >
            <v-select
              v-model="editedItem.authorId"
              :items="authorsInfo"
              label="¿Quieres cambiar el autor?"
              item-title="name"
              item-value="authorId"
            ></v-select>
          </v-col>
        </v-row>
      </v-card-text>
      <v-divider></v-divider>
      <v-card-actions class="text-center">
        <v-btn color="blue darken-1" text @click="close">Cancelar</v-btn>
        <v-btn color="blue darken-1" text @click="save">Guardar</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

  <!-- Dialogo para confirmar eliminación -->
  <v-dialog v-model="dialogDelete" max-width="500px">
    <v-card>
      <v-card-title class="text-center">Estas seguro que quieres eliminar este autor?</v-card-title>
      <v-divider></v-divider>
      <v-card-actions >
        <v-btn color="blue darken-1" text @click="closeDelete">Cancelar</v-btn>
        <v-btn color="blue darken-1" text @click="deleteItemConfirm">Confirmar</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>

</template>