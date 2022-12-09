using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class tendermodelexpandedagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finished",
                table: "EquipmentTenders");

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "EquipmentTenders",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 20, 11, 35, 785, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 20, 11, 35, 803, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 20, 11, 35, 803, DateTimeKind.Local).AddTicks(3925));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "EquipmentTenders");

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
    }
}
