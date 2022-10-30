using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HospitalLibrary.Migrations
{
    public partial class RoomsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Privatisation = table.Column<bool>(type: "boolean", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    User = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    IsDisplayedPublic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.Id);
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

            migrationBuilder.InsertData(
                table: "Feedbacks",
                columns: new[] { "Id", "Date", "IsDisplayedPublic", "Privatisation", "Text", "User" },
                values: new object[,]
                {
                    { "1", "25.10.2022", false, false, "Awesome clinic!", "Милош" },
                    { "2", "25.10.2022", false, false, "It's okay... I guess.", "Немања" },
                    { "3", "25.10.2022", false, false, "Awful.", "Огњен" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "BuildingId", "Description", "FloorId", "Height", "Number", "Type", "Width", "X", "Y" },
                values: new object[,]
                {
                    { 16, "B", "neki opis6", 3, 100, "301B", 0, 100, 0, 0 },
                    { 15, "B", "neki opis5", 2, 100, "203B", 0, 100, 0, 2 },
                    { 14, "B", "neki opis4", 2, 100, "202B", 0, 100, 0, 1 },
                    { 13, "B", "neki opis3", 2, 100, "201B", 0, 100, 0, 0 },
                    { 12, "B", "neki opis2", 1, 100, "103B", 0, 100, 0, 2 },
                    { 11, "B", "neki opis1", 1, 100, "102B", 0, 100, 0, 1 },
                    { 10, "B", "neki opis", 1, 100, "101B", 0, 100, 0, 0 },
                    { 9, "A", "neki opis8", 3, 100, "303A", 0, 100, 0, 2 },
                    { 8, "A", "neki opis7", 3, 100, "302A", 0, 100, 0, 1 },
                    { 7, "A", "neki opis6", 3, 100, "301A", 0, 100, 0, 0 },
                    { 6, "A", "neki opis5", 2, 100, "203A", 0, 100, 0, 2 },
                    { 5, "A", "neki opis4", 2, 100, "202A", 0, 100, 0, 1 },
                    { 4, "A", "neki opis3", 2, 100, "201A", 0, 100, 0, 0 },
                    { 3, "A", "neki opis2", 1, 100, "103A", 0, 100, 0, 2 },
                    { 2, "A", "neki opis1", 1, 100, "102A", 0, 100, 0, 1 },
                    { 1, "A", "neki opis", 1, 100, "101A", 0, 100, 0, 0 },
                    { 17, "B", "neki opis7", 3, 100, "302B", 0, 100, 0, 1 },
                    { 18, "B", "neki opis8", 3, 100, "303B", 0, 100, 0, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedbacks");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
