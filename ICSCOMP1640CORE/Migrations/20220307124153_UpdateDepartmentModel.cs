using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class UpdateDepartmentModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "09b9fd50-45dd-45ed-b369-2e25e8e7ac41");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "40ebc0ae-29f2-4994-aafb-8917b573d7b6", "438f6e4c-624e-483c-8d7a-29231788273c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0e3011cb-e29f-4677-95af-180a90b8cc8c", "dc7ab08a-d7c4-4793-b2ff-8312d9f6b7db" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e3011cb-e29f-4677-95af-180a90b8cc8c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40ebc0ae-29f2-4994-aafb-8917b573d7b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "438f6e4c-624e-483c-8d7a-29231788273c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc7ab08a-d7c4-4793-b2ff-8312d9f6b7db");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6957eaaf-5ccf-4d5d-8095-f62f79baa402", "47de875b-ae19-45a8-b47c-7ebdcf67db0b", "Admin", "ADMIN" },
                    { "4be3d120-e729-426b-968e-c06b563cedcd", "ca0f7591-f67c-452a-b432-4c7c4090487c", "Staff", "STAFF" },
                    { "55d76a9a-a81d-49a5-b063-02bb8aa079e1", "c7043d96-e2b4-4e77-8e95-4aa3dc6423e9", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "af5997e3-f7b9-4580-84cd-37e4567859a7", 0, null, 0, "f21f6587-e740-4048-84d3-4ced590ac877", "User", "admin@gmail.com", true, "Administrator", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEIVd6PgwqwiUngGZBcgnO2SWbABAQvh0lPKsqOPzysyrTbdW87kc8O705JJR3Rr/hw==", null, true, "6e21e384-4edb-4df3-bab6-8caa179cfe83", false, "admin@gmail.com" },
                    { "cdc27f1c-3b0b-4dab-a7f4-4f00ae8b598c", 0, null, 0, "925bf353-6391-46bc-83db-c383640aed42", "User", "coordinator@gmail.com", true, "Coordinator", false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEErH1vR4PjSfiyxgkuWLTF525waEpi3xxHpEeC+Hsk2CPiwZODyATfSX5s8QOkn2Ug==", null, true, "3cabf58b-d2df-4492-968d-1d4164e98d42", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6957eaaf-5ccf-4d5d-8095-f62f79baa402", "af5997e3-f7b9-4580-84cd-37e4567859a7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "55d76a9a-a81d-49a5-b063-02bb8aa079e1", "cdc27f1c-3b0b-4dab-a7f4-4f00ae8b598c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4be3d120-e729-426b-968e-c06b563cedcd");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6957eaaf-5ccf-4d5d-8095-f62f79baa402", "af5997e3-f7b9-4580-84cd-37e4567859a7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "55d76a9a-a81d-49a5-b063-02bb8aa079e1", "cdc27f1c-3b0b-4dab-a7f4-4f00ae8b598c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55d76a9a-a81d-49a5-b063-02bb8aa079e1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6957eaaf-5ccf-4d5d-8095-f62f79baa402");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af5997e3-f7b9-4580-84cd-37e4567859a7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cdc27f1c-3b0b-4dab-a7f4-4f00ae8b598c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "40ebc0ae-29f2-4994-aafb-8917b573d7b6", "6c60fc86-9841-4b3e-9618-9b0aaab4d655", "Admin", "ADMIN" },
                    { "09b9fd50-45dd-45ed-b369-2e25e8e7ac41", "b53a7b40-8b4a-4030-99a9-531fba1962dc", "Staff", "STAFF" },
                    { "0e3011cb-e29f-4677-95af-180a90b8cc8c", "313f2808-881f-43ff-9c65-3384fcc28b7e", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "438f6e4c-624e-483c-8d7a-29231788273c", 0, null, 0, "9ee749da-fa36-4032-9c4e-25a88e08ecb9", "User", "admin@gmail.com", true, "Administrator", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEA8/9YOYTcT2mFUZKwFik7xsKAo8nNz5ICXXN1hgb2JgzUQe/2E8gvud5fwk2qgdhQ==", null, true, "2438bcdf-8833-414c-b3bb-8c106f032919", false, "admin@gmail.com" },
                    { "dc7ab08a-d7c4-4793-b2ff-8312d9f6b7db", 0, null, 0, "9b541107-2db5-45d5-9f86-9d2f8f5f863f", "User", "coordinator@gmail.com", true, "Coordinator", false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEPrG9Y7Ru4tUrpDRpSfGDMoTG8ktCKAC7UK3fRq5rloF+z+Nh8el6B6TswKFj8sU5w==", null, true, "3b74d89f-ca2c-46be-a24b-f4bcca38a9e7", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "40ebc0ae-29f2-4994-aafb-8917b573d7b6", "438f6e4c-624e-483c-8d7a-29231788273c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0e3011cb-e29f-4677-95af-180a90b8cc8c", "dc7ab08a-d7c4-4793-b2ff-8312d9f6b7db" });
        }
    }
}
