using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Data.Migrations
{
    public partial class ChangeStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Disable",
                table: "Menu");

            migrationBuilder.RenameColumn(
                name: "MenuArea",
                table: "Menu",
                newName: "CssClass");

            migrationBuilder.RenameColumn(
                name: "HasAccess",
                table: "Menu",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Menu",
                newName: "HasAccess");

            migrationBuilder.RenameColumn(
                name: "CssClass",
                table: "Menu",
                newName: "MenuArea");

            migrationBuilder.AddColumn<bool>(
                name: "Disable",
                table: "Menu",
                nullable: false,
                defaultValue: false);
        }
    }
}
