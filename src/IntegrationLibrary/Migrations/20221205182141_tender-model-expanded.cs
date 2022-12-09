using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class tendermodelexpanded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasWon",
                table: "TenderApplications",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Finished",
                table: "EquipmentTenders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 19, 21, 40, 455, DateTimeKind.Local).AddTicks(5668));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 19, 21, 40, 470, DateTimeKind.Local).AddTicks(6827));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 19, 21, 40, 470, DateTimeKind.Local).AddTicks(7427));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasWon",
                table: "TenderApplications");

            migrationBuilder.DropColumn(
                name: "Finished",
                table: "EquipmentTenders");

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 18, 19, 51, 50, 156, DateTimeKind.Local).AddTicks(9736));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 18, 19, 51, 50, 177, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 18, 19, 51, 50, 177, DateTimeKind.Local).AddTicks(501));
        }
    }
}
