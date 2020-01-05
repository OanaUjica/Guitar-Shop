using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarShop.Migrations
{
    public partial class AddedGuitarPropInGuitarSpecification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuitarId",
                table: "Guitars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_GuitarId",
                table: "Guitars",
                column: "GuitarId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_Guitars_GuitarId",
                table: "Guitars",
                column: "GuitarId",
                principalTable: "Guitars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_Guitars_GuitarId",
                table: "Guitars");

            migrationBuilder.DropIndex(
                name: "IX_Guitars_GuitarId",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "GuitarId",
                table: "Guitars");
        }
    }
}
