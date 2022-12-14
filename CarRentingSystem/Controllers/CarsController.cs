namespace CarRentingSystem.Controllers
{
    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using CarRentingSystem.Models.Cars;
    using CarRentingSystem.Services.Cars;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly CarRentingDbContext data;

        public CarsController(CarRentingDbContext data, ICarService cars)
        {
            this.data = data;
            this.cars = cars;

        }

        public IActionResult All([FromQuery]AllCarsQueryModel query)
        {
            var queryResult = this.cars.All(
                query.Brand,
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                AllCarsQueryModel.CarsPerPage);

            var carBrands = this.cars.AllCarBrands();

            query.TotalCars = queryResult.TotalCars;
            query.Brands = carBrands;
            query.Cars = queryResult.Cars;

            return View(query);
        }

        // We use this one if we want to add files to the form + a validation + one way of saving it ( we better change the name of the file before saving it) and fix the path of saving

        //using FileSystem = System.IO.File;

        //public IActionResult Add(AddCarFormModel car, IFormFile image)
        //{
        //    if (image != null || image.Length > 2 * 1024 * 1024)
        //    {
        //        this.ModelState.AddModelError("Image", "The image is not valid. It is required and it should be less than 2 MB. ");
        //    }
        //      image.CopyTo(FileSystem.OpenWrite($"/images/{image.FileName}"));


        //public IActionResult Download()
        //{
        //    return File("/wwwroot/images/site.jpg", "image/jpg");
        //}

        public IActionResult Add() => View(new AddCarFormModel
        {
            Categories = this.GetCarCategories()
        });


        [HttpPost]
        public IActionResult Add(AddCarFormModel car)
        {

            if (!this.data.Categories.Any(c => c.Id == car.CategoryID))
            {
                this.ModelState.AddModelError(nameof(car.CategoryID), "Category does not exist.");
            }


            if (!ModelState.IsValid)
            {
                car.Categories = this.GetCarCategories();
                return View(car);
            }

            var carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year,
                CategoryId = car.CategoryID,
            };

            this.data.Cars.Add(carData);

            this.data.SaveChanges();

            return RedirectToAction(nameof(All));

        }

        private IEnumerable<CarCategoryViewModel> GetCarCategories()
            => this.data
            .Categories
            .Select(c => new CarCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToList();

    }
}
