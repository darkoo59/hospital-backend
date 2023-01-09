using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class migration333 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2023, 2, 8, 12, 44, 57, 184, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2023, 2, 8, 12, 44, 57, 194, DateTimeKind.Local).AddTicks(7171));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2023, 2, 8, 12, 44, 57, 194, DateTimeKind.Local).AddTicks(8208));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2023, 2, 8, 12, 44, 33, 973, DateTimeKind.Local).AddTicks(8119));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2023, 2, 8, 12, 44, 33, 988, DateTimeKind.Local).AddTicks(5856));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2023, 2, 8, 12, 44, 33, 988, DateTimeKind.Local).AddTicks(6277));
        }
    }
}
