using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistenz.Migrations
{
    public partial class Modelle_Erstellen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modelle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MarkeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TagesPreis = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BildUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modelle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modelle_Marken_MarkeId",
                        column: x => x.MarkeId,
                        principalTable: "Marken",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Modelle",
                columns: new[] { "Id", "BildUrl", "MarkeId", "Name", "TagesPreis" },
                values: new object[] { 1, "", 1, "Panamera", 1000m });

            migrationBuilder.InsertData(
                table: "Modelle",
                columns: new[] { "Id", "BildUrl", "MarkeId", "Name", "TagesPreis" },
                values: new object[] { 2, "", 2, "760 LI", 1100m });

            migrationBuilder.InsertData(
                table: "Modelle",
                columns: new[] { "Id", "BildUrl", "MarkeId", "Name", "TagesPreis" },
                values: new object[] { 3, "", 1, "Cayenne", 1000m });

            migrationBuilder.CreateIndex(
                name: "IX_Modelle_MarkeId",
                table: "Modelle",
                column: "MarkeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Modelle");
        }
    }
}
