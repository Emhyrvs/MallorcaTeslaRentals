namespace MallorcaTeslaRentals.Models
{
    public class Car
    {

        public Guid Id { get; set; }
        public string ModelName { get; set; }

        public decimal PriceForDay { get; set; }

    }
}
