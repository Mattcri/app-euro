using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabaseWithInitData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Autor",
                columns: new[] { "AuthorId", "City", "DateOfBirth", "Email", "GenderSex", "Name", "Rut" },
                values: new object[,]
                {
                    { new Guid("2afe10ff-ae64-4344-9cf8-4e787188e4d6"), "Londres", new DateTime(1894, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "aldous@gmail.com", 0, "Aldous Huxley", "19220247-7" },
                    { new Guid("71064522-0fb7-478b-853d-c589a49dbdd2"), "Santiago", new DateTime(1942, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "iallende@gmail.com", 1, "Isabel Allende", "13371020-5" }
                });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "BookId", "AuthorId", "GenderBook", "NumPages", "Title", "Year" },
                values: new object[,]
                {
                    { new Guid("08259855-554d-4d8f-a51c-32fb8c7dc3a2"), new Guid("2afe10ff-ae64-4344-9cf8-4e787188e4d6"), "Ficción distópica", 275, "Un mundo feliz", 1982 },
                    { new Guid("dddfec9d-cd41-4c61-98d6-ba6d98cfa0df"), new Guid("71064522-0fb7-478b-853d-c589a49dbdd2"), "Realismo mágico", 464, "La casa de los espíritus", 1932 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Libro",
                keyColumn: "BookId",
                keyValue: new Guid("08259855-554d-4d8f-a51c-32fb8c7dc3a2"));

            migrationBuilder.DeleteData(
                table: "Libro",
                keyColumn: "BookId",
                keyValue: new Guid("dddfec9d-cd41-4c61-98d6-ba6d98cfa0df"));

            migrationBuilder.DeleteData(
                table: "Autor",
                keyColumn: "AuthorId",
                keyValue: new Guid("2afe10ff-ae64-4344-9cf8-4e787188e4d6"));

            migrationBuilder.DeleteData(
                table: "Autor",
                keyColumn: "AuthorId",
                keyValue: new Guid("71064522-0fb7-478b-853d-c589a49dbdd2"));
        }
    }
}
