using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RebecaBarrezueta_Examen1P.Migrations
{
    /// <inheritdoc />
    public partial class Cambios1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ZapatosRB",
                columns: table => new
                {
                    ZapatosID_RB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_RB = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EdicionEspecial_RB = table.Column<bool>(type: "bit", nullable: false),
                    Precio_RB = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZapatosRB", x => x.ZapatosID_RB);
                });

            migrationBuilder.CreateTable(
                name: "PromocionRB",
                columns: table => new
                {
                    PromocionID_RB = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion_RB = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaPromo_RB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ZapatosID_RB = table.Column<int>(type: "int", nullable: false),
                    ZapatosRBZapatosID_RB = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromocionRB", x => x.PromocionID_RB);
                    table.ForeignKey(
                        name: "FK_PromocionRB_ZapatosRB_ZapatosRBZapatosID_RB",
                        column: x => x.ZapatosRBZapatosID_RB,
                        principalTable: "ZapatosRB",
                        principalColumn: "ZapatosID_RB");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromocionRB_ZapatosRBZapatosID_RB",
                table: "PromocionRB",
                column: "ZapatosRBZapatosID_RB");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromocionRB");

            migrationBuilder.DropTable(
                name: "ZapatosRB");
        }
    }
}
