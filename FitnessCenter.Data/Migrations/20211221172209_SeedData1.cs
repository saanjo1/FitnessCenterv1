using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    public partial class SeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OpenFrom",
                table: "FitnessRooms");

            migrationBuilder.DropColumn(
                name: "OpenTo",
                table: "FitnessRooms");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedFrom",
                table: "FitnessRooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReservedTo",
                table: "FitnessRooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Excercises",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Private" },
                    { 2, "Functional" },
                    { 3, "Full body" },
                    { 4, "Focus gluteus" },
                    { 5, "Pilates" },
                    { 6, "Zumba" },
                    { 7, "Core and cardio" }
                });

            migrationBuilder.InsertData(
                table: "FitnessRooms",
                columns: new[] { "Id", "Name", "Price", "ReservedFrom", "ReservedTo" },
                values: new object[,]
                {
                    { 1, "Functional room", 20.0, null, null },
                    { 2, "Cardio room", 25.0, null, null },
                    { 3, "Piletes room", 30.0, null, null },
                    { 4, "Private traingins room", 50.0, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "admin@admin", "admin", "admin", "admin", "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "Role", "Username" },
                values: new object[] { "muhamed.brkan@edu.fit.ba", "Muhamed", "Brkan", 2, "muhamed.brkan" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role", "ServicePrice", "Username" },
                values: new object[] { 3, "sanjin.golos@edu.fit.ba", "Sanjin", "Gološ", "_", "_", 1, null, "sanjin.golos" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Excercises",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "FitnessRooms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FitnessRooms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FitnessRooms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FitnessRooms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "ReservedFrom",
                table: "FitnessRooms");

            migrationBuilder.DropColumn(
                name: "ReservedTo",
                table: "FitnessRooms");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenFrom",
                table: "FitnessRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OpenTo",
                table: "FitnessRooms",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { "muhamed.brkan@edu.fit.ba", "Muhamed", "Brkan", "_", "_", "muhamed.brkan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName", "Role", "Username" },
                values: new object[] { "sanjin.golos@edu.fit.ba", "Sanjin", "Gološ", 0, "sanjin.golos" });
        }
    }
}
