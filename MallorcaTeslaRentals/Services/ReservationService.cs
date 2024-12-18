using MallorcaTeslaRentals.Data;
using MallorcaTeslaRentals.Models;
using MallorcaTeslaRentals.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ReservationService : IReservationService
{
    private readonly DataDbContext _context;

    public ReservationService(DataDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Reservation>> GetReservationsAsync()
    {
        return await _context.Reservations.Include(a=>a.Car).Include(a=>a.Client).Include(a=>a.ReturnLocation).Include(a=>a.PickupLocation).ToListAsync();
    }

    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task<Reservation> CreateReservationAsync(Reservation request)
    {
       
        Client client = _context.Clients.FirstOrDefault(a => a.PersonalIdentificationNumber == request.Client.PersonalIdentificationNumber);

        if (client == null)
        {
         
            client = new Client
            {
                Id = Guid.NewGuid(),
                PersonalIdentificationNumber = request.Client.PersonalIdentificationNumber,
                Name = request.Client.Name, 
                LastName = request.Client.LastName,  
               PhoneNumber = request.Client.PhoneNumber
            };

          
            _context.Clients.Add(client);
        }

        
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            PickupLocationId = request.PickupLocation.Id,
            ReturnLocationId = request.ReturnLocation.Id,
            EndDate = request.EndDate,
            StartDate = request.StartDate,
            CarId = request.Car.Id,
            ClientId = client.Id, 
            Client = client, 
            TotalCost = request.TotalCost,
        };

       
        _context.Reservations.Add(reservation);

       
        await _context.SaveChangesAsync();

        
        return reservation;
    }


    public async Task<Reservation> UpdateReservationAsync(int id, Reservation request)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
        {
            return null;
        }

      

        await _context.SaveChangesAsync();

        return reservation;
    }

    public async Task<bool> DeleteReservationAsync(int id)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
        {
            return false;
        }

        _context.Reservations.Remove(reservation);
        await _context.SaveChangesAsync();

        return true;
    }
}
