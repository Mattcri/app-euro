
using backend_api.Context;
using backend_api.DTOs;
using backend_api.Interfaces;
using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Services
{
  public class BookService : IBookService
  {
    private readonly dbEuroContext _context;
    private const int MaxBooks = 10;

    public BookService(dbEuroContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<BookDto>> GetBooksAsync()
    {
      return await _context.Books
        .Include(b => b.Author)
        .Select(b => new BookDto
        {
          BookId = b.BookId,
          AuthorId = b.AuthorId,
          Title = b.Title,
          Year = b.Year,
          GenderBook = b.GenderBook,
          NumPages = b.NumPages,
          Author = new AuthorDto
          {
            AuthorId = b.Author.AuthorId,
            Rut = b.Author.Rut,
            Name = b.Author.Name,
            DateOfBirth = b.Author.DateOfBirth,
            GenderSex = b.Author.GenderSex.ToString(),
            Email = b.Author.Email,
            City = b.Author.City
          }
        })
        .ToListAsync();
    }

    public async Task<BookDto> GetBookByIdAsync(Guid id)
    {
      var book = await _context.Books
        .Include(b => b.Author)
        .FirstOrDefaultAsync(b => b.BookId == id);

      if (book == null)
      {
        return null;
      }

      return new BookDto
      {
        BookId = book.BookId,
        AuthorId = book.AuthorId,
        Title = book.Title,
        Year = book.Year,
        GenderBook = book.GenderBook,
        NumPages = book.NumPages,
        Author = new AuthorDto
        {
          AuthorId = book.Author.AuthorId,
          Rut = book.Author.Rut,
          Name = book.Author.Name,
          DateOfBirth = book.Author.DateOfBirth,
          GenderSex = book.Author.GenderSex.ToString(),
          Email = book.Author.Email,
          City = book.Author.City
        }
      };
    }

    public async Task<Book> CreateBookAsync(BookCreateDto bookDto)
    {
      var author = await _context.Authors.FindAsync(bookDto.AuthorId);
      var countBooksPerAuthor = await _context.Books.CountAsync(b => b.AuthorId == bookDto.AuthorId);

      if (author == null)
      {
        throw new Exception("Autor no registrado");
      }

      if (countBooksPerAuthor >= MaxBooks)
      {
        throw new Exception("No es posible crear el registro, dado que el autor alcanzo el máximo de libros permitidos");
      }

      var book = new Book
      {
        BookId = Guid.NewGuid(),
        AuthorId = bookDto.AuthorId,
        Title = bookDto.Title,
        Year = bookDto.Year,
        GenderBook = bookDto.GenderBook,
        NumPages = bookDto.NumPages
      };

      _context.Books.Add(book);
      await _context.SaveChangesAsync();

      return book;
    }

    public async Task<bool> UpdateBookAsync(Guid id, BookUpdateDto bookDto)
    {
      var book = await _context.Books.FindAsync(id);

      if (book == null)
      {
        return false;
      }

      book.AuthorId = bookDto.AuthorId;
      book.Title = bookDto.Title;
      book.Year = bookDto.Year;
      book.GenderBook = bookDto.GenderBook;
      book.NumPages = bookDto.NumPages;

      _context.Entry(book).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return true;
    }

    public async Task<bool> DeleteBookAsync(Guid id)
    {
      var book = await _context.Books.FindAsync(id);

      if (book == null)
      {
        return false;
      }

      _context.Books.Remove(book);
      await _context.SaveChangesAsync();

      return true;
    }

  }
}