using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    public partial class newMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_PhotoId",
                table: "Contacts",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Photo_PhotoId",
                table: "Contacts",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Photo_PhotoId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_PhotoId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Contacts");
        }
    }
}
