using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab2.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Baza_Danych",
                columns: table => new
                {
                    Index = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WalutaDb = table.Column<string>(type: "TEXT", nullable: false),
                    WartoscDb = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Baza_Danych", x => x.Index);
                });

            migrationBuilder.InsertData(
                table: "Baza_Danych",
                columns: new[] { "Index", "WalutaDb", "WartoscDb" },
                values: new object[] { 1, "BAM", 1.8001749515533447 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Baza_Danych");
        }
    }
}
