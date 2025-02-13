using System.Drawing;
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Web.Data
    {
    public class ApplicationDbContext : IdentityDbContext
        {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
            : base(options)
            {
            }

        public DbSet<LeaveType> LeaveTypes { get; set; }

        protected override void OnModelCreating ( ModelBuilder builder )
            {
            //builder.Entity<LeaveType>(lt =>
            //{
            //    lt.HasKey(e => e.Id);
            //    lt.Property(e => e.Id)
            //        .ValueGeneratedOnAdd() // Client-side
            //        .HasDefaultValueSql("NEWID()"); // Database-side
            //}
            //);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole()
                    {
                    Id = "e27e4fb8-ce1e-4aad-ab63-1c551447c566",
                    Name = "RegularUser",
                    NormalizedName = "REGULARUSER",
                    },
                new IdentityRole()
                    {
                    Id = "824d7b4e-3ca3-4c4c-98fd-0448854fb205",
                    Name = "Supervisor",
                    NormalizedName = "SUPERVISOR",
                    },
                new IdentityRole()
                    {
                    Id = "4f7161af-f792-4596-bc5e-94d61d438455",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR",
                    }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            builder.Entity<IdentityUser>()
                .HasData(
                    new IdentityUser()
                        {
                        Id = "ac8bab34-0e3c-4c8a-b7c1-d19c13f36aa1",
                        Email = "admin@ipbses.com",
                        NormalizedEmail = "ADMIN@IPBSES.COM",
                        NormalizedUserName = "ADMIN@IPBSES.COM",
                        UserName = "admin@ipbses.com",
                        PasswordHash = hasher.HashPassword(null, "myPassword@1"),
                        EmailConfirmed = true
                        }
                );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                     RoleId = "4f7161af-f792-4596-bc5e-94d61d438455", // administrator's ID
                     UserId = "ac8bab34-0e3c-4c8a-b7c1-d19c13f36aa1",
                    }
                );

                base.OnModelCreating(builder);
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);

                optionsBuilder
                    .ConfigureWarnings(warnings =>
                    {
                        warnings.Log(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning); 

                    });
            }
        }
    }
