namespace CarRentingSystem.Controllers.Api
{
    using CarRentingSystem.Models.Api.Cars;
    using CarRentingSystem.Services.Cars;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/cars")]
    public class CarsApiController : ControllerBase
    {
        private readonly ICarService cars;

        public CarsApiController(ICarService cars)
            => this.cars = cars;


        [HttpGet]
        public CarQueryServiceModel All([FromQuery] AllCarsApiRequestModel query)
         => this.cars.All(
            query.Brand,
            query.SearchTerm,
            query.Sorting,
            query.CurrentPage,
            query.CarsPerPage);


        //[HttpGet]
        //public IEnumerable GetCar()
        //{
        //    return this.data.Cars.ToList();
        //}


        //[HttpPost]
        //public IActionResult SaveCar(Car car)
        //{
        //    return Ok();
        //}

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