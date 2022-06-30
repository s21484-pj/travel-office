using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelOffice.Infrastructure.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TouristAttractions_Offers_OfferId",
                table: "TouristAttractions");

            migrationBuilder.DropIndex(
                name: "IX_TouristAttractions_OfferId",
                table: "TouristAttractions");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "DateOfUpdate",
                table: "Transports");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "TouristAttractions");

            migrationBuilder.DropColumn(
                name: "DateOfUpdate",
                table: "TouristAttractions");

            migrationBuilder.DropColumn(
                name: "OfferId",
                table: "TouristAttractions");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DateOfUpdate",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "DateOfCreation",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "DateOfUpdate",
                table: "Hotels");

            migrationBuilder.AlterColumn<string>(
                name: "TransportType",
                table: "Transports",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "AttractionId",
                table: "Offers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TouristAttractionId",
                table: "Offers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_TouristAttractionId",
                table: "Offers",
                column: "TouristAttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_TouristAttractions_TouristAttractionId",
                table: "Offers",
                column: "TouristAttractionId",
                principalTable: "TouristAttractions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_TouristAttractions_TouristAttractionId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_TouristAttractionId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "AttractionId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "TouristAttractionId",
                table: "Offers");

            migrationBuilder.AlterColumn<int>(
                name: "TransportType",
                table: "Transports",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Transports",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfUpdate",
                table: "Transports",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "TouristAttractions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfUpdate",
                table: "TouristAttractions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "OfferId",
                table: "TouristAttractions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Offers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfUpdate",
                table: "Offers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfCreation",
                table: "Hotels",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfUpdate",
                table: "Hotels",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_TouristAttractions_OfferId",
                table: "TouristAttractions",
                column: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_TouristAttractions_Offers_OfferId",
                table: "TouristAttractions",
                column: "OfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }
    }
}
