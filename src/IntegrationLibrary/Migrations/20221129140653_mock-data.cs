using Microsoft.EntityFrameworkCore.Migrations;

namespace IntegrationLibrary.Migrations
{
    public partial class mockdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { "Congue nisi vitae suscipit tellus mauris. Et leo duis ut diam quam nulla. Porttitor eget dolor morbi non arcu risus quis. Tempor nec feugiat nisl pretium. Pharetra et ultrices neque ornare aenean euismod elementum nisi. Dui sapien eget mi proin sed libero enim sed faucibus. Vitae turpis massa sed elementum tempus. Urna molestie at elementum eu facilisis sed. Nisl nisi scelerisque eu ultrices vitae auctor eu augue ut. Facilisi cras fermentum odio eu feugiat. Rhoncus aenean vel elit scelerisque. Eget nunc scelerisque viverra mauris in aliquam. Blandit libero volutpat sed cras ornare. Tellus elementum sagittis vitae et leo duis. Est lorem ipsum dolor sit amet consectetur. Ullamcorper malesuada proin libero nunc consequat interdum varius.", "[{\"Name\":\"item1\",\"Amount\":150},{\"Name\":\"item2\",\"Amount\":100}]" });

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { "Egestas congue quisque egestas diam in. Pretium aenean pharetra magna ac placerat. Ultrices neque ornare aenean euismod. Eget felis eget nunc lobortis mattis aliquam faucibus purus. Ac feugiat sed lectus vestibulum. Mi proin sed libero enim sed faucibus turpis in eu. Et molestie ac feugiat sed lectus vestibulum mattis ullamcorper. Enim ut tellus elementum sagittis vitae et.", "[{\"Name\":\"item3\",\"Amount\":250},{\"Name\":\"item4\",\"Amount\":350}]" });

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { "Nisl nisi scelerisque eu ultrices vitae auctor eu augue ut. Facilisi cras fermentum odio eu feugiat. Rhoncus aenean vel elit scelerisque. Eget nunc scelerisque viverra mauris in aliquam. Blandit libero volutpat sed cras ornare. Tellus elementum sagittis vitae et leo duis. Est lorem ipsum dolor sit amet consectetur. Ullamcorper malesuada proin libero nunc consequat interdum varius.", "[{\"Name\":\"item5\",\"Amount\":120},{\"Name\":\"item6\",\"Amount\":230}]" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "EquipmentTenders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Requirements" },
                values: new object[] { null, null });
        }
    }
}
