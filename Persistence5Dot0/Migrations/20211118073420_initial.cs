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
