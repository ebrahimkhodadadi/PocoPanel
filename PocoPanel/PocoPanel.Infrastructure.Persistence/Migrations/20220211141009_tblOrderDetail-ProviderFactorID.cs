using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblOrderDetailProviderFactorID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProviderOrderId",
                table: "tblOrderDetail",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetail_ProviderOrderId",
                table: "tblOrderDetail",
                column: "ProviderOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrderDetail_tblProvider_ProviderOrderId",
                table: "tblOrderDetail",
                column: "ProviderOrderId",
                principalTable: "tblProvider",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderDetail_tblProvider_ProviderOrderId",
                table: "tblOrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_tblOrderDetail_ProviderOrderId",
                table: "tblOrderDetail");

            migrationBuilder.DropColumn(
                name: "ProviderOrderId",
                table: "tblOrderDetail");
        }
    }
}
