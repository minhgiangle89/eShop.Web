using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class SeedIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[] { new Guid("1ad298bd-670e-4c66-b6ee-96b41698fc1e"), "9d2b47ff-fe6d-4977-a232-b031f222d845", "Administrator Role", "admin", "admin" });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { new Guid("50e6a4f2-d964-46b0-8ae3-2c944f2e20f8"), new Guid("1ad298bd-670e-4c66-b6ee-96b41698fc1e") });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("50e6a4f2-d964-46b0-8ae3-2c944f2e20f8"), 0, "a57e42fd-faeb-400c-b193-b38cebe8244e", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "some-admin-email@nonce.fake", true, "Minh", "Giang", false, null, "some-admin-email@nonce.fake", "admin", "AQAAAAEAACcQAAAAEH6YUQ5EDrnOIkvOtgOB046cMrU6DC6vDuQAHZwtXjsqrqy1OFT85Z6wbs5gNR6yNg==", null, false, "", false, "admin" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 12, 20, 21, 12, 435, DateTimeKind.Local).AddTicks(1927));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ad298bd-670e-4c66-b6ee-96b41698fc1e"));

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("50e6a4f2-d964-46b0-8ae3-2c944f2e20f8"), new Guid("1ad298bd-670e-4c66-b6ee-96b41698fc1e") });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("50e6a4f2-d964-46b0-8ae3-2c944f2e20f8"));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2020, 4, 12, 19, 49, 0, 946, DateTimeKind.Local).AddTicks(4751));
        }
    }
}
