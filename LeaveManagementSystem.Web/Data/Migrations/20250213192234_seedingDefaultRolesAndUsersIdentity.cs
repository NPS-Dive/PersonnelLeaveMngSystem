using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LeaveManagementSystem.Web.Data.Migrations
{
    /// <inheritdoc />
    public partial class seedingDefaultRolesAndUsersIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f7161af-f792-4596-bc5e-94d61d438455", null, "Administrator", "ADMINISTRATOR" },
                    { "824d7b4e-3ca3-4c4c-98fd-0448854fb205", null, "Supervisor", "SUPERVISOR" },
                    { "e27e4fb8-ce1e-4aad-ab63-1c551447c566", null, "RegularUser", "REGULARUSER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ac8bab34-0e3c-4c8a-b7c1-d19c13f36aa1", 0, "2afcc199-4d91-40c5-8af8-50dda9173209", "admin@ipbses.com", true, false, null, "ADMIN@IPBSES.COM", "ADMIN@IPBSES.COM", "AQAAAAIAAYagAAAAEEX+LvL1iaLSVGS9bR24ikCIhokCasi+XZW5D/GzYd7TRIhgLn3Mt5ZpkVIvlK1hkQ==", null, false, "b0335730-20aa-4436-8f86-6ebe4841c0ae", false, "admin@ipbses.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4f7161af-f792-4596-bc5e-94d61d438455", "ac8bab34-0e3c-4c8a-b7c1-d19c13f36aa1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "824d7b4e-3ca3-4c4c-98fd-0448854fb205");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e27e4fb8-ce1e-4aad-ab63-1c551447c566");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4f7161af-f792-4596-bc5e-94d61d438455", "ac8bab34-0e3c-4c8a-b7c1-d19c13f36aa1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4f7161af-f792-4596-bc5e-94d61d438455");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ac8bab34-0e3c-4c8a-b7c1-d19c13f36aa1");
        }
    }
}
