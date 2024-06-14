using System.Text.Json.Serialization;

namespace backend_api.Models
{
  public class Author
  {
    public Guid AuthorId { get; set; }

    public required string Rut { get; set; }

    public required string Name { get; set; }

    public DateTime DateOfBirth { get; set; }

    public Gender GenderSex { get; set; }

    public required string Email { get; set; }

    public string? City { get; set; }
    [JsonIgnore]
    public virtual ICollection<Book> Books { get; set; }

  }

  public enum Gender
  {
    Masculino,
    Femenino,
    Otro
  }

}
