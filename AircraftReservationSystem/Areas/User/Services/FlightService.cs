using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AircraftReservationSystem.DataAccess.Repository.IRepository;

namespace AircraftReservationSystem.Areas.User.Services
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

        public IEnumerable<FlightVM> FindFlights(TravelData travelData)
        {
            var flights = _unitOfWork.Flight.GetAll().ToList();
            return flights.Select(MapToViewModel);
        }

        private FlightVM MapToViewModel(Flight flight)
        {
            return new FlightVM
            {
                Id = flight.Id,
                DepartureDate = flight.DepartureDate,
                ArrivalDate = flight.ArrivalDate
                // Map other properties as needed
            };
        }
    }
}
