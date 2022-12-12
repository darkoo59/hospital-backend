using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddColumnInExaminationReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<List<int>>(
                name: "MedicineIds",
                table: "Recipes",
                type: "integer[]",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MedicineIds",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "SymptomIds",
                table: "ExaminationReports");

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 20, 18, 26, 54, 793, DateTimeKind.Local).AddTicks(9625), new DateTime(2022, 12, 15, 18, 26, 54, 786, DateTimeKind.Local).AddTicks(87) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 25, 18, 26, 54, 794, DateTimeKind.Local).AddTicks(5060), new DateTime(2022, 12, 20, 18, 26, 54, 794, DateTimeKind.Local).AddTicks(5031) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 30, 18, 26, 54, 794, DateTimeKind.Local).AddTicks(5074), new DateTime(2022, 12, 25, 18, 26, 54, 794, DateTimeKind.Local).AddTicks(5068) });
        }
    }
}
