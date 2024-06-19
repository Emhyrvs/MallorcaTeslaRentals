using MallorcaTeslaRentals.Data;
using MallorcaTeslaRentals.Models;
using Microsoft.EntityFrameworkCore;

namespace MallorcaTeslaRentals.Services
{
    public class LocationService:ILocationService
    {

        public readonly DataDbContext context;
        public LocationService(DataDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<Location>> GetLocationAsync()
        {
            return await context.Locations.ToListAsync();
        }
    }
}
