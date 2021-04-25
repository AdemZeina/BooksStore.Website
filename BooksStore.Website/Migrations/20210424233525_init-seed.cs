using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BooksStore.Website.Migrations
{
    public partial class initseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "ca66449f-99b6-48f1-a217-ae57bf2ed673", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "1361a8e8-a83f-47b7-bd4d-34475c121b6b", "admin@admin.com", true, false, null, null, "admin@admin.com", "AQAAAAEAACcQAAAAEJObSr6Oz7PemOYnNEI1ZwVL3cHrkcjGT5gDpVpI2k7/CHRn9Dv4KbRm1mebojP9WQ==", null, false, "14153ebb-9df1-472e-8ac9-a8005906751b", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedAt", "Name" },
                values: new object[,]
                {
                    { 1, null, "Science" },
                    { 2, null, "Technology" },
                    { 3, null, "Psycology" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

        //    migrationBuilder.InsertData(
        //        table: "Books",
        //        columns: new[] { "Id", "Author", "Content", "CreatedAt", "CreatedUserId", "Description", "ImageUrl", "Price", "ReadCount", "TagId", "Title" },
        //        values: new object[] { 1, "Bill Gates", "C# Programming Guide, From A to Z Guid to program in c#", new DateTime(2021, 4, 24, 23, 35, 23, 939, DateTimeKind.Utc).AddTicks(9905), new Guid("8e445865-a24d-4543-a6c6-9443d048cdb9"), "From A to Z Guid to program in c#", "", 50.0, 1, 2, "C# Programming Guide" });
        //
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2c5e174e-3b0e-446f-86af-483d56fd7210", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c5e174e-3b0e-446f-86af-483d56fd7210");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
