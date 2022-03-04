using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblProductKindaddnewSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tblProductKind",
                columns: new[] { "Id", "Name", "ParentID" },
                values: new object[,]
                {
                    { 14, "Other", null },
                    { 16, "Aparat", null },
                    { 20, "ClubHouse", null },
                    { 21, "Spotify", null },
                    { 24, "Unknown", null },
                    { 10, "Story", 2 },
                    { 11, "Live", 2 },
                    { 12, "Save", 2 },
                    { 13, "Other", 2 }
                });

            migrationBuilder.InsertData(
                table: "tblProductKind",
                columns: new[] { "Id", "Name", "ParentID" },
                values: new object[,]
                {
                    { 15, "Design", 14 },
                    { 17, "View", 16 },
                    { 18, "Like", 16 },
                    { 19, "Follower", 16 },
                    { 22, "Follower", 20 },
                    { 23, "Listen", 21 },
                    { 25, "Unknown", 24 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "tblProductKind",
                keyColumn: "Id",
                keyValue: 24);
        }
    }
}
