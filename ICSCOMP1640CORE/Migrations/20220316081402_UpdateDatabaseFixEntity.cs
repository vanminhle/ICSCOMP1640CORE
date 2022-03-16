using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class UpdateDatabaseFixEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ideas_IdeaId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b0966ae-1638-4805-bcec-03df748c031a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dd6a246a-5866-473e-b2f2-26717bb5a868", "4febf72f-9a98-439e-8b6a-6ea693f4e12b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fa849b6e-d6b3-4ec4-9e7a-c0be7ba9ca26", "9a0a34fb-8026-47f3-94d5-ad25a1d57f83" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c19c500e-fa61-4cd1-95e2-16d779b559e5", "9c3211e0-b34e-4c17-8d9e-e78aa8ea5e1e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c19c500e-fa61-4cd1-95e2-16d779b559e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd6a246a-5866-473e-b2f2-26717bb5a868");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa849b6e-d6b3-4ec4-9e7a-c0be7ba9ca26");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4febf72f-9a98-439e-8b6a-6ea693f4e12b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a0a34fb-8026-47f3-94d5-ad25a1d57f83");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c3211e0-b34e-4c17-8d9e-e78aa8ea5e1e");

            migrationBuilder.AlterColumn<string>(
                name: "IdeaName",
                table: "Ideas",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<int>(
                name: "ThumbDown",
                table: "Ideas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThumbUp",
                table: "Ideas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "IdeaId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ideas_IdeaId",
                table: "Comments",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Ideas_IdeaId",
                table: "Comments");

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

            migrationBuilder.DropColumn(
                name: "ThumbDown",
                table: "Ideas");

            migrationBuilder.DropColumn(
                name: "ThumbUp",
                table: "Ideas");

            migrationBuilder.AlterColumn<string>(
                name: "IdeaName",
                table: "Ideas",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<int>(
                name: "IdeaId",
                table: "Comments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dd6a246a-5866-473e-b2f2-26717bb5a868", "ad8a8213-e433-4142-a55d-7c745cced57c", "Admin", "ADMIN" },
                    { "0b0966ae-1638-4805-bcec-03df748c031a", "6ff9917c-db58-44cc-8c03-36c7f431361f", "Staff", "STAFF" },
                    { "fa849b6e-d6b3-4ec4-9e7a-c0be7ba9ca26", "939a755b-6474-4c85-9e0d-9b51f7903125", "Coordinator", "COORDINATOR" },
                    { "c19c500e-fa61-4cd1-95e2-16d779b559e5", "111611d0-adb7-4297-ae92-3e31b2db59d4", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4febf72f-9a98-439e-8b6a-6ea693f4e12b", 0, null, 0, "64c43a31-2aad-4762-98d7-63437c662660", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEBaVlkIXZSWdQFom+D/cQuOVejolaHPStCtKtzNNoRrq+mm0Bf7KSe/+cmPqxXle8w==", null, true, "5789eb98-fef0-47bb-8559-a6f82381e967", false, "admin@gmail.com" },
                    { "9a0a34fb-8026-47f3-94d5-ad25a1d57f83", 0, null, 0, "361b68eb-9ccc-4fdf-91dd-39d379ca48a6", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEJLEAZY0Xyyjvc1rcofr6bbNJ5k2u4ZzScX/KXysVMYFhUzIGEUYw3g17uJSVFgyNA==", null, true, "5c95fe70-7abd-4819-8b46-5b91652e77da", false, "coordinator@gmail.com" },
                    { "9c3211e0-b34e-4c17-8d9e-e78aa8ea5e1e", 0, null, 0, "2d708b74-8b12-4980-a24d-22060355d8a4", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAECgSu82jETy1zr7s9Znrt0OZkZiHwl+sSUpmA6ydBi/J/kExY4KUI88QmXk2TbIyJg==", null, true, "af72aa4b-717f-456b-93d9-957f1c695335", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dd6a246a-5866-473e-b2f2-26717bb5a868", "4febf72f-9a98-439e-8b6a-6ea693f4e12b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fa849b6e-d6b3-4ec4-9e7a-c0be7ba9ca26", "9a0a34fb-8026-47f3-94d5-ad25a1d57f83" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c19c500e-fa61-4cd1-95e2-16d779b559e5", "9c3211e0-b34e-4c17-8d9e-e78aa8ea5e1e" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Ideas_IdeaId",
                table: "Comments",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
