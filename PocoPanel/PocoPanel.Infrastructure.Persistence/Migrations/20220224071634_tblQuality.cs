using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblQuality : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tblQualityId",
                table: "tblProduct",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "tblQuality",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblQuality", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblQuality",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Top" });

            migrationBuilder.InsertData(
                table: "tblQuality",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "middle" });

            migrationBuilder.InsertData(
                table: "tblQuality",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "low" });

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_tblQualityId",
                table: "tblProduct",
                column: "tblQualityId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProduct_tblQuality_tblQualityId",
                table: "tblProduct",
                column: "tblQualityId",
                principalTable: "tblQuality",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProduct_tblQuality_tblQualityId",
                table: "tblProduct");

            migrationBuilder.DropTable(
                name: "tblQuality");

            migrationBuilder.DropIndex(
                name: "IX_tblProduct_tblQualityId",
                table: "tblProduct");

            migrationBuilder.DropColumn(
                name: "tblQualityId",
                table: "tblProduct");
        }
    }
}
