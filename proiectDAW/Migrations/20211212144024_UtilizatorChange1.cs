using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectDAW.Migrations
{
    public partial class UtilizatorChange1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Admin",
                table: "Utilizatori");

            migrationBuilder.AddColumn<string>(
                name: "ParolaHashed",
                table: "Utilizatori",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rol",
                table: "Utilizatori",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Utilizatori",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParolaHashed",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Utilizatori");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Utilizatori");

            migrationBuilder.AddColumn<bool>(
                name: "Admin",
                table: "Utilizatori",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
