using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspNetCore_NlogTest.Migrations
{
    public partial class AdditionalOwnerRowInserted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "DateOfBirth", "Name" },
                values: new object[,]
                {
                    { new Guid("54aeb677-a1fc-479f-b095-98476a027e6d"), "河南", new DateTime(1999, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name1" },
                    { new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3"), "河北", new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name2" },
                    { new Guid("be24d142-c750-4cee-90eb-2b99d942b33c"), "湖南", new DateTime(1992, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name3" },
                    { new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5"), "湖北", new DateTime(1991, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("54aeb677-a1fc-479f-b095-98476a027e6d"));

            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("be24d142-c750-4cee-90eb-2b99d942b33c"));

            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5"));

            migrationBuilder.DeleteData(
                table: "Owner",
                keyColumn: "OwnerId",
                keyValue: new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3"));
        }
    }
}
