
using backend_api.DTOs;
using backend_api.Models;

namespace backend_api.Interfaces
{
  public interface IBookService
  {
    Task<IEnumerable<BookDto>> GetBooksAsync();
    Task<BookDto> GetBookByIdAsync(Guid id);
    Task<Book> CreateBookAsync(BookCreateDto bookDto);
    Task<bool> UpdateBookAsync(Guid id, BookUpdateDto bookDto);
    Task<bool> DeleteBookAsync(Guid id);
  }
}