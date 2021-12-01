using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectDAW.Migrations
{
    public partial class RelationsTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "tara_origine",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "telefon",
                table: "Utilizatori");

            migrationBuilder.RenameColumn(
                name: "total_puncte",
                table: "Utilizatori",
                newName: "Total_Puncte");

            migrationBuilder.RenameColumn(
                name: "prenume_utilizator",
                table: "Utilizatori",
                newName: "Prenume_Utilizator");

            migrationBuilder.RenameColumn(
                name: "nume_utilizator",
                table: "Utilizatori",
                newName: "Nume_Utilizator");

            migrationBuilder.RenameColumn(
                name: "admin",
                table: "Utilizatori",
                newName: "Admin");

            migrationBuilder.AddColumn<Guid>(
                name: "Date_PersonaleId",
                table: "Utilizatori",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Bucatarii",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Nume_Bucatarie = table.Column<string>(nullable: true),
                    Descriere_Bucatarie = table.Column<string>(nullable: true),
                    Regiune_Glob = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bucatarii", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colectii",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Titlu_Colectie = table.Column<string>(nullable: true),
                    Descriere_Colectie = table.Column<string>(nullable: true),
                    Publica = table.Column<bool>(nullable: false),
                    Cale_Poza = table.Column<string>(nullable: true),
                    UtilizatorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colectii", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colectii_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Date_Personale",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Tara_Origine = table.Column<string>(nullable: true),
                    Telefon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date_Personale", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Concursuri",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Titlu_Concurs = table.Column<string>(nullable: true),
                    Data_Inceput = table.Column<DateTime>(nullable: false),
                    Data_Sfarsit = table.Column<DateTime>(nullable: false),
                    Stadiu = table.Column<string>(nullable: true),
                    Puncte_Oferite = table.Column<int>(nullable: false),
                    Nume_Castigator = table.Column<string>(nullable: true),
                    BucatarieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concursuri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Concursuri_Bucatarii_BucatarieId",
                        column: x => x.BucatarieId,
                        principalTable: "Bucatarii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Retete",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Titlu_Reteta = table.Column<string>(nullable: true),
                    Ingrediente = table.Column<string>(nullable: true),
                    Instructiuni = table.Column<string>(nullable: true),
                    Cale_Poza = table.Column<string>(nullable: true),
                    Participa_Concurs = table.Column<bool>(nullable: false),
                    ColectieId = table.Column<Guid>(nullable: false),
                    BucatarieId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retete", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Retete_Bucatarii_BucatarieId",
                        column: x => x.BucatarieId,
                        principalTable: "Bucatarii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Retete_Colectii_ColectieId",
                        column: x => x.ColectieId,
                        principalTable: "Colectii",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactii_Retete",
                columns: table => new
                {
                    RetetaId = table.Column<Guid>(nullable: false),
                    UtilizatorId = table.Column<Guid>(nullable: false),
                    Reactie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactii_Retete", x => new { x.RetetaId, x.UtilizatorId });
                    table.ForeignKey(
                        name: "FK_Reactii_Retete_Retete_RetetaId",
                        column: x => x.RetetaId,
                        principalTable: "Retete",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reactii_Retete_Utilizatori_UtilizatorId",
                        column: x => x.UtilizatorId,
                        principalTable: "Utilizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Utilizatori_Date_PersonaleId",
                table: "Utilizatori",
                column: "Date_PersonaleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colectii_UtilizatorId",
                table: "Colectii",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Concursuri_BucatarieId",
                table: "Concursuri",
                column: "BucatarieId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactii_Retete_UtilizatorId",
                table: "Reactii_Retete",
                column: "UtilizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Retete_BucatarieId",
                table: "Retete",
                column: "BucatarieId");

            migrationBuilder.CreateIndex(
                name: "IX_Retete_ColectieId",
                table: "Retete",
                column: "ColectieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Utilizatori_Date_Personale_Date_PersonaleId",
                table: "Utilizatori",
                column: "Date_PersonaleId",
                principalTable: "Date_Personale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utilizatori_Date_Personale_Date_PersonaleId",
                table: "Utilizatori");

            migrationBuilder.DropTable(
                name: "Concursuri");

            migrationBuilder.DropTable(
                name: "Date_Personale");

            migrationBuilder.DropTable(
                name: "Reactii_Retete");

            migrationBuilder.DropTable(
                name: "Retete");

            migrationBuilder.DropTable(
                name: "Bucatarii");

            migrationBuilder.DropTable(
                name: "Colectii");

            migrationBuilder.DropIndex(
                name: "IX_Utilizatori_Date_PersonaleId",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "Date_PersonaleId",
                table: "Utilizatori");

            migrationBuilder.RenameColumn(
                name: "Total_Puncte",
                table: "Utilizatori",
                newName: "total_puncte");

            migrationBuilder.RenameColumn(
                name: "Prenume_Utilizator",
                table: "Utilizatori",
                newName: "prenume_utilizator");

            migrationBuilder.RenameColumn(
                name: "Nume_Utilizator",
                table: "Utilizatori",
                newName: "nume_utilizator");

            migrationBuilder.RenameColumn(
                name: "Admin",
                table: "Utilizatori",
                newName: "admin");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "tara_origine",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "telefon",
                table: "Utilizatori",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
