using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskComment> TaskComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().ToTable("TaskItems"); // Ensure the table name is "Tasks"
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<TaskComment>().ToTable("TaskComments");
            }


        // Override the OnModelCreating method to add seed data
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Seed initial data for Users
        //    modelBuilder.Entity<User>().HasData(
        //        new User { Id = 1, Username = "admin", Password = "admin123", Role = Role.Admin },
        //        new User { Id = 2, Username = "user", Password = "user123", Role = Role.User }
        //    );

        //    // Seed TaskItems and set the foreign key for AssignedToUserId
        //    modelBuilder.Entity<TaskItem>().HasData(
        //        new TaskItem { Id = 1, Title = "Sample Task", Description = "This is a sample task", AssignedToUserId = 1 }
        //    );
        //}



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User { Id = 1, Username = "admin", Password = "admin123", Role = Role.Admin },
        //        new User { Id = 2, Username = "user", Password = "user123", Role = Role.User }
        //    );
        //}
    }
}
