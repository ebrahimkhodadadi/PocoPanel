using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblProviderinstatell : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderDetail_tblProvider_ProviderOrderId",
                table: "tblOrderDetail");

            migrationBuilder.DropIndex(
                name: "IX_tblOrderDetail_ProviderOrderId",
                table: "tblOrderDetail");

            migrationBuilder.InsertData(
                table: "tblProvider",
                columns: new[] { "Id", "Code", "Created", "CreatedBy", "DocumentAddress", "Email", "LastModified", "LastModifiedBy", "Password", "ProviderCredit", "ProviderToken", "Url" },
                values: new object[] { 1, "instatell", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://instatell.ir/api/v1", "09904955342", null, null, "Pouyapouya800", 0m, "UjXn0H3iBwdj7q9T1P7UiMaB0d6RxsX5", "https://instatell.ir/api/v1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblProvider",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
