using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddColumnAppointmentIdInReportTable : Migration
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
                values: new object[] { new DateTime(2022, 12, 26, 14, 26, 10, 622, DateTimeKind.Local).AddTicks(3439), new DateTime(2022, 12, 21, 14, 26, 10, 616, DateTimeKind.Local).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 31, 14, 26, 10, 622, DateTimeKind.Local).AddTicks(6917), new DateTime(2022, 12, 26, 14, 26, 10, 622, DateTimeKind.Local).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 5, 14, 26, 10, 622, DateTimeKind.Local).AddTicks(6935), new DateTime(2022, 12, 31, 14, 26, 10, 622, DateTimeKind.Local).AddTicks(6926) });
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
                values: new object[] { new DateTime(2022, 12, 25, 15, 22, 19, 253, DateTimeKind.Local).AddTicks(7805), new DateTime(2022, 12, 20, 15, 22, 19, 248, DateTimeKind.Local).AddTicks(5185) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 30, 15, 22, 19, 254, DateTimeKind.Local).AddTicks(420), new DateTime(2022, 12, 25, 15, 22, 19, 254, DateTimeKind.Local).AddTicks(398) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 4, 15, 22, 19, 254, DateTimeKind.Local).AddTicks(432), new DateTime(2022, 12, 30, 15, 22, 19, 254, DateTimeKind.Local).AddTicks(426) });
        }
    }
}
