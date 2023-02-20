using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlahlyMomknTask.Server.Migrations
{
    public partial class InitUserSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "IsActive", "Password", "Username" },
                values: new object[] { new Guid("88106e82-3258-466d-a95d-afb9b8434791"), "user2@mail.com", true, "$2a$12$64XpCZjUHeTY9WZc1NRJle9Imn1gBo29O3.QCTeniyP4f2Zkad2iy", "User2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "Email", "IsActive", "Password", "Username" },
                values: new object[] { new Guid("ee99ef29-ba24-4d45-ad73-bbc674283af7"), "user1@mail.com", true, "$2a$12$64XpCZjUHeTY9WZc1NRJle9Imn1gBo29O3.QCTeniyP4f2Zkad2iy", "User1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("88106e82-3258-466d-a95d-afb9b8434791"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("ee99ef29-ba24-4d45-ad73-bbc674283af7"));
        }
    }
}
