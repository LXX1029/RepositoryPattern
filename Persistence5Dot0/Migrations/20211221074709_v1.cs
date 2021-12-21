using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence5Dot0.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("4c605048-2faf-4cad-99e2-715201ee8b33"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("bdeba495-e02a-416f-a462-126b353ec8b6"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("cea2d9ce-d815-44fe-9763-98634bdd1388"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("dbfa3622-8150-4730-b4e9-321cfa4d79c7"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedTime",
                table: "Account",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "CreatedTime", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("9f4c21a5-6ec7-48d1-8984-d16e2eef229f"), "网易", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 15, 47, 8, 455, DateTimeKind.Local).AddTicks(4630), new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "CreatedTime", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("6ac4858f-6864-421b-8f87-279b27c86a3c"), "腾讯", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 15, 47, 8, 455, DateTimeKind.Local).AddTicks(5455), new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "CreatedTime", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("b180dfee-1ec4-49cd-b693-01071f982f84"), "京东", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 15, 47, 8, 455, DateTimeKind.Local).AddTicks(5468), new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "CreatedTime", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("2a337bed-3d8c-4bdf-86c1-80816906c061"), "CSDN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 15, 47, 8, 455, DateTimeKind.Local).AddTicks(5472), new Guid("54aeb677-a1fc-479f-b095-98476a027e6d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("2a337bed-3d8c-4bdf-86c1-80816906c061"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("6ac4858f-6864-421b-8f87-279b27c86a3c"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("9f4c21a5-6ec7-48d1-8984-d16e2eef229f"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("b180dfee-1ec4-49cd-b693-01071f982f84"));

            migrationBuilder.DropColumn(
                name: "CreatedTime",
                table: "Account");

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("cea2d9ce-d815-44fe-9763-98634bdd1388"), "网易", new DateTime(2021, 11, 18, 15, 34, 20, 74, DateTimeKind.Local).AddTicks(4031), new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("4c605048-2faf-4cad-99e2-715201ee8b33"), "腾讯", new DateTime(2021, 11, 18, 15, 34, 20, 74, DateTimeKind.Local).AddTicks(4867), new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("bdeba495-e02a-416f-a462-126b353ec8b6"), "京东", new DateTime(2021, 11, 18, 15, 34, 20, 74, DateTimeKind.Local).AddTicks(4880), new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("dbfa3622-8150-4730-b4e9-321cfa4d79c7"), "CSDN", new DateTime(2021, 11, 18, 15, 34, 20, 74, DateTimeKind.Local).AddTicks(4886), new Guid("54aeb677-a1fc-479f-b095-98476a027e6d") });
        }
    }
}
