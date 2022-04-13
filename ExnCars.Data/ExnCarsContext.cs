using ExnCars.Data.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExnCars.Data
{
    public class ExnCarsContext :DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserVehicle> UserVehicles { get; set; }

        public ExnCarsContext(DbContextOptions<ExnCarsContext> options)
            :base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-FU828I7\MSSQLSERVER01;Initial Catalog=ExnCars;Integrated Security=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserVehicle>()
                .HasKey(uv => new { uv.UserID, uv.VehicleID });
            modelBuilder.Entity<User>()
                .HasMany(u => u.Vehicles)
                .WithMany(v => v.Users);
                //.UsingEntity<UserVehicle>();
        }
    }
}
