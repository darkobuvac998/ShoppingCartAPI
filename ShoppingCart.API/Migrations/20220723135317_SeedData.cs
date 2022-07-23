using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingCart.API.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 1,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3379), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3408) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 2,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3412), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3410) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 3,
                columns: new[] { "Status", "TimeCreated", "TimeUpdated" },
                values: new object[] { 2, new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3415), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3413) });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CreatedBy", "Status", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 4, "User 1", 1, new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3418), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3417) },
                });

            migrationBuilder.InsertData(
                table: "Cart",
                columns: new[] { "CartId", "CreatedBy", "Status", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 5, "User 1", 1, new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3421), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3420) }
                });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3529), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3532) });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3535), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3537) });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 2, 1, 2m, "User 1", "CartItem 1 Description", "CartItem 1 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3548), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3550) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 3, 1, 2m, "User 1", "CartItem 1 Description", "CartItem 1 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3566), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3567) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 2, 2, 2m, "User 1", "CartItem 2 Description", "CartItem 2 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3551), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3553) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 3, 2, 2m, "User 1", "CartItem 2 Description", "CartItem 2 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3569), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3570) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 1, 3, 2m, "User 1", "CartItem 3 Description", "CartItem 3 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3539), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3540) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 2, 3, 2m, "User 1", "CartItem 3 Description", "CartItem 3 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3555), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3556) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 3, 3, 2m, "User 1", "CartItem 3 Description", "CartItem 3 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3572), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3573) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 1, 4, 2m, "User 1", "CartItem 4 Description", "CartItem 4 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3542), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3543) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 2, 4, 2m, "User 1", "CartItem 4 Description", "CartItem 4 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3558), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3560) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 3, 4, 2m, "User 1", "CartItem 4 Description", "CartItem 4 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3575), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3577) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 1, 5, 2m, "User 1", "CartItem 5 Description", "CartItem 5 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3545), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3547) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 2, 5, 2m, "User 1", "CartItem 5 Description", "CartItem 5 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3562), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3563) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 3, 5, 2m, "User 1", "CartItem 5 Description", "CartItem 5 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3578), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3580) }
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 4, 1, 2m, "User 1", "CartItem 1 Description", "CartItem 1 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3582), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3583) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 4, 2, 2m, "User 1", "CartItem 2 Description", "CartItem 2 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3585), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3586) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 4, 3, 2m, "User 1", "CartItem 3 Description", "CartItem 3 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3588), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3589) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 4, 4, 2m, "User 1", "CartItem 4 Description", "CartItem 4 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3591), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3592) },
                });

            migrationBuilder.InsertData(
                table: "CartItem",
                columns: new[] { "CartId", "CartItemId", "Amount", "CreatedBy", "Description", "Name", "TimeCreated", "TimeUpdated" },
                values: new object[,]
                {
                    { 4, 5, 2m, "User 1", "CartItem 5 Description", "CartItem 5 Name", new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3594), new DateTime(2022, 7, 23, 15, 53, 16, 854, DateTimeKind.Local).AddTicks(3596) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 1,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(24), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(26) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 2,
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(27), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(27) });

            migrationBuilder.UpdateData(
                table: "Cart",
                keyColumn: "CartId",
                keyValue: 3,
                columns: new[] { "Status", "TimeCreated", "TimeUpdated" },
                values: new object[] { 0, new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(28), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(28) });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(158), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(158) });

            migrationBuilder.UpdateData(
                table: "CartItem",
                keyColumns: new[] { "CartId", "CartItemId" },
                keyValues: new object[] { 1, 2 },
                columns: new[] { "TimeCreated", "TimeUpdated" },
                values: new object[] { new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(162), new DateTime(2022, 7, 18, 21, 14, 27, 608, DateTimeKind.Utc).AddTicks(162) });
        }
    }
}
