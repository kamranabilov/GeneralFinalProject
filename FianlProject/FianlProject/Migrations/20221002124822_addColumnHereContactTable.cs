using Microsoft.EntityFrameworkCore.Migrations;

namespace FianlProject.Migrations
{
    public partial class addColumnHereContactTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Here",
                table: "Contacts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Here",
                table: "Contacts");
        }
    }
}
