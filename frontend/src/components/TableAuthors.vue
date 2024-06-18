<script setup>
import { useAuthorsStore } from '@/store/authors';
import { computed, ref } from 'vue'

const store = useAuthorsStore()
const tableInfo = computed(() => store.getOnlyAuthorsTable)

const headers = [
  { title: 'Nombre', key: 'name' },
  { title: 'RUT', key: 'rut' },
  { title: 'Fecha de nacimiento', key: 'dateOfBirth' },
  { title: 'Género', key: 'genderSex' },
  { title: 'Email', key: 'email' },
  { title: 'Ciudad', key: 'city' },
  { title: 'Acciones', key: 'actions', sortable: false },
]
const dialog = ref(false)
const dialogDelete = ref(false)
const editedIndex = ref(-1)
const editedItem = ref({
  name: '',
  dateOfBirth: '',
  genderSex: '',
  email: '',
  city: '',
})
const defaultItem = ref({
  name: '',
  dateOfBirth: '',
  genderSex: '',
  email: '',
  city: '',
})
let authorIdSelected = ref('')

const formTitle = 'Editar Autor'

function initialize() {
  store.getAuthors();
}

function editItemModal(item) {
  editedIndex.value = tableInfo.value.indexOf(item);
  editedItem.value = Object.assign({}, item);
  console.log('edit', item);
  authorIdSelected = item.authorId
  console.log(authorIdSelected)
  dialog.value = true;
}

function deleteItem(item) {
  editedIndex.value = tableInfo.value.indexOf(item);
  editedItem.value = Object.assign({}, item);
  authorIdSelected = item.authorId
  dialogDelete.value = true;
}

function deleteItemConfirm() {
  store.deleteAuthor(authorIdSelected);
  closeDelete();
}

function close() {
  dialog.value = false;
  editedItem.value = Object.assign({}, defaultItem.value);
  editedIndex.value = -1;
  authorIdSelected = ref('')
}

function closeDelete() {
  dialogDelete.value = false;
  editedItem.value = Object.assign({}, defaultItem.value);
  editedIndex.value = -1;
  authorIdSelected = ref('')
}

function save() {
  if (authorIdSelected !== '') {
    store.updateAuthor(authorIdSelected, editedItem.value);
  }
  close();
  // console.log('clean author selected:', authorIdSelected)
}

// initialize()
</script>

<template>
  <div>
    
    <v-data-table 
      :headers="headers"
      :items="tableInfo"
      :sort-by="[{ key: 'name', order: 'asc' }]"
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

    <!-- Dialogo para editar autor -->
    <v-dialog v-model="dialog" max-width="500px">
      <v-card>
        <v-card-title>
          <span class="headline">{{ formTitle }}</span>
        </v-card-title>
        <v-card-text>
          <p></p>
          <v-container>
            <v-row>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="editedItem.name" label="Nombre"></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="editedItem.dateOfBirth" label="Fecha de nacimiento"></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="editedItem.genderSex" label="Género"></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="editedItem.email" label="Email"></v-text-field>
              </v-col>
              <v-col cols="12" sm="6" md="4">
                <v-text-field v-model="editedItem.city" label="Ciudad"></v-text-field>
              </v-col>
            </v-row>
          </v-container>
        </v-card-text>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="close">Cancelar</v-btn>
          <v-btn color="blue darken-1" text @click="save">Guardar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

    <!-- Dialogo para confirmar eliminación -->
    <v-dialog v-model="dialogDelete" max-width="500px">
      <v-card>
        <v-card-title class="headline">Estás seguro que quieres eliminar este autor?</v-card-title>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="blue darken-1" text @click="closeDelete">Cancelar</v-btn>
          <v-btn color="blue darken-1" text @click="deleteItemConfirm">Confirmar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>

  </div>
</template>