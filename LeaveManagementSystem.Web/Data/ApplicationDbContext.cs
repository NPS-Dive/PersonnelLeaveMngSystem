using System.Drawing;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<LeaveType>(lt =>
        //    {
        //        lt.HasKey(e => e.Id);
        //        lt.Property(e => e.Id)
        //            .ValueGeneratedOnAdd() // Client-side
        //            .HasDefaultValueSql("NEWID()"); // Database-side
        //    }
        //    );

        //}
    }
}
