using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AircraftReservationSystem.Models
{
    public class FlightTicket
    {
        public FlightTicket()
        {
        }

        public FlightTicket(int id, string seatNumber, bool isAvailable, SoldTicket soldTicket, int soldTicketId, Flight flight, int flightId)
        {
            Id = id;
            SeatNumber = seatNumber;
            IsAvailable = isAvailable;
            SoldTicket = soldTicket;
            SoldTicketId = soldTicketId;
            Flight = flight;
            FlightId = flightId;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        public bool IsAvailable { get; set; }
        public SoldTicket SoldTicket { get; set; }
        public int SoldTicketId { get; set; }
        public Flight Flight { get; set; }
        public int FlightId { get; set; }

    }
}
