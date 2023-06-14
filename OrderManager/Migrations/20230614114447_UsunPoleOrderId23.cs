using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManager.Migrations
{
    /// <inheritdoc />
    public partial class UsunPoleOrderId23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ORder1Id",
                table: "OrderItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ORder1s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORder1s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ORder1s_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ORder1s_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ORder1Id",
                table: "OrderItems",
                column: "ORder1Id");

            migrationBuilder.CreateIndex(
                name: "IX_ORder1s_CustomerId",
                table: "ORder1s",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ORder1s_ProductId",
                table: "ORder1s",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_ORder1s_ORder1Id",
                table: "OrderItems",
                column: "ORder1Id",
                principalTable: "ORder1s",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_ORder1s_ORder1Id",
                table: "OrderItems");

            migrationBuilder.DropTable(
                name: "ORder1s");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_ORder1Id",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "ORder1Id",
                table: "OrderItems");
        }
    }
}
