using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Web.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Caategory = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Caategory", "Description", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Telefon", "Samusungun en iyi telefonu", "Samsung S24", 40000m },
                    { 2, "Telefon", "Samusungun en iyi telefonu", "Samsung S25", 50000m },
                    { 3, "Telefon", "Samusungun en iyi telefonu", "Samsung S26", 60000m },
                    { 4, "Telefon", "Samusungun en iyi telefonu", "Samsung S27", 70000m },
                    { 5, "Telefon", "Samusungun en iyi telefonu", "Samsung S28", 80000m },
                    { 6, "Telefon", "Samusungun en iyi telefonu", "Samsung S29", 90000m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
