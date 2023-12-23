using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AutoMapper;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace AircraftReservationSystem.Areas.AirlineUser.Services
{
    public class AircraftTypeService : IAircraftTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AircraftTypeService> _logger;
        private readonly IMapper _mapper;

        public AircraftTypeService(IUnitOfWork unitOfWork, ILogger<AircraftTypeService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public void AddAircraftType(AircraftTypeVM aircraftTypeVM)
        {
            AircraftType aircraftType = _mapper.Map<AircraftType>(aircraftTypeVM);
            _unitOfWork.AircraftType.Add(aircraftType);
            _unitOfWork.Save();
        }

        public void DeleteAircraftType(int id)
        {
            AircraftType aircraftType = _unitOfWork.AircraftType.GetFirstOrDefault(x => x.Id == id) ?? throw new NullReferenceException($"AircraftType with ID {id} not found.");
            _unitOfWork.AircraftType.Remove(aircraftType);
            _unitOfWork.Save();
        }

        public AircraftTypeVM GetAircraftTypeVMById(int id)
        {
            var aircraftType = _unitOfWork.AircraftType.GetFirstOrDefault(x => x.Id == id);
            return _mapper.Map<AircraftTypeVM>(aircraftType);
        }

        public List<AircraftTypeVM> GetAircraftTypeVMs()
        {
            var aircraftTypes = _unitOfWork.AircraftType.GetAll();
            var aircraftVMs = _mapper.Map<List<AircraftType>, List<AircraftTypeVM>>(aircraftTypes.ToList());
            return aircraftVMs;
        }

        public void UpdateAircraftType(AircraftTypeVM aircraftTypeVM)
        {
            AircraftType existingAircraftType = _unitOfWork.AircraftType.GetFirstOrDefault(x=>x.Id == aircraftTypeVM.Id);
            _mapper.Map<AircraftTypeVM,AircraftType>(aircraftTypeVM,existingAircraftType);
            _unitOfWork.AircraftType.Update(existingAircraftType);
            _unitOfWork.Save();
        }
    }
}
