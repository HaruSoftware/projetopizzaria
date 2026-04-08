using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace crudcomdb.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "Pizza Calabresa", 39.90m },
                    { 2, "Pizza Marguerita", 42.50m },
                    { 3, "Pizza Frango com Catupiry", 45.00m },
                    { 4, "Refrigerante 2L", 12.00m },
                    { 5, "Pizza Portuguesa", 47.90m },
                    { 6, "Refrigerante", 9.90m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
