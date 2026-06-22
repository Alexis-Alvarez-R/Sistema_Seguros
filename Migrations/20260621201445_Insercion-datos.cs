using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Sistema_Emision_Seguros.Migrations
{
    /// <inheritdoc />
    public partial class Inserciondatos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "IdCliente", "Email", "Identificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "ramirez151202@gmail.com", "001-151202-1013T", "Alexis Alvarez" },
                    { 2, "maria@gmail.com", "001-120365-1014T", "Maria Ramirez" },
                    { 3, "ysp67@gmail.com", "001-020606-1015T", "Yaser Perez" },
                    { 4, "noguera10@gmail.com", "001-100504-1016T", "Jose Noguera" },
                    { 5, "tayson15@gmail.com", "001-151206-1017T", "Tayson Ramirez" },
                    { 6, "underwood@gmail.com", "001-010213-1018T", "Kevin Spacey" },
                    { 7, "saymyname@gmail.com", "001-200108-1019T", "Walter White" }
                });

            migrationBuilder.InsertData(
                table: "Coberturas",
                columns: new[] { "IdCobertura", "MontoCobertura", "NombreCobertura" },
                values: new object[,]
                {
                    { 1, 150.00m, "Responsabilidad Civil" },
                    { 2, 250.50m, "Robo Total" },
                    { 3, 300.00m, "Choque o Colisión" },
                    { 4, 120.25m, "Daños por Fenómenos Naturales" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "IdCliente",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "IdCliente",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "IdCliente",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "IdCliente",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "IdCliente",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "IdCliente",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "IdCliente",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Coberturas",
                keyColumn: "IdCobertura",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coberturas",
                keyColumn: "IdCobertura",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coberturas",
                keyColumn: "IdCobertura",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coberturas",
                keyColumn: "IdCobertura",
                keyValue: 4);
        }
    }
}
