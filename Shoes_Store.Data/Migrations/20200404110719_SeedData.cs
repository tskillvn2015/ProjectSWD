using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shoes_Store.Data.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Address", "CreatedAt", "FullName", "IsDelete", "Password", "Role", "Username" },
                values: new object[] { new Guid("defdd286-ca21-440b-a05f-d23acf0e2a1e"), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, "123", 0, "sa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: new Guid("defdd286-ca21-440b-a05f-d23acf0e2a1e"));
        }
    }
}
