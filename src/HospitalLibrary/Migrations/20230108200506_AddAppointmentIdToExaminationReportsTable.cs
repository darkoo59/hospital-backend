using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddAppointmentIdToExaminationReportsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "ExaminationReports",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 23, 21, 5, 3, 954, DateTimeKind.Local).AddTicks(4659), new DateTime(2023, 1, 18, 21, 5, 3, 944, DateTimeKind.Local).AddTicks(2139) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 28, 21, 5, 3, 954, DateTimeKind.Local).AddTicks(7647), new DateTime(2023, 1, 23, 21, 5, 3, 954, DateTimeKind.Local).AddTicks(7622) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 2, 21, 5, 3, 954, DateTimeKind.Local).AddTicks(7661), new DateTime(2023, 1, 28, 21, 5, 3, 954, DateTimeKind.Local).AddTicks(7655) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "ExaminationReports");

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 22, 22, 10, 47, 57, DateTimeKind.Local).AddTicks(8220), new DateTime(2023, 1, 17, 22, 10, 47, 53, DateTimeKind.Local).AddTicks(1831) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 27, 22, 10, 47, 58, DateTimeKind.Local).AddTicks(2447), new DateTime(2023, 1, 22, 22, 10, 47, 58, DateTimeKind.Local).AddTicks(2426) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 1, 22, 10, 47, 58, DateTimeKind.Local).AddTicks(2459), new DateTime(2023, 1, 27, 22, 10, 47, 58, DateTimeKind.Local).AddTicks(2454) });
        }
    }
}
