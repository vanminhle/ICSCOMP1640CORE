﻿using ICSCOMP1640CORE.Data.SeedData;
using ICSCOMP1640CORE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DbSet<Department> Departments { get; set; }
        public DbSet<Coordinator> Coordinators { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Staff> Staffs { get; set; }
    }
}