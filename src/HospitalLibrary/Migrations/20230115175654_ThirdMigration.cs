using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class ThirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "User",
                table: "Feedbacks");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                table: "Feedbacks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "PatientId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "PatientId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "PatientId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 30, 18, 56, 51, 467, DateTimeKind.Local).AddTicks(3950), new DateTime(2023, 1, 25, 18, 56, 51, 459, DateTimeKind.Local).AddTicks(9649) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 4, 18, 56, 51, 467, DateTimeKind.Local).AddTicks(6909), new DateTime(2023, 1, 30, 18, 56, 51, 467, DateTimeKind.Local).AddTicks(6882) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 9, 18, 56, 51, 467, DateTimeKind.Local).AddTicks(6922), new DateTime(2023, 2, 4, 18, 56, 51, 467, DateTimeKind.Local).AddTicks(6917) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "Feedbacks");

            migrationBuilder.AddColumn<string>(
                name: "User",
                table: "Feedbacks",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 1,
                column: "User",
                value: "Милош");

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 2,
                column: "User",
                value: "Немања");

            migrationBuilder.UpdateData(
                table: "Feedbacks",
                keyColumn: "Id",
                keyValue: 3,
                column: "User",
                value: "Огњен");

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 30, 16, 34, 54, 26, DateTimeKind.Local).AddTicks(1202), new DateTime(2023, 1, 25, 16, 34, 54, 18, DateTimeKind.Local).AddTicks(8445) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 4, 16, 34, 54, 26, DateTimeKind.Local).AddTicks(4172), new DateTime(2023, 1, 30, 16, 34, 54, 26, DateTimeKind.Local).AddTicks(4144) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 9, 16, 34, 54, 26, DateTimeKind.Local).AddTicks(4184), new DateTime(2023, 2, 4, 16, 34, 54, 26, DateTimeKind.Local).AddTicks(4180) });
        }
    }
}
