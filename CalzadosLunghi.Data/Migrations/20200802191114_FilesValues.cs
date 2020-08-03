using Microsoft.EntityFrameworkCore.Migrations;

namespace CalzadosLunghi.Data.Migrations
{
    public partial class FilesValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilesValues",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(nullable: true),
                    Path = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    AmazonUri = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilesValues", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilesValues");
        }
    }
}
