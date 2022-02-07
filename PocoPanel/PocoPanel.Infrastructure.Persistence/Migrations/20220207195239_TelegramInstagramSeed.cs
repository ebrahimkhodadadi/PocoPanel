using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class TelegramInstagramSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblPriceKind",
                columns: new[] { "Id", "Name", "tblCountryId" },
                values: new object[,]
                {
                    { 1, "Rial", null },
                    { 2, "USD", null }
                });

            migrationBuilder.InsertData(
                table: "tblProductKind",
                columns: new[] { "Id", "Name", "ParentID" },
                values: new object[,]
                {
                    { 1, "Telegram", null },
                    { 2, "Instagram", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblPriceKind",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblPriceKind",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
