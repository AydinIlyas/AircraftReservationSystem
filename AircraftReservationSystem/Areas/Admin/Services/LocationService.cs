using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.Models;
using BulkyBook.DataAccess.Repository.IRepository;

namespace AircraftReservationSystem.Areas.Admin.Services
{
    public class LocationService : ILocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LocationService> _logger;

        public LocationService(IUnitOfWork unitOfWork, ILogger<LocationService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public List<City> GetCities()
        {
            return _unitOfWork.City.GetAll().ToList();
        }

        public List<Country> GetCountries()
        {
            return _unitOfWork.Country.GetAll().ToList();
        }

        public List<District> GetDistricts()
        {
            return _unitOfWork.District.GetAll().ToList();
        }
    }
}
