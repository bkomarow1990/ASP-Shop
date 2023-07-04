using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392b3112-751b-4345-b4d7-d5a24d46dc19"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 19, 39, 24, 424, DateTimeKind.Local).AddTicks(6696));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bafa6da-0516-4e3a-b839-5a89098dff48"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 19, 39, 24, 424, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a701c49d-ee5b-45d7-a922-3395f0c073ee"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 19, 39, 24, 424, DateTimeKind.Local).AddTicks(6948));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce00721c-db00-4cfc-b611-edb11d437894"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 19, 39, 24, 424, DateTimeKind.Local).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13b4505-d361-46e1-a915-0e9b6d25aa1c"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 19, 39, 24, 424, DateTimeKind.Local).AddTicks(6928));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEdited = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Quantity = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => new { x.UserId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_Carts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Carts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392b3112-751b-4345-b4d7-d5a24d46dc19"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 17, 36, 10, 183, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bafa6da-0516-4e3a-b839-5a89098dff48"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 17, 36, 10, 184, DateTimeKind.Local).AddTicks(34));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a701c49d-ee5b-45d7-a922-3395f0c073ee"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 17, 36, 10, 184, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce00721c-db00-4cfc-b611-edb11d437894"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 17, 36, 10, 183, DateTimeKind.Local).AddTicks(9993));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13b4505-d361-46e1-a915-0e9b6d25aa1c"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 6, 17, 36, 10, 184, DateTimeKind.Local).AddTicks(59));

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ProductId",
                table: "Carts",
                column: "ProductId");
        }
    }
}
