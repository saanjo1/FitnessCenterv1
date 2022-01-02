using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessCenter.Data.Migrations
{
    public partial class RefactorPhotos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Discounts");

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Supplements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Sponsors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Equipment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PhotoId",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Supplements_PhotoId",
                table: "Supplements",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_PhotoId",
                table: "Sponsors",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PhotoId",
                table: "Events",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_PhotoId",
                table: "Equipment",
                column: "PhotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_PhotoId",
                table: "Discounts",
                column: "PhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Photo_PhotoId",
                table: "Discounts",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipment_Photo_PhotoId",
                table: "Equipment",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Photo_PhotoId",
                table: "Events",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Photo_PhotoId",
                table: "Sponsors",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Supplements_Photo_PhotoId",
                table: "Supplements",
                column: "PhotoId",
                principalTable: "Photo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Photo_PhotoId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipment_Photo_PhotoId",
                table: "Equipment");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Photo_PhotoId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Photo_PhotoId",
                table: "Sponsors");

            migrationBuilder.DropForeignKey(
                name: "FK_Supplements_Photo_PhotoId",
                table: "Supplements");

            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.DropIndex(
                name: "IX_Supplements_PhotoId",
                table: "Supplements");

            migrationBuilder.DropIndex(
                name: "IX_Sponsors_PhotoId",
                table: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Events_PhotoId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Equipment_PhotoId",
                table: "Equipment");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_PhotoId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Supplements");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "PhotoId",
                table: "Discounts");

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Sponsors",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Events",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Equipment",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Discounts",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
