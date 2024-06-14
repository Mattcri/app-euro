
using backend_api.Context;
using backend_api.DTOs;
using backend_api.Interfaces;
using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Services
{
  public class AuthorService : IAuthorService
  {
    private readonly dbEuroContext _context;

    public AuthorService(dbEuroContext context) {
      _context = context;
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
      return await _context.Authors
        .Include(a => a.Books)
        .Select(a => new AuthorDto
        {
          AuthorId = a.AuthorId,
          Rut = a.Rut,
          Name = a.Name,
          DateOfBirth = a.DateOfBirth,
          GenderSex = a.GenderSex.ToString(),
          Email = a.Email,
          City = a.City,
          Books = a.Books.Select(b => new BookDto 
          {
            BookId = b.BookId,
            AuthorId = b.AuthorId,
            Title = b.Title,
            Year = b.Year,
            GenderBook = b.GenderBook,
            NumPages = b.NumPages
          }).ToList()
        })
        .ToListAsync();
    }

    public async Task<AuthorDto> GetAuthorByIdAsync(Guid id)
    {
      var author = await _context.Authors
        .Include(a => a.Books)
        .FirstOrDefaultAsync(a => a.AuthorId == id);

      if (author == null)
      {
        return null;
      }

      return new AuthorDto
      {
        AuthorId = author.AuthorId,
        Rut = author.Rut,
        Name = author.Name,
        DateOfBirth = author.DateOfBirth,
        GenderSex = author.GenderSex.ToString(),
        Email = author.Email,
        City = author.City,
        Books = author.Books.Select(b => new BookDto 
        {
          BookId = b.BookId,
          AuthorId = b.AuthorId,
          Title = b.Title,
          Year = b.Year,
          GenderBook = b.GenderBook,
          NumPages = b.NumPages
        }).ToList()
      };
    }

    public async Task<Author> CreateAuthorAsync(AuthorCreateDto authorDto)
    {
      if (!Enum.TryParse<Gender>(authorDto.GenderSex, out var gender))
      {
        throw new ArgumentException("Género inválido");
      }

      var author = new Author
      {
        AuthorId = Guid.NewGuid(),
        Rut = authorDto.Rut,
        Name = authorDto.Name,
        DateOfBirth = authorDto.DateOfBirth,
        GenderSex = gender,
        Email = authorDto.Email,
        City = authorDto.City
      };

      _context.Authors.Add(author);
      await _context.SaveChangesAsync();

      return author;
    }

    public async Task<bool> UpdateAuthorAsync(Guid id, AuthorUpdateDto authorDto)
    {
      if (!Enum.TryParse<Gender>(authorDto.GenderSex, out var gender))
      {
        throw new ArgumentException("Género inválido");
      }

      var author = await _context.Authors.FindAsync(id);

      if (author == null)
      {
        return false;
      }

      author.Name = authorDto.Name;
      author.DateOfBirth = authorDto.DateOfBirth;
      author.GenderSex = gender;
      author.Email = authorDto.Email;
      author.City = authorDto.City;

      _context.Entry(author).State = EntityState.Modified;
      await _context.SaveChangesAsync();

      return true;
    }

    public async Task<bool> DeleteAuthorAsync(Guid id)
    {
      var author = await _context.Authors.FindAsync(id);

      if (author == null)
      {
        return false;
      }

      _context.Authors.Remove(author);
      await _context.SaveChangesAsync();

      return true;
    }

  }

}