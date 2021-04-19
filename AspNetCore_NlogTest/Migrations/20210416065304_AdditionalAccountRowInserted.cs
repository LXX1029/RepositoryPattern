using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore_NlogTest.Migrations
{
    public partial class AdditionalAccountRowInserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[,]
                {
                    { new Guid("666f89db-f6e6-42c5-ba84-f2e93a176544"), "网易", new DateTime(2021, 4, 16, 14, 53, 3, 587, DateTimeKind.Local).AddTicks(1979), new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3") },
                    { new Guid("6cb4b826-a441-450e-97fb-da3a66b9079d"), "腾讯", new DateTime(2021, 4, 16, 14, 53, 3, 587, DateTimeKind.Local).AddTicks(3385), new Guid("be24d142-c750-4cee-90eb-2b99d942b33c") },
                    { new Guid("626c5ff4-76b8-43a1-aa78-5f0b420097d2"), "京东", new DateTime(2021, 4, 16, 14, 53, 3, 587, DateTimeKind.Local).AddTicks(3428), new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5") },
                    { new Guid("53bd472c-69ae-453f-9b82-f3ff683c6391"), "CSDN", new DateTime(2021, 4, 16, 14, 53, 3, 587, DateTimeKind.Local).AddTicks(3432), new Guid("54aeb677-a1fc-479f-b095-98476a027e6d") }
                });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("54aeb677-a1fc-479f-b095-98476a027e6d"),
                columns: new[] { "Address", "DateOfBirth", "Name" },
                values: new object[] { "湖北", new DateTime(1991, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name4" });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("be24d142-c750-4cee-90eb-2b99d942b33c"),
                columns: new[] { "Address", "DateOfBirth", "Name" },
                values: new object[] { "河北", new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name2" });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5"),
                columns: new[] { "Address", "DateOfBirth", "Name" },
                values: new object[] { "湖南", new DateTime(1992, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name3" });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3"),
                columns: new[] { "Address", "DateOfBirth", "Name" },
                values: new object[] { "河南", new DateTime(1999, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("53bd472c-69ae-453f-9b82-f3ff683c6391"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("626c5ff4-76b8-43a1-aa78-5f0b420097d2"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("666f89db-f6e6-42c5-ba84-f2e93a176544"));

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "AccountId",
                keyValue: new Guid("6cb4b826-a441-450e-97fb-da3a66b9079d"));

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("54aeb677-a1fc-479f-b095-98476a027e6d"),
                columns: new[] { "Address", "DateOfBirth", "Name" },
                values: new object[] { "河南", new DateTime(1999, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name1" });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("be24d142-c750-4cee-90eb-2b99d942b33c"),
                columns: new[] { "Address", "DateOfBirth", "Name" },
                values: new object[] { "湖南", new DateTime(1992, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name3" });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5"),
                columns: new[] { "Address", "DateOfBirth", "Name" },
                values: new object[] { "湖北", new DateTime(1991, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name4" });

            migrationBuilder.UpdateData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3"),
                columns: new[] { "Address", "DateOfBirth", "Name" },
                values: new object[] { "河北", new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name2" });
        }
    }
}
