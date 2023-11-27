using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class SoldTicket
    {

        [Key]
        public int Id { get; set; }
        
        [Required]
        public string seatNumber { get; set; }
        
        [Required]
        public float totalPrice { get; set; }

        [ForeignKey("passenger")]
        public int passengerId { get; set; }

        [ForeignKey("flightTicket")]
        public int flightTicketId { get; set; }

        public Passenger passenger { get; set; }

        public FlightTicket flightTicket { get; set; }

        public PaymentInformation paymentInformation { get; set; }
    
    }
}
