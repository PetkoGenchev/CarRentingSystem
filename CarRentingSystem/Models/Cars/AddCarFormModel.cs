namespace CarRentingSystem.Models.Cars
{
    public class AddCarFormModel
    {
        public string Brand { get; init; }

        public string Model { get; init; }

        public string Description { get; init; }

        public string ImageUrl { get; init; }

        public int Year { get; init; }

        public int CategoryID { get; init; }
    }
}
