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
    public class PassengerRepository:Repository<Passenger>,IPassengerRepository
    {
        private ApplicationDbContext _db;

        public PassengerRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

		public void Update(Passenger obj)
		{
			_db.Passengers.Update(obj);
		}
        public void Delete(Passenger obj)
        {
            _db.Passengers.Remove(obj);
        }
	}
}
