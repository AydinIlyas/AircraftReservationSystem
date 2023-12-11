using AircraftReservationSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<Passenger>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<FlightClass> FlightClasses { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightTicket> FlightTickets { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<PaymentInformation> PaymentInformation { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<SoldTicket> SoldTickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PaymentInformation>()
            .HasOne(pi => pi.PaymentType)
            .WithMany(pt => pt.PaymentInformations)
            .HasForeignKey(pi => pi.PaymentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoldTicket>()
            .HasOne(st => st.PaymentInformation)
            .WithOne(pi => pi.SoldTicket)
            .HasForeignKey<PaymentInformation>(pi => pi.SoldTicketId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoldTicket>()
           .HasOne(st => st.Passenger)
           .WithMany(p => p.SoldTickets)
           .HasForeignKey(p => p.PassengerId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoldTicket>()
           .HasOne(st => st.FlightClass)
           .WithMany(p => p.SoldTickets)
           .HasForeignKey(p => p.FlightClassId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SoldTicket>()
            .HasOne(st => st.FlightTicket)
            .WithOne(ft => ft.SoldTicket)
            .HasForeignKey<FlightTicket>(ft => ft.SoldTicketId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FlightTicket>()
                .HasOne(ft => ft.Flight)
                .WithMany(f => f.FlightTickets)
                .HasForeignKey(f => f.FlightId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Flight>()
            .HasOne(f => f.DepartureAirport)
            .WithMany(a => a.Departures)
            .HasForeignKey(f => f.DepartureAirportId)
            .OnDelete(DeleteBehavior.Restrict); // Deleting an Airport affects its Departures (Flights)

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.ArrivalAirport)
                .WithMany(a => a.Arrivals)
                .HasForeignKey(f => f.ArrivalAirportId)
                .OnDelete(DeleteBehavior.Restrict); // Deleting an Airport affects its Arrivals (Flights)

            modelBuilder.Entity<Flight>()
                .HasOne(f => f.DepartureAirport)
                .WithMany(a => a.Departures)
                .HasForeignKey(f => f.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict); // Deleting an Airport affects its Arrivals (Flights)

            // The following configuration is not strictly necessary but can be added for clarity
            modelBuilder.Entity<Airport>()
                .HasMany(a => a.Departures)
                .WithOne(f => f.DepartureAirport)
                .HasForeignKey(f => f.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict); // Restricting deletion of an Airport (no cascading)

            modelBuilder.Entity<Airport>()
                .HasMany(a => a.Arrivals)
                .WithOne(f => f.ArrivalAirport)
                .HasForeignKey(f => f.ArrivalAirportId)
                .OnDelete(DeleteBehavior.Restrict); // Restricting deletion of an Airport (no cascading)

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
