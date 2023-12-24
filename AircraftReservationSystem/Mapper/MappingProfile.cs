using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using AutoMapper;

namespace AircraftReservationSystem.Mapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Aircraft, AircraftVM>()
                .ForMember(dest => dest.AirlineName, opt => opt.MapFrom(src => src.Airline.Name))
                .ForMember(dest => dest.AircraftTypeName, opt => opt.MapFrom(src => src.AircraftType.Type));
            CreateMap<AircraftVM,Aircraft >();
            CreateMap<AircraftType,AircraftTypeVM>();
            CreateMap<AircraftTypeVM,AircraftType>();
            CreateMap<Flight, FlightInformation>()
                .ForMember(dest => dest.AircraftName, opt => opt.MapFrom(src => src.Aircraft.Name))
                .ForMember(dest => dest.ArrivalAirportName, opt => opt.MapFrom(src => src.ArrivalAirport.Name))
                .ForMember(dest => dest.DepartureAirportName, opt => opt.MapFrom(src => src.DepartureAirport.Name));
            CreateMap<FlightInformation, Flight>();

        }

    }
}
