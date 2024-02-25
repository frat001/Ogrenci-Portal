using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentPortal_DataAccess.Context.IdentityContext.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74f37192-b74b-4330-b875-372e82c04002", null, "student", "STUDENT" },
                    { "b609c887-e794-4762-be5a-6c95232812a4", null, "admin", "ADMIN" },
                    { "dd8eadf8-f90f-41f3-9d81-096ef9e7829b", null, "hrPersonal", "HRPERSONAL" },
                    { "e256341e-70f6-4573-b09a-ab4205a7efc6", null, "teacher", "TEACHER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedDate", "DeletedDate", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdatedDate", "UserName" },
                values: new object[,]
                {
                    { "2735fcfe-c490-4055-ae67-18ae6eca2212", 0, "1d1731e5-5205-4324-9ba4-766e6b2444f7", new DateTime(2024, 2, 18, 11, 36, 44, 893, DateTimeKind.Local).AddTicks(8512), null, "student2@test.com", false, false, null, "STUDENT2@TEST.COM", "STUDENT2", "AQAAAAIAAYagAAAAEGIaRBu58A5uONr/AYHW7mbtEZdC4xbG7sw8fdnZAlgiLoG0Evp5CjMpaENQ8ABrXg==", null, false, "d2717fbd-5036-40c8-a90f-076e4f02d31c", 1, false, null, "student2" },
                    { "427f1691-2f27-44bb-b9f1-d1a4782381af", 0, "27a2ddef-0434-4770-9975-90218e1fdec5", new DateTime(2024, 2, 18, 11, 36, 44, 984, DateTimeKind.Local).AddTicks(9648), null, "teacher@test.com", false, false, null, "TEACHER@TEST.COM", "TEACHER", "AQAAAAIAAYagAAAAEKVhoiBgyM4HLFRro/hVQIaEblfAo8uISpzAXkBGyS2rBc9cq3YrSfQcFjUvPTsfWQ==", null, false, "b22dfc4b-f1f3-4e7c-9f6d-56062fd84603", 1, false, null, "teacher" },
                    { "8b3cd4dd-84f7-4c44-8279-7124a458dfbf", 0, "24ca635f-18fa-4b9e-a4b5-cb09b3ca7163", new DateTime(2024, 2, 18, 11, 36, 45, 73, DateTimeKind.Local).AddTicks(3835), null, "hrpersonal@test.com", false, false, null, "HRPERSONAL@TEST.COM", "HRPERSONAL", "AQAAAAIAAYagAAAAEKTsIi0/vsl0niE4MLq2/nCV4rOO/YqVV8atlV+HTkaOaMLRCRx8h/jVaRtub6tRUA==", null, false, "2a92b3dd-c12e-4028-9660-e05353017be3", 1, false, null, "hrPersonal" },
                    { "92881b6d-cb5d-4809-b964-91074a5184d1", 0, "f01d82d4-ca71-42b4-a861-85797a8e18fa", new DateTime(2024, 2, 18, 11, 36, 44, 714, DateTimeKind.Local).AddTicks(3089), null, "admin@test.com", false, false, null, "ADMIN@TEST.COM", "ADMIN", "AQAAAAIAAYagAAAAEFVdbz3sZFkC8uHLBpwuLnsfh3Vb22EEFJwAb7FeEwM23L832HZk2tF5SIHZGUIh6Q==", null, false, "ddd1bdaa-6fc4-4562-a488-de0742ce7c65", 1, false, null, "admin" },
                    { "9d14c127-c5ec-4372-8ba9-26d58ebcdbe1", 0, "537d7b01-7079-45b5-92c1-b648cc65a073", new DateTime(2024, 2, 18, 11, 36, 44, 802, DateTimeKind.Local).AddTicks(4607), null, "student@test.com", false, false, null, "STUDENT@TEST.COM", "STUDENT", "AQAAAAIAAYagAAAAEJHA1g4vZvysMRhNjdp1Li+8C46sNI/pRnU/oWcbVkfQzQOEAOhQvjxcXS4nmIDRdQ==", null, false, "2c3cad65-fba0-4681-bf0f-22ce5348ac15", 1, false, null, "student" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "74f37192-b74b-4330-b875-372e82c04002", "2735fcfe-c490-4055-ae67-18ae6eca2212" },
                    { "e256341e-70f6-4573-b09a-ab4205a7efc6", "427f1691-2f27-44bb-b9f1-d1a4782381af" },
                    { "dd8eadf8-f90f-41f3-9d81-096ef9e7829b", "8b3cd4dd-84f7-4c44-8279-7124a458dfbf" },
                    { "b609c887-e794-4762-be5a-6c95232812a4", "92881b6d-cb5d-4809-b964-91074a5184d1" },
                    { "74f37192-b74b-4330-b875-372e82c04002", "9d14c127-c5ec-4372-8ba9-26d58ebcdbe1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
