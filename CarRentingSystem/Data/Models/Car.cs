namespace CarRentingSystem.Data.Models
{
    public class Car
    {
        public int Id { get; init; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string ImageUrl { get; set; }

        public int Year { get; set; }
    }
}
