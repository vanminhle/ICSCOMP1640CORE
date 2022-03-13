using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class AddDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01a6a1a5-1014-4ef4-b1bd-b7a69b8cfd83");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "698e8d63-9d02-4ba2-a20c-f4db1c134406", "b835ded8-dba7-495d-a213-5ff8fe02d35d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b86eab10-6e43-476a-8499-3874b7262fc2", "e40a4ae0-56ec-40ed-80c3-1d4c78f00726" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8dd9d434-e249-4fdf-8377-933f8a0ccc90", "eb10c466-9a83-4ad1-8647-0cc4fdbe0030" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "698e8d63-9d02-4ba2-a20c-f4db1c134406");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8dd9d434-e249-4fdf-8377-933f8a0ccc90");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b86eab10-6e43-476a-8499-3874b7262fc2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b835ded8-dba7-495d-a213-5ff8fe02d35d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e40a4ae0-56ec-40ed-80c3-1d4c78f00726");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb10c466-9a83-4ad1-8647-0cc4fdbe0030");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2b44bff6-5d2d-4e3a-81ff-c5ea175ec3f1", "38eef8b9-4bd7-4b1e-bc7c-34c74e7f142f", "Admin", "ADMIN" },
                    { "50be00ce-dc4d-48ae-ae7a-8b397524b7f9", "444c64d1-04d4-440e-a159-a553a633899e", "Staff", "STAFF" },
                    { "93338e14-064f-4b56-8b38-220c8c2ef486", "65a9ecb6-0022-459f-9d83-f374d90d89e8", "Coordinator", "COORDINATOR" },
                    { "64e05f80-b965-40f5-bfb9-fb6694edd457", "e3b56da4-78c7-4759-b61f-41434fea5fa5", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "43368fac-0595-4505-815f-6ff0076a2ef1", 0, null, 0, "d4af559b-d783-43cb-85c1-81ab31da88f0", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAENZuojCbrAXqPMMk+rmiNR2NtIHyzxOa9spvnX5apLNwv2dKDklHwQlhnWT6qgwy3g==", null, true, "38ddc3ed-e9fd-49ce-ae00-ac7223f70189", false, "admin@gmail.com" },
                    { "b171a751-321c-402a-b8d3-9afe9961eeba", 0, null, 0, "401b09f5-0207-4f57-8655-23593e7564d6", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBetad344IdHBwzpjvg1yED95I20ECTWFFgMh2D8/lb8JYcSAArn/2xM3wzYsCQT6g==", null, true, "f06c3592-f236-4e8a-a381-f3ef1098fa8f", false, "coordinator@gmail.com" },
                    { "5e4c31d6-8558-4f11-b49c-bb5e84adb9d5", 0, null, 0, "6490cb37-84d8-40a6-a6d5-08d433086011", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEAxDcaNXJuo0Ep+SzvWMZtjeSWVr/OF2fymWeMhK+7rkY4ZEo+sQ/WBFlPVncDvtOA==", null, true, "f0af9601-24ae-40b8-8fac-d3fc6ff2cbf1", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2b44bff6-5d2d-4e3a-81ff-c5ea175ec3f1", "43368fac-0595-4505-815f-6ff0076a2ef1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "93338e14-064f-4b56-8b38-220c8c2ef486", "b171a751-321c-402a-b8d3-9afe9961eeba" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "64e05f80-b965-40f5-bfb9-fb6694edd457", "5e4c31d6-8558-4f11-b49c-bb5e84adb9d5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "50be00ce-dc4d-48ae-ae7a-8b397524b7f9");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2b44bff6-5d2d-4e3a-81ff-c5ea175ec3f1", "43368fac-0595-4505-815f-6ff0076a2ef1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64e05f80-b965-40f5-bfb9-fb6694edd457", "5e4c31d6-8558-4f11-b49c-bb5e84adb9d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "93338e14-064f-4b56-8b38-220c8c2ef486", "b171a751-321c-402a-b8d3-9afe9961eeba" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2b44bff6-5d2d-4e3a-81ff-c5ea175ec3f1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e05f80-b965-40f5-bfb9-fb6694edd457");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93338e14-064f-4b56-8b38-220c8c2ef486");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "43368fac-0595-4505-815f-6ff0076a2ef1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5e4c31d6-8558-4f11-b49c-bb5e84adb9d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b171a751-321c-402a-b8d3-9afe9961eeba");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "698e8d63-9d02-4ba2-a20c-f4db1c134406", "dd89a420-19fe-422d-a58c-b42bbe4f002b", "Admin", "ADMIN" },
                    { "01a6a1a5-1014-4ef4-b1bd-b7a69b8cfd83", "c20800fa-983c-4fcd-9a89-b48800b96fec", "Staff", "STAFF" },
                    { "8dd9d434-e249-4fdf-8377-933f8a0ccc90", "ed77ec60-2ef2-4a5f-9b10-5cf57a21c383", "Coordinator", "COORDINATOR" },
                    { "b86eab10-6e43-476a-8499-3874b7262fc2", "ffe79a43-1ccd-4230-a366-c52e1ee06666", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "b835ded8-dba7-495d-a213-5ff8fe02d35d", 0, null, 0, "4219b429-e26a-4321-a4d1-4399e281535b", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEHssbBPv5X8v2701sWsjinVuLqvj2w0BX2SquWvXXEFmP6iaSs9anLBa3b39ZU9tRw==", null, true, "e7289d6c-319a-464d-a2f3-7b99eda1a311", false, "admin@gmail.com" },
                    { "eb10c466-9a83-4ad1-8647-0cc4fdbe0030", 0, null, 0, "ba9e865a-bef5-4ad5-b3c6-20bc31603015", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEE/TIDqim3EEMGAfqC3gQBAUFwT5xNxnSDonrw+6FlIvviE30eyDUVRTwig2xICuWA==", null, true, "214c4344-ba41-4adb-a34f-a98e1c909dd9", false, "coordinator@gmail.com" },
                    { "e40a4ae0-56ec-40ed-80c3-1d4c78f00726", 0, null, 0, "ce885f79-a32b-4b01-9e5f-6f65d86a8bdb", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEDbR6/LQyGG+8DHQVmKwWT+ywkmFly/x8KMGc/r9Wc1bN0k7ZMWhjeGevUljfSYGtw==", null, true, "811b94be-9d6b-4a62-bd1b-802bda8305bf", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "698e8d63-9d02-4ba2-a20c-f4db1c134406", "b835ded8-dba7-495d-a213-5ff8fe02d35d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8dd9d434-e249-4fdf-8377-933f8a0ccc90", "eb10c466-9a83-4ad1-8647-0cc4fdbe0030" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b86eab10-6e43-476a-8499-3874b7262fc2", "e40a4ae0-56ec-40ed-80c3-1d4c78f00726" });
        }
    }
}
