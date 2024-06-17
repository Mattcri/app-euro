import { createRouter, createWebHistory } from 'vue-router'

import HomeView from '@/views/Home.vue'
import AuthorsView from '@/views/Authors.vue'
import BooksView from '@/views/Books.vue'

const routes = [
  { path: '/', component: HomeView },
  { path: '/authors', component: AuthorsView },
  { path: '/books', component: BooksView }

]

const router = createRouter({
  history: createWebHistory(),
  routes
})

export default router