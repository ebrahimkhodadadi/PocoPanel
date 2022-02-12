using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblProductMinMax : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "tblProduct");

            migrationBuilder.AddColumn<int>(
                name: "Max",
                table: "tblProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Min",
                table: "tblProduct",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "tblStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 6, "InProgress" });

            migrationBuilder.InsertData(
                table: "tblStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 7, "Cancled" });

            migrationBuilder.InsertData(
                table: "tblStatus",
                columns: new[] { "Id", "Name" },
                values: new object[] { 8, "ReturnedMony" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblStatus",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblStatus",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblStatus",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "Max",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "Min",
                table: "tblProduct");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "tblProduct",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
