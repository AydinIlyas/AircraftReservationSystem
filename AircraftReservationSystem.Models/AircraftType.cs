using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models
{
    public class AircraftType
    {
        public AircraftType()
        {
        }

        public AircraftType(int id, string type, int seatLength, int seatWidth, int capacity, int businessRows, ICollection<Aircraft> aircrafts)
        {
            Id = id;
            Type = type;
            SeatLength = seatLength;
            SeatWidth = seatWidth;
            Capacity = capacity;
            BusinessRows = businessRows;
            Aircrafts = aircrafts;
        }
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
        public int SeatLength { get; set; }
        public int SeatWidth { get; set; }
        public int Capacity { get; set; }
        public int BusinessRows { get; set; }

        public ICollection<Aircraft> Aircrafts { get; set; }
    }
}
