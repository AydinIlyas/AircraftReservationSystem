using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class Aircraft
    {
        public Aircraft()
        {
        }

        public Aircraft(int id, string name, Airline airline, int airlineId, AircraftType aircraftType, int aircraftTypeId, ICollection<Flight> flights)
        {
            Id = id;
            Name = name;
            Airline = airline;
            AirlineId = airlineId;
            AircraftType = aircraftType;
            AircraftTypeId = aircraftTypeId;
            Flights = flights;
        }
        [Key]
        public int Id { get; set; }
        public string Name {  get; set; }
        public Airline Airline { get; set; }
        public int AirlineId { get; set; }
        public AircraftType AircraftType { get; set; }
        public int AircraftTypeId { get; set; }

        public ICollection<Flight> Flights { get; set; }

    }
}
