using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class FourthMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Feedbacks",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 30, 20, 26, 6, 794, DateTimeKind.Local).AddTicks(8385), new DateTime(2023, 1, 25, 20, 26, 6, 756, DateTimeKind.Local).AddTicks(6740) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 4, 20, 26, 6, 795, DateTimeKind.Local).AddTicks(1371), new DateTime(2023, 1, 30, 20, 26, 6, 795, DateTimeKind.Local).AddTicks(1339) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 2, 9, 20, 26, 6, 795, DateTimeKind.Local).AddTicks(1383), new DateTime(2023, 2, 4, 20, 26, 6, 795, DateTimeKind.Local).AddTicks(1378) });

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Patients_PatientId",
                table: "Feedbacks",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Patients_PatientId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_PatientId",
                table: "Feedbacks");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Feedbacks",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

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
    }
}
