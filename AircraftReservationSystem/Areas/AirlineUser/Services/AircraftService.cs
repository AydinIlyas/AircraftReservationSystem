using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AutoMapper;

namespace AircraftReservationSystem.Areas.AirlineUser.Services
{
    public class AircraftService : IAircraftService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AircraftService> _logger;
        private readonly IMapper _mapper;

        public AircraftService(IUnitOfWork unitOfWork, ILogger<AircraftService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper= mapper;
        }

        public void AddAircraft(AircraftVM aircraftVM)
        {
            Aircraft aircraft=_mapper.Map<Aircraft>(aircraftVM);
            _unitOfWork.Aircraft.Add(aircraft);
            _unitOfWork.Save();
        }

        public List<AircraftVM> GetAircraftVMs()
        {
            var aircrafts = _unitOfWork.Aircraft.GetAll();
            var aircraftVMs= aircrafts.Select(aircraft => _mapper.Map<Aircraft, AircraftVM>(aircraft)).ToList();

            return aircraftVMs;
        }
    }
}
