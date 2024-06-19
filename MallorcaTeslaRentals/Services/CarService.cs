using MallorcaTeslaRentals.Data;
using MallorcaTeslaRentals.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MallorcaTeslaRentals.Services
{
    public class CarService : ICarService
    {
        private readonly DataDbContext _context;

        public CarService(DataDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Car>> GetCarAsync()
        {
            try
            {
                return await _context.Cars.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error retrieving cars from database.", ex);
            }
        }

       
    }
}
