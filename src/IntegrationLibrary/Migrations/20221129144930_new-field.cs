using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class newfield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresOn",
                table: "EquipmentTenders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2022, 11, 30, 15, 49, 29, 426, DateTimeKind.Local).AddTicks(6125));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2022, 11, 30, 15, 49, 29, 434, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2022, 11, 30, 15, 49, 29, 434, DateTimeKind.Local).AddTicks(1266));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiresOn",
                table: "EquipmentTenders");
        }
    }
}
