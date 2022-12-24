using Common.Enums;
using Entities.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DataContext
{
    public class MyAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<SupportRequestMessages> SupportRequestMessages { get; set; }
        public DbSet<Report> Reports { get; set; }

        public MyAppDbContext(DbContextOptions<MyAppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().HasKey(k => k.Id);
            builder.Entity<User>().HasAlternateKey(ak => ak.Email);
            builder.Entity<SupportRequest>().HasKey(k => k.Id);
            builder.Entity<SupportRequestMessages>().HasKey(k => k.Id);
            builder.Entity<Report>().HasKey(k => k.Id);
            builder.Entity<Report>().HasAlternateKey(ak => ak.PublicId);

            builder.Entity<User>().HasMany(d => d.Requests)
                .WithOne(d => d.User).HasForeignKey(k => k.UserId);
            builder.Entity<SupportRequest>().HasMany(d => d.Messages)
                .WithOne(d => d.SupportRequest).HasForeignKey(k => k.RequestId);
            
            var user = new User
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Adamson",
                Email = "adamson@mail.com",
                Role = RoleTypes.User,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var admin = new User
            {
                Id = 2,
                FirstName = "Bob",
                LastName = "Admin",
                Email = "admin@mail.com",
                Role = RoleTypes.Admin,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            var password = new PasswordHasher<User>().HashPassword(user, "mypassword1234");
            user.Password = password;

            var adminPassword = new PasswordHasher<User>().HashPassword(admin, "admin1234");
            admin.Password = adminPassword;

            builder.Entity<User>().HasData(user, admin);

            builder.Entity<SupportRequest>().HasData(new SupportRequest 
            {
            Id = 1,
            UserId = user.Id,
            IssueDescription = "Some Issue",
            UrgencyLevel = UrgencyTypes.Medium,
            DueDate = DateTime.Now,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now,
            Status = RequestStatusTypes.Closed,
            StatusDetails = "Test Data",
            IssueType = IssueTypes.ConnectionProblems,
            IssueSubject = "Some connection problems"
            });
        }
    }
}
