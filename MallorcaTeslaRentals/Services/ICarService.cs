using MallorcaTeslaRentals.Models;

namespace MallorcaTeslaRentals.Services
{
    public interface ICarService
    {
      
        Task<IEnumerable<Car>> GetCarAsync();
    }
}
