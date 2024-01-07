using Microsoft.EntityFrameworkCore.Migrations;

namespace FianlProject.Migrations
{
    public partial class addColumnAvgPointFurnitureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvgPoint",
                table: "Furnitures",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgPoint",
                table: "Furnitures");
        }
    }
}
