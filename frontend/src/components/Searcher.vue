
<template>
  <v-row justify="center">
    <v-col cols="12">
      <v-text-field 
        v-model="searchQuery"
        prepend-inner-icon="mdi-magnify"
        class="mx-auto" 
        density="comfortable"
        style="max-width: 620px;" 
        variant="outlined" 
        
        @input="onInput" 
        label="Buscar"
        hide-details="auto" />
      <!-- <p>{{ lastSearch }}</p> -->
    </v-col>
  </v-row>

</template>

<script setup>
import { ref, watch } from 'vue'

const searchQuery = ref('')
const emit = defineEmits(['update:modelValue'])

const onInput = () => {
  emit('update:modelValue', searchQuery.value);
};

</script>