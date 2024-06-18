import { defineStore } from "pinia";

const URL = 'http://localhost:5299/api/authors'

export const useAuthorsStore = defineStore('authors', {
  state: () => ({
    authors: [],
  }),
  actions: {
    async getAuthors() {
      let response = await fetch(URL)
      let data = await response.json()
      console.log('data', data)
      this.authors = await data

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
    },

    async updateAuthor(id, updatedAuthor) {
      let response = await fetch(`${URL}/${id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(updatedAuthor)
      })
      console.log('id store', id)

      if (response.ok) this.getAuthors()
    },

    async deleteAuthor(id) {
      let response = await fetch(`${URL}/${id}`, {
        method: 'DELETE'
      })

      if (response.ok) this.getAuthors()
    },

    async createAuthor(newAuthor) {
      let response = await fetch(URL, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(newAuthor)
      })

      if (response.ok) this.getAuthors()
    }

  },
  getters: {
    getOnlyAuthorsTable(state) {
      return state.authors.length > 0 ? state.authors.map(author => {
        let authorId = author.authorId
        let name = author.name
        let rut = author.rut
        let dateOfBirth = author.dateOfBirth
        let genderSex = author.genderSex
        let email = author.email
        let city = author.city

        return {
          authorId,
          name,
          rut,
          dateOfBirth,
          genderSex,
          email,
          city
        }
      }) : []
    },
    
  }
})