using Microsoft.EntityFrameworkCore.Migrations;

namespace Rentless.Migrations
{
    public partial class updateCityLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateCode",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_PostalCode_City_CityCode",
                table: "PostalCode");

            migrationBuilder.DropIndex(
                name: "IX_PostalCode_CityCode",
                table: "PostalCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.AddColumn<string>(
                name: "CityCode1",
                table: "PostalCode",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityStateCode",
                table: "PostalCode",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "StateCode",
                table: "City",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "City",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(10)",
                oldMaxLength: 10);

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                columns: new[] { "Code", "StateCode" });

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_CityCode1_CityStateCode",
                table: "PostalCode",
                columns: new[] { "CityCode1", "CityStateCode" });

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateCode",
                table: "City",
                column: "StateCode",
                principalTable: "State",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostalCode_City_CityCode1_CityStateCode",
                table: "PostalCode",
                columns: new[] { "CityCode1", "CityStateCode" },
                principalTable: "City",
                principalColumns: new[] { "Code", "StateCode" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_State_StateCode",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_PostalCode_City_CityCode1_CityStateCode",
                table: "PostalCode");

            migrationBuilder.DropIndex(
                name: "IX_PostalCode_CityCode1_CityStateCode",
                table: "PostalCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityCode1",
                table: "PostalCode");

            migrationBuilder.DropColumn(
                name: "CityStateCode",
                table: "PostalCode");

            migrationBuilder.AlterColumn<string>(
                name: "StateCode",
                table: "City",
                type: "character varying(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Code",
                table: "City",
                type: "character varying(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 30);

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_CityCode",
                table: "PostalCode",
                column: "CityCode");

            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateCode",
                table: "City",
                column: "StateCode",
                principalTable: "State",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PostalCode_City_CityCode",
                table: "PostalCode",
                column: "CityCode",
                principalTable: "City",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
