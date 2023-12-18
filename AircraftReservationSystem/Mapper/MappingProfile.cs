using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AutoMapper;

namespace AircraftReservationSystem.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Aircraft, AircraftVM>();

        }

    }
}
