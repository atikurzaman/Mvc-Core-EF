using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Data.Migrations
{
    public partial class fff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductValue_Attribute_AttributeId",
                table: "ProductValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductValue",
                table: "ProductValue");

            migrationBuilder.RenameTable(
                name: "ProductValue",
                newName: "AttributeValue");

            migrationBuilder.RenameIndex(
                name: "IX_ProductValue_AttributeId",
                table: "AttributeValue",
                newName: "IX_AttributeValue_AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AttributeValue",
                table: "AttributeValue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AttributeValue_Attribute_AttributeId",
                table: "AttributeValue",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttributeValue_Attribute_AttributeId",
                table: "AttributeValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AttributeValue",
                table: "AttributeValue");

            migrationBuilder.RenameTable(
                name: "AttributeValue",
                newName: "ProductValue");

            migrationBuilder.RenameIndex(
                name: "IX_AttributeValue_AttributeId",
                table: "ProductValue",
                newName: "IX_ProductValue_AttributeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductValue",
                table: "ProductValue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductValue_Attribute_AttributeId",
                table: "ProductValue",
                column: "AttributeId",
                principalTable: "Attribute",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
