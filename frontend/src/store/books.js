import { defineStore } from "pinia";

const URL = 'http://localhost:5299/api/books'

export const useBooksStore = defineStore('booksStore', {
  state: () => ({
    books: [],
  }),
  actions: {
    async getBooks() {
      let response = await fetch(URL)
      let data = await response.json()
      console.log('data books', data)
      this.books = await data
    },
    async updateBook(id, bodyBook) {
      let response = await fetch(`${URL}/${id}`, {
        method: 'PUT',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(bodyBook)
      })

      if (response.ok) this.getBooks()
    },
    async deleteBook(id) {
      let response = await fetch(`${URL}/${id}`, {
        method: 'DELETE'
      })

      if (response.ok) this.getBooks()
    },
    async createBook(newBookBody) {
      let response = await fetch(`${URL}`, {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json'
        },
        body: JSON.stringify(newBookBody)
      })

      if (response.ok) this.getBooks()
    }

  },
  getters: {
    getOnlyBooksTable(state) {
      if (state.books.length > 0) {
        return state.books.map(book => {
          let bookId = book.bookId
          let title = book.title
          let year = book.year
          let genderBook = book.genderBook
          let numPages = book.numPages
          let authorName = book.author.name
          let authorId = book.authorId

          return {
            bookId,
            title,
            year,
            genderBook,
            numPages,
            authorName,
            authorId
          }
        })
      } else {
        return []
      }
    }
  }
})