using Microsoft.EntityFrameworkCore.Migrations;

namespace WM.Core.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Category = table.Column<int>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: true),
                    Supplier = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Manufacturer", "Name", "Price", "Supplier" },
                values: new object[] { 1, 0, "Store fresh at 7C", "PACIFIC FRUIT LTD DOO", "Banana", 64.0, "Maxi" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Manufacturer", "Name", "Price", "Supplier" },
                values: new object[] { 2, 1, "White potatoes", "FRUIT COMPANY DOO", "Potato", 33.0, "Maxi" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Category", "Description", "Manufacturer", "Name", "Price", "Supplier" },
                values: new object[] { 3, 3, "Nutella cream 750g", "DELTA DMD DOO", "Nutella", 689.99000000000001, "Maxi" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
