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
    public class AircraftRepository:Repository<Aircraft>,IAircraftRepository
    {
        private ApplicationDbContext _db;

        public AircraftRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IQueryable<Aircraft> GetAllWithAirlineAndAircraftType()
        {
            return _db.Aircrafts.Include(a => a.Airline).Include(a=>a.AircraftType);
        }
    }
}
