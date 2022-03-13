using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class UpdateIdeaDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsAnonymous",
                table: "Ideas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "73b65350-d464-4a29-af79-5df1ea5b6f3d", "d0e3c9f2-5dfe-4475-bd51-62c04d56d556", "Admin", "ADMIN" },
                    { "96eb9e5b-62f1-4144-84d0-535b156900f2", "b2d43420-5c38-44df-a52a-953578c70d88", "Staff", "STAFF" },
                    { "82a66618-41a4-4da9-8063-f9ea4dd27090", "a3264fbf-9732-4c74-b046-2ed9ac7fda47", "Coordinator", "COORDINATOR" },
                    { "3658de35-08b4-4b1b-9417-72a4c008bf61", "edc46dd1-4b3d-402e-80ed-fc7c02f0086c", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "39cf40b9-82e4-49d4-8288-7c29c8f2e090", 0, null, 0, "c10483c2-1f4f-48a0-ae44-4ac842075094", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEFUo8wdM7+Or9sLEmklDTVy9WX31wOAa8c/et/XHV1QjVjk/1g2+E6HBjcnrEpTOJg==", null, true, "62821388-bc60-4c5f-b556-fcca67fc3e41", false, "admin@gmail.com" },
                    { "ae89a5b5-1379-4301-90ed-628479d0a76d", 0, null, 0, "8f6f52be-dbd5-45f2-a59b-9ea850553f1c", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEHkxvan78JUHUhm3GaWkq/fwets+x8Xx5FMvn6oJ2DTgus0NCvIeCMVvWugvx71xrw==", null, true, "804cb2e6-12af-4b36-89b9-f5ac9ae703b1", false, "coordinator@gmail.com" },
                    { "35f1f368-132c-4501-ad65-074223fd5a4e", 0, null, 0, "2cabcf3c-9ca3-4629-b8a9-020519305122", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEOk4ZNsgqVfZGNuf9m5wgJBAJgbAXRWlZn4mcqhlkIeGkjVAFmKVnI+x/Iv5AfcWTg==", null, true, "abaca5b3-5673-4d0e-87e5-89365158bd60", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "73b65350-d464-4a29-af79-5df1ea5b6f3d", "39cf40b9-82e4-49d4-8288-7c29c8f2e090" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "82a66618-41a4-4da9-8063-f9ea4dd27090", "ae89a5b5-1379-4301-90ed-628479d0a76d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3658de35-08b4-4b1b-9417-72a4c008bf61", "35f1f368-132c-4501-ad65-074223fd5a4e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96eb9e5b-62f1-4144-84d0-535b156900f2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3658de35-08b4-4b1b-9417-72a4c008bf61", "35f1f368-132c-4501-ad65-074223fd5a4e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "73b65350-d464-4a29-af79-5df1ea5b6f3d", "39cf40b9-82e4-49d4-8288-7c29c8f2e090" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82a66618-41a4-4da9-8063-f9ea4dd27090", "ae89a5b5-1379-4301-90ed-628479d0a76d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3658de35-08b4-4b1b-9417-72a4c008bf61");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73b65350-d464-4a29-af79-5df1ea5b6f3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82a66618-41a4-4da9-8063-f9ea4dd27090");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "35f1f368-132c-4501-ad65-074223fd5a4e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39cf40b9-82e4-49d4-8288-7c29c8f2e090");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ae89a5b5-1379-4301-90ed-628479d0a76d");

            migrationBuilder.DropColumn(
                name: "IsAnonymous",
                table: "Ideas");

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
    }
}
