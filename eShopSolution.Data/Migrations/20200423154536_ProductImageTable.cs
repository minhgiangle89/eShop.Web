using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ProductImages",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "ProductImages",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ad298bd-670e-4c66-b6ee-96b41698fc1e"),
                column: "ConcurrencyStamp",
                value: "9af09442-a53b-46f3-a005-e86e77dc3aa8");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("50e6a4f2-d964-46b0-8ae3-2c944f2e20f8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d632f832-82f7-458e-bc5f-aa73ed763a01", "AQAAAAEAACcQAAAAEEmgqkQdAgR6lARlRV+LwaP6DCzYNTuaPB++lX4hX7bW3TvCoyqxKrok02XigF0G7A==" });

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
                value: new DateTime(2020, 4, 23, 22, 45, 35, 950, DateTimeKind.Local).AddTicks(6690));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Caption",
                table: "ProductImages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ad298bd-670e-4c66-b6ee-96b41698fc1e"),
                column: "ConcurrencyStamp",
                value: "9d2b47ff-fe6d-4977-a232-b031f222d845");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("50e6a4f2-d964-46b0-8ae3-2c944f2e20f8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a57e42fd-faeb-400c-b193-b38cebe8244e", "AQAAAAEAACcQAAAAEH6YUQ5EDrnOIkvOtgOB046cMrU6DC6vDuQAHZwtXjsqrqy1OFT85Z6wbs5gNR6yNg==" });

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
    }
}
