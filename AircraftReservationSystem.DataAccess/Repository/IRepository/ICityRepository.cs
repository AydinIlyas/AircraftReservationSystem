﻿using AircraftReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Repository.IRepository
{
	public interface ICityRepository : IRepository<City>
	{
		Task<IEnumerable<City>> GetAllAsync();
	}
}
