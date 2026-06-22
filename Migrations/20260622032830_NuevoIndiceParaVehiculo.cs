using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Emision_Seguros.Migrations
{
    /// <inheritdoc />
    public partial class NuevoIndiceParaVehiculo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vehiculos_Placa",
                table: "Vehiculos",
                column: "Placa",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Vehiculos_Placa",
                table: "Vehiculos");
        }
    }
}
