namespace CarRentingSystem.Controllers.Api
{
    using CarRentingSystem.Data;
    using CarRentingSystem.Data.Models;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections;
    using System.Linq;

    [ApiController]
    [Route("api/cars")]
    public class CarsApiController : ControllerBase
    {
        private readonly CarRentingDbContext data;

        public CarsApiController(CarRentingDbContext data) 
            => this.data = data;

        [HttpGet]
        public IEnumerable GetCar()
        {
            return this.data.Cars.ToList();
        }


        [HttpPost]
        public IActionResult SaveCar(Car car)
        {
            return Ok();
        }






        //[HttpGet]
        //[Route("{id}")]
        //public IActionResult GetDetails(int id)
        //{
        //    var car = this.data.Cars.Find(id);

        //    if (car == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(car);
        //}
    }
}