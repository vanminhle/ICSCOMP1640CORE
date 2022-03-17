using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class UpdateNewDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaLikes");

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

            migrationBuilder.CreateTable(
                name: "UserActionOnIdeas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdeaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserActionOnIdeas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserActionOnIdeas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserActionOnIdeas_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9d565ffa-9340-4e7f-94bb-7180849cfd53", "b1370c6c-aafe-424f-96d6-131c96a9f247", "Admin", "ADMIN" },
                    { "dbe32ca8-518b-4069-9e2b-ae863208a5a3", "989366a4-2a19-4193-8292-d2638506aaff", "Staff", "STAFF" },
                    { "59eb4c96-3167-4138-aab7-e1f50a101db2", "547542c2-5ef7-40b9-bd4c-48c27c42a9d6", "Coordinator", "COORDINATOR" },
                    { "92bb09d6-0ecd-45b6-b4d6-6e099e1e0a43", "565590b8-a1d9-425c-b16e-7f8d433f5dcd", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "c21dcab6-789c-44d8-96b9-4a4c32508b84", 0, null, 0, "35340345-5d80-4406-9028-92818cf25904", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEBTM5BvY7jrwfwComZ3qNoYYN+68+P3RZ9quYJeQ1jkG26PWxr8OX1Y7GYf4PvmdfA==", null, true, "32c09688-50f5-49f4-a962-51bd514c214c", false, "admin@gmail.com" },
                    { "67b05e1c-d4e6-4a8e-9124-cae2faac23f5", 0, null, 0, "8335f65a-7511-4013-b362-519177b73cb5", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEFjVG+DaYWajwag6NcOk5Mbk+IuqfTvO1VJTrvRLZXR+HrYCkgDFG6GKQRlppdxsmg==", null, true, "d236319e-73a6-4c13-a356-859577c114af", false, "coordinator@gmail.com" },
                    { "e2ac72a5-1fdd-4d96-839a-6f8df8f3da46", 0, null, 0, "f65a73a6-01bb-4ee1-8f8a-9fc604bfbdd6", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEPSAAhG/KCEuNS+HZD2+BgpNowZaZc0y/XokhnWpcY2uD60mh39MBKa+UOhQk0kSIw==", null, true, "ae0c44d2-e0c6-48ab-869c-acef7c9bc911", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "9d565ffa-9340-4e7f-94bb-7180849cfd53", "c21dcab6-789c-44d8-96b9-4a4c32508b84" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "59eb4c96-3167-4138-aab7-e1f50a101db2", "67b05e1c-d4e6-4a8e-9124-cae2faac23f5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "92bb09d6-0ecd-45b6-b4d6-6e099e1e0a43", "e2ac72a5-1fdd-4d96-839a-6f8df8f3da46" });

            migrationBuilder.CreateIndex(
                name: "IX_UserActionOnIdeas_IdeaId",
                table: "UserActionOnIdeas",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_UserActionOnIdeas_UserId",
                table: "UserActionOnIdeas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserActionOnIdeas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dbe32ca8-518b-4069-9e2b-ae863208a5a3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "59eb4c96-3167-4138-aab7-e1f50a101db2", "67b05e1c-d4e6-4a8e-9124-cae2faac23f5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "9d565ffa-9340-4e7f-94bb-7180849cfd53", "c21dcab6-789c-44d8-96b9-4a4c32508b84" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "92bb09d6-0ecd-45b6-b4d6-6e099e1e0a43", "e2ac72a5-1fdd-4d96-839a-6f8df8f3da46" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "59eb4c96-3167-4138-aab7-e1f50a101db2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92bb09d6-0ecd-45b6-b4d6-6e099e1e0a43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9d565ffa-9340-4e7f-94bb-7180849cfd53");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "67b05e1c-d4e6-4a8e-9124-cae2faac23f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c21dcab6-789c-44d8-96b9-4a4c32508b84");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e2ac72a5-1fdd-4d96-839a-6f8df8f3da46");

            migrationBuilder.CreateTable(
                name: "IdeaLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdeaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdeaLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IdeaLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IdeaLikes_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_IdeaLikes_UserId",
                table: "IdeaLikes",
                column: "UserId");
        }
    }
}
