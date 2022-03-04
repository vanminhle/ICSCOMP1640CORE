using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Data.Migrations
{
    public partial class ModelsUpdateAndSetup_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08e0bd95-4305-4d49-810b-d54360164c55");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7c23dbdc-b7e9-49c9-8c6d-70d0c20b5d4d", "a75296f6-de4b-46c1-abd5-b834ba67f997" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9514cfc1-06e7-4441-9368-519de68dc98b", "f3c5515c-9fa7-4e84-b120-fa10a4317ba6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7c23dbdc-b7e9-49c9-8c6d-70d0c20b5d4d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9514cfc1-06e7-4441-9368-519de68dc98b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a75296f6-de4b-46c1-abd5-b834ba67f997");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f3c5515c-9fa7-4e84-b120-fa10a4317ba6");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "9514cfc1-06e7-4441-9368-519de68dc98b", "a6d1f313-da33-4ef3-b037-70ce9d181462", "Admin", "ADMIN" },
                    { "08e0bd95-4305-4d49-810b-d54360164c55", "68d13bb4-31cf-4a29-b3bd-ccef8971651d", "Staff", "STAFF" },
                    { "7c23dbdc-b7e9-49c9-8c6d-70d0c20b5d4d", "5a3d44e9-ac89-4c3b-979a-16a1a2614f58", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "f3c5515c-9fa7-4e84-b120-fa10a4317ba6", 0, null, 0, "3037bcf0-fb99-40a1-ab6d-83ef1b0b4b52", "User", "admin@gmail.com", true, "Admin", false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEGJY/DcZIDJNoIAbRH+vvzkV/cMb+A462PCh3XW+dYe0bvpI2HYfGQ9dQqFAnnec1Q==", null, true, "ee0f965f-f74d-49e0-98b0-d1cad075da67", false, "admin@gmail.com" },
                    { "a75296f6-de4b-46c1-abd5-b834ba67f997", 0, null, 0, "99aabdd5-6645-4fc1-a225-c9425681c0ab", "User", "coordinator@gmail.com", true, "Coordinator", false, null, null, null, "AQAAAAEAACcQAAAAELymbXd+pPRmAf1dLkqEylf5IWHf3fhIqdYmGmxN/WPO81WAUeUZehaBZvrCsootKQ==", null, true, "5b050beb-2bb3-4cb1-b1af-dafd84cb7b06", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9514cfc1-06e7-4441-9368-519de68dc98b", "f3c5515c-9fa7-4e84-b120-fa10a4317ba6" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7c23dbdc-b7e9-49c9-8c6d-70d0c20b5d4d", "a75296f6-de4b-46c1-abd5-b834ba67f997" });
        }
    }
}
