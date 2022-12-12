using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class AddExaminationReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ExaminationReportId",
                table: "Symptoms",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Medicines",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExaminationReports",
                columns: table => new
                {
                    ExaminationReportId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Report = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationReports", x => x.ExaminationReportId);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    WayOfUse = table.Column<string>(type: "text", nullable: true),
                    DateOfIssue = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExaminationReportId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.RecipeId);
                    table.ForeignKey(
                        name: "FK_Recipes_ExaminationReports_ExaminationReportId",
                        column: x => x.ExaminationReportId,
                        principalTable: "ExaminationReports",
                        principalColumn: "ExaminationReportId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Symptoms_ExaminationReportId",
                table: "Symptoms",
                column: "ExaminationReportId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicines_RecipeId",
                table: "Medicines",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ExaminationReportId",
                table: "Recipes",
                column: "ExaminationReportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicines_Recipes_RecipeId",
                table: "Medicines",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "RecipeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Symptoms_ExaminationReports_ExaminationReportId",
                table: "Symptoms",
                column: "ExaminationReportId",
                principalTable: "ExaminationReports",
                principalColumn: "ExaminationReportId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicines_Recipes_RecipeId",
                table: "Medicines");

            migrationBuilder.DropForeignKey(
                name: "FK_Symptoms_ExaminationReports_ExaminationReportId",
                table: "Symptoms");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "ExaminationReports");

            migrationBuilder.DropIndex(
                name: "IX_Symptoms_ExaminationReportId",
                table: "Symptoms");

            migrationBuilder.DropIndex(
                name: "IX_Medicines_RecipeId",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "ExaminationReportId",
                table: "Symptoms");

            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Medicines");

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 17, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(4189), new DateTime(2022, 12, 12, 12, 49, 16, 841, DateTimeKind.Local).AddTicks(1098) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 22, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(6733), new DateTime(2022, 12, 17, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(6710) });

            migrationBuilder.UpdateData(
                table: "VacationRequests",
                keyColumn: "VacationRequestId",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2022, 12, 27, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(6744), new DateTime(2022, 12, 22, 12, 49, 16, 847, DateTimeKind.Local).AddTicks(6739) });
        }
    }
}
