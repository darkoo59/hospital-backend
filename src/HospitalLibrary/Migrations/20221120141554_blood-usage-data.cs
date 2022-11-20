using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HospitalLibrary.Migrations
{
    public partial class bloodusagedata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "Start",
                value: new DateTime(2022, 11, 20, 15, 15, 53, 463, DateTimeKind.Local).AddTicks(5240));

            migrationBuilder.InsertData(
                table: "BloodUsageEvidencies",
                columns: new[] { "BloodUsageEvidencyId", "BloodType", "DateOfUsage", "DoctorId", "QuantityUsedInMililiters", "ReasonForUsage" },
                values: new object[,]
                {
                    { 2, 3, new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 300.0, "Hearth surgery" },
                    { 3, 6, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 450.0, "Hearth surgery" },
                    { 4, 0, new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 700.0, "Hearth surgery" },
                    { 5, 3, new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 180.0, "Hearth surgery" },
                    { 6, 5, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1100.0, "Hearth surgery" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BloodUsageEvidencies",
                keyColumn: "BloodUsageEvidencyId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BloodUsageEvidencies",
                keyColumn: "BloodUsageEvidencyId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BloodUsageEvidencies",
                keyColumn: "BloodUsageEvidencyId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BloodUsageEvidencies",
                keyColumn: "BloodUsageEvidencyId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BloodUsageEvidencies",
                keyColumn: "BloodUsageEvidencyId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "Start",
                value: new DateTime(2022, 11, 13, 17, 16, 41, 312, DateTimeKind.Local).AddTicks(7550));
        }
    }
}
