using MallorcaTeslaRentals.Models;

namespace MallorcaTeslaRentals.Services
{
    public interface ILocationService
    {
        
        Task<IEnumerable<Location>> GetLocationAsync();
    }
}
