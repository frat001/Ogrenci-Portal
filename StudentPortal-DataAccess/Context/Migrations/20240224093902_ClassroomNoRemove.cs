using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentPortal_DataAccess.Context.Migrations
{
    /// <inheritdoc />
    public partial class ClassroomNoRemove : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassroomNo",
                table: "Classrooms");

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 39, 2, 640, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 39, 2, 640, DateTimeKind.Local).AddTicks(2594));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 39, 2, 640, DateTimeKind.Local).AddTicks(2600));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 24, 12, 39, 2, 640, DateTimeKind.Local).AddTicks(1745));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ClassroomNo",
                table: "Classrooms",
                type: "smallint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Classrooms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClassroomNo", "CreatedDate" },
                values: new object[] { (byte)10, new DateTime(2024, 2, 17, 14, 10, 40, 933, DateTimeKind.Local).AddTicks(6239) });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 17, 14, 10, 40, 933, DateTimeKind.Local).AddTicks(6558));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 17, 14, 10, 40, 933, DateTimeKind.Local).AddTicks(6566));

            migrationBuilder.UpdateData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2024, 2, 17, 14, 10, 40, 933, DateTimeKind.Local).AddTicks(5690));
        }
    }
}
