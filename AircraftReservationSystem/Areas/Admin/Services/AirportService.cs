using AircraftReservationSystem.Areas.Admin.Services.Interfaces;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AircraftReservationSystem.DataAccess.Repository.IRepository;

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
        public void UpdateAirport(Airport airport)
        {
            Airport existingAirport = GetAirportById(airport.Id);

            existingAirport.Name = airport.Name;
            existingAirport.AirportCode = airport.AirportCode;
            existingAirport.DistrictId = (int)airport.DistrictId;

            _unitOfWork.Airport.Update(existingAirport);
            _unitOfWork.Save();
        } 

        public Airport GetAirportById(int id)
        {
            Airport airport = _unitOfWork.Airport.GetFirstOrDefault(x => x.Id == id);
            if (airport != null)
            {
                return airport;
            }
            else
            {
                _logger.LogWarning("Airport not found! Id: " + id);
                return null;
            }
        }

        public void DeleteAirport(Airport airport)
        {
            _unitOfWork.Airport.Remove(airport);
            _unitOfWork.Save();
        }


    }
}
