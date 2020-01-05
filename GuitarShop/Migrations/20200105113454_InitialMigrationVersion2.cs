using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarShop.Migrations
{
    public partial class InitialMigrationVersion2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackWood",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "Builder",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "ContactMe",
                table: "Contacts");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Guitars",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "TopWood",
                table: "Guitars",
                newName: "Description");

            migrationBuilder.AddColumn<int>(
                name: "SpecificationsId",
                table: "Guitars",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GuitarSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Builder = table.Column<int>(nullable: false),
                    Model = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    BackWood = table.Column<int>(nullable: false),
                    TopWood = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarSpecifications", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guitars_GuitarSpecifications_SpecificationsId",
                table: "Guitars");

            migrationBuilder.DropTable(
                name: "GuitarSpecifications");

            migrationBuilder.DropIndex(
                name: "IX_Guitars_SpecificationsId",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "SpecificationsId",
                table: "Guitars");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Guitars",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Guitars",
                newName: "TopWood");

            migrationBuilder.AddColumn<string>(
                name: "BackWood",
                table: "Guitars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Builder",
                table: "Guitars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Guitars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ContactMe",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }
    }
}
