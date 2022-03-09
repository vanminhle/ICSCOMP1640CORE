using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class DatabaseEntityUpdate_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f9b40a23-1a25-4379-9bf7-5e9a538aa95b");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ef5bf0d1-e08a-43ca-8b6e-4d2924317cbb", "b198c487-4103-4857-81c0-b1a41abae7e1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "629f873e-ea65-46ca-9853-13211ccec550", "c0e6ee53-1eb0-4729-861d-919042fb493e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "629f873e-ea65-46ca-9853-13211ccec550");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef5bf0d1-e08a-43ca-8b6e-4d2924317cbb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b198c487-4103-4857-81c0-b1a41abae7e1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c0e6ee53-1eb0-4729-861d-919042fb493e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13089e9a-3a5d-4985-ba6b-4e7d52f84a4a", "df564e93-f9e9-4324-b011-cd8f4be07f78", "Admin", "ADMIN" },
                    { "6bffdb91-775a-474c-bb3b-849e38057435", "8ef12dbf-8948-4f29-bf5f-63e3d4a3919a", "Staff", "STAFF" },
                    { "0a4b8387-822c-4844-bd7f-96b1d79f5020", "197843fa-68ec-438b-8c86-baf0351f667f", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e233eb1d-98e4-4aca-b23f-97d9e9631ced", 0, null, 0, "b9a4af73-1ffd-4cfb-9bc4-26341b92d1ea", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEIcAvjt7Is8iTBakhCMZogpPa9KT8KAMnZWJJsvevlCL3JKtWRfCI3Peph+PUxRfbA==", null, true, "0b40732e-fd68-4acb-84b1-4d8e24fa96a4", false, "admin@gmail.com" },
                    { "7b099584-c946-4cf5-99fb-011d2f6c5ef8", 0, null, 0, "75d41e1a-be9f-498e-aa35-269a950c5fc1", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAENFzjVVNrZRzLbaTXSF+XLYqfoT3Xw7B2SMY8XIiCX2r2STH5tTJUjc0+K/2an2kig==", null, true, "9845603a-b464-4520-81c0-a09246b09d85", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "13089e9a-3a5d-4985-ba6b-4e7d52f84a4a", "e233eb1d-98e4-4aca-b23f-97d9e9631ced" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0a4b8387-822c-4844-bd7f-96b1d79f5020", "7b099584-c946-4cf5-99fb-011d2f6c5ef8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bffdb91-775a-474c-bb3b-849e38057435");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0a4b8387-822c-4844-bd7f-96b1d79f5020", "7b099584-c946-4cf5-99fb-011d2f6c5ef8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "13089e9a-3a5d-4985-ba6b-4e7d52f84a4a", "e233eb1d-98e4-4aca-b23f-97d9e9631ced" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a4b8387-822c-4844-bd7f-96b1d79f5020");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13089e9a-3a5d-4985-ba6b-4e7d52f84a4a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b099584-c946-4cf5-99fb-011d2f6c5ef8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e233eb1d-98e4-4aca-b23f-97d9e9631ced");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "629f873e-ea65-46ca-9853-13211ccec550", "02f6b3f2-3536-4351-9bb6-92f9cf75c708", "Admin", "ADMIN" },
                    { "f9b40a23-1a25-4379-9bf7-5e9a538aa95b", "b2dbabf6-17af-466f-b9a8-b82201b70c0e", "Staff", "STAFF" },
                    { "ef5bf0d1-e08a-43ca-8b6e-4d2924317cbb", "76e0f924-3bbf-4d00-995e-27e40adedb81", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c0e6ee53-1eb0-4729-861d-919042fb493e", 0, null, 0, "8be46606-cd47-4649-bdee-74445243a28e", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEIRrRXgTmRzLf0nOzB/BZMWeGjf6qqC3LuQtVgHylaMxNNHUcYRbO6Oy3kmTFCp+QA==", null, true, "5a29e485-3b12-4f25-bddb-7f0816b44988", false, "admin@gmail.com" },
                    { "b198c487-4103-4857-81c0-b1a41abae7e1", 0, null, 0, "e048dbfd-20df-4345-be57-25752eea5b22", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEF/2L0lJPJxgA6+A0gzv5HMsuWUx6/8x6TCbvpbC3oRnVI7M9FKudQy0PCUnY12Sug==", null, true, "e46dbfbb-f308-40a2-9a41-bccc439e7478", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "629f873e-ea65-46ca-9853-13211ccec550", "c0e6ee53-1eb0-4729-861d-919042fb493e" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ef5bf0d1-e08a-43ca-8b6e-4d2924317cbb", "b198c487-4103-4857-81c0-b1a41abae7e1" });
        }
    }
}
