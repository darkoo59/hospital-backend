using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class RenameColumnInExaminationReportsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_ExaminationReports_ExaminationReportId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_ExaminationReports_ExaminationReportId",
                table: "Symptoms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExaminationReports",
                table: "ExaminationReports");

            migrationBuilder.DropColumn(
                name: "ExaminationReportId",
                table: "ExaminationReports");

            migrationBuilder.DropColumn(
                name: "SymptomIds",
                table: "ExaminationReports");

            migrationBuilder.RenameColumn(
                name: "AppointmentId",
                table: "ExaminationReports",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ExaminationReports",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExaminationReports",
                table: "ExaminationReports",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_ExaminationReports_ExaminationReportId",
                table: "Recipes",
                column: "ExaminationReportId",
                principalTable: "ExaminationReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_ExaminationReports_ExaminationReportId",
                table: "Symptoms",
                column: "ExaminationReportId",
                principalTable: "ExaminationReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_ExaminationReports_ExaminationReportId",
                table: "Recipes");

            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_ExaminationReports_ExaminationReportId",
                table: "Symptoms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExaminationReports",
                table: "ExaminationReports");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExaminationReports",
                newName: "AppointmentId");

            migrationBuilder.AlterColumn<int>(
                name: "AppointmentId",
                table: "ExaminationReports",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ExaminationReportId",
                table: "ExaminationReports",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<List<int>>(
                name: "SymptomIds",
                table: "ExaminationReports",
                type: "integer[]",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExaminationReports",
                table: "ExaminationReports",
                column: "ExaminationReportId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_ExaminationReports_ExaminationReportId",
                table: "Recipes",
                column: "ExaminationReportId",
                principalTable: "ExaminationReports",
                principalColumn: "ExaminationReportId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_ExaminationReports_ExaminationReportId",
                table: "Symptoms",
                column: "ExaminationReportId",
                principalTable: "ExaminationReports",
                principalColumn: "ExaminationReportId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
