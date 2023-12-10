using AircraftReservationSystem.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IAircraftRepository Aircraft { get; }
        IAircraftTypeRepository AircraftType { get; }
        IAirlineRepository Airline { get; }
        IAirportRepository Airport { get; }
        ICityRepository City { get; }
        ICountryRepository Country { get; }
        IDistrictRepository District { get; }
        IFlightClassRepository FlightClass { get; }
        IFlightRepository Flight { get; }
        IFlightTicketRepository FlightTicket { get; }
        IPassengerRepository Passenger { get; }
        IPaymentInformationRepository PaymentInformation { get; }
        IPaymentTypeRepository PaymentType { get; }
        ISoldTicketRepository SoldTicket { get; }

        void Save();
    }
}
