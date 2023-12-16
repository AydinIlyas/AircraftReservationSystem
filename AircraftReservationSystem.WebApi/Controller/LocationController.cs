using AircraftReservationSystem.Models;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AircraftReservationSystem.WebApi.Controllers
{
	[Route("api/locations")]
	[ApiController]
	public class LocationController : ControllerBase
	{
		private readonly IUnitOfWork _unitOfWork;

		public LocationController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet("districts")]
		public async Task<IEnumerable<District>> GetDistricts(int cityId)
		{
			
			IEnumerable<District> districts = await _unitOfWork.District.GetAllAsync();
			districts = districts.Where(d => d.CityId == cityId);
			return districts;
		}

		[HttpGet("cities")]
		public async Task<IEnumerable<City>> GetCities(int countryId)
		{
			IEnumerable<City> cities = await _unitOfWork.City.GetAllAsync();
			cities= cities.Where(c=>c.CountryId== countryId);
			return cities;
		}

		[HttpGet("countries")]
		public async Task<IEnumerable<Country>> GetCountries()
		{
			IEnumerable<Country> countries = await _unitOfWork.Country.GetAllAsync();
			return countries;
		}
	}
}
