using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class SetDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93906e18-3ddc-4894-bad2-879a7834f7b6");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9203ca31-8ab3-4e98-bdfa-b48bd4ca0d13", "130629c5-7a35-4261-841e-4973158a9795" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c96d6569-841f-4ae6-861d-a958e55085d2", "b5c99df0-9bcc-4d03-a2ad-f333c254363b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2200810b-3ca4-4caf-915f-6916e40c1136", "ce153582-bfec-4487-9d2a-aa840c2a8080" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2200810b-3ca4-4caf-915f-6916e40c1136");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9203ca31-8ab3-4e98-bdfa-b48bd4ca0d13");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c96d6569-841f-4ae6-861d-a958e55085d2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "130629c5-7a35-4261-841e-4973158a9795");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b5c99df0-9bcc-4d03-a2ad-f333c254363b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ce153582-bfec-4487-9d2a-aa840c2a8080");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f44424b8-a22e-4a7b-a6b0-e72582250e68", "b127d220-9bc5-4970-8dc5-055ed1b99d18", "Admin", "ADMIN" },
                    { "747a4186-cf82-4774-a330-edd4a2d4f573", "4469fd34-3433-42ff-a83e-ce0229b34661", "Staff", "STAFF" },
                    { "67081ad7-7553-4ada-b444-eff87ba7545c", "3b49a451-5ef3-4528-97f7-48bd9bf65737", "Coordinator", "COORDINATOR" },
                    { "bd5074d8-9363-4ac7-9949-daee96561485", "8906df9f-31e3-4a16-8c2d-a5490c57824f", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bb9dcc6f-d34d-494f-a1b0-7ea2ea27ce41", 0, null, 0, "1dc00d1a-9933-4906-88c3-7cb194b8e857", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEEvgjf6ykXp5kRu3a3e8B2Qkl+MB3IJclXuCmp1hwE1QJijLv/HdU8v9mTtInvToag==", null, true, "b4e3c55e-3672-49ad-8a8c-bf78e3077113", false, "admin@gmail.com" },
                    { "cbaef4a6-0a13-4a4d-995b-0a034145e30b", 0, null, 0, "53b5069c-b765-46d0-9e4f-0cd1c9c4d5c6", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBF0/MQ/xPYsSQvAZPhwRhx90tb84WavHgdPo0C9/54LGuybSvQFabCrnTPF90fOrQ==", null, true, "73cb5696-aa8b-4431-a124-01215003e0b5", false, "coordinator@gmail.com" },
                    { "822b6f75-1c8a-4a34-a329-64953a584fa3", 0, null, 0, "d4e83ccf-30f1-4917-a26a-999d9dfd4b84", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEGpnxb3mcQuTcxSsWNZFU2FW7X6Ljv0vCB8gePhNKFfBPj/B0iHfu5OQTlWPCYYXow==", null, true, "278be987-2e12-4297-9fe3-477109e68292", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f44424b8-a22e-4a7b-a6b0-e72582250e68", "bb9dcc6f-d34d-494f-a1b0-7ea2ea27ce41" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "67081ad7-7553-4ada-b444-eff87ba7545c", "cbaef4a6-0a13-4a4d-995b-0a034145e30b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bd5074d8-9363-4ac7-9949-daee96561485", "822b6f75-1c8a-4a34-a329-64953a584fa3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "747a4186-cf82-4774-a330-edd4a2d4f573");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd5074d8-9363-4ac7-9949-daee96561485", "822b6f75-1c8a-4a34-a329-64953a584fa3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f44424b8-a22e-4a7b-a6b0-e72582250e68", "bb9dcc6f-d34d-494f-a1b0-7ea2ea27ce41" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "67081ad7-7553-4ada-b444-eff87ba7545c", "cbaef4a6-0a13-4a4d-995b-0a034145e30b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67081ad7-7553-4ada-b444-eff87ba7545c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd5074d8-9363-4ac7-9949-daee96561485");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f44424b8-a22e-4a7b-a6b0-e72582250e68");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "822b6f75-1c8a-4a34-a329-64953a584fa3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb9dcc6f-d34d-494f-a1b0-7ea2ea27ce41");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cbaef4a6-0a13-4a4d-995b-0a034145e30b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2200810b-3ca4-4caf-915f-6916e40c1136", "1c936958-a2f7-4647-b020-c9366025494c", "Admin", "ADMIN" },
                    { "93906e18-3ddc-4894-bad2-879a7834f7b6", "976a2b33-0808-4a80-9efb-3c34c97c9844", "Staff", "STAFF" },
                    { "c96d6569-841f-4ae6-861d-a958e55085d2", "47a2c545-6997-43e1-881d-75abbad54a4e", "Coordinator", "COORDINATOR" },
                    { "9203ca31-8ab3-4e98-bdfa-b48bd4ca0d13", "f5546d14-9c6c-4f3e-b682-a7297da4581f", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ce153582-bfec-4487-9d2a-aa840c2a8080", 0, null, 0, "119aecbb-2307-4f74-bec8-39fb18a0f4a7", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEPQmayxP/87zSTZTmOYsMPirVYZ6rIna1qZV/hQ2IMGv0TY5OQDjeXNb3vykfCrrtQ==", null, true, "e6abb8dc-50cc-472c-8fd0-91409cb0a3d7", false, "admin@gmail.com" },
                    { "b5c99df0-9bcc-4d03-a2ad-f333c254363b", 0, null, 0, "46af0509-31e5-4229-8566-ffa641c2c9d0", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEOhOOZR0VSuA/9f2OdUUSulVafGOIw5fc1M5WTzPs0j6Jf6LtVr0qprW1oFAQ90M5A==", null, true, "77a100ec-8d20-4757-9515-bd60cb2c95ad", false, "coordinator@gmail.com" },
                    { "130629c5-7a35-4261-841e-4973158a9795", 0, null, 0, "1ec645a2-7f53-4d7e-8374-dc2206aad247", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEFeBgJbjFk/TSsnQe8WfGpSFBZDIwt77d4f+ahoEWQNg0ZKcYDAuqCQJHk11HXiJkA==", null, true, "ea901c93-e344-45cf-bf9c-51af204a2f6a", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2200810b-3ca4-4caf-915f-6916e40c1136", "ce153582-bfec-4487-9d2a-aa840c2a8080" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c96d6569-841f-4ae6-861d-a958e55085d2", "b5c99df0-9bcc-4d03-a2ad-f333c254363b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9203ca31-8ab3-4e98-bdfa-b48bd4ca0d13", "130629c5-7a35-4261-841e-4973158a9795" });
        }
    }
}
