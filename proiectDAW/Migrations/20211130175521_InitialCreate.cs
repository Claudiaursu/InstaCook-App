using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectDAW.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Utilizatori",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    nume_utilizator = table.Column<string>(nullable: true),
                    prenume_utilizator = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    tara_origine = table.Column<string>(nullable: true),
                    telefon = table.Column<string>(nullable: true),
                    total_puncte = table.Column<int>(nullable: false),
                    admin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizatori", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Utilizatori");
        }
    }
}
