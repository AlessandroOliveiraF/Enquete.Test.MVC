using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Enquete.Test.MVC.Data.Migrations
{
    public partial class EnqueteDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enquetes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enquetes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Opcoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnqueteId = table.Column<int>(type: "int", nullable: false),
                    OpcaoDescricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcoes_Enquetes_EnqueteId",
                        column: x => x.EnqueteId,
                        principalTable: "Enquetes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Opcoes_EnqueteId",
                table: "Opcoes",
                column: "EnqueteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opcoes");

            migrationBuilder.DropTable(
                name: "Enquetes");
        }
    }
}
