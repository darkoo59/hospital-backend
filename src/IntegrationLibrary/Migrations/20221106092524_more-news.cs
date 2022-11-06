using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class morenews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BankNews",
                columns: new[] { "Id", "Content", "State", "Title" },
                values: new object[,]
                {
                    { 4, "sadrzaj vijesti 4", 0, "vijest 4" },
                    { 5, "sadrzaj vijesti 5", 2, "vijest 5" },
                    { 6, "sadrzaj vijesti 6", 0, "vijest 6" },
                    { 7, "sadrzaj vijesti 7", 0, "vijest 7" },
                    { 8, "sadrzaj vijesti 8", 0, "vijest 8" },
                    { 9, "sadrzaj vijesti 9", 1, "vijest 9" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BankNews",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BankNews",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BankNews",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "BankNews",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BankNews",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "BankNews",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
