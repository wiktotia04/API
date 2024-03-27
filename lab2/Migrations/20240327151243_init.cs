using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Baza_Danych",
                keyColumn: "Index",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Baza_Danych",
                columns: new[] { "Index", "WalutaDb", "WartoscDb" },
                values: new object[] { 1, "BAM", 1.8001749515533447 });
        }
    }
}
