using Assignment3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment3.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<ContactModel>()
            //    .Property(c => c.FirstName)
            //    .HasColumnType("varchar");

            //builder.Entity<ContactModel>()
            //    .Property(c => c.LastName)
            //    .HasColumnType("varchar");

            //builder.Entity<ContactModel>()
            //    .Property(c => c.Email)
            //    .HasColumnType("varchar");

            //builder.Entity<ContactModel>()
            //    .Property(c => c.Phone)
            //    .HasColumnType("varchar");

            //builder.Entity<ContactModel>()
            //    .Property(c => c.PostalCode)
            //    .HasColumnType("varchar");


            //builder.Entity<ContactModel>()
            //    .Property(c => c.Topic)
            //    .HasColumnType("varchar");

            //builder.Entity<ContactModel>()
            //    .Property(c => c.Comments)
            //    .HasColumnType("varchar");


            //builder.Entity<ContactModel>()
            //    .Property(c => c.CreationDate)
            //    .HasColumnType("datetime");





        }
    }
}
