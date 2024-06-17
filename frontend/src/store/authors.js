import { defineStore } from "pinia";

const URL = 'http://localhost:5299/api/authors'

export const useAuthorsStore = defineStore('authors', {
  state: () => ({
    authors: null,
    firtsAuthors: null,
  }),
  actions: {
    async getAuthors() {
      let response = await fetch(URL)
      let data = await response.json()
      console.log('data', data)
      this.authors = await data

      this.firtsAuthors = this.authors.slice(0, 2).map(author => ({
        prependIcon: 'mdi-clock-outline',
        title: author.name
      }))
    },
    searchInfo(query) {
      if (!query) return []

      query = query.toLowerCase()

      return this.authors.filter(author => {
        return (
          author.name.toLowerCase().includes(query) ||
          author.rut.toLowerCase().includes(query) ||
          author.city.toLowerCase().includes(query) ||
          author.books.some(book => book.title.toLowerCase().includes(query))
        )
      })

    }

  }
})