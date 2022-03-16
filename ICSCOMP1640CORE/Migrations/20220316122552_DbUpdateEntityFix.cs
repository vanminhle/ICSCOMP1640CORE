using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class DbUpdateEntityFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e8b5c19-74d2-443c-96b0-081af6638228");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "0a1b124c-4b3d-48fb-a040-d49931814519", "aff4db75-42d7-4723-a2fc-f9f10e5dcad8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b00c0443-9a8a-4c99-932e-815d44becc53", "ea7672a0-3eca-41ac-ba9e-c312d9c0080c" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f96d0ec8-ae27-42ed-bf14-b81023f335c1", "ec2038b6-9a66-466c-83a6-c098473594a7" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0a1b124c-4b3d-48fb-a040-d49931814519");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b00c0443-9a8a-4c99-932e-815d44becc53");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f96d0ec8-ae27-42ed-bf14-b81023f335c1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aff4db75-42d7-4723-a2fc-f9f10e5dcad8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ea7672a0-3eca-41ac-ba9e-c312d9c0080c");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec2038b6-9a66-466c-83a6-c098473594a7");

            migrationBuilder.AddColumn<bool>(
                name: "IsAssignedCoordinator",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ff0923ff-2290-47d4-8d0e-7138f75fbdc0", "d76980a0-ce4c-45d2-bdd5-0c7462ce57de", "Admin", "ADMIN" },
                    { "e4d93d88-3503-4eaf-bbdf-e48d772a18fa", "da7177fd-a509-4a8a-bd36-03e2acb0753d", "Staff", "STAFF" },
                    { "4d1d462e-b637-4b8b-8abc-88e000697199", "9e9d052d-79ac-480e-a793-b74da3f86971", "Coordinator", "COORDINATOR" },
                    { "839acb37-4119-4f43-bd1b-3bd3b314d7d2", "90505df3-2f7f-4a8b-919d-a8c53195be16", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "3fa866dd-cc93-4fb5-bf34-83a2c90ccc91", 0, null, 0, "94c1f509-1d47-443b-83bd-a47d87c86196", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEC8CYuu/0DSjneFezu336oOYHz6Ru0YRwc5Ni/vsLsPQQEskZM3yCS3YsbQrGx6RuQ==", null, true, "5918cb8f-fefd-469e-a172-c0b19ecbc831", false, "admin@gmail.com" },
                    { "32f0dade-d3d2-41be-bf86-b2217861518d", 0, null, 0, "eaaf8c85-2575-49c1-b981-ada68fade673", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEP0OPqgksOv0pwMdma44N7IWYMursA6m26Ya2KM1eq/o3aNxBkjDA/Y/NedZUxpu8w==", null, true, "fb8515c6-669a-4486-a12f-64c51f96b748", false, "coordinator@gmail.com" },
                    { "152cb4f3-7f66-4f8f-90c6-0fc7095fb557", 0, null, 0, "9f626fc3-dc39-4e10-9b51-10dbf4edf083", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEC2alrag+RgQR5yjv4/taxvZFxVYUhqmAKHnbRqtxriTYn5Hr95eIt/opzhJhV7taw==", null, true, "f3a1b658-547e-4590-99cb-9c03eb788e00", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ff0923ff-2290-47d4-8d0e-7138f75fbdc0", "3fa866dd-cc93-4fb5-bf34-83a2c90ccc91" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "4d1d462e-b637-4b8b-8abc-88e000697199", "32f0dade-d3d2-41be-bf86-b2217861518d" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "839acb37-4119-4f43-bd1b-3bd3b314d7d2", "152cb4f3-7f66-4f8f-90c6-0fc7095fb557" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e4d93d88-3503-4eaf-bbdf-e48d772a18fa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "839acb37-4119-4f43-bd1b-3bd3b314d7d2", "152cb4f3-7f66-4f8f-90c6-0fc7095fb557" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "4d1d462e-b637-4b8b-8abc-88e000697199", "32f0dade-d3d2-41be-bf86-b2217861518d" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ff0923ff-2290-47d4-8d0e-7138f75fbdc0", "3fa866dd-cc93-4fb5-bf34-83a2c90ccc91" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4d1d462e-b637-4b8b-8abc-88e000697199");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "839acb37-4119-4f43-bd1b-3bd3b314d7d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff0923ff-2290-47d4-8d0e-7138f75fbdc0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "152cb4f3-7f66-4f8f-90c6-0fc7095fb557");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "32f0dade-d3d2-41be-bf86-b2217861518d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3fa866dd-cc93-4fb5-bf34-83a2c90ccc91");

            migrationBuilder.DropColumn(
                name: "IsAssignedCoordinator",
                table: "Departments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f96d0ec8-ae27-42ed-bf14-b81023f335c1", "67f15bc4-a140-4d0f-b3bb-0372ac499d38", "Admin", "ADMIN" },
                    { "6e8b5c19-74d2-443c-96b0-081af6638228", "bb4452fc-d741-41a4-b09f-f3757b09cb00", "Staff", "STAFF" },
                    { "b00c0443-9a8a-4c99-932e-815d44becc53", "b3fa2a5b-7070-4202-b92c-9501eb0fe208", "Coordinator", "COORDINATOR" },
                    { "0a1b124c-4b3d-48fb-a040-d49931814519", "79a43cb5-3341-4b6e-82fa-3a5e0d34c8b5", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "ec2038b6-9a66-466c-83a6-c098473594a7", 0, null, 0, "447cf80e-0df5-4487-b6ec-66a4943dee50", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAECQgj/zPbkZxQhHaBiwYo7C8h9s3Da/4XYO8ptpd353mtPDMfUWd9K36Y8x+/kfgdA==", null, true, "068b2432-f324-4003-a000-778d213d6887", false, "admin@gmail.com" },
                    { "ea7672a0-3eca-41ac-ba9e-c312d9c0080c", 0, null, 0, "f5d7b54a-f38e-4e1d-8ba4-e695c295ec5d", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAENphZkFCiuzct1CK7Q1yRUYBcpsT8HBsjWUR3duSibMRQOCJEHo6Mxy6fEamT5SPyw==", null, true, "f960ac89-746e-4f26-85a0-f42ea2d7fee2", false, "coordinator@gmail.com" },
                    { "aff4db75-42d7-4723-a2fc-f9f10e5dcad8", 0, null, 0, "5592514b-da87-4488-9492-a815a5e0a303", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEMPpgRY1JRlZZAZPJhT0xss2w+wROlkpBTjh7kqZQHusKtUWhkz2VaHd5Qp45SwCCA==", null, true, "8323bff0-2ab1-452a-b1b0-65e3e95a2566", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f96d0ec8-ae27-42ed-bf14-b81023f335c1", "ec2038b6-9a66-466c-83a6-c098473594a7" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b00c0443-9a8a-4c99-932e-815d44becc53", "ea7672a0-3eca-41ac-ba9e-c312d9c0080c" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "0a1b124c-4b3d-48fb-a040-d49931814519", "aff4db75-42d7-4723-a2fc-f9f10e5dcad8" });
        }
    }
}
