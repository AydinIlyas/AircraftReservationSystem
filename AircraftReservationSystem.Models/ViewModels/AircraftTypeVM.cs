using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models.ViewModels
{
    public class AircraftTypeVM
    {
        public AircraftTypeVM()
        {
        }

        public AircraftTypeVM(int id, string type, int seatLength, int seatWidth, int capacity, string businessRows)
        {
            Id = id;
            Type = type;
            SeatLength = seatLength;
            SeatWidth = seatWidth;
            Capacity = capacity;
            BusinessRows = businessRows;
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public int SeatLength { get; set; }
        public int SeatWidth { get; set; }
        public int Capacity { get; set; }
        public String BusinessRows { get; set; }
    }
}
