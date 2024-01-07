using Microsoft.EntityFrameworkCore.Migrations;

namespace FianlProject.Migrations
{
    public partial class addColumnBestSellerandTrendFurnitureTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestSeller",
                table: "Furnitures",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Trend",
                table: "Furnitures",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestSeller",
                table: "Furnitures");

            migrationBuilder.DropColumn(
                name: "Trend",
                table: "Furnitures");
        }
    }
}
