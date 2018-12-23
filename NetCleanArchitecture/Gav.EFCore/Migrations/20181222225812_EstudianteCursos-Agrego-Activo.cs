using Microsoft.EntityFrameworkCore.Migrations;

namespace Gav.EFCore.Migrations
{
    public partial class EstudianteCursosAgregoActivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Activo",
                table: "EstudiantesCursos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Activo",
                table: "EstudiantesCursos");
        }
    }
}
