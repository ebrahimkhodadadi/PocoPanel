using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblProductPriceKindPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblPriceKind_tblPriceKindId",
                table: "tblProductPriceKind");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblProduct_tblProductId",
                table: "tblProductPriceKind");

            migrationBuilder.AlterColumn<int>(
                name: "tblProductId",
                table: "tblProductPriceKind",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "tblPriceKindId",
                table: "tblProductPriceKind",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "tblProductPriceKind",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPriceKind_tblPriceKind_tblPriceKindId",
                table: "tblProductPriceKind",
                column: "tblPriceKindId",
                principalTable: "tblPriceKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPriceKind_tblProduct_tblProductId",
                table: "tblProductPriceKind",
                column: "tblProductId",
                principalTable: "tblProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblPriceKind_tblPriceKindId",
                table: "tblProductPriceKind");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblProduct_tblProductId",
                table: "tblProductPriceKind");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "tblProductPriceKind");

            migrationBuilder.AlterColumn<int>(
                name: "tblProductId",
                table: "tblProductPriceKind",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "tblPriceKindId",
                table: "tblProductPriceKind",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPriceKind_tblPriceKind_tblPriceKindId",
                table: "tblProductPriceKind",
                column: "tblPriceKindId",
                principalTable: "tblPriceKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPriceKind_tblProduct_tblProductId",
                table: "tblProductPriceKind",
                column: "tblProductId",
                principalTable: "tblProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
