using AM.ApplicationCore.domain;
using AM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=FenniraMoetezBellahDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Flight> Flights{ get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Plane> Planes{ get; set; }
        public DbSet<Staff> Staffes { get; set; }
        public DbSet<Traveller> travellers { get; set; }
        //tp4 Q6
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

            modelBuilder.ApplyConfiguration(new FlightConfiguration());

            //tp4 Q8
            //modelBuilder.Entity<Plane>().HasKey(p => p.PlaneId);
            //modelBuilder.Entity<Plane>().ToTable("MyPlane");
            //modelBuilder.Entity<Plane>().Property(p => p.Capacity).HasColumnName("PlaneCapacity");

            //Tp4 Q14
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

            //tp5 Q2
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            //tp5 Q6
            modelBuilder.ApplyConfiguration(new TicketConfiguration());
        }
        //tp4 Q9
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
            //configurationBuilder.Properties<String>().HaveMaxLength(20);
        }
        

    }
}
