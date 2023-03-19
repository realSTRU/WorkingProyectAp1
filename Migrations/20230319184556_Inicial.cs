using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RegistroPrestamosAp1.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ocupacion",
                columns: table => new
                {
                    OcupacionID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    Sueldo = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ocupacion", x => x.OcupacionID);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                columns: table => new
                {
                    PersonaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Telefono = table.Column<string>(type: "TEXT", nullable: true),
                    Celular = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", nullable: true),
                    FechaNacimiento = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    OcupacionID = table.Column<int>(type: "INTEGER", nullable: false),
                    Balance = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.PersonaID);
                });

            migrationBuilder.CreateTable(
                name: "Prestamo",
                columns: table => new
                {
                    PrestamoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Vence = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    PersonaID = table.Column<int>(type: "INTEGER", nullable: false),
                    Concepto = table.Column<string>(type: "TEXT", nullable: true),
                    Monto = table.Column<double>(type: "REAL", nullable: true),
                    Balance = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamo", x => x.PrestamoID);
                    table.ForeignKey(
                        name: "FK_Prestamo_Persona_PersonaID",
                        column: x => x.PersonaID,
                        principalTable: "Persona",
                        principalColumn: "PersonaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Ocupacion",
                columns: new[] { "OcupacionID", "Descripcion", "Sueldo" },
                values: new object[] { 1, "Full stack DevOp", 89000.0 });

            migrationBuilder.InsertData(
                table: "Persona",
                columns: new[] { "PersonaID", "Balance", "Celular", "Direccion", "Email", "FechaNacimiento", "Nombre", "OcupacionID", "Telefono" },
                values: new object[,]
                {
                    { 1, 0.0, "829-863-5107", "Desconocida o prefiere no decirelo", "CesarUnknowPro@Hotmail.com", new DateOnly(2003, 7, 8), "Cesar Reynoso", 1, "829-863-5107" },
                    { 2, 0.0, "829-863-5107", "Desconocida o prefiere no decirelo", "CesarUnknowPro@Hotmail.com", new DateOnly(2003, 7, 8), "Casper Gonzalez Reynoso", 1, "829-863-5107" },
                    { 3, 0.0, "829-863-5107", "Desconocida o prefiere no decirelo", "CesarUnknowPro@Hotmail.com", new DateOnly(2003, 7, 8), "Gustavo Reynoso", 1, "829-863-5107" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_PersonaID",
                table: "Prestamo",
                column: "PersonaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ocupacion");

            migrationBuilder.DropTable(
                name: "Prestamo");

            migrationBuilder.DropTable(
                name: "Persona");
        }
    }
}
