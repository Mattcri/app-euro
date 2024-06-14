using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backend_api.Models
{
  public class Book
  {
    public Guid BookId { get; set; }

    public Guid AuthorId { get; set; }

    public required string Title { get; set; }

    public int Year { get; set; }

    public required string GenderBook { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Ingresar un número de páginas valido")]
    public required int NumPages { get; set; }
    [JsonIgnore]
    public virtual Author Author { get; set; }
  }
  

}
