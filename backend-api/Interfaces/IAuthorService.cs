using backend_api.DTOs;
using backend_api.Models;

namespace backend_api.Interfaces
{
  public interface IAuthorService
  {
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    Task<AuthorDto> GetAuthorByIdAsync(Guid id);
    Task<Author> CreateAuthorAsync(AuthorCreateDto authorDto);
    Task<bool> UpdateAuthorAsync(Guid id, AuthorUpdateDto authorDto);
    Task<bool> DeleteAuthorAsync(Guid id);
  }
}