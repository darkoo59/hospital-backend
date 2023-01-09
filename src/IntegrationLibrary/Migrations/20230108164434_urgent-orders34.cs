using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class urgentorders34 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UrgentOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BloodType = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<double>(type: "double precision", nullable: false),
                    BloodBankName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrgentOrders", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 23, 17, 44, 33, 435, DateTimeKind.Local).AddTicks(7374));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 23, 17, 44, 33, 451, DateTimeKind.Local).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2023, 1, 23, 17, 44, 33, 451, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.InsertData(
                table: "UrgentOrders",
                columns: new[] { "Id", "BloodBankName", "BloodType", "Quantity" },
                values: new object[,]
                {
                    { 1, "app2", 0, 100.0 },
                    { 2, "app1", 3, 80.0 },
                    { 3, "app2", 6, 160.0 },
                    { 4, "app3", 4, 310.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UrgentOrders");

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 27, 8, 59, 56, 137, DateTimeKind.Local).AddTicks(5481));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 27, 8, 59, 56, 150, DateTimeKind.Local).AddTicks(4343));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 27, 8, 59, 56, 150, DateTimeKind.Local).AddTicks(4832));
        }
    }
}
