using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class addApplicationUserintoIdentityUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Family",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac8bab34-0e3c-4c8a-b7c1-d19c13f36aa1",
                columns: new[] { "ConcurrencyStamp", "DateOfBirth", "Family", "Name", "NationalId", "PasswordHash", "SecurityStamp" },
                values: new object[] { "99740091-ab3a-4390-946b-ac772d842110", new DateOnly(1983, 8, 3), "Admin", "Default", "2233445566", "AQAAAAIAAYagAAAAELe5U6VYgWz61RDRkOZJTtyd5nQ6hPm6nPQwAX9VtSgHV7hfaKM9340E2nUaw6IwMQ==", "f9ad5dc2-ff64-44c0-b939-05ee30ce2dad" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Family",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac8bab34-0e3c-4c8a-b7c1-d19c13f36aa1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2afcc199-4d91-40c5-8af8-50dda9173209", "AQAAAAIAAYagAAAAEEX+LvL1iaLSVGS9bR24ikCIhokCasi+XZW5D/GzYd7TRIhgLn3Mt5ZpkVIvlK1hkQ==", "b0335730-20aa-4436-8f86-6ebe4841c0ae" });
        }
    }
}
