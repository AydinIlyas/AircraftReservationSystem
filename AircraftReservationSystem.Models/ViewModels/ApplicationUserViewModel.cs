using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.Models.ViewModels
{
	public class ApplicationUserViewModel
	{
		public ApplicationUserViewModel()
		{
		}

        public ApplicationUserViewModel(string id, string firstname, string lastname, string email, string role)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Role = role;
        }

        public string Id { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public string Email { get; set; }
		public string? Role { get; set; }
	}
}
