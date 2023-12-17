using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models.ViewModels
{
	public class PassengerViewModel
	{
		public PassengerViewModel()
		{
		}

        public PassengerViewModel(string id, string firstname, string lastname, string email)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
        }

        public string Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
	}
}
