using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tuya_Project1.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "Base", "CalculationDate", "Height", "Perimeter", "Type" },
                values: new object[,]
                {
                    { -4, 27200.0, 0.34000000000000002, new DateTime(2024, 2, 14, 8, 6, 16, 818, DateTimeKind.Local).AddTicks(2042), 0.16, 1.1100000000000001, "Triangel" },
                    { -3, 221.0, 17.0, new DateTime(2024, 2, 14, 8, 6, 16, 818, DateTimeKind.Local).AddTicks(2038), 13.0, 68.0, "Rhombus" },
                    { -2, 376.73000000000002, 37.299999999999997, new DateTime(2024, 2, 14, 8, 6, 16, 818, DateTimeKind.Local).AddTicks(2034), 10.1, 99.599999999999994, "Parallelogram" },
                    { -1, 1280.0, 64.0, new DateTime(2024, 2, 14, 8, 6, 16, 818, DateTimeKind.Local).AddTicks(1974), 20.0, 168.0, "Rectangle" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Shapes",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.InsertData(
                table: "Shapes",
                columns: new[] { "Id", "Area", "Base", "CalculationDate", "Height", "Perimeter", "Type" },
                values: new object[,]
                {
                    { 1, 1280.0, 64.0, new DateTime(2024, 2, 7, 22, 22, 33, 569, DateTimeKind.Local).AddTicks(3931), 20.0, 168.0, "Rectangle" },
                    { 2, 376.73000000000002, 37.299999999999997, new DateTime(2024, 2, 7, 22, 22, 33, 569, DateTimeKind.Local).AddTicks(3975), 10.1, 99.599999999999994, "Parallelogram" },
                    { 3, 221.0, 17.0, new DateTime(2024, 2, 7, 22, 22, 33, 569, DateTimeKind.Local).AddTicks(3978), 13.0, 68.0, "Rhombus" },
                    { 4, 27200.0, 0.34000000000000002, new DateTime(2024, 2, 7, 22, 22, 33, 569, DateTimeKind.Local).AddTicks(3980), 0.16, 1.1100000000000001, "Triangel" }
                });
        }
    }
}
