using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence5Dot0.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedTime",
                table: "Account",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "CreatedTime", "DateCreated", "LastUpdatedTime", "OwnerId" },
                values: new object[] { new Guid("6bb3c8c5-be24-4ceb-a864-0f53bd1048e4"), "网易", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 15, 48, 11, 188, DateTimeKind.Local).AddTicks(5973), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "CreatedTime", "DateCreated", "LastUpdatedTime", "OwnerId" },
                values: new object[] { new Guid("21a3abe5-1c6b-4d3d-aa12-15674b2a21b9"), "腾讯", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 15, 48, 11, 188, DateTimeKind.Local).AddTicks(6873), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "CreatedTime", "DateCreated", "LastUpdatedTime", "OwnerId" },
                values: new object[] { new Guid("4977fbec-11f1-4ddb-9bb7-2a2bf3c988b2"), "京东", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 15, 48, 11, 188, DateTimeKind.Local).AddTicks(6887), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "CreatedTime", "DateCreated", "LastUpdatedTime", "OwnerId" },
                values: new object[] { new Guid("d8ec6486-3dd6-4151-92fb-ed830b5575b2"), "CSDN", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 12, 21, 15, 48, 11, 188, DateTimeKind.Local).AddTicks(6918), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("54aeb677-a1fc-479f-b095-98476a027e6d") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("21a3abe5-1c6b-4d3d-aa12-15674b2a21b9"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("4977fbec-11f1-4ddb-9bb7-2a2bf3c988b2"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("6bb3c8c5-be24-4ceb-a864-0f53bd1048e4"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("d8ec6486-3dd6-4151-92fb-ed830b5575b2"));

            migrationBuilder.DropColumn(
                name: "LastUpdatedTime",
                table: "Account");

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
    }
}
