using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;

namespace AircraftReservationSystem.Areas.Admin.Services
{
    public class AirlineService : IAirlineService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AirlineService> _logger;

        public AirlineService(IUnitOfWork unitOfWork, ILogger<AirlineService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public void AddAirline(Airline airline)
        {
            _unitOfWork.Airline.Add(airline);
            _unitOfWork.Save();
        }

        public IEnumerable<Airline> GetAirlines()
        {
            return _unitOfWork.Airline.GetAll();
        }
    }
}
