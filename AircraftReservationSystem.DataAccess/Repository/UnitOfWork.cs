using AircraftReservationSystem.DataAccess.Data;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Aircraft = new AircraftRepository(_db);
            AircraftType = new AircraftTypeRepository(_db);
            Airline = new AirlineRepository(_db);
            Airport = new AirportRepository(_db);
            City = new CityRepository(_db);
            Country = new CountryRepository(_db);
            District = new DistrictRepository(_db);
            FlightClass = new FlightClassRepository(_db);
            Flight = new FlightRepository(_db);
            FlightTicket = new FlightTicketRepository(_db);
            Passenger = new PassengerRepository(_db);
            PaymentInformation = new PaymentInformationRepository(_db);
            PaymentType = new PaymentTypeRepository(_db);
            SoldTicket = new SoldTicketRepository(_db);
        }

        public IAircraftRepository Aircraft { get; private set; }

        public IAircraftTypeRepository AircraftType { get; private set; }

        public IAirlineRepository Airline { get; private set; }

        public IAirportRepository Airport { get; private set; }

        public ICityRepository City { get; private set; }

        public ICountryRepository Country { get; private set; }

        public IDistrictRepository District { get; private set; }

        public IFlightClassRepository FlightClass { get; private set; }

        public IFlightRepository Flight { get; private set; }

        public IFlightTicketRepository FlightTicket { get; private set; }

        public IPassengerRepository Passenger { get; private set; }

        public IPaymentInformationRepository PaymentInformation { get; private set; }

        public IPaymentTypeRepository PaymentType { get; private set; }

        public ISoldTicketRepository SoldTicket { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
