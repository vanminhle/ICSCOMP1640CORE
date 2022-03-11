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
            var managerRole = new IdentityRole()
            {
                Name = "Manager",
                NormalizedName = "MANAGER",
            };
            var coordinatorRole = new IdentityRole()
            {
                Name = "Coordinator",
                NormalizedName = "COORDINATOR",
            };
            var staffRole = new IdentityRole()
            {
                Name = "Staff",
                NormalizedName = "STAFF",
            };

            builder.Entity<IdentityRole>().HasData(
                adminRole,
                staffRole,
                coordinatorRole,
                managerRole
                );

            #endregion RoleData

            #region DepartmentData

            var adminDepartment = new Department()
            {
                Id = 1,
                Name = "Admin",
                Description = "The Administrator System"
            };
            var managerDepartment = new Department()
            {
                Id = 2,
                Name = "Manager",
                Description = "The Organization senior management"
            };

            builder.Entity<Department>().HasData(
                managerDepartment,
                adminDepartment
                );

            #endregion DepartmentData

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
                DepartmentId = 1
            };
            var manager = new User()
            {
                Email = "manager@gmail.com",
                UserName = "manager@gmail.com",
                NormalizedUserName = "manager@gmail.com".ToUpper(),
                NormalizedEmail = "manager@gmail.com".ToUpper(),
                FullName = "Manager",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Manager@123"),
                DepartmentId = 1
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
                DepartmentId = 1
            };
            builder.Entity<User>().HasData(
                admin,
                coordinator,
                manager
                );

            #endregion UserData

            #region UserRole

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = admin.Id, RoleId = adminRole.Id },
                new IdentityUserRole<string> { UserId = coordinator.Id, RoleId = coordinatorRole.Id },
                new IdentityUserRole<string> { UserId = manager.Id , RoleId = managerRole.Id }
                );

            #endregion UserRole
        }
    }
}
