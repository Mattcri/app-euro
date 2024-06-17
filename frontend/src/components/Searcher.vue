
<template>
  <v-row justify="center">
    <v-col cols="12">
      <v-text-field 
        v-model="searchQuery"
        prepend-inner-icon="mdi-magnify"
        class="mx-auto" 
        density="comfortable"
        placeholder="Buscar" 
        style="max-width: 600px;" 
        theme="light"
        variant="solo" 
        outlined 
        @input="onInput" 
        hide-details="auto" />
      <!-- <p>{{ lastSearch }}</p> -->
    </v-col>
  </v-row>

</template>

<script setup>
import { ref, watch } from 'vue'

const props = defineProps({
  lastSearch: { type: Array, required: true },
  // bar: Number
})

const searchQuery = ref('')
const emit = defineEmits(['update:modelValue'])

const onInput = () => {
  emit('update:modelValue', searchQuery.value);
};

</script>