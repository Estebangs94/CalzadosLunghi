using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalzadosLunghi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Temporadas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporadas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoMateriales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    EstaActivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMateriales", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PrecioMateriales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaVigencia = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: true),
                    MaterialID = table.Column<int>(nullable: true),
                    EstaActivo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioMateriales", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Zapatos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemporadaID = table.Column<int>(nullable: true),
                    ForroCapelladaID = table.Column<int>(nullable: true),
                    ForroPlantillaID = table.Column<int>(nullable: true),
                    PunteraID = table.Column<int>(nullable: true),
                    ContraFuerteID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zapatos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Zapatos_Temporadas_TemporadaID",
                        column: x => x.TemporadaID,
                        principalTable: "Temporadas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Materiales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    TipoMaterialID = table.Column<int>(nullable: true),
                    UnidadDeMedida = table.Column<int>(nullable: false),
                    EstaActivo = table.Column<bool>(nullable: false),
                    ZapatoID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materiales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Materiales_TipoMateriales_TipoMaterialID",
                        column: x => x.TipoMaterialID,
                        principalTable: "TipoMateriales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Materiales_Zapatos_ZapatoID",
                        column: x => x.ZapatoID,
                        principalTable: "Zapatos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_TipoMaterialID",
                table: "Materiales",
                column: "TipoMaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_ZapatoID",
                table: "Materiales",
                column: "ZapatoID");

            migrationBuilder.CreateIndex(
                name: "IX_PrecioMateriales_MaterialID",
                table: "PrecioMateriales",
                column: "MaterialID");

            migrationBuilder.CreateIndex(
                name: "IX_Zapatos_ContraFuerteID",
                table: "Zapatos",
                column: "ContraFuerteID");

            migrationBuilder.CreateIndex(
                name: "IX_Zapatos_ForroCapelladaID",
                table: "Zapatos",
                column: "ForroCapelladaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zapatos_ForroPlantillaID",
                table: "Zapatos",
                column: "ForroPlantillaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zapatos_PunteraID",
                table: "Zapatos",
                column: "PunteraID");

            migrationBuilder.CreateIndex(
                name: "IX_Zapatos_TemporadaID",
                table: "Zapatos",
                column: "TemporadaID");

            migrationBuilder.AddForeignKey(
                name: "FK_PrecioMateriales_Materiales_MaterialID",
                table: "PrecioMateriales",
                column: "MaterialID",
                principalTable: "Materiales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zapatos_Materiales_ContraFuerteID",
                table: "Zapatos",
                column: "ContraFuerteID",
                principalTable: "Materiales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zapatos_Materiales_ForroCapelladaID",
                table: "Zapatos",
                column: "ForroCapelladaID",
                principalTable: "Materiales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zapatos_Materiales_ForroPlantillaID",
                table: "Zapatos",
                column: "ForroPlantillaID",
                principalTable: "Materiales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Zapatos_Materiales_PunteraID",
                table: "Zapatos",
                column: "PunteraID",
                principalTable: "Materiales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiales_TipoMateriales_TipoMaterialID",
                table: "Materiales");

            migrationBuilder.DropForeignKey(
                name: "FK_Materiales_Zapatos_ZapatoID",
                table: "Materiales");

            migrationBuilder.DropTable(
                name: "PrecioMateriales");

            migrationBuilder.DropTable(
                name: "TipoMateriales");

            migrationBuilder.DropTable(
                name: "Zapatos");

            migrationBuilder.DropTable(
                name: "Materiales");

            migrationBuilder.DropTable(
                name: "Temporadas");
        }
    }
}
