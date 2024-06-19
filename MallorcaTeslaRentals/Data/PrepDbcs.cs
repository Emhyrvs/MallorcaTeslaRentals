using MallorcaTeslaRentals.Models;
using Microsoft.EntityFrameworkCore;

namespace MallorcaTeslaRentals.Data
{
    public class PrepDbcs
    {
        public static async Task PrepPopulation(IApplicationBuilder app, bool isProduction)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
               

                await SeedData(serviceScope.ServiceProvider.GetRequiredService<DataDbContext>());
            }
        }

        private static async Task SeedData(DataDbContext context)
        {



            if (context.Reservations.Count() == 0)
            {
                // Dodaj przykładowych klientów
                var clients = new[]
                {
                    new Client
                    {
                        Id = Guid.NewGuid(),
                        Name = "John",
                        LastName = "Doe",
                        PersonalIdentificationNumber = "123456789",
                        PhoneNumber = "123-456-7890"
                    },
                    new Client
                    {
                        Id = Guid.NewGuid(),
                        Name = "Jane",
                        LastName = "Smith",
                        PersonalIdentificationNumber = "987654321",
                        PhoneNumber = "098-765-4321"
                    }
                    // Dodaj więcej klientów według potrzeb
                };
                context.Clients.AddRange(clients);

                // Dodaj przykładowe lokalizacje
                var locations = new[]
                {
                    new Location
                    {
                        Id = Guid.NewGuid(),
                        PostalCode = "12345",
                        Name = "Palma Airport,",
                        BuildingNumber = 1
                    },
                    new Location
                    {
                        Id = Guid.NewGuid(),
                        PostalCode = "54321",
                        Name = "Palma City Center,",
                        BuildingNumber = 2
                    },
                    new Location
                    {
                        Id = Guid.NewGuid(),
                        PostalCode ="533222",
                        Name = "Alcudia and Mancor"
                    }
                    // Dodaj więcej lokalizacji według potrzeb
                };
                context.Locations.AddRange(locations);

                // Dodaj przykładowe samochody
                var cars = new[]
                {
                    new Car
                    {
                        Id = Guid.NewGuid(),
                        ModelName = "Tesla Model S",
                        PriceForDay = 220
                     
                    },
                    new Car
                    {
                        Id = Guid.NewGuid(),
                        ModelName = "Tesla Model 3",
                        PriceForDay = 120
                    },
                    new Car
                    {
                        Id = Guid.NewGuid(),
                        ModelName = "Tesla Model X",
                        PriceForDay = 140
                    },
                    new Car
                    {
                        Id = Guid.NewGuid(),
                        ModelName = "Tesla Model Y",
                        PriceForDay = 150
                    },
                     new Car
                    {
                        Id = Guid.NewGuid(),
                        ModelName = "Tesla CyberPunk",
                        PriceForDay = 140
                    }, 
                     new Car
                     {
                         Id = Guid.NewGuid(),
                         ModelName = "Roadster",
                         PriceForDay = 166
                     }
                };
                context.Cars.AddRange(cars);

                // Dodaj przykładowe rezerwacje
                var random = new Random();
                var reservations = new[]
                {
                    new Reservation
                    {
                        Id = Guid.NewGuid(),
                        ReturnLocationId = locations[random.Next(locations.Length)].Id,
                        PickupLocationId = locations[random.Next(locations.Length)].Id,
                        StartDate = DateTime.Today.AddDays(1),
                        EndDate = DateTime.Today.AddDays(3),
                        ClientId = clients[random.Next(clients.Length)].Id,
                        CarId = cars[random.Next(cars.Length)].Id
                    },
                    new Reservation
                    {
                        Id = Guid.NewGuid(),
                        ReturnLocationId = locations[random.Next(locations.Length)].Id,
                        PickupLocationId = locations[random.Next(locations.Length)].Id,
                        StartDate = DateTime.Today.AddDays(5),
                        EndDate = DateTime.Today.AddDays(7),
                        ClientId = clients[random.Next(clients.Length)].Id,
                        CarId = cars[random.Next(cars.Length)].Id
                    }
                    // Dodaj więcej rezerwacji według potrzeb
                };
                context.Reservations.AddRange(reservations);

                context.SaveChanges();
            }
           
        }
    }
}

