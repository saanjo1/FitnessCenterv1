using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    public partial class Reservations2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReservedTo",
                table: "FitnessRooms",
                newName: "OpenTo");

            migrationBuilder.RenameColumn(
                name: "ReservedFrom",
                table: "FitnessRooms",
                newName: "OpenFrom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OpenTo",
                table: "FitnessRooms",
                newName: "ReservedTo");

            migrationBuilder.RenameColumn(
                name: "OpenFrom",
                table: "FitnessRooms",
                newName: "ReservedFrom");
        }
    }
}
