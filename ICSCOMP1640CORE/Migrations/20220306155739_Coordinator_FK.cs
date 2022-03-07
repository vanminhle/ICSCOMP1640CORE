using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class Coordinator_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinators_Departments_DepartmentId",
                table: "Coordinators");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ec74b906-8099-4055-8e27-3a40403b67c1");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4b34d340-ad9e-4317-9f24-c5e7b48ed1ab", "677d8338-e7fa-4e0b-92b7-f8e0c3751092" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b1438b52-a681-4da2-ad97-b43582676ffa", "bf500224-5870-4ae9-92ec-005ee2a55e40" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4b34d340-ad9e-4317-9f24-c5e7b48ed1ab");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b1438b52-a681-4da2-ad97-b43582676ffa");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "677d8338-e7fa-4e0b-92b7-f8e0c3751092");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bf500224-5870-4ae9-92ec-005ee2a55e40");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Coordinators",
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
                name: "FK_Coordinators_Departments_DepartmentId",
                table: "Coordinators",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coordinators_Departments_DepartmentId",
                table: "Coordinators");

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
                table: "Coordinators",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b1438b52-a681-4da2-ad97-b43582676ffa", "629eefdc-b3e4-4eb7-a3b2-709d3d224000", "Admin", "ADMIN" },
                    { "ec74b906-8099-4055-8e27-3a40403b67c1", "a6498b96-683f-46bb-808e-148886ed6f01", "Staff", "STAFF" },
                    { "4b34d340-ad9e-4317-9f24-c5e7b48ed1ab", "1181befe-d905-4514-ad3f-556026d4c9e3", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bf500224-5870-4ae9-92ec-005ee2a55e40", 0, null, 0, "537a3e05-56e4-41d3-8ebb-88c8696b5a9b", "User", "admin@gmail.com", true, "Administrator", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEGzhswy6+M3xnISgPM5RqbPB+ImCJUo3ahVJMoQY88E7gtUcgWSHuJrO8wxbw4n4gQ==", null, true, "fe04ea16-1643-4df6-a39f-bc1ef666939f", false, "admin@gmail.com" },
                    { "677d8338-e7fa-4e0b-92b7-f8e0c3751092", 0, null, 0, "5ceca122-7964-4849-8b33-12effa0f1d1d", "User", "coordinator@gmail.com", true, "Coordinator", false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEIgc647sA7rGZvgspbRoE930QWGrA+vrwVlE+ZPHVF+tJ1fPDEjfTC02l1XaCS7ekA==", null, true, "655dd570-eb85-44f3-bf55-e654c97bbcbe", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b1438b52-a681-4da2-ad97-b43582676ffa", "bf500224-5870-4ae9-92ec-005ee2a55e40" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4b34d340-ad9e-4317-9f24-c5e7b48ed1ab", "677d8338-e7fa-4e0b-92b7-f8e0c3751092" });

            migrationBuilder.AddForeignKey(
                name: "FK_Coordinators_Departments_DepartmentId",
                table: "Coordinators",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
