using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Entity.Entities
{
    public class FlightClass
    {
        public FlightClass()
        {
        }

        public FlightClass(int id, string name, bool isCancelable, bool hasFood, int baggage, bool baggageCabin, int additionalPrice, ICollection<SoldTicket> soldTicket, Airline airline, int airlineId)
        {
            Id = id;
            Name = name;
            IsCancelable = isCancelable;
            HasFood = hasFood;
            Baggage = baggage;
            BaggageCabin = baggageCabin;
            AdditionalPrice = additionalPrice;
            SoldTickets = soldTicket;
            Airline = airline;
            AirlineId = airlineId;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsCancelable { get; set; }

        public bool HasFood { get; set; }
        public int Baggage { get; set; }
        public bool BaggageCabin { get; set; }
        public int AdditionalPrice { get; set; }
        [InverseProperty("FlightClass")]
        public ICollection<SoldTicket> SoldTickets { get; set; }

        public Airline Airline { get; set; }
        public int AirlineId { get; set; }

}
}
