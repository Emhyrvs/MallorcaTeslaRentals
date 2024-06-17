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
        return await _context.Reservations.ToListAsync();
    }

    public async Task<Reservation> GetReservationByIdAsync(int id)
    {
        return await _context.Reservations.FindAsync(id);
    }

    public async Task<Reservation> CreateReservationAsync(Reservation request)
    {
        var reservation = new Reservation
        {
            Id = request.Id,
            PickupLocation = request.PickupLocation,
            EndDate = request.EndDate,
            StartDate = request.StartDate,
            Car = request.Car,
            Client = request.Client,
            ReturnLocation = request.ReturnLocation,
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
