using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddColumnInExaminationReportsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "SymptomIds",
                table: "ExaminationReports",
                type: "integer[]",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 27, 11, 42, 35, 578, DateTimeKind.Local).AddTicks(814), new DateTime(2022, 12, 22, 11, 42, 35, 573, DateTimeKind.Local).AddTicks(7645) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 1, 11, 42, 35, 578, DateTimeKind.Local).AddTicks(3231), new DateTime(2022, 12, 27, 11, 42, 35, 578, DateTimeKind.Local).AddTicks(3210) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 6, 11, 42, 35, 578, DateTimeKind.Local).AddTicks(3243), new DateTime(2023, 1, 1, 11, 42, 35, 578, DateTimeKind.Local).AddTicks(3238) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SymptomIds",
                table: "ExaminationReports");

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 27, 11, 34, 56, 466, DateTimeKind.Local).AddTicks(158), new DateTime(2022, 12, 22, 11, 34, 56, 460, DateTimeKind.Local).AddTicks(5573) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 1, 11, 34, 56, 466, DateTimeKind.Local).AddTicks(3224), new DateTime(2022, 12, 27, 11, 34, 56, 466, DateTimeKind.Local).AddTicks(3197) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 6, 11, 34, 56, 466, DateTimeKind.Local).AddTicks(3238), new DateTime(2023, 1, 1, 11, 34, 56, 466, DateTimeKind.Local).AddTicks(3231) });
        }
    }
}
