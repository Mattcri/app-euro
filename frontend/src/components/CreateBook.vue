<script setup>
import { useAuthorsStore } from '@/store/authors';
import { useBooksStore } from '@/store/books';
import { ref, computed } from 'vue';

const storeAuthors = useAuthorsStore()
const storeBooks = useBooksStore()

const authorsInfo = computed(() => storeAuthors.getNameAndIdAuthor)

const dialog = ref(false)
const valid = ref(false)
const bookCreate = ref({
  authorId: '',
  title: '',
  year: '',
  genderBook: '',
  numPages: '',
})
const rules = {
  required: v => !!v || 'Requerido',
  minLength: min => v => (v && v.length >= min) || `Min. ${min} caracteres`,
  maxLength: max => v => (v && v.length <= max) || `Max. ${max} caracteres`,
  rangePage: v => v >= 15 || 'El número de páginas debe ser superior a 15',
  rangeYear: v => v > 1300 || 'El año debe ser superior al 1300 d.c'
}

function closeDialog() {
  dialog.value = false
  bookCreate.value = ref({
    authorId: '',
    title: '',
    year: '',
    genderBook: '',
    numPages: '',
  })
}

function create(event) {
  event.preventDefault()
  console.log('data send: ', bookCreate.value)
  if (valid.value) {
    storeBooks.createBook(bookCreate.value)
    closeDialog()
  }
}

function validateField(fieldName) {
  const field = bookCreate.value[fieldName]
  rules[field]
}

</script>


<template>
  <v-btn append-icon="mdi-plus-circle" color="blue-grey-lighten-5"
    variant="elevated" class="mr-3" @click="dialog = true">
    <template v-slot:append>
      <v-icon color="success" size="large"></v-icon>
    </template>
    Registrar nuevo libro
  </v-btn>

  <v-dialog
    v-model="dialog"
    max-width="600"
  >
    <v-card
      prepend-icon="mdi-book-open-blank-variant"
      title="Crear un nuevo libro"
    >
      <template v-slot:prepend>
        <v-icon color="indigo" size="large"></v-icon>
      </template>
      <v-card-text>
        <v-form ref="form" v-model="valid">
          <v-row dense>
            <v-col cols="12" md="6">
              <v-text-field
                label="Título*"
                v-model="bookCreate.title"
                :rules="[rules.required, rules.minLength(4), rules.maxLength(100)]"
                
                required
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field
                v-model="bookCreate.genderBook"
                label="Género libro*"
                :rules="[rules.required, rules.minLength(6), rules.maxLength(60)]"
                
                required
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field
                v-model="bookCreate.numPages"
                label="N° de páginas*"
                :rules="[rules.required, rules.rangePage]"
                
              ></v-text-field>
            </v-col>
            <v-col cols="12" md="6">
              <v-text-field
                v-model="bookCreate.year"
                label="Año publicación*"
                :rules="[rules.required, rules.rangeYear]"
                
              ></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-select
                v-model="bookCreate.authorId"
                label="Seleccionar Autor"
                :items="authorsInfo"
                item-title="name"
                item-value="authorId"
                :rules="[rules.required]"
                required
              ></v-select>
            </v-col>
          </v-row>

        </v-form>
      </v-card-text>

      <v-divider class="my-3"></v-divider>
      <v-card-actions>
        <v-btn color="blue darken-1" text @click="closeDialog">Cancelar</v-btn>
        <v-btn color="blue darken-1" text @click="create" :disabled="valid === true ? false : true">Crear</v-btn>
      </v-card-actions>

    </v-card>
  </v-dialog>

</template>