using CadViagem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadViagem.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        { }

        public DbSet<DriverViewModel> Driver { get; set; }

        public DbSet<TripViewModel> Trip { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DriverViewModel>()
                .HasMany(x => x.Trips).WithOne(x => x.Driver).HasForeignKey(x => x.DriverId);
        }
    }
}
