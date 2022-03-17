using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class UpdateIdeaLikeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdeaLikes_Ideas_IdeaId1",
                table: "IdeaLikes");

            migrationBuilder.DropIndex(
                name: "IX_IdeaLikes_IdeaId1",
                table: "IdeaLikes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5362add-f506-4473-ba72-1a664de2ac97");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "82a3e2c7-b8e7-4efd-8559-9152fa47c3c4", "02c599fc-9c40-425c-bea3-72c6a9fa9d33" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "cc0ca253-1baf-4b5d-8def-3e3ae9685f28", "0a4b8ddb-1ff5-4826-9b59-d222bca55a48" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "385e6a8c-72aa-4bfd-8561-29af7c301b8f", "c91a0c55-1d08-47c5-a52e-b256eac1a845" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "385e6a8c-72aa-4bfd-8561-29af7c301b8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82a3e2c7-b8e7-4efd-8559-9152fa47c3c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cc0ca253-1baf-4b5d-8def-3e3ae9685f28");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "02c599fc-9c40-425c-bea3-72c6a9fa9d33");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0a4b8ddb-1ff5-4826-9b59-d222bca55a48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c91a0c55-1d08-47c5-a52e-b256eac1a845");

            migrationBuilder.DropColumn(
                name: "IdeaId1",
                table: "IdeaLikes");

            migrationBuilder.AlterColumn<int>(
                name: "IdeaId",
                table: "IdeaLikes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2a9bc1b3-e8e7-466f-9643-b512654148ca", "2146bced-f75f-4f41-9b88-d01e00beeb90", "Admin", "ADMIN" },
                    { "9449d7f7-cbc3-4a46-86ea-87229171a291", "f8f6edfa-aa31-405b-8fb9-a6227b8567d0", "Staff", "STAFF" },
                    { "3029f888-a6de-4673-a0a2-0407e57833eb", "ab122347-dade-4c8a-98f8-3b4a95bd1a06", "Coordinator", "COORDINATOR" },
                    { "3e03677b-e61c-4e68-b747-682e75d96f93", "868b2500-6496-4e71-b25e-a33a88b75f41", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "e034c82b-0ffa-47d1-ba31-b73ddd77061b", 0, null, 0, "27fc2f9f-fb0c-4d77-a09f-54503c6f911a", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEG3Xi3rKJdjTWIFxcYPmE+UU/FZ4zEm0u2CO+k3uVpeJZs4hOw/iuQz5egwCiScawQ==", null, true, "f2d16cab-1f7b-46cf-af09-bd7a49e485df", false, "admin@gmail.com" },
                    { "fad75e99-816c-48dc-ba58-bc300e66a989", 0, null, 0, "47821688-a561-4554-83d3-4a93282f586e", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEDS4Rd5cAellQnItffk8PpMwi79GQ4davRkfUEpEOPSctaAH99CWmrcNDRFIXL/x6w==", null, true, "cc1baa71-feb2-423f-8824-bd7264dff104", false, "coordinator@gmail.com" },
                    { "f1460b1d-a35c-4a18-9e16-e4943ad4217f", 0, null, 0, "7b61559e-a5fa-48e7-9199-fdcf9d17ebe0", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEFIsrzmicb5DbKP2K5RO/gxP4OZLWm/KEQu79BvkZFORUFdFRgUCWOEQFiYxTPgsUg==", null, true, "9fe31e59-ad23-4527-ad2c-f2810b6a4830", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2a9bc1b3-e8e7-466f-9643-b512654148ca", "e034c82b-0ffa-47d1-ba31-b73ddd77061b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3029f888-a6de-4673-a0a2-0407e57833eb", "fad75e99-816c-48dc-ba58-bc300e66a989" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "3e03677b-e61c-4e68-b747-682e75d96f93", "f1460b1d-a35c-4a18-9e16-e4943ad4217f" });

            migrationBuilder.CreateIndex(
                name: "IX_IdeaLikes_IdeaId",
                table: "IdeaLikes",
                column: "IdeaId");

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaLikes_Ideas_IdeaId",
                table: "IdeaLikes",
                column: "IdeaId",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IdeaLikes_Ideas_IdeaId",
                table: "IdeaLikes");

            migrationBuilder.DropIndex(
                name: "IX_IdeaLikes_IdeaId",
                table: "IdeaLikes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9449d7f7-cbc3-4a46-86ea-87229171a291");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2a9bc1b3-e8e7-466f-9643-b512654148ca", "e034c82b-0ffa-47d1-ba31-b73ddd77061b" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3e03677b-e61c-4e68-b747-682e75d96f93", "f1460b1d-a35c-4a18-9e16-e4943ad4217f" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "3029f888-a6de-4673-a0a2-0407e57833eb", "fad75e99-816c-48dc-ba58-bc300e66a989" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a9bc1b3-e8e7-466f-9643-b512654148ca");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3029f888-a6de-4673-a0a2-0407e57833eb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e03677b-e61c-4e68-b747-682e75d96f93");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e034c82b-0ffa-47d1-ba31-b73ddd77061b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f1460b1d-a35c-4a18-9e16-e4943ad4217f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "fad75e99-816c-48dc-ba58-bc300e66a989");

            migrationBuilder.AlterColumn<string>(
                name: "IdeaId",
                table: "IdeaLikes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdeaId1",
                table: "IdeaLikes",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cc0ca253-1baf-4b5d-8def-3e3ae9685f28", "48e6314a-633d-4412-a2b3-792e42cdae83", "Admin", "ADMIN" },
                    { "b5362add-f506-4473-ba72-1a664de2ac97", "c9b139de-14ae-4712-a80d-d18250b813d5", "Staff", "STAFF" },
                    { "82a3e2c7-b8e7-4efd-8559-9152fa47c3c4", "6907fd65-d75d-49fa-8786-5b5ebe86e11a", "Coordinator", "COORDINATOR" },
                    { "385e6a8c-72aa-4bfd-8561-29af7c301b8f", "bd607b48-e5fa-4030-b5e0-96caa257f34e", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0a4b8ddb-1ff5-4826-9b59-d222bca55a48", 0, null, 0, "9296c487-ed88-4e5b-9d18-c2a3aa5d4c8e", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELQe2yLeDqXFh9oIrShkw5SDU4kMbaKVAPgSa493f2owTz81FyUHPXZLyEMW0fFXSQ==", null, true, "49b2c9d1-e8d2-4039-a218-213fa2061364", false, "admin@gmail.com" },
                    { "02c599fc-9c40-425c-bea3-72c6a9fa9d33", 0, null, 0, "d1e1bb86-abae-4888-8b7c-fb6883319858", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAENWMynpRJPGAFACA5tyE+gT5gs3FZolUgWm5I0iviHs5RL82eR05ONquyGAcrspq9Q==", null, true, "80623dd0-a763-4ec8-b2c0-6131a2473a71", false, "coordinator@gmail.com" },
                    { "c91a0c55-1d08-47c5-a52e-b256eac1a845", 0, null, 0, "da41017d-a37a-48a3-a4bb-45e1a8c62c13", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEDyV2fPxGkcDQiCl1kKuqNUkoTt0H0I/PswTnkh1Dkq6Ht7g6L6h6qe0nZtcILqfUQ==", null, true, "895bfd79-df26-4a1f-9278-d4afe6e9fe2f", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "cc0ca253-1baf-4b5d-8def-3e3ae9685f28", "0a4b8ddb-1ff5-4826-9b59-d222bca55a48" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "82a3e2c7-b8e7-4efd-8559-9152fa47c3c4", "02c599fc-9c40-425c-bea3-72c6a9fa9d33" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "385e6a8c-72aa-4bfd-8561-29af7c301b8f", "c91a0c55-1d08-47c5-a52e-b256eac1a845" });

            migrationBuilder.CreateIndex(
                name: "IX_IdeaLikes_IdeaId1",
                table: "IdeaLikes",
                column: "IdeaId1");

            migrationBuilder.AddForeignKey(
                name: "FK_IdeaLikes_Ideas_IdeaId1",
                table: "IdeaLikes",
                column: "IdeaId1",
                principalTable: "Ideas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
