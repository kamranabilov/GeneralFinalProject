using Microsoft.EntityFrameworkCore.Migrations;

namespace FianlProject.Migrations
{
    public partial class createFurnitureDescriptionTableandFurnitureTableFurnitureDescriptionColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FurnitureDescriptionId",
                table: "Furnitures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FurnitureDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FurnitureDescriptions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Furnitures_FurnitureDescriptionId",
                table: "Furnitures",
                column: "FurnitureDescriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Furnitures_FurnitureDescriptions_FurnitureDescriptionId",
                table: "Furnitures",
                column: "FurnitureDescriptionId",
                principalTable: "FurnitureDescriptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Furnitures_FurnitureDescriptions_FurnitureDescriptionId",
                table: "Furnitures");

            migrationBuilder.DropTable(
                name: "FurnitureDescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Furnitures_FurnitureDescriptionId",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "FurnitureDescriptionId",
                table: "Furnitures");
        }
    }
}
