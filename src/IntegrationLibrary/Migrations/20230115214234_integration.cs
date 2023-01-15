using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class integration : Migration
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
                    State = table.Column<int>(type: "integer", nullable: false),
                    Urgent = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BloodSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodBankId = table.Column<int>(type: "integer", nullable: false),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    QuantityInLiters = table.Column<double>(type: "double precision", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodSubscription", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentTenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    ExpiresOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentTenders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagerNotification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerNotification", x => x.Id);
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
                name: "UrgentOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    BloodBankName = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrgentOrders", x => x.Id);
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
                name: "TenderRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<double>(type: "double precision", nullable: false),
                    EquipmentTenderId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderRequirements_EquipmentTenders_EquipmentTenderId",
                        column: x => x.EquipmentTenderId,
                        principalTable: "EquipmentTenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenderApplications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Note = table.Column<string>(type: "text", nullable: true),
                    EquipmentTenderId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    HasWon = table.Column<bool>(type: "boolean", nullable: false),
                    Finished = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderApplications_EquipmentTenders_EquipmentTenderId",
                        column: x => x.EquipmentTenderId,
                        principalTable: "EquipmentTenders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenderApplications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TenderOffers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Money = table.Column<double>(type: "double precision", nullable: true),
                    TenderRequirementId = table.Column<int>(type: "integer", nullable: false),
                    TenderApplicationId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenderOffers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TenderOffers_TenderApplications_TenderApplicationId",
                        column: x => x.TenderApplicationId,
                        principalTable: "TenderApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TenderOffers_TenderRequirements_TenderRequirementId",
                        column: x => x.TenderRequirementId,
                        principalTable: "TenderRequirements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankNews",
                columns: new[] { "Id", "Content", "State", "Title" },
                values: new object[,]
                {
                    { 1, "sadrzaj vijesti 1", 0, "vijest 1" },
                    { 2, "sadrzaj vijesti 2", 2, "vijest 2" },
                    { 3, "sadrzaj vijesti 3", 1, "vijest 3" },
                    { 4, "sadrzaj vijesti 4", 0, "vijest 4" },
                    { 5, "sadrzaj vijesti 5", 2, "vijest 5" },
                    { 6, "sadrzaj vijesti 6", 0, "vijest 6" },
                    { 7, "sadrzaj vijesti 7", 0, "vijest 7" },
                    { 8, "sadrzaj vijesti 8", 0, "vijest 8" },
                    { 9, "sadrzaj vijesti 9", 1, "vijest 9" }
                });

            migrationBuilder.InsertData(
                table: "BloodRequests",
                columns: new[] { "Id", "BloodType", "DoctorId", "FinalDate", "QuantityInLiters", "ReasonForAdjustment", "ReasonForRequest", "State", "Urgent" },
                values: new object[,]
                {
                    { 3, 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0, null, "treba 3", 2, false },
                    { 8, 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, "Ne moze 2", "treba 8", 3, false },
                    { 7, 7, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9.0, null, "treba 7", 2, false },
                    { 6, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0, null, "treba 6", 1, false },
                    { 5, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, null, "treba 5", 0, false },
                    { 4, 7, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0, "Ne moze", "treba 4", 3, false },
                    { 1, 0, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0, null, "treba 1", 0, false },
                    { 2, 2, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.0, null, "treba 2", 1, false }
                });

            migrationBuilder.InsertData(
                table: "BloodSubscription",
                columns: new[] { "Id", "BloodBankId", "BloodType", "QuantityInLiters", "StartDate" },
                values: new object[] { 1, 1, 0, 1.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "EquipmentTenders",
                columns: new[] { "Id", "Description", "ExpiresOn", "State", "Title" },
                values: new object[,]
                {
                    { 1, "Congue nisi vitae suscipit tellus mauris. Et leo duis ut diam quam nulla. Porttitor eget dolor morbi non arcu risus quis. Tempor nec feugiat nisl pretium. Pharetra et ultrices neque ornare aenean euismod elementum nisi. Dui sapien eget mi proin sed libero enim sed faucibus. Vitae turpis massa sed elementum tempus. Urna molestie at elementum eu facilisis sed. Nisl nisi scelerisque eu ultrices vitae auctor eu augue ut. Facilisi cras fermentum odio eu feugiat. Rhoncus aenean vel elit scelerisque. Eget nunc scelerisque viverra mauris in aliquam. Blandit libero volutpat sed cras ornare. Tellus elementum sagittis vitae et leo duis. Est lorem ipsum dolor sit amet consectetur. Ullamcorper malesuada proin libero nunc consequat interdum varius.", new DateTime(2023, 2, 14, 22, 42, 33, 965, DateTimeKind.Local).AddTicks(8047), 0, "Tender 1" },
                    { 2, "Egestas congue quisque egestas diam in. Pretium aenean pharetra magna ac placerat. Ultrices neque ornare aenean euismod. Eget felis eget nunc lobortis mattis aliquam faucibus purus. Ac feugiat sed lectus vestibulum. Mi proin sed libero enim sed faucibus turpis in eu. Et molestie ac feugiat sed lectus vestibulum mattis ullamcorper. Enim ut tellus elementum sagittis vitae et.", new DateTime(2023, 2, 14, 22, 42, 33, 981, DateTimeKind.Local).AddTicks(1449), 0, "Tender 2" },
                    { 3, "Nisl nisi scelerisque eu ultrices vitae auctor eu augue ut. Facilisi cras fermentum odio eu feugiat. Rhoncus aenean vel elit scelerisque. Eget nunc scelerisque viverra mauris in aliquam. Blandit libero volutpat sed cras ornare. Tellus elementum sagittis vitae et leo duis. Est lorem ipsum dolor sit amet consectetur. Ullamcorper malesuada proin libero nunc consequat interdum varius.", new DateTime(2023, 2, 14, 22, 42, 33, 981, DateTimeKind.Local).AddTicks(1859), 0, "Tender 3" }
                });

            migrationBuilder.InsertData(
                table: "ManagerNotification",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { 1, "This is test notification", "Test notification" });

            migrationBuilder.InsertData(
                table: "ReportConfigurations",
                columns: new[] { "Id", "BloodBankId", "ReportFrequency", "ReportPeriod" },
                values: new object[] { 1, 2, "* * * * *", 3 });

            migrationBuilder.InsertData(
                table: "UrgentOrders",
                columns: new[] { "Id", "BloodBankName", "BloodType", "Date", "Quantity" },
                values: new object[,]
                {
                    { 1, "app2", 0, new DateTime(2022, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 100.0 },
                    { 2, "app1", 3, new DateTime(2022, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 80.0 },
                    { 4, "app3", 4, new DateTime(2022, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 310.0 },
                    { 3, "app2", 6, new DateTime(2022, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 160.0 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AppName", "Email", "Password", "Server" },
                values: new object[,]
                {
                    { 3, "app3", "darkoo59bet@gmail.com", "123", "localhost:7555" },
                    { 2, "app2", "darko.selakovic11@gmail.com", "123", "localhost:6555" },
                    { 1, "app1", "darkoo59@gmail.com", "123", "localhost:5555" }
                });

            migrationBuilder.InsertData(
                table: "TenderRequirements",
                columns: new[] { "Id", "Amount", "BloodType", "EquipmentTenderId" },
                values: new object[,]
                {
                    { 1, 150.0, 0, 1 },
                    { 2, 100.0, 2, 1 },
                    { 3, 250.0, 1, 2 },
                    { 4, 350.0, 6, 2 },
                    { 5, 120.0, 4, 3 },
                    { 6, 230.0, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportConfigurations_BloodBankId",
                table: "ReportConfigurations",
                column: "BloodBankId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TenderApplications_EquipmentTenderId",
                table: "TenderApplications",
                column: "EquipmentTenderId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderApplications_UserId",
                table: "TenderApplications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderOffers_TenderApplicationId",
                table: "TenderOffers",
                column: "TenderApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderOffers_TenderRequirementId",
                table: "TenderOffers",
                column: "TenderRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_TenderRequirements_EquipmentTenderId",
                table: "TenderRequirements",
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
                name: "BloodSubscription");

            migrationBuilder.DropTable(
                name: "ManagerNotification");

            migrationBuilder.DropTable(
                name: "ReportConfigurations");

            migrationBuilder.DropTable(
                name: "TenderOffers");

            migrationBuilder.DropTable(
                name: "UrgentOrders");

            migrationBuilder.DropTable(
                name: "TenderApplications");

            migrationBuilder.DropTable(
                name: "TenderRequirements");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "EquipmentTenders");
        }
    }
}
