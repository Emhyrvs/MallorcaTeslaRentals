using MallorcaTeslaRentals.Models;

namespace MallorcaTeslaRentals.Services
{
   
        public interface IReservationService
        {
            Task<IEnumerable<Reservation>> GetReservationsAsync();
            Task<Reservation> GetReservationByIdAsync(int id);
            Task<Reservation> CreateReservationAsync(Reservation request);
            Task<Reservation> UpdateReservationAsync(int id, Reservation request);
            Task<bool> DeleteReservationAsync(int id);
        }
    
}
