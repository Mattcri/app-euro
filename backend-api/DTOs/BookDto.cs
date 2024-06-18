using System.Text.Json.Serialization;

namespace backend_api.DTOs
{
  public class BookDto
  {
    public Guid BookId { get; set; }
    public Guid AuthorId { get; set; }
    public required string Title { get; set; }
    public int Year { get; set; }
    public required string GenderBook { get; set; }
    public int NumPages { get; set; }
    public AuthorDto? Author { get; set; }
  }

  // BookId se crea automaticamente en la implementación
  public class BookCreateDto
  { 
    public Guid AuthorId { get; set; }
    public required string Title { get; set; }
    public int Year { get; set; }
    public required string GenderBook { get; set; }
    public int NumPages { get; set; }
  }

  // Solo es necesario los datos a modificar
  public class BookUpdateDto
  {
    public Guid AuthorId { get; set; }
    public required string Title { get; set; }
    public int Year { get; set; }
    public required string GenderBook { get; set; }
    public int NumPages { get; set; }
  }

}
