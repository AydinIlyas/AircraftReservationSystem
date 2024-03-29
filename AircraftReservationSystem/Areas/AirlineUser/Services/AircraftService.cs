﻿using AircraftReservationSystem.Areas.AirlineUser.Services.Interfaces;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public SelectList GetAircraftTypeSelectList()
        {
            var aircraftTypeVMs = _mapper.Map<IEnumerable<AircraftType>, IEnumerable<AircraftTypeVM>>(_unitOfWork.AircraftType.GetAll());
            return new SelectList(aircraftTypeVMs, "Id", "Type");
        }

        public List<AircraftVM> GetAircraftVMs()
        {
            var aircrafts = _unitOfWork.Aircraft.GetAllWithAirlineAndAircraftType().ToList();
            var aircraftVMs = _mapper.Map<List<Aircraft>, List<AircraftVM>>(aircrafts.ToList());

            return aircraftVMs;
        }

        public SelectList GetAirlineTypeSelectList()
        {
            var airlines = _unitOfWork.Airline.GetAll();
            return new SelectList(airlines, "Id", "Name");
        }
    }
}
