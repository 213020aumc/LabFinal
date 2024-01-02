using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q2_Part1.Migrations
{
    public partial class MyBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Book_Info",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookTitle = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    BookAuthor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    ISBN = table.Column<int>(type: "int", nullable: true),
                    Publication_Year = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Book_Inf__3DE0C2078D7FE96E", x => x.BookId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Book_Info");
        }
    }
}
