﻿// <auto-generated />
using System;
using AircraftReservationSystem.Data.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AircraftReservationSystem.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231202151453_test")]
    partial class test
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AircraftTypeId")
                        .HasColumnType("int");

                    b.Property<int>("AirlineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AircraftTypeId");

                    b.HasIndex("AirlineId");

                    b.ToTable("Aircrafts");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.AircraftType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BusinessRows")
                        .HasColumnType("int");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("SeatLength")
                        .HasColumnType("int");

                    b.Property<int>("SeatWidth")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AircraftType");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AirportCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AirCraftId")
                        .HasColumnType("int");

                    b.Property<int>("ArrivalAirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("BusinessPrice")
                        .HasColumnType("real");

                    b.Property<int>("DepartureAirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("FligthNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDisabledFlight")
                        .HasColumnType("bit");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("AirCraftId");

                    b.HasIndex("ArrivalAirportId");

                    b.HasIndex("DepartureAirportId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.FlightClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdditionalPrice")
                        .HasColumnType("int");

                    b.Property<int>("AirlineId")
                        .HasColumnType("int");

                    b.Property<int>("Baggage")
                        .HasColumnType("int");

                    b.Property<bool>("BaggageCabin")
                        .HasColumnType("bit");

                    b.Property<bool>("HasFood")
                        .HasColumnType("bit");

                    b.Property<bool>("IsCancelable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AirlineId");

                    b.ToTable("FlightClasses");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.FlightTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightId")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoldTicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.HasIndex("SoldTicketId")
                        .IsUnique();

                    b.ToTable("FlightTickets");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.PaymentInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentTypeId")
                        .HasColumnType("int");

                    b.Property<int>("SoldTicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaymentTypeId");

                    b.HasIndex("SoldTicketId")
                        .IsUnique();

                    b.ToTable("PaymentInformation");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PaymentTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.SoldTicket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FlightClassId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerId")
                        .HasColumnType("int");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("FlightClassId");

                    b.HasIndex("PassengerId");

                    b.ToTable("SoldTickets");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Aircraft", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.AircraftType", "AircraftType")
                        .WithMany("Aircrafts")
                        .HasForeignKey("AircraftTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AircraftReservationSystem.Entity.Entities.Airline", "Airline")
                        .WithMany("Aircrafts")
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AircraftType");

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Airport", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.District", "District")
                        .WithMany("Airports")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.City", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.District", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.City", "City")
                        .WithMany("Districts")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Flight", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.Aircraft", "Aircraft")
                        .WithMany("Flights")
                        .HasForeignKey("AirCraftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AircraftReservationSystem.Entity.Entities.Airport", "ArrivalAirport")
                        .WithMany("Arrivals")
                        .HasForeignKey("ArrivalAirportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AircraftReservationSystem.Entity.Entities.Airport", "DepartureAirport")
                        .WithMany("Departures")
                        .HasForeignKey("DepartureAirportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Aircraft");

                    b.Navigation("ArrivalAirport");

                    b.Navigation("DepartureAirport");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.FlightClass", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.Airline", "Airline")
                        .WithMany("FlightClasses")
                        .HasForeignKey("AirlineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Airline");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.FlightTicket", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.Flight", "Flight")
                        .WithMany("FlightTickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AircraftReservationSystem.Entity.Entities.SoldTicket", "SoldTicket")
                        .WithOne("FlightTicket")
                        .HasForeignKey("AircraftReservationSystem.Entity.Entities.FlightTicket", "SoldTicketId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Flight");

                    b.Navigation("SoldTicket");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.PaymentInformation", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.PaymentType", "PaymentType")
                        .WithMany("PaymentInformations")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AircraftReservationSystem.Entity.Entities.SoldTicket", "SoldTicket")
                        .WithOne("PaymentInformation")
                        .HasForeignKey("AircraftReservationSystem.Entity.Entities.PaymentInformation", "SoldTicketId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PaymentType");

                    b.Navigation("SoldTicket");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.SoldTicket", b =>
                {
                    b.HasOne("AircraftReservationSystem.Entity.Entities.FlightClass", "FlightClass")
                        .WithMany("SoldTickets")
                        .HasForeignKey("FlightClassId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("AircraftReservationSystem.Entity.Entities.Passenger", "Passenger")
                        .WithMany("SoldTickets")
                        .HasForeignKey("PassengerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FlightClass");

                    b.Navigation("Passenger");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Aircraft", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.AircraftType", b =>
                {
                    b.Navigation("Aircrafts");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Airline", b =>
                {
                    b.Navigation("Aircrafts");

                    b.Navigation("FlightClasses");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Airport", b =>
                {
                    b.Navigation("Arrivals");

                    b.Navigation("Departures");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.City", b =>
                {
                    b.Navigation("Districts");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.District", b =>
                {
                    b.Navigation("Airports");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Flight", b =>
                {
                    b.Navigation("FlightTickets");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.FlightClass", b =>
                {
                    b.Navigation("SoldTickets");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.Passenger", b =>
                {
                    b.Navigation("SoldTickets");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.PaymentType", b =>
                {
                    b.Navigation("PaymentInformations");
                });

            modelBuilder.Entity("AircraftReservationSystem.Entity.Entities.SoldTicket", b =>
                {
                    b.Navigation("FlightTicket");

                    b.Navigation("PaymentInformation");
                });
#pragma warning restore 612, 618
        }
    }
}