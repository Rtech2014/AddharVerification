using System;
using System.Collections.Generic;
using System.Text;
using AddharVerification.Controllers;
using AddharVerification.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AddharVerification.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AppUser>()
                .HasOne<Passport>(s => s.Passport)
                .WithOne(ad => ad.AppUser)
                .HasForeignKey<Passport>(ad => ad.ApplicationMemberId);


            modelBuilder.Entity<AppUser>()
            .HasOne<Visa>(s => s.Visa)
            .WithOne(ad => ad.AppUser)
            .HasForeignKey<Visa>(ad => ad.ApplicationMemberId);
        }

        public DbSet<AddharVerification.Models.Passport> Passport { get; set; }

        public DbSet<AddharVerification.Models.Visa> Visa { get; set; }
        public DbSet<AddharVerification.Models.PassportApprove> PassportApprove { get; set; }

    }
}
