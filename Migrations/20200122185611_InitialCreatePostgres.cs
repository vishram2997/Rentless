using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Rentless.Migrations
{
    public partial class InitialCreatePostgres : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeType",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Desc = table.Column<string>(maxLength: 50, nullable: true),
                    ValueType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    VerificationStatus = table.Column<int>(nullable: false),
                    ContactNo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DocuType",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Desc = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocuType", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PaymMode",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Desc = table.Column<string>(maxLength: 50, nullable: true),
                    ReqAccountNo = table.Column<bool>(nullable: false),
                    ReqIFSC = table.Column<bool>(nullable: false),
                    ReqCVV = table.Column<bool>(nullable: false),
                    ReqCVV2 = table.Column<bool>(nullable: false),
                    ReqExpDate = table.Column<bool>(nullable: false),
                    ReqSwift = table.Column<bool>(nullable: false),
                    ReqIBAN = table.Column<bool>(nullable: false),
                    ReqRoutingNo = table.Column<bool>(nullable: false),
                    ReqBIC = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymMode", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Code = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Desc = table.Column<string>(maxLength: 50, nullable: true),
                    Desc2 = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 20, nullable: false),
                    ContactNo = table.Column<string>(maxLength: 20, nullable: false),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CurrencyCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Currency_CurrencyCode",
                        column: x => x.CurrencyCode,
                        principalTable: "Currency",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 10, nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DocuTypeCode = table.Column<string>(nullable: true),
                    Desc = table.Column<string>(maxLength: 50, nullable: true),
                    FileType = table.Column<string>(maxLength: 10, nullable: true),
                    FileBase64 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Document_DocuType_DocuTypeCode",
                        column: x => x.DocuTypeCode,
                        principalTable: "DocuType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustPaymMode",
                columns: table => new
                {
                    CustomerId = table.Column<string>(maxLength: 10, nullable: false),
                    PaymModeCode = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    AccountNo = table.Column<string>(maxLength: 50, nullable: true),
                    IFSC = table.Column<string>(maxLength: 50, nullable: true),
                    CVV = table.Column<string>(maxLength: 50, nullable: true),
                    CVV2 = table.Column<string>(maxLength: 50, nullable: true),
                    ExpDate = table.Column<DateTime>(nullable: false),
                    Swift = table.Column<string>(maxLength: 50, nullable: true),
                    IBAN = table.Column<string>(maxLength: 50, nullable: true),
                    RoutingNo = table.Column<string>(maxLength: 50, nullable: true),
                    BIC = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustPaymMode", x => new { x.CustomerId, x.PaymModeCode });
                    table.ForeignKey(
                        name: "FK_CustPaymMode_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustPaymMode_PaymMode_PaymModeCode",
                        column: x => x.PaymModeCode,
                        principalTable: "PaymMode",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustListing",
                columns: table => new
                {
                    CustomerId = table.Column<string>(maxLength: 10, nullable: false),
                    ProductCode = table.Column<int>(nullable: false),
                    Location = table.Column<Point>(nullable: true),
                    Longtude = table.Column<decimal>(nullable: false),
                    Latitude = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustListing", x => new { x.CustomerId, x.ProductCode });
                    table.ForeignKey(
                        name: "FK_CustListing_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustListing_Product_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Product",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductAttribute",
                columns: table => new
                {
                    ProductCoode = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductCode = table.Column<int>(nullable: true),
                    AttributeTypeCode = table.Column<string>(maxLength: 10, nullable: true),
                    Value = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAttribute", x => x.ProductCoode);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_AttributeType_AttributeTypeCode",
                        column: x => x.AttributeTypeCode,
                        principalTable: "AttributeType",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductAttribute_Product_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Product",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CountryId = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Code);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductDocument",
                columns: table => new
                {
                    ProductCode = table.Column<int>(nullable: false),
                    DocumentId = table.Column<int>(nullable: false),
                    Desc = table.Column<string>(maxLength: 50, nullable: true),
                    VerificationStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDocument", x => new { x.ProductCode, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_ProductDocument_Document_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Document",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductDocument_Product_ProductCode",
                        column: x => x.ProductCode,
                        principalTable: "Product",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    StateCode = table.Column<string>(maxLength: 10, nullable: true),
                    CountryId = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Code);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_City_State_StateCode",
                        column: x => x.StateCode,
                        principalTable: "State",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostalCode",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Desc = table.Column<string>(maxLength: 50, nullable: true),
                    CityCode = table.Column<string>(maxLength: 10, nullable: true),
                    StateCode = table.Column<string>(maxLength: 10, nullable: true),
                    CountryId = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostalCode", x => x.Code);
                    table.ForeignKey(
                        name: "FK_PostalCode_City_CityCode",
                        column: x => x.CityCode,
                        principalTable: "City",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostalCode_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostalCode_State_StateCode",
                        column: x => x.StateCode,
                        principalTable: "State",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateCode",
                table: "City",
                column: "StateCode");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CurrencyCode",
                table: "Country",
                column: "CurrencyCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustListing_ProductCode",
                table: "CustListing",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_CustPaymMode_PaymModeCode",
                table: "CustPaymMode",
                column: "PaymModeCode");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DocuTypeCode",
                table: "Document",
                column: "DocuTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_CityCode",
                table: "PostalCode",
                column: "CityCode");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_CountryId",
                table: "PostalCode",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostalCode_StateCode",
                table: "PostalCode",
                column: "StateCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_AttributeTypeCode",
                table: "ProductAttribute",
                column: "AttributeTypeCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAttribute_ProductCode",
                table: "ProductAttribute",
                column: "ProductCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProductDocument_DocumentId",
                table: "ProductDocument",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustListing");

            migrationBuilder.DropTable(
                name: "CustPaymMode");

            migrationBuilder.DropTable(
                name: "PostalCode");

            migrationBuilder.DropTable(
                name: "ProductAttribute");

            migrationBuilder.DropTable(
                name: "ProductDocument");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "PaymMode");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "AttributeType");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "DocuType");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
