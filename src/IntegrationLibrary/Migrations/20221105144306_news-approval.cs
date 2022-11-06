using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    public partial class newsapproval : Migration
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

            migrationBuilder.InsertData(
                table: "BankNews",
                columns: new[] { "Id", "Content", "State", "Title" },
                values: new object[,]
                {
                    { 1, "sadrzaj vijesti 1", 0, "vijest 1" },
                    { 2, "sadrzaj vijesti 2", 2, "vijest 2" },
                    { 3, "sadrzaj vijesti 3", 1, "vijest 3" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AppName", "Email", "Password", "Server" },
                values: new object[,]
                {
                    { 1, "app1", "email1@gmail.com", "OLIfDWaYYunpFtiQ", "localhost:5555" },
                    { 2, "app2", "email2@gmail.com", "UzX1V1A0FfLerVn5", "localhost:6555" },
                    { 3, "app3", "email3@gmail.com", "dd13xfCA5Jz9Y9ho", "localhost:7555" }
                });

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
                name: "Users");
        }
    }
}
