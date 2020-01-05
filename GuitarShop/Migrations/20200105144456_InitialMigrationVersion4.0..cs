using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuitarShop.Migrations
{
    public partial class InitialMigrationVersion40 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GuitarSpecifications");

            migrationBuilder.AddColumn<int>(
                name: "BackWood",
                table: "Guitars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Builder",
                table: "Guitars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Model",
                table: "Guitars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TopWood",
                table: "Guitars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Guitars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "TopWood",
                table: "Guitars");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Guitars");

            migrationBuilder.CreateTable(
                name: "GuitarSpecifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackWood = table.Column<int>(nullable: false),
                    Builder = table.Column<int>(nullable: false),
                    GuitarForeignKey = table.Column<int>(nullable: false),
                    Model = table.Column<int>(nullable: false),
                    TopWood = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuitarSpecifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuitarSpecifications_Guitars_GuitarForeignKey",
                        column: x => x.GuitarForeignKey,
                        principalTable: "Guitars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GuitarSpecifications_GuitarForeignKey",
                table: "GuitarSpecifications",
                column: "GuitarForeignKey",
                unique: true);
        }
    }
}
