using Microsoft.EntityFrameworkCore.Migrations;

namespace CalzadosLunghi.Data.Migrations
{
    public partial class Color : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorID",
                table: "Materiales",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Colores",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colores", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materiales_ColorID",
                table: "Materiales",
                column: "ColorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Materiales_Colores_ColorID",
                table: "Materiales",
                column: "ColorID",
                principalTable: "Colores",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materiales_Colores_ColorID",
                table: "Materiales");

            migrationBuilder.DropTable(
                name: "Colores");

            migrationBuilder.DropIndex(
                name: "IX_Materiales_ColorID",
                table: "Materiales");

            migrationBuilder.DropColumn(
                name: "ColorID",
                table: "Materiales");
        }
    }
}
