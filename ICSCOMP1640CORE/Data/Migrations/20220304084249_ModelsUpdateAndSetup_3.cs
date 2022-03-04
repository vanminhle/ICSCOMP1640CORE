using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Data.Migrations
{
    public partial class ModelsUpdateAndSetup_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f6614b4-af9b-418e-b0ac-83ab645ada56");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "88952340-2098-4577-b0e6-cf9bccc7b82e", "0ecc9f2b-6b7d-4201-a9f3-ae30acd1f686" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d1ba7b6a-eab8-40e2-9f75-47c8025a53e0", "4ddb4357-c3cf-4d2d-b804-1a48ed0dfea4" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88952340-2098-4577-b0e6-cf9bccc7b82e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d1ba7b6a-eab8-40e2-9f75-47c8025a53e0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0ecc9f2b-6b7d-4201-a9f3-ae30acd1f686");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4ddb4357-c3cf-4d2d-b804-1a48ed0dfea4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "74fa7898-d6bf-4c23-985b-4e527308f710", "01f5e58e-7936-4174-b975-bc6d82ee8ae2", "Admin", "ADMIN" },
                    { "6b5dc52d-01bb-4be6-971b-90157a0ff405", "95cec438-d700-4647-bd36-1b2b8430d898", "Staff", "STAFF" },
                    { "808f7cbd-3788-42a4-833f-dd369447dcb5", "b31d5645-88fe-4e60-86e1-37dbabce41c5", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f369b8d4-0ee7-435e-8055-1684e03d2257", 0, null, 0, "462b7588-fde0-4f11-87ba-984df86bd870", "User", "admin@gmail.com", true, "Admin Account", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEHGhu0Uv0EkLFYYWcq9XfJOtNoAEwgNe2NoUkimC7VZbX7i3ZWo4QxFCy8enD5fueQ==", null, true, "49ef42e7-c387-4154-8c96-8cb0943bfde6", false, "admin@gmail.com" },
                    { "91d570ee-81b7-4d97-a482-d40507ff7b54", 0, null, 0, "e3961488-ebde-4507-a555-cf92bab18c54", "User", "coordinator@gmail.com", true, "Coordinator Account", false, null, null, null, "AQAAAAEAACcQAAAAEBxSemtWbB6WAxNDGr4ejb4GeTE9Tqz+UIOiY+lCycKgN54O/bh8PVIq3TuyNRhiEQ==", null, true, "b28b3eec-7e07-4f52-9fd6-16de2d3e9679", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "74fa7898-d6bf-4c23-985b-4e527308f710", "f369b8d4-0ee7-435e-8055-1684e03d2257" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "808f7cbd-3788-42a4-833f-dd369447dcb5", "91d570ee-81b7-4d97-a482-d40507ff7b54" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6b5dc52d-01bb-4be6-971b-90157a0ff405");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "808f7cbd-3788-42a4-833f-dd369447dcb5", "91d570ee-81b7-4d97-a482-d40507ff7b54" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "74fa7898-d6bf-4c23-985b-4e527308f710", "f369b8d4-0ee7-435e-8055-1684e03d2257" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74fa7898-d6bf-4c23-985b-4e527308f710");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "808f7cbd-3788-42a4-833f-dd369447dcb5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91d570ee-81b7-4d97-a482-d40507ff7b54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f369b8d4-0ee7-435e-8055-1684e03d2257");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d1ba7b6a-eab8-40e2-9f75-47c8025a53e0", "377a7328-f2d3-4fd0-82fc-deb6583b3f43", "Admin", "ADMIN" },
                    { "8f6614b4-af9b-418e-b0ac-83ab645ada56", "20ab1767-f500-415b-bf3b-426018d226cb", "Staff", "STAFF" },
                    { "88952340-2098-4577-b0e6-cf9bccc7b82e", "663eb77a-f486-4fe5-a3c3-98f39a6bd02d", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4ddb4357-c3cf-4d2d-b804-1a48ed0dfea4", 0, null, 0, "cb059fe7-b2a0-4c8e-9841-8dddfec15ade", "User", "admin@gmail.com", true, "Admin Account", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEDS2V5lwzK1Y+hmXUHPkNU3gFbR2Dfw9GN8BVcdel5GCYfKo8qOoSVbwmh7N/ZALZg==", null, true, "23040a63-f393-4c26-a463-c5ee68b8afff", false, "admin@gmail.com" },
                    { "0ecc9f2b-6b7d-4201-a9f3-ae30acd1f686", 0, null, 0, "012bbf9d-1c19-4b29-b1b8-ad377e24b283", "User", "coordinator@gmail.com", true, "Coordinator Account", false, null, null, null, "AQAAAAEAACcQAAAAEF7MM1Vhr9RhVrECho2Qd8PDi1ZNHp5IOZc8Gjh7WJXs2Uol+O1yJKFwva2Q9RKhSA==", null, true, "61b513cc-3caf-4db4-8885-76a5984f38e6", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d1ba7b6a-eab8-40e2-9f75-47c8025a53e0", "4ddb4357-c3cf-4d2d-b804-1a48ed0dfea4" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "88952340-2098-4577-b0e6-cf9bccc7b82e", "0ecc9f2b-6b7d-4201-a9f3-ae30acd1f686" });
        }
    }
}
