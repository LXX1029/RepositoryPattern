using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence5Dot0.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Owner",
                columns: table => new
                {
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owner", x => x.OwnerId);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AccountType = table.Column<string>(type: "TEXT", nullable: false),
                    OwnerId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Account_Owner_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Owner",
                        principalColumn: "OwnerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "DateOfBirth", "Name" },
                values: new object[] { new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3"), "河南", new DateTime(1999, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name1" });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "DateOfBirth", "Name" },
                values: new object[] { new Guid("be24d142-c750-4cee-90eb-2b99d942b33c"), "河北", new DateTime(1990, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name2" });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "DateOfBirth", "Name" },
                values: new object[] { new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5"), "湖南", new DateTime(1992, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name3" });

            migrationBuilder.InsertData(
                table: "Owner",
                columns: new[] { "OwnerId", "Address", "DateOfBirth", "Name" },
                values: new object[] { new Guid("54aeb677-a1fc-479f-b095-98476a027e6d"), "湖北", new DateTime(1991, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Name4" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("d7ddc108-6b05-4a59-b1c2-7a7b5bc8c1cb"), "网易", new DateTime(2021, 11, 17, 13, 39, 43, 431, DateTimeKind.Local).AddTicks(3446), new Guid("efd9b8e4-b759-434d-bda1-21d268531fb3") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("92352da2-6f82-4ae3-80b5-596b80d70b91"), "腾讯", new DateTime(2021, 11, 17, 13, 39, 43, 431, DateTimeKind.Local).AddTicks(5785), new Guid("be24d142-c750-4cee-90eb-2b99d942b33c") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("89676aed-dcf6-4b99-a3fc-b2c3134945f3"), "京东", new DateTime(2021, 11, 17, 13, 39, 43, 431, DateTimeKind.Local).AddTicks(5848), new Guid("e8253d32-603a-45c3-8d7b-48b2971b20e5") });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "AccountId", "AccountType", "DateCreated", "OwnerId" },
                values: new object[] { new Guid("44e257ca-d7a9-426b-a4eb-9d124cf45941"), "CSDN", new DateTime(2021, 11, 17, 13, 39, 43, 431, DateTimeKind.Local).AddTicks(5853), new Guid("54aeb677-a1fc-479f-b095-98476a027e6d") });

            migrationBuilder.CreateIndex(
                name: "IX_Account_OwnerId",
                table: "Account",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Owner");
        }
    }
}
