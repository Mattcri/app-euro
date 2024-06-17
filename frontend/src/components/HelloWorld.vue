<template>
  <v-container>
    <v-row class="text-center">
      <v-col cols="12">
        <v-img :src="logo" class="my-3" contain height="200" />
      </v-col>

      <v-col cols="3">
        <v-btn rounded="lg" size="large" block to="/authors">Go to authors</v-btn>
      </v-col>

    </v-row>
  </v-container>
</template>

<script>
import logo from '../assets/logo.svg'

export default {
  name: 'HelloWorld',

  data: () => ({
    ecosystem: [
      {
        text: 'vuetify-loader',
        href: 'https://github.com/vuetifyjs/vuetify-loader/tree/next',
      },
      {
        text: 'github',
        href: 'https://github.com/vuetifyjs/vuetify/tree/next',
      },
      {
        text: 'awesome-vuetify',
        href: 'https://github.com/vuetifyjs/awesome-vuetify',
      },
    ],
    importantLinks: [
      {
        text: 'Chat',
        href: 'https://community.vuetifyjs.com',
      },
      {
        text: 'Made with Vuetify',
        href: 'https://madewithvuejs.com/vuetify',
      },
      {
        text: 'Twitter',
        href: 'https://twitter.com/vuetifyjs',
      },
      {
        text: 'Articles',
        href: 'https://medium.com/vuetify',
      },
    ],
    logo,
    whatsNext: [
      {
        text: 'Explore components',
        href: 'https://vuetifyjs.com',
      },
      {
        text: 'Roadmap',
        href: 'https://vuetifyjs.com/introduction/roadmap/',
      },
      {
        text: 'Frequently Asked Questions',
        href: 'https://vuetifyjs.com/getting-started/frequently-asked-questions',
      },
    ],
  }),
}
</script>
