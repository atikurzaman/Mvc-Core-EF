using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Data.Migrations
{
    public partial class NewInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAttributeItem");

            migrationBuilder.DropTable(
                name: "ProductAttribute");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Brand",
                newName: "IsActive");

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    IPAddress = table.Column<string>(maxLength: 256, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductValue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<long>(nullable: false),
                    ModifiedBy = table.Column<long>(nullable: true),
                    IPAddress = table.Column<string>(maxLength: 256, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 256, nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AttributeId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductValue_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductValue_AttributeId",
                table: "ProductValue",
                column: "AttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductValue");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Brand",
                newName: "Status");

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    IPAddress = table.Column<string>(maxLength: 256, nullable: true),
                    Label = table.Column<string>(maxLength: 128, nullable: false),
                    MacAddress = table.Column<string>(maxLength: 256, nullable: true),
                    ModifiedBy = table.Column<long>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    OrderBy = table.Column<int>(maxLength: 128, nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttributeItem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 1024, nullable: true),
                    IPAddress = table.Column<string>(maxLength: 256, nullable: true),
                    MacAddress = table.Column<string>(maxLength: 256, nullable: true),
                    ModifiedBy = table.Column<long>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    ProductAttributeId = table.Column<long>(nullable: false),
                    Status = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttributeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAttributeItem_ProductAttribute_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "ProductAttribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttributeItem_ProductAttributeId",
                table: "ProductAttributeItem",
                column: "ProductAttributeId");
        }
    }
}
