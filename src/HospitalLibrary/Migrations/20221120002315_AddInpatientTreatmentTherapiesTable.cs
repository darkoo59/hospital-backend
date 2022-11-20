using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class AddInpatientTreatmentTherapiesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Beds",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "InpatientTreatments",
                columns: table => new
                {
                    InpatientTreatmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    ReasonForAdmission = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    BedId = table.Column<int>(type: "integer", nullable: false),
                    DateOfAdmission = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InpatientTreatments", x => x.InpatientTreatmentId);
                    table.ForeignKey(
                        name: "FK_InpatientTreatments_Beds_BedId",
                        column: x => x.BedId,
                        principalTable: "Beds",
                        principalColumn: "BedId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InpatientTreatments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InpatientTreatments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Manufacturer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "InpatientTreatmentTherapies",
                columns: table => new
                {
                    InpatientTreatmentTherapyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InpatientTreatmentId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InpatientTreatmentTherapies", x => x.InpatientTreatmentTherapyId);
                    table.ForeignKey(
                        name: "FK_InpatientTreatmentTherapies_InpatientTreatments_InpatientTr~",
                        column: x => x.InpatientTreatmentId,
                        principalTable: "InpatientTreatments",
                        principalColumn: "InpatientTreatmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodTherapies",
                columns: table => new
                {
                    BloodTherapyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityInLiters = table.Column<double>(type: "double precision", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InpatientTreatmentTherapyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodTherapies", x => x.BloodTherapyId);
                    table.ForeignKey(
                        name: "FK_BloodTherapies_InpatientTreatmentTherapies_InpatientTreatme~",
                        column: x => x.InpatientTreatmentTherapyId,
                        principalTable: "InpatientTreatmentTherapies",
                        principalColumn: "InpatientTreatmentTherapyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicineTherapies",
                columns: table => new
                {
                    MedicineTherapyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MedicineId = table.Column<int>(type: "integer", nullable: false),
                    Dosage = table.Column<string>(type: "text", nullable: true),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    InpatientTreatmentTherapyId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineTherapies", x => x.MedicineTherapyId);
                    table.ForeignKey(
                        name: "FK_MedicineTherapies_InpatientTreatmentTherapies_InpatientTrea~",
                        column: x => x.InpatientTreatmentTherapyId,
                        principalTable: "InpatientTreatmentTherapies",
                        principalColumn: "InpatientTreatmentTherapyId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicineTherapies_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "Start",
                value: new DateTime(2022, 11, 20, 1, 23, 13, 702, DateTimeKind.Local).AddTicks(4438));

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "BedId",
                keyValue: 2,
                column: "IsAvailable",
                value: true);

            migrationBuilder.UpdateData(
                table: "Beds",
                keyColumn: "BedId",
                keyValue: 3,
                column: "IsAvailable",
                value: true);

            migrationBuilder.InsertData(
                table: "InpatientTreatments",
                columns: new[] { "InpatientTreatmentId", "BedId", "DateOfAdmission", "PatientId", "ReasonForAdmission", "RoomId" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Headache", 21 });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "MedicineId", "Manufacturer", "Name" },
                values: new object[,]
                {
                    { 1, "Galenika", "Aspirin" },
                    { 2, "Hemofarm", "Bromazepam" },
                    { 3, "Hemofarm", "Caffetin" }
                });

            migrationBuilder.InsertData(
                table: "InpatientTreatmentTherapies",
                columns: new[] { "InpatientTreatmentTherapyId", "InpatientTreatmentId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_BloodTherapies_InpatientTreatmentTherapyId",
                table: "BloodTherapies",
                column: "InpatientTreatmentTherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientTreatments_BedId",
                table: "InpatientTreatments",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientTreatments_PatientId",
                table: "InpatientTreatments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientTreatments_RoomId",
                table: "InpatientTreatments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_InpatientTreatmentTherapies_InpatientTreatmentId",
                table: "InpatientTreatmentTherapies",
                column: "InpatientTreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTherapies_InpatientTreatmentTherapyId",
                table: "MedicineTherapies",
                column: "InpatientTreatmentTherapyId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineTherapies_MedicineId",
                table: "MedicineTherapies",
                column: "MedicineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodTherapies");

            migrationBuilder.DropTable(
                name: "MedicineTherapies");

            migrationBuilder.DropTable(
                name: "InpatientTreatmentTherapies");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "InpatientTreatments");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Beds");

            migrationBuilder.UpdateData(
                table: "Appointments",
                keyColumn: "AppointmentId",
                keyValue: 1,
                column: "Start",
                value: new DateTime(2022, 11, 19, 22, 5, 41, 151, DateTimeKind.Local).AddTicks(5251));
        }
    }
}
