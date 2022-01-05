using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    public partial class EditEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplements_Sponsors_SponsorId",
                table: "Supplements");

            migrationBuilder.AlterColumn<int>(
                name: "SponsorId",
                table: "Supplements",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplements_Sponsors_SponsorId",
                table: "Supplements",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplements_Sponsors_SponsorId",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "SponsorId",
                table: "Supplements",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplements_Sponsors_SponsorId",
                table: "Supplements",
                column: "SponsorId",
                principalTable: "Sponsors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
