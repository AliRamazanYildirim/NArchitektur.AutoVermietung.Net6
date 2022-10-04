using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistenz.Migrations
{
    public partial class JWT_Hinzufügen : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Benutzer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NachName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswortSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswortHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    AuthentifizierungsArt = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Benutzer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationsAnspruch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationsAnspruch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenAktualisieren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ablauf = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Erstellt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErstelltVonIp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Widerrufen = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WiderrufenVonIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ErsetztDurchToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrundWiderrufen = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenAktualisieren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TokenAktualisieren_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BenutzerOperationsAnspruch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BenutzerId = table.Column<int>(type: "int", nullable: false),
                    OperationsAnspruchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenutzerOperationsAnspruch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BenutzerOperationsAnspruch_Benutzer_BenutzerId",
                        column: x => x.BenutzerId,
                        principalTable: "Benutzer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BenutzerOperationsAnspruch_OperationsAnspruch_OperationsAnspruchId",
                        column: x => x.OperationsAnspruchId,
                        principalTable: "OperationsAnspruch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BenutzerOperationsAnspruch_BenutzerId",
                table: "BenutzerOperationsAnspruch",
                column: "BenutzerId");

            migrationBuilder.CreateIndex(
                name: "IX_BenutzerOperationsAnspruch_OperationsAnspruchId",
                table: "BenutzerOperationsAnspruch",
                column: "OperationsAnspruchId");

            migrationBuilder.CreateIndex(
                name: "IX_TokenAktualisieren_BenutzerId",
                table: "TokenAktualisieren",
                column: "BenutzerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenutzerOperationsAnspruch");

            migrationBuilder.DropTable(
                name: "TokenAktualisieren");

            migrationBuilder.DropTable(
                name: "OperationsAnspruch");

            migrationBuilder.DropTable(
                name: "Benutzer");
        }
    }
}
