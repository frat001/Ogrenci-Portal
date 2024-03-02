using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal_DataAccess.Context.IdentityContext.Migrations
{
    /// <inheritdoc />
    public partial class AppUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2735fcfe-c490-4055-ae67-18ae6eca2212",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "5da18c98-c4c2-41c1-9ab7-bb540124596c", new DateTime(2024, 3, 2, 10, 59, 32, 18, DateTimeKind.Local).AddTicks(1016), null, null, "AQAAAAIAAYagAAAAEK+oUolPzfkXIouJlaFy+ZGRUIOQrm173EPO4DzBaLgkwDnFpNm1mWUdUlAoHWhNPQ==", "f41f7466-839d-4bb6-b4b9-1016c42f91f3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "427f1691-2f27-44bb-b9f1-d1a4782381af",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "e7dfeb93-f936-416c-bc8b-b63902eb0501", new DateTime(2024, 3, 2, 10, 59, 32, 88, DateTimeKind.Local).AddTicks(5597), null, null, "AQAAAAIAAYagAAAAEAhDOP/7sfOKfZT8cylvNE8kRdJr/6dKIjiwZBA1CiWC80Gj8I0MszTkYIJoKhzNxA==", "4c052279-4db9-45b6-99ef-0e614c622349" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b3cd4dd-84f7-4c44-8279-7124a458dfbf",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "257d0f46-b76c-42c2-b89c-b732520f7b09", new DateTime(2024, 3, 2, 10, 59, 32, 158, DateTimeKind.Local).AddTicks(8671), null, null, "AQAAAAIAAYagAAAAEPbdFkEbBEfRKS77aMoENX4BvRmIXNtwUCDRMNPxozOPntXCUdUWAvOLpgghuqTG8Q==", "7d66dac7-2684-449e-9ce5-f7ee4d0de5d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92881b6d-cb5d-4809-b964-91074a5184d1",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "9fd11181-f06f-424f-b0ce-7fb40ca83e7c", new DateTime(2024, 3, 2, 10, 59, 31, 875, DateTimeKind.Local).AddTicks(3980), null, null, "AQAAAAIAAYagAAAAEFK3JxsaomkXiitTc83XhsZRHvEz6b8ttSxW3L5rT3njOtys7pnO7DaORJ7l8KcT/g==", "0d520a29-c2b3-419b-ad8f-0cffd45fd862" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d14c127-c5ec-4372-8ba9-26d58ebcdbe1",
                columns: new[] { "BirthDate", "ConcurrencyStamp", "CreatedDate", "FirstName", "LastName", "PasswordHash", "SecurityStamp" },
                values: new object[] { null, "d945a6b8-8244-44ba-ac5f-9c0304e1e0f4", new DateTime(2024, 3, 2, 10, 59, 31, 949, DateTimeKind.Local).AddTicks(3122), null, null, "AQAAAAIAAYagAAAAEHe3VQ1ZIIwWjj97YjVG6szz3PcCFCdOWc2QH8tgYBAWZBUT2DZOXr6CpFR7RbS4uA==", "05468dbc-fa28-4559-84ac-768f99ce2920" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2735fcfe-c490-4055-ae67-18ae6eca2212",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d1731e5-5205-4324-9ba4-766e6b2444f7", new DateTime(2024, 2, 18, 11, 36, 44, 893, DateTimeKind.Local).AddTicks(8512), "AQAAAAIAAYagAAAAEGIaRBu58A5uONr/AYHW7mbtEZdC4xbG7sw8fdnZAlgiLoG0Evp5CjMpaENQ8ABrXg==", "d2717fbd-5036-40c8-a90f-076e4f02d31c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "427f1691-2f27-44bb-b9f1-d1a4782381af",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27a2ddef-0434-4770-9975-90218e1fdec5", new DateTime(2024, 2, 18, 11, 36, 44, 984, DateTimeKind.Local).AddTicks(9648), "AQAAAAIAAYagAAAAEKVhoiBgyM4HLFRro/hVQIaEblfAo8uISpzAXkBGyS2rBc9cq3YrSfQcFjUvPTsfWQ==", "b22dfc4b-f1f3-4e7c-9f6d-56062fd84603" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8b3cd4dd-84f7-4c44-8279-7124a458dfbf",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "24ca635f-18fa-4b9e-a4b5-cb09b3ca7163", new DateTime(2024, 2, 18, 11, 36, 45, 73, DateTimeKind.Local).AddTicks(3835), "AQAAAAIAAYagAAAAEKTsIi0/vsl0niE4MLq2/nCV4rOO/YqVV8atlV+HTkaOaMLRCRx8h/jVaRtub6tRUA==", "2a92b3dd-c12e-4028-9660-e05353017be3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "92881b6d-cb5d-4809-b964-91074a5184d1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f01d82d4-ca71-42b4-a861-85797a8e18fa", new DateTime(2024, 2, 18, 11, 36, 44, 714, DateTimeKind.Local).AddTicks(3089), "AQAAAAIAAYagAAAAEFVdbz3sZFkC8uHLBpwuLnsfh3Vb22EEFJwAb7FeEwM23L832HZk2tF5SIHZGUIh6Q==", "ddd1bdaa-6fc4-4562-a488-de0742ce7c65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d14c127-c5ec-4372-8ba9-26d58ebcdbe1",
                columns: new[] { "ConcurrencyStamp", "CreatedDate", "PasswordHash", "SecurityStamp" },
                values: new object[] { "537d7b01-7079-45b5-92c1-b648cc65a073", new DateTime(2024, 2, 18, 11, 36, 44, 802, DateTimeKind.Local).AddTicks(4607), "AQAAAAIAAYagAAAAEJHA1g4vZvysMRhNjdp1Li+8C46sNI/pRnU/oWcbVkfQzQOEAOhQvjxcXS4nmIDRdQ==", "2c3cad65-fba0-4681-bf0f-22ce5348ac15" });
        }
    }
}
