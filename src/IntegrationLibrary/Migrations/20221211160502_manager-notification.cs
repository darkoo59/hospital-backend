using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class managernotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 26, 17, 5, 1, 205, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 26, 17, 5, 1, 212, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 26, 17, 5, 1, 212, DateTimeKind.Local).AddTicks(4858));

            migrationBuilder.InsertData(
                table: "ManagerNotification",
                columns: new[] { "Id", "Content", "Title" },
                values: new object[] { 1, "This is test notification", "Test notification" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManagerNotification");

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 20, 11, 35, 785, DateTimeKind.Local).AddTicks(669));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 20, 11, 35, 803, DateTimeKind.Local).AddTicks(3599));

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                column: "ExpiresOn",
                value: new DateTime(2022, 12, 20, 20, 11, 35, 803, DateTimeKind.Local).AddTicks(3925));
        }
    }
}
