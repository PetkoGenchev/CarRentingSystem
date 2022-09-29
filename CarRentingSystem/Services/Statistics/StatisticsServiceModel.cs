namespace CarRentingSystem.Services.Statistics
{
    using CarRentingSystem.Data;

    public class StatisticsServiceModel
    {
        public int TotalCars { get; init; }
        public int TotalUsers { get; init; }
        public int TotalRents { get; init; }
    }
}
