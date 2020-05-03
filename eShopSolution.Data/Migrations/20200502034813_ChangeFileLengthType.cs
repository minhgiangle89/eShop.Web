using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eShopSolution.Data.Migrations
{
    public partial class ChangeFileLengthType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("1ad298bd-670e-4c66-b6ee-96b41698fc1e"),
                column: "ConcurrencyStamp",
                value: "d526a88c-a4ce-44b0-9a36-300378e9a27e");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: new Guid("50e6a4f2-d964-46b0-8ae3-2c944f2e20f8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a4c5f042-feaf-458f-853b-bd23fac589fd", "AQAAAAEAACcQAAAAEMsR6zSCZxhjk6qXMG3phVUeSHlbgi46TEARKRhNsdqLYpJcyd3S9otoYjqOE0v/FQ==" });

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
                value: new DateTime(2020, 5, 2, 10, 48, 12, 630, DateTimeKind.Local).AddTicks(7259));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
