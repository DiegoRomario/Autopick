using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autopick.Api.Migrations
{
    public partial class PlayerNewFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Foot",
                table: "Player",
                type: "TINYINT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Player",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Player",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foot",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Player");
        }
    }
}
