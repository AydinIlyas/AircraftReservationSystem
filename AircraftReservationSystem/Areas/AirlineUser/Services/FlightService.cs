using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AircraftReservationSystem.Areas.AirlineUser.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<FlightService> _logger;
        private readonly IMapper _mapper;

        public FlightService(IUnitOfWork unitOfWork, ILogger<FlightService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public bool AddFlight(FlightInformation flightInformation)
        {
            Flight flight =_mapper.Map<Flight>(flightInformation);
            _unitOfWork.Flight.Add(flight);
            _unitOfWork.Save();
            return true;
        }

        public SelectList GetAircraftSelectList()
        {
            return new SelectList(_unitOfWork.Aircraft.GetAll(),"Id","Name");
        }

        public SelectList GetAirportSelectList()
        {
            return new SelectList(_unitOfWork.Airport.GetAll(), "Id", "Name");
        }

        public List<FlightInformation> GetFlights()
        {
            var flights=_unitOfWork.Flight.GetAllWithAdditionalNames();

            return _mapper.Map<List<FlightInformation>>(flights);
        }
    }
}
