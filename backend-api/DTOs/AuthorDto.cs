using System.Text.Json.Serialization;

namespace backend_api.DTOs
{
  public class AuthorDto
  {
    public Guid AuthorId { get; set; }
    public required string Rut { get; set; }
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string GenderSex { get; set; }
    public required string Email { get; set; }
    public string? City { get; set; }
    public List<BookDto>? Books { get; set; }
  }

  public class AuthorCreateDto
  {
    public required string Rut { get; set; }
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string GenderSex { get; set; }
    public required string Email { get; set; }
    public string? City { get; set; }
  }

  public class AuthorUpdateDto
  {
    public required string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public required string GenderSex { get; set; }
    public required string Email { get; set; }
    public string? City { get; set; }
  }

}