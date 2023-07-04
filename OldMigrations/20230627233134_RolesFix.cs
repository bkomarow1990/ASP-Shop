using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RolesFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RoleId1",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId1",
                table: "AspNetUserRoles",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("392b3112-751b-4345-b4d7-d5a24d46dc19"),
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 2, 31, 34, 719, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8bafa6da-0516-4e3a-b839-5a89098dff48"),
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 2, 31, 34, 719, DateTimeKind.Local).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a701c49d-ee5b-45d7-a922-3395f0c073ee"),
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 2, 31, 34, 719, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ce00721c-db00-4cfc-b611-edb11d437894"),
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 2, 31, 34, 719, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f13b4505-d361-46e1-a915-0e9b6d25aa1c"),
                column: "DateCreated",
                value: new DateTime(2023, 6, 28, 2, 31, 34, 719, DateTimeKind.Local).AddTicks(3183));

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles",
                column: "RoleId1",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUserRoles_UserId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "RoleId1",
                table: "AspNetUserRoles");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "AspNetUserRoles");

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
    }
}
