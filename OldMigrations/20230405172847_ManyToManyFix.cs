using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Carts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392b3112-751b-4345-b4d7-d5a24d46dc19"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 5, 20, 28, 47, 170, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bafa6da-0516-4e3a-b839-5a89098dff48"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 5, 20, 28, 47, 170, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a701c49d-ee5b-45d7-a922-3395f0c073ee"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 5, 20, 28, 47, 170, DateTimeKind.Local).AddTicks(9134));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce00721c-db00-4cfc-b611-edb11d437894"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 5, 20, 28, 47, 170, DateTimeKind.Local).AddTicks(9050));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13b4505-d361-46e1-a915-0e9b6d25aa1c"),
                column: "DateCreated",
                value: new DateTime(2023, 4, 5, 20, 28, 47, 170, DateTimeKind.Local).AddTicks(9112));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Carts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392b3112-751b-4345-b4d7-d5a24d46dc19"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bafa6da-0516-4e3a-b839-5a89098dff48"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a701c49d-ee5b-45d7-a922-3395f0c073ee"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce00721c-db00-4cfc-b611-edb11d437894"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13b4505-d361-46e1-a915-0e9b6d25aa1c"),
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
