using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class WorkTimeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTime_Doctors_DoctorId",
                table: "WorkTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTime",
                table: "WorkTime");

            migrationBuilder.RenameTable(
                name: "WorkTime",
                newName: "WorkTimes");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTime_DoctorId",
                table: "WorkTimes",
                newName: "IX_WorkTimes_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTimes",
                table: "WorkTimes",
                column: "WorkTimeId");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 10, 21, 20, 34, 37, 222, DateTimeKind.Local).AddTicks(1756));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTimes_Doctors_DoctorId",
                table: "WorkTimes",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTimes_Doctors_DoctorId",
                table: "WorkTimes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTimes",
                table: "WorkTimes");

            migrationBuilder.RenameTable(
                name: "WorkTimes",
                newName: "WorkTime");

            migrationBuilder.RenameIndex(
                name: "IX_WorkTimes_DoctorId",
                table: "WorkTime",
                newName: "IX_WorkTime_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTime",
                table: "WorkTime",
                column: "WorkTimeId");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 10, 21, 20, 27, 49, 335, DateTimeKind.Local).AddTicks(2063));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTime_Doctors_DoctorId",
                table: "WorkTime",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
