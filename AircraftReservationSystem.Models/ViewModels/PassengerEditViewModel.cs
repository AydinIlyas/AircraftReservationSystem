using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models.ViewModels
{
	public class PassengerEditViewModel
	{
		public PassengerEditViewModel()
		{
		}

		public PassengerEditViewModel(string firstname, string lastname, string email)
		{
			Firstname = firstname;
			Lastname = lastname;
			Email = email;
		}

		string Firstname { get; set; }
		string Lastname { get; set; }
		string Email { get; set; }
	}
}
