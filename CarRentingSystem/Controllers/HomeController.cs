namespace CarRentingSystem.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using CarRentingSystem.Data;
    using CarRentingSystem.Models;
    using CarRentingSystem.Models.Home;
    using CarRentingSystem.Services.Statistics;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        private readonly CarRentingDbContext data;
        private readonly IStatisticsService statistics;

        public HomeController(
            IStatisticsService statistics,
            CarRentingDbContext data)
        {
            this.data = data;
            this.statistics = statistics;
        }

        public IActionResult Index()
        {

        var cars = this.data
            .Cars
            .OrderByDescending(c => c.Id)
            .Select(c => new CarIndexViewModel
            {
                Id = c.Id,
                Brand = c.Brand,
                Model = c.Model,
                ImageUrl = c.ImageUrl,
                Year = c.Year
            })
            .Take(3)
            .ToList();

            var totalStatistics = this.statistics.Total();

            return View(new IndexViewModel
            {
                TotalCars = totalStatistics.TotalCars,
                TotalUsers = totalStatistics.TotalUsers,
                Cars = cars

            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
