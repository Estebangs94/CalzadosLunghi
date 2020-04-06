using Microsoft.EntityFrameworkCore.Migrations;

namespace CalzadosLunghi.Data.Migrations
{
    public partial class ParteZapato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZapatoMaterial_ParteZapato_ParteZapatoId",
                table: "ZapatoMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParteZapato",
                table: "ParteZapato");

            migrationBuilder.RenameTable(
                name: "ParteZapato",
                newName: "ParteZapatos");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ParteZapatos",
                newName: "ID");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Colores",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "ParteZapatos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParteZapatos",
                table: "ParteZapatos",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ZapatoMaterial_ParteZapatos_ParteZapatoId",
                table: "ZapatoMaterial",
                column: "ParteZapatoId",
                principalTable: "ParteZapatos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ZapatoMaterial_ParteZapatos_ParteZapatoId",
                table: "ZapatoMaterial");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParteZapatos",
                table: "ParteZapatos");

            migrationBuilder.RenameTable(
                name: "ParteZapatos",
                newName: "ParteZapato");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ParteZapato",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Colores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "ParteZapato",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParteZapato",
                table: "ParteZapato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ZapatoMaterial_ParteZapato_ParteZapatoId",
                table: "ZapatoMaterial",
                column: "ParteZapatoId",
                principalTable: "ParteZapato",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
