using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class FixDatabase02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Departments_DepartmentId",
                table: "Staffs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "466a5743-29a7-4a49-a105-8c33a4a818de");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d69236c7-c367-47cd-9e85-6521f77bc661", "0d1604f1-e501-4346-a2e4-c1606bcf874d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "65b3c289-880c-48ae-832a-956b322d4faf", "ca82489a-6d94-419e-bde7-ec1c67712a8d" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65b3c289-880c-48ae-832a-956b322d4faf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d69236c7-c367-47cd-9e85-6521f77bc661");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0d1604f1-e501-4346-a2e4-c1606bcf874d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca82489a-6d94-419e-bde7-ec1c67712a8d");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Staffs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Departments_DepartmentId",
                table: "Staffs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Departments_DepartmentId",
                table: "Staffs");

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

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Staffs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d69236c7-c367-47cd-9e85-6521f77bc661", "c7a4f7f7-57d4-4dd1-9a7f-00cae959a439", "Admin", "ADMIN" },
                    { "466a5743-29a7-4a49-a105-8c33a4a818de", "8639eb1e-4f77-4b7b-aa75-185d057031f0", "Staff", "STAFF" },
                    { "65b3c289-880c-48ae-832a-956b322d4faf", "57970cd7-3534-4d32-a212-67903bfbadc0", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0d1604f1-e501-4346-a2e4-c1606bcf874d", 0, null, 0, "e2cfbb2a-836e-4b79-b6a4-451199351878", "User", "admin@gmail.com", true, "Administrator", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGM48n4QchMfLnIY4cLCqsYC1pQkuo3nk0/424xPSb1L8+5YLSE7gmhEX7tpouVrcg==", null, true, "03982632-3820-4306-ad43-7465243a0537", false, "admin@gmail.com" },
                    { "ca82489a-6d94-419e-bde7-ec1c67712a8d", 0, null, 0, "44b6d895-8809-4f4e-b432-37d0a807ed9f", "User", "coordinator@gmail.com", true, "Coordinator", false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEP9ocevG3Q5UTNp+TVCMzWFaExh1GSkGFzWME6NcY/iPgAZcoMWO8nwKJsSGWro+lA==", null, true, "280e937c-31f0-4a7e-8df2-912ae9a7e51b", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d69236c7-c367-47cd-9e85-6521f77bc661", "0d1604f1-e501-4346-a2e4-c1606bcf874d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "65b3c289-880c-48ae-832a-956b322d4faf", "ca82489a-6d94-419e-bde7-ec1c67712a8d" });

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Departments_DepartmentId",
                table: "Staffs",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
