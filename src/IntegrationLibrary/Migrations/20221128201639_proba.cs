using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class proba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankNews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankNews", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityInLiters = table.Column<double>(type: "double precision", nullable: false),
                    ReasonForRequest = table.Column<string>(type: "text", nullable: true),
                    FinalDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DoctorId = table.Column<int>(type: "integer", nullable: false),
                    ReasonForAdjustment = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Requirements = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReportConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReportFrequency = table.Column<string>(type: "text", nullable: true),
                    ReportPeriod = table.Column<int>(type: "integer", nullable: false),
                    BloodBankId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportConfigurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    AppName = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Server = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TenderApplication",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Notes = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<int>(type: "integer", nullable: false),
                    EquipmentTenderId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderApplication", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderApplication_EquipmentTenders_EquipmentTenderId",
                        column: x => x.EquipmentTenderId,
                        principalTable: "EquipmentTenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BankNews",
                columns: new[] { "Id", "Content", "State", "Title" },
                values: new object[,]
                {
                    { 9, "sadrzaj vijesti 9", 1, "vijest 9" },
                    { 8, "sadrzaj vijesti 8", 0, "vijest 8" },
                    { 6, "sadrzaj vijesti 6", 0, "vijest 6" },
                    { 5, "sadrzaj vijesti 5", 2, "vijest 5" },
                    { 4, "sadrzaj vijesti 4", 0, "vijest 4" },
                    { 7, "sadrzaj vijesti 7", 0, "vijest 7" },
                    { 2, "sadrzaj vijesti 2", 2, "vijest 2" },
                    { 1, "sadrzaj vijesti 1", 0, "vijest 1" },
                    { 3, "sadrzaj vijesti 3", 1, "vijest 3" }
                });

            migrationBuilder.InsertData(
                table: "BloodRequests",
                columns: new[] { "Id", "BloodType", "DoctorId", "FinalDate", "QuantityInLiters", "ReasonForAdjustment", "ReasonForRequest", "State" },
                values: new object[,]
                {
                    { 7, 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0, null, "treba 7", 2 },
                    { 1, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, null, "treba 1", 0 },
                    { 2, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0, null, "treba 2", 1 },
                    { 3, 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0, null, "treba 3", 2 },
                    { 4, 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, "Ne moze", "treba 4", 3 },
                    { 5, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, null, "treba 5", 0 },
                    { 6, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0, null, "treba 6", 1 },
                    { 8, 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, "Ne moze 2", "treba 8", 3 }
                });

            migrationBuilder.InsertData(
                table: "EquipmentTenders",
                columns: new[] { "Id", "Requirements", "Title" },
                values: new object[,]
                {
                    { 1, null, "Tender 1" },
                    { 2, null, "Tender 2" },
                    { 3, null, "Tender 3" }
                });

            migrationBuilder.InsertData(
                table: "ReportConfigurations",
                columns: new[] { "Id", "BloodBankId", "ReportFrequency", "ReportPeriod" },
                values: new object[] { 1, 2, "* * * * *", 3 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AppName", "Email", "Password", "Server" },
                values: new object[,]
                {
                    { 2, "app2", "email2@gmail.com", "UzX1V1A0FfLerVn5", "localhost:6555" },
                    { 3, "app3", "email3@gmail.com", "dd13xfCA5Jz9Y9ho", "localhost:7555" },
                    { 1, "app1", "email1@gmail.com", "OLIfDWaYYunpFtiQ", "localhost:5555" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportConfigurations_BloodBankId",
                table: "ReportConfigurations",
                column: "BloodBankId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenderApplication_EquipmentTenderId",
                table: "TenderApplication",
                column: "EquipmentTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankNews");

            migrationBuilder.DropTable(
                name: "BloodRequests");

            migrationBuilder.DropTable(
                name: "ReportConfigurations");

            migrationBuilder.DropTable(
                name: "TenderApplication");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EquipmentTenders");
        }
    }
}
