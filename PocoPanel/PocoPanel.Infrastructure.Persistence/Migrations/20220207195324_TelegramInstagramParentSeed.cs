using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class TelegramInstagramParentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblProductKind",
                columns: new[] { "Id", "Name", "ParentID" },
                values: new object[,]
                {
                    { 3, "Member", 1 },
                    { 4, "Like", 1 },
                    { 5, "Comment", 1 },
                    { 6, "View", 1 },
                    { 7, "Follower", 2 },
                    { 8, "Like", 2 },
                    { 9, "Comment", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
