using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistenz.Migrations
{
    public partial class InitialeErstellen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Marken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marken", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Marken",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Porsche" });

            migrationBuilder.InsertData(
                table: "Marken",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "BMW" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Marken");
        }
    }
}
