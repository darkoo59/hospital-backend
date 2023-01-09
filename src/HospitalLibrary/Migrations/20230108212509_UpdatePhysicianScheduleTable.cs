using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class UpdatePhysicianScheduleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhysicianScheduleId",
                table: "PhysicianSchedules",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 23, 22, 25, 6, 865, DateTimeKind.Local).AddTicks(1156), new DateTime(2023, 1, 18, 22, 25, 6, 858, DateTimeKind.Local).AddTicks(1178) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 28, 22, 25, 6, 865, DateTimeKind.Local).AddTicks(4674), new DateTime(2023, 1, 23, 22, 25, 6, 865, DateTimeKind.Local).AddTicks(4644) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 2, 22, 25, 6, 865, DateTimeKind.Local).AddTicks(4689), new DateTime(2023, 1, 28, 22, 25, 6, 865, DateTimeKind.Local).AddTicks(4683) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PhysicianSchedules",
                newName: "PhysicianScheduleId");

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
    }
}
