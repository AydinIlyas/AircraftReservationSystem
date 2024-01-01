using AircraftReservationSystem.Models;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftReservationSystem.WebApi.Controllers
{
	[Route("api/airports")]
	[ApiController]
	public class AirportController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public AirportController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("airports")]
		public async Task<IEnumerable<Airport>> GetAirports(string inputValue)
		{

			IEnumerable<Airport> airports = await _unitOfWork.Airport.GetAllAsync();
			var filteredAirports=airports.Where(a => a.Name.ToLower().Contains(inputValue.ToLower()));
			return filteredAirports;
		}
        [HttpGet("getAirports")]
        public async Task<IEnumerable<Airport>> GetAllAirports()
        {

            IEnumerable<Airport> airports = await _unitOfWork.Airport.GetAllAsync();
            return airports;
        }


    }
}
