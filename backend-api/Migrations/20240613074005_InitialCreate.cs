using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rut = table.Column<string>(type: "VARCHAR(11)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATE", nullable: false),
                    GenderSex = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    GenderBook = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    NumPages = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Autor",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AuthorId",
                table: "Libro",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
