﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using RowiTechTask.Models;

namespace RowiTechTask.Data.DataAccess
{
    /// <summary>
    /// It needs to inherit from IdentityDbContext and not DbContext
    /// because IdentityDbContext allows us to implement logging;
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            try
            {
                var databaseCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
                if (databaseCreator != null)
                {
                    if (!databaseCreator.CanConnect()) databaseCreator.Create();
                    if (!databaseCreator.HasTables()) databaseCreator.CreateTables();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Remark> Remarks { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagTask> TagTask { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Solution> Solutions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TagTask>().HasKey(u => new { u.TaskId, u.TagId});

            modelBuilder.Entity<Models.Task>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Tasks)
                .UsingEntity<TagTask>();

            modelBuilder.Entity<PayType>().HasData(
                new PayType { Id = 1, PayTypeName = "Hourly" },
                new PayType { Id = 2, PayTypeName = "Fixed" }
                );
            modelBuilder.Entity<State>().HasData(
                new State { Id = 1, StateName = "New" },  // awaiting for an executor
                new State { Id = 2, StateName = "In Process" },
                new State { Id = 4, StateName = "Finished" },
                new State { Id = 6, StateName = "Failed" },
                new State { Id = 7, StateName = "Expired" }
                );
            
            modelBuilder.Entity<Tag>().HasData(
                new Tag { Id = 1, TagName = "C#" },
                new Tag { Id = 2, TagName = "Web" },
                new Tag { Id = 3, TagName = "JavaScript" },
                new Tag { Id = 4, TagName = "Asp.NET" },
                new Tag { Id = 5, TagName = "Real Job"}
                );
            modelBuilder.Entity<Models.Task>().HasData(
                new Models.Task
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    Amount = 2000,
                    ExpirationDate = DateTime.Now + TimeSpan.FromDays(14),
                    LongDescription = "We need to build a marketplace with admins, users, logging. Users must be able to complete tasks " +
                    "and get rewarded for them. This counts as your summer internship, pay some attention to it",
                    ShortDescription = "Marketplace with tasks",
                    PayTypeId = 1,
                    StateId = 1
                },
                new Models.Task
                {
                    Id = 2,
                    CreatedDate = DateTime.Now - TimeSpan.FromDays(1),
                    Amount = 5000,
                    ExpirationDate = DateTime.Now + TimeSpan.FromDays(13),
                    LongDescription = "My room is a mess! I need somebody to clean it up, because i wont handle it myself... You will " +
                    "get paid tho. If only i knew how to handle all of that dirty stuff",
                    ShortDescription = "I need you to clean my room",
                    PayTypeId = 2,
                    StateId = 2
                }
                );
            modelBuilder.Entity<TagTask>().HasData(
                new TagTask { TaskId = 1, TagId = 1},
                new TagTask { TaskId = 1, TagId = 2},
                new TagTask { TaskId = 1, TagId = 4},
                new TagTask { TaskId = 2, TagId = 5}
                );
        }
    }
}
