using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORY",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PARENT_ID = table.Column<Guid>(nullable: true),
                    SORT_ORDER = table.Column<int>(nullable: false),
                    IS_SHOW_ON_HOME = table.Column<bool>(nullable: false),
                    STATUS = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CATEGORY_CATEGORY_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONTACT",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    EMAIL = table.Column<string>(nullable: true),
                    PHONE_NUMBER = table.Column<string>(nullable: true),
                    MESSAGE = table.Column<string>(nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LANGUAGE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    IS_DEFAULT = table.Column<bool>(nullable: false, defaultValue: true),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LANGUAGE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORDER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ORDER_DATE = table.Column<DateTime>(nullable: false),
                    SHIP_NAME = table.Column<string>(nullable: true),
                    SHIP_ADDRESS = table.Column<string>(nullable: false),
                    SHIP_EMAIL = table.Column<string>(nullable: true),
                    SHIP_PHONE_NUMBER = table.Column<string>(nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ORIGINAL_PRICE = table.Column<double>(nullable: false),
                    SELLING_PRICE = table.Column<double>(nullable: false),
                    STOCK_AMOUNT = table.Column<int>(nullable: false),
                    VIEW_COUNT = table.Column<int>(nullable: false),
                    STATUS = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PROMOTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    FROM_DATE = table.Column<DateTime>(nullable: false),
                    TO_DATE = table.Column<DateTime>(nullable: false),
                    DISCOUNT_PERCENT = table.Column<double>(nullable: false),
                    DISCOUNT_AMOUNT = table.Column<double>(nullable: false),
                    IS_APPLY_FOR_ALL = table.Column<bool>(nullable: false),
                    APPLIED_PRODUCTIDS = table.Column<string>(nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROMOTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CATEGORY_TRANSLATION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CATEGORY_ID = table.Column<Guid>(nullable: false),
                    LANGUAGE_ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DETAILS = table.Column<string>(nullable: true),
                    SEO_DESCRIPTION = table.Column<string>(nullable: true),
                    SEO_TITLE = table.Column<string>(nullable: true),
                    SEO_ALIAS = table.Column<string>(nullable: true),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORY_TRANSLATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CATEGORY_TRANSLATION_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CATEGORY_TRANSLATION_LANGUAGE_LANGUAGE_ID",
                        column: x => x.LANGUAGE_ID,
                        principalTable: "LANGUAGE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CART",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PRODUCT_ID = table.Column<Guid>(nullable: false),
                    QUANTITY = table.Column<int>(nullable: false, defaultValue: 0),
                    PRICE = table.Column<double>(nullable: false, defaultValue: 0.0),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CART", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CART_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ORDER_DETAIL",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ORDER_ID = table.Column<Guid>(nullable: false),
                    PRODUCT_ID = table.Column<Guid>(nullable: false),
                    QUANTITY = table.Column<int>(nullable: false),
                    PRICE = table.Column<double>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORDER_DETAIL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAIL_ORDER_ORDER_ID",
                        column: x => x.ORDER_ID,
                        principalTable: "ORDER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORDER_DETAIL_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_IMAGE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PRODUCT_ID = table.Column<Guid>(nullable: false),
                    CAPTION = table.Column<string>(nullable: true),
                    PATH = table.Column<string>(nullable: false),
                    SORT_ORDER = table.Column<int>(nullable: false),
                    IS_DEFAULT = table.Column<bool>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_IMAGE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_IMAGE_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_IN_CATEGORY",
                columns: table => new
                {
                    CATEGORY_ID = table.Column<Guid>(nullable: false),
                    PRODUCT_ID = table.Column<Guid>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_IN_CATEGORY", x => new { x.CATEGORY_ID, x.PRODUCT_ID });
                    table.ForeignKey(
                        name: "FK_PRODUCT_IN_CATEGORY_CATEGORY_CATEGORY_ID",
                        column: x => x.CATEGORY_ID,
                        principalTable: "CATEGORY",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_IN_CATEGORY_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT_TRANSLATION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PRODUCT_ID = table.Column<Guid>(nullable: false),
                    LANGUAGE_ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DETAILS = table.Column<string>(nullable: true),
                    SEO_DESCRIPTION = table.Column<string>(nullable: true),
                    SEO_TITLE = table.Column<string>(nullable: true),
                    SEO_ALIAS = table.Column<string>(nullable: true),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT_TRANSLATION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_TRANSLATION_LANGUAGE_LANGUAGE_ID",
                        column: x => x.LANGUAGE_ID,
                        principalTable: "LANGUAGE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PRODUCT_TRANSLATION_PRODUCT_PRODUCT_ID",
                        column: x => x.PRODUCT_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CART_PRODUCT_ID",
                table: "CART",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_PARENT_ID",
                table: "CATEGORY",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_TRANSLATION_CATEGORY_ID",
                table: "CATEGORY_TRANSLATION",
                column: "CATEGORY_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORY_TRANSLATION_LANGUAGE_ID",
                table: "CATEGORY_TRANSLATION",
                column: "LANGUAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAIL_ORDER_ID",
                table: "ORDER_DETAIL",
                column: "ORDER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_DETAIL_PRODUCT_ID",
                table: "ORDER_DETAIL",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_IMAGE_PRODUCT_ID",
                table: "PRODUCT_IMAGE",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_IN_CATEGORY_PRODUCT_ID",
                table: "PRODUCT_IN_CATEGORY",
                column: "PRODUCT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_TRANSLATION_LANGUAGE_ID",
                table: "PRODUCT_TRANSLATION",
                column: "LANGUAGE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_TRANSLATION_PRODUCT_ID",
                table: "PRODUCT_TRANSLATION",
                column: "PRODUCT_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CART");

            migrationBuilder.DropTable(
                name: "CATEGORY_TRANSLATION");

            migrationBuilder.DropTable(
                name: "CONTACT");

            migrationBuilder.DropTable(
                name: "ORDER_DETAIL");

            migrationBuilder.DropTable(
                name: "PRODUCT_IMAGE");

            migrationBuilder.DropTable(
                name: "PRODUCT_IN_CATEGORY");

            migrationBuilder.DropTable(
                name: "PRODUCT_TRANSLATION");

            migrationBuilder.DropTable(
                name: "PROMOTION");

            migrationBuilder.DropTable(
                name: "ORDER");

            migrationBuilder.DropTable(
                name: "CATEGORY");

            migrationBuilder.DropTable(
                name: "LANGUAGE");

            migrationBuilder.DropTable(
                name: "PRODUCT");
        }
    }
}
