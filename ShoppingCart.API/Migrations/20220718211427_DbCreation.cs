using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.API.Migrations
{
    public partial class DbCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 1, nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    TimeUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    CartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TimeCreated = table.Column<DateTime>(type: "datetime", nullable: false),
                    TimeUpdated = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => new { x.CartItemId, x.CartId });
                    table.ForeignKey(
                        name: "FK_CartItem_Cart",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CreatedBy", "Status", "TimeCreated", "TimeUpdated" },
                values: new object[] { 1, "User 1", 0, new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(24), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(26) });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CreatedBy", "Status", "TimeCreated", "TimeUpdated" },
                values: new object[] { 2, "User 2", 0, new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(27), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(27) });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CreatedBy", "Status", "TimeCreated", "TimeUpdated" },
                values: new object[] { 3, "User 3", 0, new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(28), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(28) });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[] { 1, 1, 2m, "User 1", "CartItem 1 Description", "CartItem 1 Name", new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(158), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(158) });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[] { 1, 2, 2m, "User 1", "CartItem 2 Description", "CartItem 2 Name", new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(162), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(162) });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartId",
                table: "CartItem",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");

            migrationBuilder.DropTable(
                name: "Cart");
        }
    }
}
