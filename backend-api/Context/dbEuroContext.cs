using backend_api.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_api.Context
{
  public class dbEuroContext: DbContext
  {
    public dbEuroContext(DbContextOptions<dbEuroContext> options) : base(options) { }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          List<Author> authorSeed =
          [
              new Author() {
                AuthorId = Guid.Parse("2afe10ff-ae64-4344-9cf8-4e787188e4d6"),
                Rut = "19220247-7",
                Name = "Aldous Huxley",
                DateOfBirth = new DateTime(1894, 3, 7),
                Email = "aldous@gmail.com",
                City = "Londres",
                GenderSex = Gender.Masculino
              },
              new Author() {
                AuthorId = Guid.Parse("71064522-0fb7-478b-853d-c589a49dbdd2"),
                Rut = "13371020-5",
                Name = "Isabel Allende",
                DateOfBirth = new DateTime(1942, 8, 2),
                Email = "iallende@gmail.com",
                City = "Santiago",
                GenderSex = Gender.Femenino
              },
          ];


          modelBuilder.Entity<Author>(author => {
            author.ToTable("Autor");
            author.HasKey(a => a.AuthorId);
            author.Property(a => a.Rut).IsRequired().HasColumnType("VARCHAR(11)");
            author.Property(a => a.Name).IsRequired().HasMaxLength(100);
            author.Property(a => a.DateOfBirth).IsRequired().HasColumnType("DATE");
            author.Property(a => a.Email).IsRequired();
            author.Property(a => a.City).IsRequired(false);
            author.Property(a => a.GenderSex);
            author.HasData(authorSeed);
          });

          List<Book> bookSeed =
          [
            new Book() {
              BookId = Guid.Parse("08259855-554d-4d8f-a51c-32fb8c7dc3a2"),
              AuthorId = Guid.Parse("2afe10ff-ae64-4344-9cf8-4e787188e4d6"),
              Title = "Un mundo feliz",
              Year = 1982,
              GenderBook = "Ficción distópica",
              NumPages = 275
            },
            new Book() {
              BookId = Guid.Parse("dddfec9d-cd41-4c61-98d6-ba6d98cfa0df"),
              AuthorId = Guid.Parse("71064522-0fb7-478b-853d-c589a49dbdd2"),
              Title = "La casa de los espíritus",
              Year = 1932,
              GenderBook = "Realismo mágico",
              NumPages = 464
            },
          ];
            
          modelBuilder.Entity<Book>(book => {
            book.ToTable("Libro");
            book.HasKey(b => b.BookId);
            book.HasOne(b => b.Author).WithMany(b => b.Books).HasForeignKey(b => b.AuthorId);
            book.Property(b => b.Title).IsRequired().HasMaxLength(120);
            book.Property(b => b.Year).IsRequired();
            book.Property(b => b.GenderBook).IsRequired().HasMaxLength(120);
            book.Property(b => b.NumPages).IsRequired();
            book.HasData(bookSeed);
          });

        }

    }
}
