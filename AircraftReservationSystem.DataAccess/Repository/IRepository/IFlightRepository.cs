using AircraftReservationSystem.Models;
using AircraftReservationSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AircraftReservationSystem.DataAccess.Repository.IRepository
{
    public interface IFlightRepository : IRepository<Flight>
    {
        IQueryable<Flight> GetAllWithAdditionalNames();
        IQueryable<Flight> SearchFlight(SearchFlight searchFlight);
    }
}
