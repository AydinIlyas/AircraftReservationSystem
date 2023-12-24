using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models.ViewModels
{
    public class AircraftVM
    {
        public AircraftVM()
        {
        }

        public AircraftVM(int id, string name, Airline airline, int airlineId, string airlineName, AircraftType aircraftType, string aircraftTypeName, int aircraftTypeId)
        {
            Id = id;
            Name = name;
            Airline = airline;
            AirlineId = airlineId;
            AirlineName = airlineName;
            AircraftType = aircraftType;
            AircraftTypeName = aircraftTypeName;
            AircraftTypeId = aircraftTypeId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public Airline Airline { get; set; }
        public int AirlineId { get; set; }
        public string AirlineName {  get; set; }
        public AircraftType AircraftType { get; set; }
        public string AircraftTypeName { get; set; }
        public int AircraftTypeId { get; set; }
    }
}
