using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AsyncInn.Migrations
{
    /// <inheritdoc />
    public partial class seedRolesWithReadPolicy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "District Manager", "56fe2c82-eccd-4bc3-ba1e-7f96e5a10896" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "56fe2c82-eccd-4bc3-ba1e-7f96e5a10896");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "district manager");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "district manager");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "delete", "district manager" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "read", "district manager" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "create", "property manager" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 17, "permissions", "update", "property manager" },
                    { 18, "permissions", "read", "property manager" },
                    { 19, "permissions", "create", "agent" },
                    { 20, "permissions", "update", "agent" },
                    { 21, "permissions", "delete", "agent" },
                    { 22, "permissions", "read", "agent" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e48f6d34-1d9e-4f77-ba55-fca396bc7444", 0, "414a6cf4-e069-42af-b9db-e14a825731ba", "districtmanager1@example.com", true, false, null, "DISTRICTMANAGER1@EXAMPLE.COM", "MANAGER1", "AQAAAAIAAYagAAAAEGVBEZ27jC5KGGcD8ERJMtmF4r08ZEg9/txkvWLf6PN/Kv/AI13SbDPXI3xsVCPH8g==", null, false, "c08d6da0-a1fd-4a29-bb56-73330bc615b1", false, "manager1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "District Manager", "e48f6d34-1d9e-4f77-ba55-fca396bc7444" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "District Manager", "e48f6d34-1d9e-4f77-ba55-fca396bc7444" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e48f6d34-1d9e-4f77-ba55-fca396bc7444");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12,
                column: "RoleId",
                value: "property manager");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13,
                column: "RoleId",
                value: "property manager");

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "create", "agent" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "update", "agent" });

            migrationBuilder.UpdateData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "ClaimValue", "RoleId" },
                values: new object[] { "delete", "agent" });

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 9, "permissions", "create", "district manager" },
                    { 10, "permissions", "update", "district manager" },
                    { 11, "permissions", "delete", "district manager" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "56fe2c82-eccd-4bc3-ba1e-7f96e5a10896", 0, "55cddbcc-7c58-41c2-98e6-44e1fb8ddaee", "districtmanager1@example.com", true, false, null, "DISTRICTMANAGER1@EXAMPLE.COM", "MANAGER1", "AQAAAAIAAYagAAAAEA/PW/kyffRqlHr1e8DIN+iiBbQVDiU7pkT+KEspgCiFoTy6NqgEcDNlRw9JdFAWdw==", null, false, "948c3f01-e1bc-4131-85c9-62a3ecc9fb79", false, "manager1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "District Manager", "56fe2c82-eccd-4bc3-ba1e-7f96e5a10896" });
        }
    }
}
