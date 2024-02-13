using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tuya_Project1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calculators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Operand1 = table.Column<double>(type: "float", nullable: false),
                    Operand2 = table.Column<double>(type: "float", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Result = table.Column<double>(type: "float", nullable: false),
                    CalculationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calculators", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shapes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Base = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Area = table.Column<double>(type: "float", nullable: false),
                    Perimeter = table.Column<double>(type: "float", nullable: false),
                    CalculationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shapes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StenSaxPåseGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerChoice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerChoice = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Outcome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GameDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StenSaxPåseGames", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calculators");

            migrationBuilder.DropTable(
                name: "Shapes");

            migrationBuilder.DropTable(
                name: "StenSaxPåseGames");
        }
    }
}
