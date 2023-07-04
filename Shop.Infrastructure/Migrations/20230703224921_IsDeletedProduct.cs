using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392b3112-751b-4345-b4d7-d5a24d46dc19"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 1, 49, 21, 612, DateTimeKind.Local).AddTicks(804));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bafa6da-0516-4e3a-b839-5a89098dff48"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 1, 49, 21, 612, DateTimeKind.Local).AddTicks(993));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a701c49d-ee5b-45d7-a922-3395f0c073ee"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 1, 49, 21, 612, DateTimeKind.Local).AddTicks(1038));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce00721c-db00-4cfc-b611-edb11d437894"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 1, 49, 21, 612, DateTimeKind.Local).AddTicks(953));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13b4505-d361-46e1-a915-0e9b6d25aa1c"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 4, 1, 49, 21, 612, DateTimeKind.Local).AddTicks(1015));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392b3112-751b-4345-b4d7-d5a24d46dc19"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 3, 3, 10, 802, DateTimeKind.Local).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bafa6da-0516-4e3a-b839-5a89098dff48"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 3, 3, 10, 802, DateTimeKind.Local).AddTicks(2742));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a701c49d-ee5b-45d7-a922-3395f0c073ee"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 3, 3, 10, 802, DateTimeKind.Local).AddTicks(2786));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce00721c-db00-4cfc-b611-edb11d437894"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 3, 3, 10, 802, DateTimeKind.Local).AddTicks(2703));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13b4505-d361-46e1-a915-0e9b6d25aa1c"),
                column: "DateCreated",
                value: new DateTime(2023, 7, 1, 3, 3, 10, 802, DateTimeKind.Local).AddTicks(2763));
        }
    }
}
