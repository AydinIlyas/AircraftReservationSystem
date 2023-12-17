using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Repository
{
    public class AirportRepository:Repository<Airport>,IAirportRepository
    {
        private ApplicationDbContext _db;

        public AirportRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Airport>> GetAllAsync()
        {
            return await _db.Airports.ToListAsync();
        }
    }
}
