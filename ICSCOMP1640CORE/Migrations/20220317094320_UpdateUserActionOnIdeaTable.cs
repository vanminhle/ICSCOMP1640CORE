using Microsoft.EntityFrameworkCore.Migrations;

namespace ICSCOMP1640CORE.Migrations
{
    public partial class UpdateUserActionOnIdeaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f45323ae-2846-4455-810f-6b9e138ae0ce");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "386b1986-fb89-4cf0-a6ee-9e64ec94f296", "732db30e-518a-4183-a7c4-043f7dc4abb1" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ff146c33-baa7-4ff5-91fc-00ab47a916e5", "7d0db887-40b6-4db5-9c2d-1c9b499439d9" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "db576aaf-d417-4b5d-91c4-2ae4df5e0e10", "932e4f2a-8f67-4f67-b7bc-e6e4afb13e32" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "386b1986-fb89-4cf0-a6ee-9e64ec94f296");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db576aaf-d417-4b5d-91c4-2ae4df5e0e10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ff146c33-baa7-4ff5-91fc-00ab47a916e5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "732db30e-518a-4183-a7c4-043f7dc4abb1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d0db887-40b6-4db5-9c2d-1c9b499439d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "932e4f2a-8f67-4f67-b7bc-e6e4afb13e32");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "da1a02a2-aa3e-47c3-a3db-449825252401", "33042abd-56b7-41cb-a9c2-8351ae82e090", "Admin", "ADMIN" },
                    { "9002ddd6-e024-4f7e-ad7a-5ee51f302000", "36cb0489-fb32-4c24-aeb0-08bb27a21d7b", "Staff", "STAFF" },
                    { "b0a59a42-7c51-48d2-8351-93b295340e6b", "8b5948a2-3827-419b-9f95-d9622a3fac4d", "Coordinator", "COORDINATOR" },
                    { "53c7bb37-6cec-4f62-bc82-ca03aa8098d0", "b929cf3a-f08a-4d5b-bee5-b2760447ccb3", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "739c89d0-9c20-45c2-940f-bae3f1e72042", 0, null, 0, "712f1886-d048-4cee-8177-411603a1d707", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEAS8eqzFinYuWRTE5jX/IZ/SWyC2hwflRLbcAMKenVRKaGt2f7lGu1uFYn99whQ18Q==", null, true, "22e52052-c929-4080-b4c6-6722c588a25a", false, "admin@gmail.com" },
                    { "1d38ab96-e3cb-4666-a65c-7ed42fd4a6d5", 0, null, 0, "2b8626fb-7528-4da9-940d-87bcbc2d61ce", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEAusiESTU5Ttnrg8yhH8mi5A0DEnRp/0RN6x3lwJF+LY0Rlk46zciTS+IsNWFeNlBQ==", null, true, "8d294112-f8ed-4220-81fb-650e84b5d7ef", false, "coordinator@gmail.com" },
                    { "bef42414-1618-4b16-8c56-f2034693382b", 0, null, 0, "455b1ae3-a4dc-404d-96ac-bbb52f109dad", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEPXymX+caNfMNgf3sWMsP60aNfLcThrxKIXsTFsyNUu4Dfc/B9DS6u1iqAG/Hlzh3A==", null, true, "f4da78da-0ba3-465a-a8bd-033654a16b47", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "da1a02a2-aa3e-47c3-a3db-449825252401", "739c89d0-9c20-45c2-940f-bae3f1e72042" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b0a59a42-7c51-48d2-8351-93b295340e6b", "1d38ab96-e3cb-4666-a65c-7ed42fd4a6d5" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "53c7bb37-6cec-4f62-bc82-ca03aa8098d0", "bef42414-1618-4b16-8c56-f2034693382b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9002ddd6-e024-4f7e-ad7a-5ee51f302000");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b0a59a42-7c51-48d2-8351-93b295340e6b", "1d38ab96-e3cb-4666-a65c-7ed42fd4a6d5" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "da1a02a2-aa3e-47c3-a3db-449825252401", "739c89d0-9c20-45c2-940f-bae3f1e72042" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "53c7bb37-6cec-4f62-bc82-ca03aa8098d0", "bef42414-1618-4b16-8c56-f2034693382b" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53c7bb37-6cec-4f62-bc82-ca03aa8098d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b0a59a42-7c51-48d2-8351-93b295340e6b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "da1a02a2-aa3e-47c3-a3db-449825252401");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1d38ab96-e3cb-4666-a65c-7ed42fd4a6d5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "739c89d0-9c20-45c2-940f-bae3f1e72042");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bef42414-1618-4b16-8c56-f2034693382b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ff146c33-baa7-4ff5-91fc-00ab47a916e5", "c265673b-a506-4104-9f3a-d2cd2c248986", "Admin", "ADMIN" },
                    { "f45323ae-2846-4455-810f-6b9e138ae0ce", "e663ae41-8607-4f9c-8eb1-97e55cdb6df5", "Staff", "STAFF" },
                    { "db576aaf-d417-4b5d-91c4-2ae4df5e0e10", "c8a42e71-76d7-460a-9837-f79fef53be89", "Coordinator", "COORDINATOR" },
                    { "386b1986-fb89-4cf0-a6ee-9e64ec94f296", "b122391c-0504-4a24-a550-8d44f1d44e9c", "Manager", "MANAGER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "Age", "ConcurrencyStamp", "DepartmentId", "Discriminator", "Email", "EmailConfirmed", "FullName", "Gender", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "7d0db887-40b6-4db5-9c2d-1c9b499439d9", 0, null, 0, "d8fc3871-96a1-4321-93b2-c52cce569dde", 1, "User", "admin@gmail.com", true, "Administrator", null, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEG3B8yuN1Y0l+RsHfNZaj0w69Nv4ARl+MBpn02YjJIcE2zFrSDhDkmKHanhIZrn4pQ==", null, true, "95d274ca-553a-4a30-84d7-22e6566ebb71", false, "admin@gmail.com" },
                    { "932e4f2a-8f67-4f67-b7bc-e6e4afb13e32", 0, null, 0, "fdd5c69d-099f-433c-85c1-5d35b52c06b5", 1, "User", "coordinator@gmail.com", true, "Coordinator", null, false, null, "COORDINATOR@GMAIL.COM", "COORDINATOR@GMAIL.COM", "AQAAAAEAACcQAAAAEFBV4UI7QtrRq2t3d0VDjl1aqeCee8hcYRso8Qrh3t9s7t2IApekkhTt/KT1hUSvDg==", null, true, "293d534c-9e18-49b0-b3fe-ccf73b71480b", false, "coordinator@gmail.com" },
                    { "732db30e-518a-4183-a7c4-043f7dc4abb1", 0, null, 0, "7094f398-d1f0-404e-8ec4-f0657d1ee5b9", 1, "User", "manager@gmail.com", true, "Manager", null, false, null, "MANAGER@GMAIL.COM", "MANAGER@GMAIL.COM", "AQAAAAEAACcQAAAAEOlYHoZesMRsb5sT84dSLSyABMnHw/51gYT9qhwbnZP9/o7XiM90Q8xyqdKCnTWb5g==", null, true, "a3b39ee9-004d-4643-9793-8f3ec061e0bf", false, "manager@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ff146c33-baa7-4ff5-91fc-00ab47a916e5", "7d0db887-40b6-4db5-9c2d-1c9b499439d9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "db576aaf-d417-4b5d-91c4-2ae4df5e0e10", "932e4f2a-8f67-4f67-b7bc-e6e4afb13e32" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "386b1986-fb89-4cf0-a6ee-9e64ec94f296", "732db30e-518a-4183-a7c4-043f7dc4abb1" });
        }
    }
}
