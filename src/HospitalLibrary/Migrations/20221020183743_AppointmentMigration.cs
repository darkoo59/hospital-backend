using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HospitalLibrary.Migrations
{
    public partial class AppointmentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "AppointmentId");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 10, 20, 20, 37, 42, 243, DateTimeKind.Local).AddTicks(6148));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Appointments",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 10, 20, 20, 10, 8, 323, DateTimeKind.Local).AddTicks(9962));
        }
    }
}
