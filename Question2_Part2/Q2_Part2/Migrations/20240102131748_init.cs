using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Q2_Part2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product_Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Catagory = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Info", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product_Info");
        }
    }
}
