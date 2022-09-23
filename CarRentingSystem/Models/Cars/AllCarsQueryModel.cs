namespace CarRentingSystem.Models.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class AllCarsQueryModel
    {
        public string Brand { get; init; }

        public IEnumerable<string> Brands { get; init; }

        [Display(Name = "Search by text:")]
        public string SearchTerm { get; init; }

        public CarSorting Sorting { get; init; }

        public IEnumerable<CarListingViewModel> Cars { get; init; }

    }
}
