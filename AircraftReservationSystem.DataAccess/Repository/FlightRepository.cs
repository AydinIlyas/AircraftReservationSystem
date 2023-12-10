using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Repository
{
    public class FlightRepository:Repository<Flight>,IFlightRepository
    {
        private ApplicationDbContext _db;

        public FlightRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
