using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class bloodreqstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "BloodRequests",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "BloodRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "BloodType",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "BloodRequests");

            migrationBuilder.UpdateData(
                table: "BloodRequests",
                keyColumn: "Id",
                keyValue: 2,
                column: "BloodType",
                value: 3);
        }
    }
}
