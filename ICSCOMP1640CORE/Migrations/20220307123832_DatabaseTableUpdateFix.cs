using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class DatabaseTableUpdateFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c425e4a3-1141-4eab-9c49-c1f0497c2daa");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "510b0d78-e0c6-40d7-8e13-70c07e166801", "1a75bb5f-222f-41b2-adf5-e4fc5de3fddb" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "28647a06-fa41-4c9f-90d3-d81c42c66937", "a8b3b892-dc2f-491c-860c-bcc50d30c841" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "28647a06-fa41-4c9f-90d3-d81c42c66937");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "510b0d78-e0c6-40d7-8e13-70c07e166801");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a75bb5f-222f-41b2-adf5-e4fc5de3fddb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8b3b892-dc2f-491c-860c-bcc50d30c841");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Staffs_UserId",
                        column: x => x.UserId,
                        principalTable: "Staffs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ideas",
                columns: table => new
                {
                    IdeaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SubmitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdeaName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdeaContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    View = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ideas", x => x.IdeaId);
                    table.ForeignKey(
                        name: "FK_Ideas_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ideas_Staffs_UserId",
                        column: x => x.UserId,
                        principalTable: "Staffs",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepartmentsIdeas",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IdeaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentsIdeas", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_DepartmentsIdeas_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartmentsIdeas_Ideas_IdeaId",
                        column: x => x.IdeaId,
                        principalTable: "Ideas",
                        principalColumn: "IdeaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "81149706-2d19-4d69-bbad-34dd50c8c4ce", "9dc14896-5f8f-426a-afb2-25d4e28cabf6", "Admin", "ADMIN" },
                    { "30b79a9f-80ca-4bb8-9643-118bda091630", "2a4fbb72-4819-4698-8ae7-75e6062fc185", "Staff", "STAFF" },
                    { "2efabbf6-f34a-4e03-a9c4-a218999f0f57", "df1cca62-baec-49a9-8506-d39bb2f0edde", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9d06a560-2fb8-43e8-a0f8-f2d84cd0c1e1", 0, null, 0, "8da2fd3e-c04a-434a-85e7-1e64f91b1c91", "User", "admin@gmail.com", true, "Administrator", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEKDh5IKhMnBtJ2CAYP1VTQtRQCqU4VKIVY6sDZv9Ms+kBRtQjWk+5Ka99loscJsWLw==", null, true, "94bb7f4e-513d-431a-ad15-d924e61c9e08", false, "admin@gmail.com" },
                    { "76c88c76-c66f-49b8-950b-5894d1211e25", 0, null, 0, "c9a04267-984b-426f-a58b-6421d13c63ef", "User", "coordinator@gmail.com", true, "Coordinator", false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEGMzWXQVOePbeA/am4fW0MI+c0GcVIu5jxtRALFXPYxzz9PhmDKoY3SMtYddOQgP3w==", null, true, "1fd58c5d-2835-4472-b916-ad2258ae8e1f", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "81149706-2d19-4d69-bbad-34dd50c8c4ce", "9d06a560-2fb8-43e8-a0f8-f2d84cd0c1e1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "2efabbf6-f34a-4e03-a9c4-a218999f0f57", "76c88c76-c66f-49b8-950b-5894d1211e25" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentsIdeas_IdeaId",
                table: "DepartmentsIdeas",
                column: "IdeaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_CategoryId",
                table: "Ideas",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Ideas_UserId",
                table: "Ideas",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "DepartmentsIdeas");

            migrationBuilder.DropTable(
                name: "Ideas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "30b79a9f-80ca-4bb8-9643-118bda091630");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "2efabbf6-f34a-4e03-a9c4-a218999f0f57", "76c88c76-c66f-49b8-950b-5894d1211e25" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "81149706-2d19-4d69-bbad-34dd50c8c4ce", "9d06a560-2fb8-43e8-a0f8-f2d84cd0c1e1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2efabbf6-f34a-4e03-a9c4-a218999f0f57");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "81149706-2d19-4d69-bbad-34dd50c8c4ce");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "76c88c76-c66f-49b8-950b-5894d1211e25");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9d06a560-2fb8-43e8-a0f8-f2d84cd0c1e1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "510b0d78-e0c6-40d7-8e13-70c07e166801", "0a2ab6c2-b5df-44bb-8310-d5aeb9f61a9c", "Admin", "ADMIN" },
                    { "c425e4a3-1141-4eab-9c49-c1f0497c2daa", "99abad44-d56e-42f0-9cce-bf53fd5f093d", "Staff", "STAFF" },
                    { "28647a06-fa41-4c9f-90d3-d81c42c66937", "94817464-63be-43b5-bb11-0b2742803488", "Coordinator", "COORDINATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FullName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1a75bb5f-222f-41b2-adf5-e4fc5de3fddb", 0, null, 0, "69e2c0f2-874f-4e4e-8aff-2076ea4433ba", "User", "admin@gmail.com", true, "Administrator", false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEDImniKRzv581567duhnM0r9icTUlGT2OJ0WgVhx8y7jC7hpKyXyPUlOmvaWNERo9g==", null, true, "b15f8f5e-d6bb-495d-819f-c32995374e77", false, "admin@gmail.com" },
                    { "a8b3b892-dc2f-491c-860c-bcc50d30c841", 0, null, 0, "538a1e62-adf4-459d-a2a5-aa7bef32c1e0", "User", "coordinator@gmail.com", true, "Coordinator", false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEMnneh41RhD+ZSHVTC5t18Cz1oVisvz3nKXt4xUwTHQhXF5g2OJ6spDaJ1fLH+zq+w==", null, true, "34f3149a-eda9-4fab-9eff-97fce097bcb1", false, "coordinator@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "510b0d78-e0c6-40d7-8e13-70c07e166801", "1a75bb5f-222f-41b2-adf5-e4fc5de3fddb" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "28647a06-fa41-4c9f-90d3-d81c42c66937", "a8b3b892-dc2f-491c-860c-bcc50d30c841" });
        }
    }
}
