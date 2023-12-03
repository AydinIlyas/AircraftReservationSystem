using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{

    public class Airline
    {
        public Airline()
        {
        }

        public Airline(int id, string name, ICollection<FlightClass> flightClasses, ICollection<Aircraft> aircrafts)
        {
            Id = id;
            Name = name;
            FlightClasses = flightClasses;
            Aircrafts = aircrafts;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FlightClass> FlightClasses { get; set; }
        public ICollection<Aircraft> Aircrafts { get; set;}
    }
}
