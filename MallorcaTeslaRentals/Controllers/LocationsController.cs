using MallorcaTeslaRentals.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MallorcaTeslaRentals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase

    {

        private readonly ILocationService _locationService;

        public LocationController(ILocationService LocationService)
        {
            _locationService = LocationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetLocations()
        {
            var Location = await _locationService.GetLocationAsync();
            return Ok(Location);
        }
    }
}
