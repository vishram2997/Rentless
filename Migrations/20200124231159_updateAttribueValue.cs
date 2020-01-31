using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentless.Migrations
{
    public partial class updateAttribueValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CityCode",
                table: "PostalCode",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longtude",
                table: "CustListing",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "CustListing",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.CreateTable(
                name: "AttributeValue",
                columns: table => new
                {
                    AttributeTypeCode = table.Column<string>(maxLength: 10, nullable: false),
                    Value = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeValue", x => new { x.AttributeTypeCode, x.Value });
                    table.ForeignKey(
                        name: "FK_AttributeValue_AttributeType_AttributeTypeCode",
                        column: x => x.AttributeTypeCode,
                        principalTable: "AttributeType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttributeValue");

            migrationBuilder.AlterColumn<string>(
                name: "CityCode",
                table: "PostalCode",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Longtude",
                table: "CustListing",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AlterColumn<decimal>(
                name: "Latitude",
                table: "CustListing",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
