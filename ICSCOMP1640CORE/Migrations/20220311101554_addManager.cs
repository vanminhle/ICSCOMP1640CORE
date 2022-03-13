using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class addManager : Migration
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
                    { "fa134c4c-6108-4be8-b19c-a5048c9789bc", "4335663d-4ed5-4a49-a4d4-5edebbfabe34", "Admin", "ADMIN" },
                    { "28ca41cc-a19a-472e-a078-c73fdd8f8e0d", "eebaba1e-b111-4451-91d1-9117f5f4436c", "Staff", "STAFF" },
                    { "e8db632c-969b-4070-98b6-5ee765f9e992", "57917223-eb57-428c-9d2d-c229eb620685", "Coordinator", "COORDINATOR" },
                    { "12053685-2a12-48ac-a4a0-c2cae90dca8c", "5289ed7a-398d-4b04-bb30-8c0c57a82041", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "770f02dd-bde3-445a-ad23-2c5f81b4af40", 0, null, 0, "23a3be17-9651-41b9-83eb-14bbf84b4089", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEEpJfST9it8Z3I+RCVFR3aO+5OoNeE3Q8iEBS1EQQ30R7fxQKRZe2fxmRhFBPlH86g==", null, true, "51883a6c-b480-4b17-9d92-55b67a31bc86", false, "admin@gmail.com" },
                    { "670e7ffd-bf7b-488b-8ae9-4f99038a7f71", 0, null, 0, "d3cc6380-c0a6-4783-b5dd-abb4726246ab", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEGOUsFRnVEU41IsS1blCBsYAIgx98oIyFYqIjVAcUAVT1EC9UmxMsEozpi8znq3DWQ==", null, true, "4bbbe7c7-6c3b-403d-93c6-32575fefa6cd", false, "coordinator@gmail.com" },
                    { "9fa80f58-8c41-4d91-bb95-4ba3ec8444ca", 0, null, 0, "84ab2f4b-330c-46ba-b18f-08853ed9f641", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEMYd27Dog2NitR44Ubv6QCthyU3zLa2yqIxRUV7+EFV51uwU1UVbJIivz2CZMoaukw==", null, true, "662a0cc1-ca9f-4568-8fec-d435c6962149", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fa134c4c-6108-4be8-b19c-a5048c9789bc", "770f02dd-bde3-445a-ad23-2c5f81b4af40" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "e8db632c-969b-4070-98b6-5ee765f9e992", "670e7ffd-bf7b-488b-8ae9-4f99038a7f71" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "12053685-2a12-48ac-a4a0-c2cae90dca8c", "9fa80f58-8c41-4d91-bb95-4ba3ec8444ca" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28ca41cc-a19a-472e-a078-c73fdd8f8e0d");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "e8db632c-969b-4070-98b6-5ee765f9e992", "670e7ffd-bf7b-488b-8ae9-4f99038a7f71" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa134c4c-6108-4be8-b19c-a5048c9789bc", "770f02dd-bde3-445a-ad23-2c5f81b4af40" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "12053685-2a12-48ac-a4a0-c2cae90dca8c", "9fa80f58-8c41-4d91-bb95-4ba3ec8444ca" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12053685-2a12-48ac-a4a0-c2cae90dca8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8db632c-969b-4070-98b6-5ee765f9e992");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa134c4c-6108-4be8-b19c-a5048c9789bc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "670e7ffd-bf7b-488b-8ae9-4f99038a7f71");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "770f02dd-bde3-445a-ad23-2c5f81b4af40");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9fa80f58-8c41-4d91-bb95-4ba3ec8444ca");

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
