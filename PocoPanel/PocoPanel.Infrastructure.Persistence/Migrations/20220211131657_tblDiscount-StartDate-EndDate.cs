using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblDiscountStartDateEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderDetail_tblProduct_tblProductId",
                table: "tblOrderDetail");

            migrationBuilder.AlterColumn<int>(
                name: "tblProductId",
                table: "tblOrderDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enable",
                table: "tblDiscount",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "tblDiscount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "tblDiscount",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrderDetail_tblProduct_tblProductId",
                table: "tblOrderDetail",
                column: "tblProductId",
                principalTable: "tblProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblOrderDetail_tblProduct_tblProductId",
                table: "tblOrderDetail");

            migrationBuilder.DropColumn(
                name: "Enable",
                table: "tblDiscount");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "tblDiscount");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "tblDiscount");

            migrationBuilder.AlterColumn<int>(
                name: "tblProductId",
                table: "tblOrderDetail",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrderDetail_tblProduct_tblProductId",
                table: "tblOrderDetail",
                column: "tblProductId",
                principalTable: "tblProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
