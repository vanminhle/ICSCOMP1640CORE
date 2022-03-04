using ICSCOMP1640CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ICSCOMP1640CORE.Data.SeedData
{
    public static class UserSeed
    {
        public static void Seed(this ModelBuilder builder)
        {
            #region RoleData

            var adminRole = new IdentityRole()
            {
                Name = "Admin",
                NormalizedName = "ADMIN",
            };
            var staffRole = new IdentityRole()
            {
                Name = "Staff",
                NormalizedName = "STAFF",
            };
            var coordinatorRole = new IdentityRole()
            {
                Name = "Coordinator",
                NormalizedName = "COORDINATOR",
            };

            builder.Entity<IdentityRole>().HasData(
                adminRole,
                staffRole,
                coordinatorRole
                );

            #endregion RoleData

            #region UserData

            var hasher = new PasswordHasher<User>();
            var admin = new User()
            {
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                NormalizedUserName = "Admin@gmail.com".ToUpper(),
                NormalizedEmail = "Admin@gmail.com".ToUpper(),
                FullName = "Administrator",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
            };
            var coordinator = new User()
            {
                Email = "coordinator@gmail.com",
                UserName = "coordinator@gmail.com",
                NormalizedUserName = "coordinator@gmail.com".ToUpper(),
                NormalizedEmail = "coordinator@gmail.com".ToUpper(),
                FullName = "Coordinator",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Coordinator@123"),
            };
            builder.Entity<User>().HasData(
                admin,
                coordinator
                );

            #endregion UserData

            #region UserRole

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = admin.Id, RoleId = adminRole.Id },
                new IdentityUserRole<string> { UserId = coordinator.Id, RoleId = coordinatorRole.Id }
                );

            #endregion UserRole
        }
    }
}
