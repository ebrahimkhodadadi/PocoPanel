using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class tblProductPriceKind : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblProductPriceKind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tblPriceKindId = table.Column<int>(nullable: true),
                    tblProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductPriceKind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductPriceKind_tblPriceKind_tblPriceKindId",
                        column: x => x.tblPriceKindId,
                        principalTable: "tblPriceKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblProductPriceKind_tblProduct_tblProductId",
                        column: x => x.tblProductId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProductPriceKind_tblPriceKindId",
                table: "tblProductPriceKind",
                column: "tblPriceKindId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductPriceKind_tblProductId",
                table: "tblProductPriceKind",
                column: "tblProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProductPriceKind");
        }
    }
}
