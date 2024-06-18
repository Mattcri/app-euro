<script setup>
import TableAuthors from '@/components/TableAuthors.vue'
import { ref } from 'vue';
import { useAuthorsStore } from '../store/authors';

const store = useAuthorsStore()

const dialog = ref(false)
const valid = ref(false)
const menu = ref(false)
const authorCreate = ref({
  rut: '',
  name: '',
  dateOfBirth: '',
  genderSex: '',
  email: '',
  city: ''
})
const rules = {
  required: v => !!v || 'Requerido',
  minLength: min => v => (v && v.length >= min) || `Min. ${min} caracteres`,
  maxLength: max => v => (v && v.length <= max) || `Max. ${max} caracteres`,
  email: v => /.+@.+\..+/.test(v) || 'El email debe ser valido',
  rut: v => validateRut(v) || 'RUT invalido'
}

function closeDialog() {
  dialog.value = false
  authorCreate.value = {
    rut: '',
    name: '',
    dateOfBirth: '',
    genderSex: '',
    email: '',
    city: ''
  }
}

function create(event) {
  event.preventDefault()
  console.log('data send: ', authorCreate.value)
  if (valid.value) {
    store.createAuthor(authorCreate.value)
    closeDialog()
  }
}

function validateRut(rut) {
  if (!rut || rut.length < 9 || rut.length > 10) return false
  rut = rut.replace(/\./g, '').replace('-', '')
  const body = rut.slice(0, -1)
  const dv = rut.slice(-1).toUpperCase()

  let sum = 0
  let multi = 2

  for (let i = 1; i <= body.length; i++) {
    sum += multi * rut.charAt(body.length - i)
    if (multi == 7) multi = 2
    else multi++
  }

  const res = 11 - (sum % 11)
  let dvr = res == 11 ? '0' : res == 10 ? 'K' : res.toString()

  return dv === dvr
}

</script>

<template>
  <div>
    <h2 class="text-h4">Authors Page</h2>
    <v-divider class="my-3"></v-divider>
    <div class="d-flex align-center justify-space-between mb-3">
      <h3 class="text-h6">Lista de Autores registrados</h3>
      <v-btn append-icon="mdi-plus-circle" color="blue-grey-lighten-5"
        variant="elevated" class="mr-3" @click="dialog = true">
        <template v-slot:append>
          <v-icon color="success" size="large"></v-icon>
        </template>
        Crear autor
      </v-btn>
    </div>
    <table-authors />

    <v-dialog
      v-model="dialog"
      max-width="600"
    >
      <v-card
        prepend-icon="mdi-account-details"
        title="Estás creando un autor"
      >
        <template v-slot:prepend>
          <v-icon color="indigo" size="large"></v-icon>
        </template>
        <v-card-text>
          <v-form ref="form" v-model="valid">
            <v-row dense>
              <v-col cols="12" md="6">
                <v-text-field
                  label="Nombre*"
                  v-model="authorCreate.name"
                  :rules="[rules.required, rules.minLength(5), rules.maxLength(50)]"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" md="6">
                <v-text-field
                  v-model="authorCreate.email"
                  label="Email*"
                  :rules="[rules.required, rules.email]"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" md="6">
                <v-text-field
                  v-model="authorCreate.city"
                  label="Ciudad*"
                  :rules="[rules.minLength(4), rules.maxLength(65)]"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" md="6">
                <v-text-field
                  v-model="authorCreate.rut"
                  label="Ingresar Rut*"
                  :rules="[rules.required, rules.rut]"
                  required
                ></v-text-field>
              </v-col>
              <v-col cols="12" md="6">
                <input 
                  type="date"
                  class="input-date" 
                  v-model="authorCreate.dateOfBirth"
                  :rules="[rules.required]"
                  required
                >
                
              </v-col>
              <v-col cols="12" md="6">
                <v-select
                  v-model="authorCreate.genderSex"
                  :items="['Masculino', 'Femenino', 'Otro']"
                  label="Gender"
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
  </div>
</template>

<style scoped>
.input-date {
  width: 100%;
  border: 1px solid #f0f0f0;
  border-radius: 4px;
  padding: .9rem .5rem;
}
</style>