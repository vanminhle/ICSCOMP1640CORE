using ICSCOMP1640CORE.Data.SeedData;
using ICSCOMP1640CORE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ICSCOMP1640CORE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            UserSeed.Seed(builder);
        }
        //public DbSet<User> User { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Idea> Ideas { get; set; }

    }
}
