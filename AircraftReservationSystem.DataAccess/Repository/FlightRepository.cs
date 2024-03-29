﻿using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Repository
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        private ApplicationDbContext _db;

        public FlightRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<Flight> GetAllWithAdditionalNames()
        {
            return _db.Flights.Include(a => a.ArrivalAirport).Include(a => a.DepartureAirport).Include(a => a.Aircraft);
        }

        public IQueryable<Flight> SearchFlight(SearchFlight searchFlight)
        {
            return _db.Flights.Include(a => a.ArrivalAirport).Include(a => a.DepartureAirport).Where(flight => flight.DepartureAirportId == searchFlight.DepartureAirportId && flight.ArrivalAirportId == searchFlight.ArrivalAirportId&& flight.DepartureDate.Date.Equals(((DateTime)searchFlight.OutboundFlightDate).Date));
        }
    }
}
