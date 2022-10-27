using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 10, 24, 11, 35, 19, 588, DateTimeKind.Local).AddTicks(9520));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 10, 24, 11, 22, 35, 948, DateTimeKind.Local).AddTicks(5392));
        }
    }
}
