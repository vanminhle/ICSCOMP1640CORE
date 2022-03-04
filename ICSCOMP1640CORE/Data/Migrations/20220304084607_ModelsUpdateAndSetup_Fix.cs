using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Data.Migrations
{
    public partial class ModelsUpdateAndSetup_Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "6d4303a8-f50e-44cd-a05b-17045ec2f0d1", "132e0a79-8b64-415a-8b17-4e668f37d8ba", "Admin", "ADMIN" },
                    { "2c02b60c-ab34-4f25-a071-e682a909f418", "fd483147-9bf7-480c-8b27-70ac27eb3afd", "Staff", "STAFF" },
                    { "174067c2-909b-42a1-9fca-48fb048c1917", "23617c76-dc68-4e13-8e7c-54e67513df53", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "86e3f61d-3d83-481a-8a25-95c19cc449ef", 0, null, 0, "7c8030cc-9e3b-48ba-a873-0a93ac7c6e36", "User", "admin@gmail.com", true, "Administrator", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDbAnNGCgWfHAMTXnlGb223UH8nf69wtBjGXeyvtN4j/BWQkzPO2yeRxb24eQER3lw==", null, true, "956c9043-cab3-4f7b-846d-1c16cbe06c98", false, "admin@gmail.com" },
                    { "864ba14c-a8cc-4a7f-9d60-8d713552203a", 0, null, 0, "a0df6f64-25d0-444f-81e4-fd450aa8096a", "User", "coordinator@gmail.com", true, "Coordinator", false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBSE8F7+ad8RuXOWPfx3bSC5TCkmaNv6+V6wqSd3tKSTH4X4O622LtiyP9AnTPGauQ==", null, true, "e4fdd0ba-1eeb-493e-ace3-e1a10732e7fe", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6d4303a8-f50e-44cd-a05b-17045ec2f0d1", "86e3f61d-3d83-481a-8a25-95c19cc449ef" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "174067c2-909b-42a1-9fca-48fb048c1917", "864ba14c-a8cc-4a7f-9d60-8d713552203a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2c02b60c-ab34-4f25-a071-e682a909f418");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "174067c2-909b-42a1-9fca-48fb048c1917", "864ba14c-a8cc-4a7f-9d60-8d713552203a" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6d4303a8-f50e-44cd-a05b-17045ec2f0d1", "86e3f61d-3d83-481a-8a25-95c19cc449ef" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "174067c2-909b-42a1-9fca-48fb048c1917");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6d4303a8-f50e-44cd-a05b-17045ec2f0d1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "864ba14c-a8cc-4a7f-9d60-8d713552203a");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "86e3f61d-3d83-481a-8a25-95c19cc449ef");

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
    }
}
