using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class Aircraft
    {
        public Aircraft()
        {
        }

        public Aircraft(int id, Airline airline, int airlineId, AircraftType aircraftType, int aircraftTypeId, ICollection<Flight> flights)
        {
            Id = id;
            Airline = airline;
            AirlineId = airlineId;
            AircraftType = aircraftType;
            AircraftTypeId = aircraftTypeId;
            Flights = flights;
        }

        public int Id { get; set; }
        public Airline Airline { get; set; }
        public int AirlineId { get; set;}
        public AircraftType AircraftType { get; set; }
        public int AircraftTypeId { get; set; }

        public ICollection<Flight> Flights { get; set; }

    }
}
