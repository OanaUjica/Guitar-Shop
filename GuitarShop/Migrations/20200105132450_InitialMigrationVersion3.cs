using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarShop.Migrations
{
    public partial class InitialMigrationVersion3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_GuitarSpecifications_SpecificationsId",
                table: "Guitars");

            migrationBuilder.DropIndex(
                name: "IX_Guitars_SpecificationsId",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "SpecificationsId",
                table: "Guitars");

            migrationBuilder.AddColumn<int>(
                name: "GuitarForeignKey",
                table: "GuitarSpecifications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GuitarSpecifications_GuitarForeignKey",
                table: "GuitarSpecifications",
                column: "GuitarForeignKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GuitarSpecifications_Guitars_GuitarForeignKey",
                table: "GuitarSpecifications",
                column: "GuitarForeignKey",
                principalTable: "Guitars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuitarSpecifications_Guitars_GuitarForeignKey",
                table: "GuitarSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_GuitarSpecifications_GuitarForeignKey",
                table: "GuitarSpecifications");

            migrationBuilder.DropColumn(
                name: "GuitarForeignKey",
                table: "GuitarSpecifications");

            migrationBuilder.AddColumn<int>(
                name: "SpecificationsId",
                table: "Guitars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guitars_SpecificationsId",
                table: "Guitars",
                column: "SpecificationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guitars_GuitarSpecifications_SpecificationsId",
                table: "Guitars",
                column: "SpecificationsId",
                principalTable: "GuitarSpecifications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
