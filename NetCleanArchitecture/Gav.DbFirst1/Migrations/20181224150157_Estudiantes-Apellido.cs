using Microsoft.EntityFrameworkCore.Migrations;

namespace Gav.DbFirst1.Migrations
{
    public partial class EstudiantesApellido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Estudiantes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Estudiantes");
        }
    }
}
