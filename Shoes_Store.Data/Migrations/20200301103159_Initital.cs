using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoes_Store.Data.Migrations
{
    public partial class Initital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false,defaultValueSql: "newsequentialid()"),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Name = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    Size = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "History",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    NameOrder = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    IdAccount = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_History", x => x.Id);
                    table.ForeignKey(
                        name: "FK_History_Account_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    NameOrder = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    IdAccount = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Account_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "newsequentialid()"),
                    Quantity = table.Column<int>(nullable: false),
                    IdProduct = table.Column<Guid>(nullable: false),
                    IdOrder = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_IdOrder",
                        column: x => x.IdOrder,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Product_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_History_IdAccount",
                table: "History",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdAccount",
                table: "Order",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_IdOrder",
                table: "OrderDetail",
                column: "IdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_IdProduct",
                table: "OrderDetail",
                column: "IdProduct");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "History");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
