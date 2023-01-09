using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class urgentorders3433 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "UrgentOrders",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 24, 2, 18, 29, 719, DateTimeKind.Local).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 24, 2, 18, 29, 735, DateTimeKind.Local).AddTicks(3251));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 24, 2, 18, 29, 735, DateTimeKind.Local).AddTicks(3912));

            migrationBuilder.UpdateData(
                table: "UrgentOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UrgentOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UrgentOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "UrgentOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "UrgentOrders");

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 23, 17, 44, 33, 435, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 23, 17, 44, 33, 451, DateTimeKind.Local).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 23, 17, 44, 33, 451, DateTimeKind.Local).AddTicks(2115));
        }
    }
}
