using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblOrderDetail");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "tblOrder");

            migrationBuilder.AddColumn<int>(
                name: "tblStatusId",
                table: "tblOrderDetail",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "tblStatusId",
                table: "tblOrder",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStatus", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblStatus",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Waiting" },
                    { 2, "Accepted" },
                    { 3, "Rejected" },
                    { 4, "Completed" },
                    { 5, "Unknown" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetail_tblStatusId",
                table: "tblOrderDetail",
                column: "tblStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_tblStatusId",
                table: "tblOrder",
                column: "tblStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrder_tblStatus_tblStatusId",
                table: "tblOrder",
                column: "tblStatusId",
                principalTable: "tblStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrderDetail_tblStatus_tblStatusId",
                table: "tblOrderDetail",
                column: "tblStatusId",
                principalTable: "tblStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrder_tblStatus_tblStatusId",
                table: "tblOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderDetail_tblStatus_tblStatusId",
                table: "tblOrderDetail");

            migrationBuilder.DropTable(
                name: "tblStatus");

            migrationBuilder.DropIndex(
                name: "IX_tblOrderDetail_tblStatusId",
                table: "tblOrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_tblOrder_tblStatusId",
                table: "tblOrder");

            migrationBuilder.DropColumn(
                name: "tblStatusId",
                table: "tblOrderDetail");

            migrationBuilder.DropColumn(
                name: "tblStatusId",
                table: "tblOrder");

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "tblOrderDetail",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "tblOrder",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}
