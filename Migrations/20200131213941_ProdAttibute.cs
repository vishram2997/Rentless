using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Rentless.Migrations
{
    public partial class ProdAttibute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttribute_AttributeType_AttributeTypeCode",
                table: "ProductAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttribute_Product_ProductCode",
                table: "ProductAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttribute",
                table: "ProductAttribute");

            migrationBuilder.DropIndex(
                name: "IX_ProductAttribute_ProductCode",
                table: "ProductAttribute");

            migrationBuilder.DropColumn(
                name: "ProductCoode",
                table: "ProductAttribute");

            migrationBuilder.AlterColumn<int>(
                name: "ProductCode",
                table: "ProductAttribute",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AttributeTypeCode",
                table: "ProductAttribute",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttribute",
                table: "ProductAttribute",
                columns: new[] { "ProductCode", "AttributeTypeCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttribute_AttributeType_AttributeTypeCode",
                table: "ProductAttribute",
                column: "AttributeTypeCode",
                principalTable: "AttributeType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttribute_Product_ProductCode",
                table: "ProductAttribute",
                column: "ProductCode",
                principalTable: "Product",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttribute_AttributeType_AttributeTypeCode",
                table: "ProductAttribute");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductAttribute_Product_ProductCode",
                table: "ProductAttribute");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductAttribute",
                table: "ProductAttribute");

            migrationBuilder.AlterColumn<string>(
                name: "AttributeTypeCode",
                table: "ProductAttribute",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<int>(
                name: "ProductCode",
                table: "ProductAttribute",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ProductCoode",
                table: "ProductAttribute",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductAttribute",
                table: "ProductAttribute",
                column: "ProductCoode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_ProductCode",
                table: "ProductAttribute",
                column: "ProductCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttribute_AttributeType_AttributeTypeCode",
                table: "ProductAttribute",
                column: "AttributeTypeCode",
                principalTable: "AttributeType",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductAttribute_Product_ProductCode",
                table: "ProductAttribute",
                column: "ProductCode",
                principalTable: "Product",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
