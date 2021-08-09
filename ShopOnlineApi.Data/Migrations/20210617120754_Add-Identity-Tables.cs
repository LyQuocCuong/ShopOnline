using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopOnline.Data.Migrations
{
    public partial class AddIdentityTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "S_USER_ID",
                table: "ORDER",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "S_ACTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NAME = table.Column<string>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_ACTION", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "S_FEATURE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    PARENT_ID = table.Column<Guid>(nullable: true),
                    NAME = table.Column<string>(nullable: false),
                    URL = table.Column<string>(nullable: true),
                    SORT_ORDER = table.Column<string>(nullable: true),
                    STATUS = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_FEATURE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_S_FEATURE_S_FEATURE_PARENT_ID",
                        column: x => x.PARENT_ID,
                        principalTable: "S_FEATURE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "S_ROLE",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_ROLE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S_ROLE_CLAIM",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_ROLE_CLAIM", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "S_SETTING",
                columns: table => new
                {
                    KEY = table.Column<string>(nullable: false),
                    VALUE = table.Column<string>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_SETTING", x => x.KEY);
                });

            migrationBuilder.CreateTable(
                name: "S_USER",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FULL_NAME = table.Column<string>(nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    LAST_LOGIN_DATE = table.Column<DateTime>(nullable: false),
                    STATUS = table.Column<int>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_USER", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S_USER_CLAIM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_USER_CLAIM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "S_USER_LOGIN",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_USER_LOGIN", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "S_USER_ROLE",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_USER_ROLE", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "S_USER_TOKEN",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_USER_TOKEN", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "S_PERMISSION",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    S_ROLE_ID = table.Column<Guid>(nullable: false),
                    S_FEATURE_ID = table.Column<Guid>(nullable: false),
                    S_ACTION_ID = table.Column<Guid>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_PERMISSION", x => x.ID);
                    table.ForeignKey(
                        name: "FK_S_PERMISSION_S_ACTION_S_ACTION_ID",
                        column: x => x.S_ACTION_ID,
                        principalTable: "S_ACTION",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_S_PERMISSION_S_FEATURE_S_FEATURE_ID",
                        column: x => x.S_FEATURE_ID,
                        principalTable: "S_FEATURE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_S_PERMISSION_S_ROLE_S_ROLE_ID",
                        column: x => x.S_ROLE_ID,
                        principalTable: "S_ROLE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "S_LOG_ACTIVITY",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    S_USER_ID = table.Column<Guid>(nullable: false),
                    CLIENT_ID = table.Column<Guid>(nullable: false),
                    S_FEATURE_NAME = table.Column<string>(nullable: false),
                    S_ACTION_NAME = table.Column<string>(nullable: false),
                    CREATED_DATE = table.Column<DateTime>(nullable: false),
                    IS_DELETED = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S_LOG_ACTIVITY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_S_LOG_ACTIVITY_S_USER_S_USER_ID",
                        column: x => x.S_USER_ID,
                        principalTable: "S_USER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ORDER_S_USER_ID",
                table: "ORDER",
                column: "S_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_S_FEATURE_PARENT_ID",
                table: "S_FEATURE",
                column: "PARENT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_S_LOG_ACTIVITY_S_USER_ID",
                table: "S_LOG_ACTIVITY",
                column: "S_USER_ID");

            migrationBuilder.CreateIndex(
                name: "IX_S_PERMISSION_S_ACTION_ID",
                table: "S_PERMISSION",
                column: "S_ACTION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_S_PERMISSION_S_FEATURE_ID",
                table: "S_PERMISSION",
                column: "S_FEATURE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_S_PERMISSION_S_ROLE_ID",
                table: "S_PERMISSION",
                column: "S_ROLE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ORDER_S_USER_S_USER_ID",
                table: "ORDER",
                column: "S_USER_ID",
                principalTable: "S_USER",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ORDER_S_USER_S_USER_ID",
                table: "ORDER");

            migrationBuilder.DropTable(
                name: "S_LOG_ACTIVITY");

            migrationBuilder.DropTable(
                name: "S_PERMISSION");

            migrationBuilder.DropTable(
                name: "S_ROLE_CLAIM");

            migrationBuilder.DropTable(
                name: "S_SETTING");

            migrationBuilder.DropTable(
                name: "S_USER_CLAIM");

            migrationBuilder.DropTable(
                name: "S_USER_LOGIN");

            migrationBuilder.DropTable(
                name: "S_USER_ROLE");

            migrationBuilder.DropTable(
                name: "S_USER_TOKEN");

            migrationBuilder.DropTable(
                name: "S_USER");

            migrationBuilder.DropTable(
                name: "S_ACTION");

            migrationBuilder.DropTable(
                name: "S_FEATURE");

            migrationBuilder.DropTable(
                name: "S_ROLE");

            migrationBuilder.DropIndex(
                name: "IX_ORDER_S_USER_ID",
                table: "ORDER");

            migrationBuilder.DropColumn(
                name: "S_USER_ID",
                table: "ORDER");
        }
    }
}
