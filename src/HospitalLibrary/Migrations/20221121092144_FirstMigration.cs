using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodRequests",
                columns: table => new
                {
                    BloodRequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityInLiters = table.Column<double>(type: "double precision", nullable: false),
                    ReasonForRequest = table.Column<string>(type: "text", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequests", x => x.BloodRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Bloods",
                columns: table => new
                {
                    BloodId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityInLiters = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloods", x => x.BloodId);
                });

            migrationBuilder.CreateTable(
                name: "BloodUsageEvidencies",
                columns: table => new
                {
                    BloodUsageEvidencyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityUsedInMililiters = table.Column<double>(type: "double precision", nullable: false),
                    ReasonForUsage = table.Column<string>(type: "text", nullable: true),
                    DateOfUsage = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodUsageEvidencies", x => x.BloodUsageEvidencyId);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    EquipmentType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Privatisation = table.Column<bool>(type: "boolean", nullable: false),
                    Textt = table.Column<string>(type: "text", nullable: true),
                    User = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    IsDisplayedPublic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PatientId = table.Column<int>(type: "integer", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<string>(type: "text", nullable: false),
                    FloorId = table.Column<int>(type: "integer", nullable: false),
                    BuildingId = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    X = table.Column<int>(type: "integer", nullable: false),
                    Y = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<int>(type: "integer", nullable: false),
                    Height = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VacationRequests",
                columns: table => new
                {
                    VacationRequestId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Urgency = table.Column<string>(type: "text", nullable: true),
                    Reason = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationRequests", x => x.VacationRequestId);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Label = table.Column<string>(type: "text", nullable: true),
                    RoomId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedId);
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    SpecializationId = table.Column<int>(type: "integer", nullable: false),
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.DoctorId);
                    table.ForeignKey(
                        name: "FK_Doctors_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Doctors_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: true),
                    PatientId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Appointments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vacations",
                columns: table => new
                {
                    VacationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacations", x => x.VacationId);
                    table.ForeignKey(
                        name: "FK_Vacations_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkTimes",
                columns: table => new
                {
                    WorkTimeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimes", x => x.WorkTimeId);
                    table.ForeignKey(
                        name: "FK_WorkTimes_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "DoctorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Beds",
                columns: new[] { "BedId", "Label", "RoomId" },
                values: new object[,]
                {
                    { 1, "201B1", null },
                    { 2, "201B2", null },
                    { 3, "201B3", null }
                });

            migrationBuilder.InsertData(
                table: "BloodRequests",
                columns: new[] { "BloodRequestId", "BloodType", "DoctorId", "FinalDate", "QuantityInLiters", "ReasonForRequest" },
                values: new object[,]
                {
                    { 3, 7, 1, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.5, "Heart surgery" },
                    { 2, 0, 1, new DateTime(2022, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3.0, "Heart surgery" },
                    { 1, 5, 1, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 2.5, "Heart surgery" }
                });

            migrationBuilder.InsertData(
                table: "BloodUsageEvidencies",
                columns: new[] { "BloodUsageEvidencyId", "BloodType", "DateOfUsage", "DoctorId", "QuantityUsedInMililiters", "ReasonForUsage" },
                values: new object[,]
                {
                    { 6, 5, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1100.0, "Hearth surgery" },
                    { 5, 3, new DateTime(2022, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 180.0, "Hearth surgery" },
                    { 4, 0, new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 700.0, "Hearth surgery" },
                    { 2, 3, new DateTime(2022, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 300.0, "Hearth surgery" },
                    { 1, 0, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 200.0, "Hearth surgery" },
                    { 3, 6, new DateTime(2022, 11, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 450.0, "Hearth surgery" }
                });

            migrationBuilder.InsertData(
                table: "Bloods",
                columns: new[] { "BloodId", "BloodType", "QuantityInLiters" },
                values: new object[,]
                {
                    { 7, 3, 4.0 },
                    { 6, 1, 4.0 },
                    { 5, 7, 4.0 },
                    { 4, 4, 4.0 },
                    { 3, 2, 4.0 },
                    { 2, 0, 4.0 },
                    { 1, 6, 4.0 },
                    { 8, 5, 4.0 }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "EquipmentType", "Name", "Quantity", "RoomId" },
                values: new object[,]
                {
                    { 5, 1, "Wheelchairs", 2, 2 },
                    { 6, 1, "Scalpel", 4, 3 },
                    { 7, 1, "Defibrillator", 2, 3 },
                    { 8, 1, "Ultrasound ", 1, 4 },
                    { 9, 1, "CT scanner", 2, 4 },
                    { 3, 1, "Gloves", 50, 2 },
                    { 1, 1, "Syringe", 50, 1 },
                    { 10, 1, "Tounge depressor", 12, 5 },
                    { 4, 1, "Scissors", 10, 2 },
                    { 2, 1, "Tounge depressor", 32, 1 }
                });

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Date", "IsDisplayedPublic", "Privatisation", "Textt", "User" },
                values: new object[,]
                {
                    { 2, "25.10.2022", false, false, "It's okay... I guess.", "Немања" },
                    { 1, "25.10.2022", false, false, "Awesome clinic!", "Милош" },
                    { 3, "25.10.2022", false, false, "Awful.", "Огњен" }
                });

            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Name", "Surname" },
                values: new object[,]
                {
                    { 2, "Marko", "Markovic" },
                    { 1, "Pera", "Peric" },
                    { 3, "Aleksa", "Aleksic" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BuildingId", "Description", "FloorId", "Height", "Number", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 27, "B", "neki opis", 1, 250, "204B", 0, 283, 10, 530 },
                    { 39, "B", "neki opis2", 2, 250, "308B", 0, 282, 706, 530 },
                    { 38, "B", "neki opis1", 2, 250, "307B", 0, 282, 706, 270 },
                    { 37, "B", "neki opis2", 2, 250, "306B", 0, 283, 358, 530 },
                    { 36, "B", "neki opis1", 2, 250, "305B", 0, 283, 358, 270 },
                    { 35, "B", "neki opis", 2, 250, "304B", 0, 283, 10, 530 },
                    { 34, "B", "neki opis2", 2, 250, "303B", 0, 283, 10, 270 },
                    { 33, "B", "neki opis1", 2, 250, "302B", 0, 480, 505, 10 },
                    { 32, "B", "neki opis", 2, 250, "301B", 0, 485, 10, 10 },
                    { 31, "B", "neki opis2", 1, 250, "208B", 0, 282, 706, 530 },
                    { 30, "B", "neki opis1", 1, 250, "207B", 0, 282, 706, 270 },
                    { 29, "B", "neki opis2", 1, 250, "206B", 0, 283, 358, 530 },
                    { 28, "B", "neki opis1", 1, 250, "205B", 0, 283, 358, 270 },
                    { 26, "B", "neki opis2", 1, 250, "203B", 0, 283, 10, 270 },
                    { 15, "A", "neki opis8", 2, 250, "305A", 0, 170, 220, 530 },
                    { 24, "B", "neki opis", 1, 250, "201B", 0, 485, 10, 10 },
                    { 8, "A", "neki opis5", 1, 250, "203A", 0, 170, 10, 530 },
                    { 9, "A", "neki opis4", 1, 250, "204A", 0, 170, 220, 270 },
                    { 5, "A", "neki opis1", 0, 250, "105A", 0, 170, 220, 530 },
                    { 4, "A", "neki opis", 0, 250, "104A", 0, 170, 220, 270 },
                    { 3, "A", "neki opis2", 0, 250, "103A", 0, 170, 10, 530 },
                    { 2, "A", "neki opis1", 0, 250, "102A", 0, 170, 10, 270 },
                    { 25, "B", "neki opis1", 1, 250, "202B", 0, 480, 505, 10 },
                    { 1, "A", "neki opis", 0, 250, "101A", 0, 380, 10, 10 },
                    { 10, "A", "neki opis5", 1, 250, "205A", 0, 170, 220, 530 },
                    { 11, "A", "neki opis6", 2, 250, "301A", 0, 380, 10, 10 },
                    { 12, "A", "neki opis7", 2, 250, "302A", 0, 170, 10, 270 },
                    { 13, "A", "neki opis8", 2, 250, "303A", 0, 170, 10, 530 },
                    { 14, "A", "neki opis7", 2, 250, "304A", 0, 170, 220, 270 },
                    { 16, "B", "neki opis", 0, 250, "101B", 0, 485, 10, 10 },
                    { 17, "B", "neki opis1", 0, 250, "102B", 0, 480, 505, 10 },
                    { 18, "B", "neki opis2", 0, 250, "103B", 0, 283, 10, 270 },
                    { 19, "B", "neki opis", 0, 250, "104B", 0, 283, 10, 530 },
                    { 20, "B", "neki opis1", 0, 250, "105B", 0, 283, 358, 270 },
                    { 21, "B", "neki opis2", 0, 250, "106B", 0, 283, 358, 530 },
                    { 22, "B", "neki opis1", 0, 250, "107B", 0, 282, 706, 270 },
                    { 23, "B", "neki opis2", 0, 250, "108B", 0, 282, 706, 530 },
                    { 7, "A", "neki opis4", 1, 250, "202A", 0, 170, 10, 270 },
                    { 6, "A", "neki opis3", 1, 250, "201A", 0, 380, 10, 10 }
                });

            migrationBuilder.InsertData(
                table: "Specializations",
                columns: new[] { "SpecializationId", "Name" },
                values: new object[,]
                {
                    { 2, "Dermatology" },
                    { 3, "Family medicine" },
                    { 1, "Anesthesiology" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Password", "Role", "Username" },
                values: new object[] { 1, "password", 0, "username" });

            migrationBuilder.InsertData(
                table: "VacationRequests",
                columns: new[] { "VacationRequestId", "DoctorId", "EndDate", "Reason", "StartDate", "Status", "Urgency" },
                values: new object[,]
                {
                    { 2, 4, new DateTime(2022, 12, 11, 10, 21, 43, 744, DateTimeKind.Local).AddTicks(5334), "Tired", new DateTime(2022, 12, 6, 10, 21, 43, 744, DateTimeKind.Local).AddTicks(5322), 2, "Urgent" },
                    { 1, 4, new DateTime(2022, 12, 6, 10, 21, 43, 744, DateTimeKind.Local).AddTicks(4031), "Tired", new DateTime(2022, 12, 1, 10, 21, 43, 744, DateTimeKind.Local).AddTicks(3676), 1, "NoUrgent" },
                    { 3, 4, new DateTime(2022, 12, 16, 10, 21, 43, 744, DateTimeKind.Local).AddTicks(5340), "Tired", new DateTime(2022, 12, 11, 10, 21, 43, 744, DateTimeKind.Local).AddTicks(5337), 0, "NoUrgent" }
                });

            migrationBuilder.InsertData(
                table: "Doctors",
                columns: new[] { "DoctorId", "Name", "RoomId", "SpecializationId", "Surname" },
                values: new object[,]
                {
                    { 1, "Ognjen", 1, 3, "Nikolic" },
                    { 2, "Mika", 2, 3, "Mikic" },
                    { 3, "Aleksa", 1, 3, "Santic" }
                });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentId", "DoctorId", "PatientId", "Start" },
                values: new object[] { 1, 1, 1, new DateTime(2022, 11, 21, 10, 21, 43, 741, DateTimeKind.Local).AddTicks(3040) });

            migrationBuilder.InsertData(
                table: "Vacations",
                columns: new[] { "VacationId", "DoctorId", "EndDate", "StartDate" },
                values: new object[] { 1, 1, new DateTime(2022, 12, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "WorkTimes",
                columns: new[] { "WorkTimeId", "DoctorId", "EndDate", "EndTime", "StartDate", "StartTime" },
                values: new object[] { 1, 1, new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 16, 0, 0, 0), new DateTime(2022, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0) });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DoctorId",
                table: "Appointments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_PatientId",
                table: "Appointments",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_RoomId",
                table: "Beds",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoomId",
                table: "Doctors",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_SpecializationId",
                table: "Doctors",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vacations_DoctorId",
                table: "Vacations",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimes_DoctorId",
                table: "WorkTimes",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropTable(
                name: "BloodRequests");

            migrationBuilder.DropTable(
                name: "Bloods");

            migrationBuilder.DropTable(
                name: "BloodUsageEvidencies");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VacationRequests");

            migrationBuilder.DropTable(
                name: "Vacations");

            migrationBuilder.DropTable(
                name: "WorkTimes");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Specializations");
        }
    }
}
