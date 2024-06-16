namespace MallorcaTeslaRentals.Models
{
    public class Location
    {
        public Guid Id { get; set; }

        public string PostalCode { get; set; }

        public string Name { get; set; }

        public int BuildingNumber { get; set; }
    }
}
