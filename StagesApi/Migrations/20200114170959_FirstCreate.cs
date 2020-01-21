using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StagesApi.Migrations
{
    public partial class FirstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENTREPRISE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTREPRISE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROGRAMME",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROGRAMME", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STAGE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Etat = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    NomPoste = table.Column<string>(unicode: false, maxLength: 255, nullable: false),
                    Salaire = table.Column<double>(nullable: true),
                    DateDebut = table.Column<DateTime>(type: "date", nullable: false),
                    DateFin = table.Column<DateTime>(type: "date", nullable: false),
                    EntrepriseId = table.Column<int>(nullable: true),
                    ProgrammeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STAGE", x => x.ID);
                    table.ForeignKey(
                        name: "FK__STAGE__Entrepris__286302EC",
                        column: x => x.EntrepriseId,
                        principalTable: "ENTREPRISE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__STAGE__Programme__29572725",
                        column: x => x.ProgrammeId,
                        principalTable: "PROGRAMME",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STAGE_EntrepriseId",
                table: "STAGE",
                column: "EntrepriseId");

            migrationBuilder.CreateIndex(
                name: "IX_STAGE_ProgrammeId",
                table: "STAGE",
                column: "ProgrammeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STAGE");

            migrationBuilder.DropTable(
                name: "ENTREPRISE");

            migrationBuilder.DropTable(
                name: "PROGRAMME");
        }
    }
}
