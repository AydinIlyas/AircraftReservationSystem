using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class FlightTicket
    {
        public FlightTicket(int ıd, string seatNumber, bool ısAvailable, int flightId, Flight flight)
        {
            Id = ıd;
            this.seatNumber = seatNumber;
            IsAvailable = ısAvailable;
            this.flightId = flightId;
            this.flight = flight;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string seatNumber { get; set; }
        
        public bool IsAvailable { get; set; }

        [ForeignKey("flight")]
        public int flightId { get; set; }


        public Flight flight { get; set; }

        
    }
}
