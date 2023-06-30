using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RowiTechTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace RowiTechTask.Data.DataAccess
{
    /// <summary>
    /// It needs to inherit from IdentityDbContext and not DbContext
    /// because IdentityDbContext allows us to implement logging;
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Remark> Remarks { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            modelBuilder.Entity<Models.Task>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Tasks);

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "User" },
                new Role { Id = 2, RoleName = "Admin" }
                );
            modelBuilder.Entity<PayType>().HasData(
                new PayType { Id = 1, PayTypeName = "Hourly" },
                new PayType { Id = 2, PayTypeName = "Fixed" }
                );
            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, StateName = "New" },  // awaiting for an executor
                new State { Id = 2, StateName = "In Process" },
                new State { Id = 3, StateName = "On Review" },
                new State { Id = 4, StateName = "Finished" },
                new State { Id = 5, StateName = "Needs Rework" },
                new State { Id = 6, StateName = "Failed" },
                new State { Id = 7, StateName = "Expired" }
                );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Timofey", LastName = "Purits", EmailAddress = "tima310103@gmail.com",
                RoleId = 2}
                );
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, TagName = "C#" },
                new Tag { Id = 2, TagName = "Web" },
                new Tag { Id = 3, TagName = "JavaScript" },
                new Tag { Id = 4, TagName = "Asp.NET" }
                );
        }
    }
}
