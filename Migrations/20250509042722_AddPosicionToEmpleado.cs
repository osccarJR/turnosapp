using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TurnosApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPosicionToEmpleado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PosicionId",
                table: "Empleados",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PosicionId",
                table: "Empleados",
                column: "PosicionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empleados_Posiciones_PosicionId",
                table: "Empleados",
                column: "PosicionId",
                principalTable: "Posiciones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empleados_Posiciones_PosicionId",
                table: "Empleados");

            migrationBuilder.DropIndex(
                name: "IX_Empleados_PosicionId",
                table: "Empleados");

            migrationBuilder.DropColumn(
                name: "PosicionId",
                table: "Empleados");
        }
    }
}
