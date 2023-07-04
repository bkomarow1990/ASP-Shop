using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RegisterDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392b3112-751b-4345-b4d7-d5a24d46dc19"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 32, 58, 914, DateTimeKind.Local).AddTicks(1535));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bafa6da-0516-4e3a-b839-5a89098dff48"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 32, 58, 914, DateTimeKind.Local).AddTicks(1741));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a701c49d-ee5b-45d7-a922-3395f0c073ee"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 32, 58, 914, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce00721c-db00-4cfc-b611-edb11d437894"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 32, 58, 914, DateTimeKind.Local).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13b4505-d361-46e1-a915-0e9b6d25aa1c"),
                column: "DateCreated",
                value: new DateTime(2023, 5, 27, 21, 32, 58, 914, DateTimeKind.Local).AddTicks(1764));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "AspNetUsers");

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
    }
}
