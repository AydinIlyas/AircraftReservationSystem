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

        public AircraftVM(int id, Airline airline, int airlineId, AircraftType aircraftType, int aircraftTypeId)
        {
            Id = id;
            Airline = airline;
            AirlineId = airlineId;
            AircraftType = aircraftType;
            AircraftTypeId = aircraftTypeId;
        }

        public int Id { get; set; }
        public Airline Airline { get; set; }
        public int AirlineId { get; set; }
        public AircraftType AircraftType { get; set; }
        public int AircraftTypeId { get; set; }
    }
}
