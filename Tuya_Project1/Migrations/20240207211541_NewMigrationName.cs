using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuya_Project1.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Calculators");

            migrationBuilder.RenameColumn(
                name: "Operand2",
                table: "Calculators",
                newName: "Num2");

            migrationBuilder.RenameColumn(
                name: "Operand1",
                table: "Calculators",
                newName: "Num1");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerChoice",
                table: "StenSaxPåseGames",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Outcome",
                table: "StenSaxPåseGames",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "GameDate",
                table: "StenSaxPåseGames",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Shapes",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CalculationDate",
                table: "Shapes",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CalculationDate",
                table: "Calculators",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Operation",
                table: "Calculators",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operation",
                table: "Calculators");

            migrationBuilder.RenameColumn(
                name: "Num2",
                table: "Calculators",
                newName: "Operand2");

            migrationBuilder.RenameColumn(
                name: "Num1",
                table: "Calculators",
                newName: "Operand1");

            migrationBuilder.AlterColumn<string>(
                name: "PlayerChoice",
                table: "StenSaxPåseGames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Outcome",
                table: "StenSaxPåseGames",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "GameDate",
                table: "StenSaxPåseGames",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "Shapes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CalculationDate",
                table: "Shapes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CalculationDate",
                table: "Calculators",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "Calculators",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
