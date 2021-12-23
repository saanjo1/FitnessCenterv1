using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    public partial class editing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FitnessRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Pilates room");

            migrationBuilder.UpdateData(
                table: "FitnessRooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Private trainings room");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FitnessRooms",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Pilates room");

            migrationBuilder.UpdateData(
                table: "FitnessRooms",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Private traingins room");
        }
    }
}
