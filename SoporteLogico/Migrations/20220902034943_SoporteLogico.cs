using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SoporteLogico.Migrations
{
    public partial class SoporteLogico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdGenero = table.Column<int>(type: "int", nullable: false),
                    IdCiudad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IdEmpleado);
                });

            migrationBuilder.CreateTable(
                name: "Vinculacion",
                columns: table => new
                {
                    IdVinculacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCargo = table.Column<int>(type: "int", nullable: false),
                    FechaRetiro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEmpleado_Vinculacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinculacion", x => x.IdVinculacion);
                    table.ForeignKey(
                        name: "FK_Vinculacion_Empleado_IdEmpleado_Vinculacion",
                        column: x => x.IdEmpleado_Vinculacion,
                        principalTable: "Empleado",
                        principalColumn: "IdEmpleado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vinculacion_IdEmpleado_Vinculacion",
                table: "Vinculacion",
                column: "IdEmpleado_Vinculacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vinculacion");

            migrationBuilder.DropTable(
                name: "Empleado");
        }
    }
}
