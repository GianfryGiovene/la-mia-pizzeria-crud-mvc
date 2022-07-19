using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaMiaPizzeria.Migrations
{
    public partial class AddCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "PizzaList",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CategoriaList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaList", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaList_CategoryId",
                table: "PizzaList",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaList_CategoriaList_CategoryId",
                table: "PizzaList",
                column: "CategoryId",
                principalTable: "CategoriaList",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PizzaList_CategoriaList_CategoryId",
                table: "PizzaList");

            migrationBuilder.DropTable(
                name: "CategoriaList");

            migrationBuilder.DropIndex(
                name: "IX_PizzaList_CategoryId",
                table: "PizzaList");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "PizzaList");
        }
    }
}
