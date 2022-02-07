using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class AlterTblProductPriceKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblPriceKind_tblPriceKindId1",
                table: "tblProductPriceKind");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblProductKind_tblPriceKindIdId",
                table: "tblProductPriceKind");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblProduct_tblProductId1",
                table: "tblProductPriceKind");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblProductKind_tblProductIdId",
                table: "tblProductPriceKind");

            migrationBuilder.DropIndex(
                name: "IX_tblProductPriceKind_tblPriceKindId1",
                table: "tblProductPriceKind");

            migrationBuilder.DropIndex(
                name: "IX_tblProductPriceKind_tblPriceKindIdId",
                table: "tblProductPriceKind");

            migrationBuilder.DropIndex(
                name: "IX_tblProductPriceKind_tblProductId1",
                table: "tblProductPriceKind");

            migrationBuilder.DropIndex(
                name: "IX_tblProductPriceKind_tblProductIdId",
                table: "tblProductPriceKind");

            migrationBuilder.DropColumn(
                name: "tblPriceKindId1",
                table: "tblProductPriceKind");

            migrationBuilder.DropColumn(
                name: "tblPriceKindIdId",
                table: "tblProductPriceKind");

            migrationBuilder.DropColumn(
                name: "tblProductId1",
                table: "tblProductPriceKind");

            migrationBuilder.DropColumn(
                name: "tblProductIdId",
                table: "tblProductPriceKind");

            migrationBuilder.AddColumn<int>(
                name: "tblPriceKindId",
                table: "tblProductPriceKind",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tblProductId",
                table: "tblProductPriceKind",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblProductPriceKind_tblPriceKindId",
                table: "tblProductPriceKind",
                column: "tblPriceKindId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductPriceKind_tblProductId",
                table: "tblProductPriceKind",
                column: "tblProductId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblPriceKind_tblPriceKindId",
                table: "tblProductPriceKind");

            migrationBuilder.DropForeignKey(
                name: "FK_tblProductPriceKind_tblProduct_tblProductId",
                table: "tblProductPriceKind");

            migrationBuilder.DropIndex(
                name: "IX_tblProductPriceKind_tblPriceKindId",
                table: "tblProductPriceKind");

            migrationBuilder.DropIndex(
                name: "IX_tblProductPriceKind_tblProductId",
                table: "tblProductPriceKind");

            migrationBuilder.DropColumn(
                name: "tblPriceKindId",
                table: "tblProductPriceKind");

            migrationBuilder.DropColumn(
                name: "tblProductId",
                table: "tblProductPriceKind");

            migrationBuilder.AddColumn<int>(
                name: "tblPriceKindId1",
                table: "tblProductPriceKind",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tblPriceKindIdId",
                table: "tblProductPriceKind",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tblProductId1",
                table: "tblProductPriceKind",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tblProductIdId",
                table: "tblProductPriceKind",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblProductPriceKind_tblPriceKindId1",
                table: "tblProductPriceKind",
                column: "tblPriceKindId1");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductPriceKind_tblPriceKindIdId",
                table: "tblProductPriceKind",
                column: "tblPriceKindIdId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductPriceKind_tblProductId1",
                table: "tblProductPriceKind",
                column: "tblProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductPriceKind_tblProductIdId",
                table: "tblProductPriceKind",
                column: "tblProductIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPriceKind_tblPriceKind_tblPriceKindId1",
                table: "tblProductPriceKind",
                column: "tblPriceKindId1",
                principalTable: "tblPriceKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPriceKind_tblProductKind_tblPriceKindIdId",
                table: "tblProductPriceKind",
                column: "tblPriceKindIdId",
                principalTable: "tblProductKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPriceKind_tblProduct_tblProductId1",
                table: "tblProductPriceKind",
                column: "tblProductId1",
                principalTable: "tblProduct",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tblProductPriceKind_tblProductKind_tblProductIdId",
                table: "tblProductPriceKind",
                column: "tblProductIdId",
                principalTable: "tblProductKind",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
