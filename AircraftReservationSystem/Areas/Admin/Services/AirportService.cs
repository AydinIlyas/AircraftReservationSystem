using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using BulkyBook.DataAccess.Repository.IRepository;

namespace AircraftReservationSystem.Areas.Admin.Services
{
    public class AirportService : IAirportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AirportService> _logger;

        public AirportService(IUnitOfWork unitOfWork, ILogger<AirportService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public IEnumerable<Airport> GetAirports()
        {
            return _unitOfWork.Airport.GetAll();
        }

        public void CreateAirport(AirportViewModel airportViewModel)
        {
            var airport = new Airport
            {
                Name = airportViewModel.Airport.Name,
                AirportCode = airportViewModel.Airport.AirportCode,
                DistrictId = (int)airportViewModel.DistrictId
            };
            _unitOfWork.Airport.Add(airport);
            _unitOfWork.Save();
        }

    }
}
