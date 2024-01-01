using AircraftReservationSystem.Areas.User.Services.Interfaces;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AutoMapper;

namespace AircraftReservationSystem.Areas.User.Services
{
    public class HomeService : IHomeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HomeService> _logger;
        private readonly IMapper _mapper;

        public HomeService(IUnitOfWork unitOfWork, ILogger<HomeService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<FlightInformation> SearchFlights(SearchFlight search)
        {
            if (search.DepartureAirport == null || search.ArrivalAirport == null) return null;
            IEnumerable<Flight> flights=_unitOfWork.Flight.SearchFlight(search);
            //_logger.LogInformation("SuccessFully searched for flight");
            return _mapper.Map<IEnumerable<FlightInformation>>(flights);
            
        }
    }
}