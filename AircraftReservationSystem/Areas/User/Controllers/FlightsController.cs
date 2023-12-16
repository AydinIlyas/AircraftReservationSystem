using AircraftReservationSystem.Areas.User.Services;
using AircraftReservationSystem.Models.ViewModels;
using AircraftReservationSystem.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

[Area("User")]
public class FlightsController : Controller
{
    private readonly ILogger<FlightsController> _logger;
    private IFlightService _flightService;
    public FlightsController(ILogger<FlightsController> logger, IFlightService flightService)
    {
        _logger = logger;
        _flightService = flightService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        // Display the form for user input
        return View();
    }

    // GET: User/Flights
    public IActionResult Index(TravelData travelData)
    {
        var flights = _flightService.FindFlights(travelData);
        return View("Results",flights);
    }

    // ... other actions ...

    private bool FlightExists(int id)
    {
        throw new NotImplementedException();
        //return _unitOfWork.Flight.Exists(id);
    }
}
