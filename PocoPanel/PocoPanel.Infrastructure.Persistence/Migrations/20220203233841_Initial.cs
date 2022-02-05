﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocoPanel.Infrastructure.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCountry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ParentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblCountry_tblCountry_ParentID",
                        column: x => x.ParentID,
                        principalTable: "tblCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblProductKind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ParentID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProductKind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProductKind_tblProductKind_ParentID",
                        column: x => x.ParentID,
                        principalTable: "tblProductKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblPriceKind",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    tblCountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblPriceKind", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblPriceKind_tblCountry_tblCountryId",
                        column: x => x.tblCountryId,
                        principalTable: "tblCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Decending = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    tblProductKindId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblProductKind_tblProductKindId",
                        column: x => x.tblProductKindId,
                        principalTable: "tblProductKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblDiscount",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    IsPercent = table.Column<bool>(nullable: false),
                    DiscountValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    DiscountCode = table.Column<string>(nullable: false),
                    tblProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDiscount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblDiscount_tblProduct_tblProductId",
                        column: x => x.tblProductId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TotallPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    tblPriceKindId = table.Column<int>(nullable: true),
                    tblDiscountId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrder_tblDiscount_tblDiscountId",
                        column: x => x.tblDiscountId,
                        principalTable: "tblDiscount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOrder_tblPriceKind_tblPriceKindId",
                        column: x => x.tblPriceKindId,
                        principalTable: "tblPriceKind",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TotallPrice = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    SocialUserName = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    tblProductId = table.Column<int>(nullable: true),
                    tblOrderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblOrderDetail_tblOrder_tblOrderId",
                        column: x => x.tblOrderId,
                        principalTable: "tblOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tblOrderDetail_tblProduct_tblProductId",
                        column: x => x.tblProductId,
                        principalTable: "tblProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblCountry_ParentID",
                table: "tblCountry",
                column: "ParentID");

            migrationBuilder.CreateIndex(
                name: "IX_tblDiscount_tblProductId",
                table: "tblDiscount",
                column: "tblProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_tblDiscountId",
                table: "tblOrder",
                column: "tblDiscountId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_tblPriceKindId",
                table: "tblOrder",
                column: "tblPriceKindId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetail_tblOrderId",
                table: "tblOrderDetail",
                column: "tblOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetail_tblProductId",
                table: "tblOrderDetail",
                column: "tblProductId");

            migrationBuilder.CreateIndex(
                name: "IX_tblPriceKind_tblCountryId",
                table: "tblPriceKind",
                column: "tblCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_tblProductKindId",
                table: "tblProduct",
                column: "tblProductKindId");

            migrationBuilder.CreateIndex(
                name: "IX_tblProductKind_ParentID",
                table: "tblProductKind",
                column: "ParentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblOrderDetail");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblDiscount");

            migrationBuilder.DropTable(
                name: "tblPriceKind");

            migrationBuilder.DropTable(
                name: "tblProduct");

            migrationBuilder.DropTable(
                name: "tblCountry");

            migrationBuilder.DropTable(
                name: "tblProductKind");
        }
    }
}
