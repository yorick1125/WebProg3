using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SamuraiApp.Domain;


namespace SamuraiApp.Data
{
    public class SamuraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Battle> Battles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source= (localdb)\MSSQLLocalDB; Initial Catalog=SamuraiAppData;")
                .LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},
                LogLevel.Error);
                
            // A .mdf file will be created. The MDF file is the SQL Server Master Database File:
            // it stores users data in relational databases in the form columns, rows, fields, indexes, 
            // views, and tables.
            // The full path below is where the .mdf file will be created. Claudiu is the Windows User.
            // Optional setting: AttachDBFileName=c:\users\claudiu\SamuraiAppData.mdf
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Samurai>()
                .HasMany(s => s.Battles)
                .WithMany(s => s.Samurais)
                .UsingEntity<BattleSamurai>
                (bs => bs.HasOne<Battle>().WithMany(),
                bs => bs.HasOne<Samurai>().WithMany())
                .Property(bs => bs.Datejoined)
                .HasDefaultValueSql("getdate()");
        }

    }
}
