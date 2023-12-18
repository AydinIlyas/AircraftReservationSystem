using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;

namespace AircraftReservationSystem.Areas.AirlineUser.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FlightService> _logger;

        public FlightService(IUnitOfWork unitOfWork, ILogger<FlightService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public bool AddFlight(FlightInformation flightInformation)
        {
            Flight flight = flightInformation.toFlight();
            _unitOfWork.Flight.Add(flight);
            _unitOfWork.Save();
            return true;
        }

        public List<FlightInformation> GetFlights()
        {
            var flights=_unitOfWork.Flight.GetAll();

            return flights.Select(flight => new FlightInformation
            {
                Id = flight.Id,
                FlightNumber = flight.FlightNumber,
                DepartureAirport = flight.DepartureAirport,
                ArrivalAirport = flight.ArrivalAirport,
                Duration = flight.Duration,
                Price = flight.Price,
                BusinessPrice = flight.BusinessPrice,
                Aircraft = flight.Aircraft,
                AirCraftId = flight.AirCraftId,
                DepartureAirportId = flight.DepartureAirportId,
                DepartureDate = flight.DepartureDate,
                ArrivalAirportId = flight.ArrivalAirportId,
                ArrivalDate = flight.ArrivalDate,
            }).ToList();
        }
    }
}
