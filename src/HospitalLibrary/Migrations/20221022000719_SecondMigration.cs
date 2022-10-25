using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace HospitalLibrary.Migrations
{
    public partial class SecondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_PatientId_PatientId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientId",
                table: "PatientId");

            migrationBuilder.RenameTable(
                name: "PatientId",
                newName: "Patients");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patients",
                table: "Patients",
                column: "PatientId");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 10, 22, 2, 7, 18, 649, DateTimeKind.Local).AddTicks(1172));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Patients_PatientId",
                table: "Appointments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patients",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "Patients",
                newName: "PatientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientId",
                table: "PatientId",
                column: "PatientId");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2022, 10, 22, 2, 1, 9, 283, DateTimeKind.Local).AddTicks(9178));

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_PatientId_PatientId",
                table: "Appointments",
                column: "PatientId",
                principalTable: "PatientId",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
