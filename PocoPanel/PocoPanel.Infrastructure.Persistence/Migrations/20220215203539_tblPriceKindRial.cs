using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblPriceKindRial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblPriceKind",
                keyColumn: "Id",
                keyValue: 1,
                column: "tblCountryId",
                value: 106);

            migrationBuilder.UpdateData(
                table: "tblPriceKind",
                keyColumn: "Id",
                keyValue: 2,
                column: "tblCountryId",
                value: 237);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "tblPriceKind",
                keyColumn: "Id",
                keyValue: 1,
                column: "tblCountryId",
                value: 198);

            migrationBuilder.UpdateData(
                table: "tblPriceKind",
                keyColumn: "Id",
                keyValue: 2,
                column: "tblCountryId",
                value: null);
        }
    }
}
