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
        // Sprawdzenie czy istnieje klient o danym PersonalIdentificationNumber
        Client client = _context.Clients.FirstOrDefault(a => a.PersonalIdentificationNumber == request.Client.PersonalIdentificationNumber);

        if (client == null)
        {
            // Jeśli klient nie istnieje, stwórz nowego klienta
            client = new Client
            {
                Id = Guid.NewGuid(),
                PersonalIdentificationNumber = request.Client.PersonalIdentificationNumber,
                Name = request.Client.Name, // Przykładowe przypisanie dodatkowych właściwości klienta
                LastName = request.Client.LastName,   // Możesz dodać inne właściwości w razie potrzeby
               PhoneNumber = request.Client.PhoneNumber
            };

            // Dodaj nowego klienta do kontekstu
            _context.Clients.Add(client);
        }

        // Stwórz nową rezerwację i przypisz istniejące lub nowo utworzone obiekty
        var reservation = new Reservation
        {
            Id = Guid.NewGuid(),
            PickupLocationId = request.PickupLocation.Id,
            ReturnLocationId = request.ReturnLocation.Id,
            EndDate = request.EndDate,
            StartDate = request.StartDate,
            CarId = request.Car.Id,
            ClientId = client.Id, // Przypisz Id klienta (nowego lub istniejącego)
            Client = client, // Przypisz klienta do rezerwacji
            TotalCost = request.TotalCost,
        };

        // Dodaj rezerwację do kontekstu
        _context.Reservations.Add(reservation);

        // Zapisz zmiany w bazie danych
        await _context.SaveChangesAsync();

        // Zwróć stworzoną rezerwację
        return reservation;
    }


    public async Task<Reservation> UpdateReservationAsync(int id, Reservation request)
    {
        var reservation = await _context.Reservations.FindAsync(id);
        if (reservation == null)
        {
            return null;
        }

        // Update fields from request
        // e.g., reservation.StartDate = request.StartDate, etc.

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
