using System;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class AddColumnToAppointmensTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Start",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "Appointments",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "DoctorId",
                table: "Appointments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Appointments",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateRange>(
                name: "ScheduledDate",
                table: "Appointments",
                type: "jsonb",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 26, 19, 4, 26, 260, DateTimeKind.Local).AddTicks(9264), new DateTime(2022, 12, 21, 19, 4, 26, 256, DateTimeKind.Local).AddTicks(2378) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 31, 19, 4, 26, 261, DateTimeKind.Local).AddTicks(8820), new DateTime(2022, 12, 26, 19, 4, 26, 261, DateTimeKind.Local).AddTicks(8757) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 1, 5, 19, 4, 26, 261, DateTimeKind.Local).AddTicks(8834), new DateTime(2022, 12, 31, 19, 4, 26, 261, DateTimeKind.Local).AddTicks(8829) });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "DoctorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Doctors_DoctorId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "ScheduledDate",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Appointments",
                newName: "AppointmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Appointments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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
    }
}
