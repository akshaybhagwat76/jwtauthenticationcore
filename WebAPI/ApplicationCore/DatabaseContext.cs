using ApplicationCore.SeedData;
using DomainModels.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore
{
    public class DatabaseContext : IdentityDbContext<User, Role, int>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
     
        public DbSet<Class> Classes { get; set; }
        public DbSet<Center> Centers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Menus> Menus { get; set; }
        public DbSet<SubMenus> SubMenus { get; set; }
        public DbSet<Location> Locations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
