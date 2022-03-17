using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class AddIdeaLikeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "747a4186-cf82-4774-a330-edd4a2d4f573");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "bd5074d8-9363-4ac7-9949-daee96561485", "822b6f75-1c8a-4a34-a329-64953a584fa3" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f44424b8-a22e-4a7b-a6b0-e72582250e68", "bb9dcc6f-d34d-494f-a1b0-7ea2ea27ce41" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "67081ad7-7553-4ada-b444-eff87ba7545c", "cbaef4a6-0a13-4a4d-995b-0a034145e30b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "67081ad7-7553-4ada-b444-eff87ba7545c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd5074d8-9363-4ac7-9949-daee96561485");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f44424b8-a22e-4a7b-a6b0-e72582250e68");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "822b6f75-1c8a-4a34-a329-64953a584fa3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bb9dcc6f-d34d-494f-a1b0-7ea2ea27ce41");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cbaef4a6-0a13-4a4d-995b-0a034145e30b");

            migrationBuilder.CreateTable(
                name: "IdeaLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IdeaId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdeaId1 = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_IdeaLikes_Ideas_IdeaId1",
                        column: x => x.IdeaId1,
                        principalTable: "Ideas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_IdeaLikes_UserId",
                table: "IdeaLikes",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdeaLikes");

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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f44424b8-a22e-4a7b-a6b0-e72582250e68", "b127d220-9bc5-4970-8dc5-055ed1b99d18", "Admin", "ADMIN" },
                    { "747a4186-cf82-4774-a330-edd4a2d4f573", "4469fd34-3433-42ff-a83e-ce0229b34661", "Staff", "STAFF" },
                    { "67081ad7-7553-4ada-b444-eff87ba7545c", "3b49a451-5ef3-4528-97f7-48bd9bf65737", "Coordinator", "COORDINATOR" },
                    { "bd5074d8-9363-4ac7-9949-daee96561485", "8906df9f-31e3-4a16-8c2d-a5490c57824f", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "bb9dcc6f-d34d-494f-a1b0-7ea2ea27ce41", 0, null, 0, "1dc00d1a-9933-4906-88c3-7cb194b8e857", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEEvgjf6ykXp5kRu3a3e8B2Qkl+MB3IJclXuCmp1hwE1QJijLv/HdU8v9mTtInvToag==", null, true, "b4e3c55e-3672-49ad-8a8c-bf78e3077113", false, "admin@gmail.com" },
                    { "cbaef4a6-0a13-4a4d-995b-0a034145e30b", 0, null, 0, "53b5069c-b765-46d0-9e4f-0cd1c9c4d5c6", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEBF0/MQ/xPYsSQvAZPhwRhx90tb84WavHgdPo0C9/54LGuybSvQFabCrnTPF90fOrQ==", null, true, "73cb5696-aa8b-4431-a124-01215003e0b5", false, "coordinator@gmail.com" },
                    { "822b6f75-1c8a-4a34-a329-64953a584fa3", 0, null, 0, "d4e83ccf-30f1-4917-a26a-999d9dfd4b84", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEGpnxb3mcQuTcxSsWNZFU2FW7X6Ljv0vCB8gePhNKFfBPj/B0iHfu5OQTlWPCYYXow==", null, true, "278be987-2e12-4297-9fe3-477109e68292", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f44424b8-a22e-4a7b-a6b0-e72582250e68", "bb9dcc6f-d34d-494f-a1b0-7ea2ea27ce41" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "67081ad7-7553-4ada-b444-eff87ba7545c", "cbaef4a6-0a13-4a4d-995b-0a034145e30b" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "bd5074d8-9363-4ac7-9949-daee96561485", "822b6f75-1c8a-4a34-a329-64953a584fa3" });
        }
    }
}
