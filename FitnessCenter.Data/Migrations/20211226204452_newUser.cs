using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    public partial class newUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Role", "ServicePrice", "Username" },
                values: new object[] { 4, "adil@edu.fit.ba", "Adil", "Joldić", "_", "_", 1, null, "adil.joldic" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
