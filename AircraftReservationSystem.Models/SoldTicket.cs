using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class SoldTicket
    {
        public SoldTicket()
        {
        }

        public SoldTicket(int id, string seatNumber, float totalPrice, PaymentInformation? paymentInformation, Passenger passenger, string passengerId, FlightClass flightClass, int flightClassId, FlightTicket? flightTicket)
        {
            Id = id;
            SeatNumber = seatNumber;
            TotalPrice = totalPrice;
            PaymentInformation = paymentInformation;
            Passenger = passenger;
            PassengerId = passengerId;
            FlightClass = flightClass;
            FlightClassId = flightClassId;
            FlightTicket = flightTicket;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        public PaymentInformation? PaymentInformation { get; set; }
        [ForeignKey("PassengerId")]
        public Passenger? Passenger { get; set; }
        public string? PassengerId { get; set; }
        [ForeignKey("FlightClassId")]
        public FlightClass FlightClass { get; set; }
        public int FlightClassId { get; set; }
        public FlightTicket? FlightTicket { get; set; }
    }
}
