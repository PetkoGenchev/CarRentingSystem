namespace CarRentingSystem.Models.Cars
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants;

    public class AddCarFormModel
    {
        [Required]
        [StringLength(CarBrandMaxLength,MinimumLength = CarBrandMinLength)]
        public string Brand { get; init; }


        [Required]
        [StringLength(CarModelMaxLength, MinimumLength = CarModelMinLength)]
        public string Model { get; init; }

        [Required]
        [StringLength(
            int.MaxValue, 
            MinimumLength = CarDescriptionMinLength,
            ErrorMessage = "The field Description must be a string with minimum length {2}")]
        public string Description { get; init; }


        [Display(Name = "Image URL")]
        [Required]
        [Url]
        public string ImageUrl { get; init; }


        [Range(CarYearMinValue, CarYearMaxValue)]
        public int Year { get; init; }


        [Display(Name = "Category")]
        public int CategoryID { get; init; }

        public IEnumerable<CarCategoryViewModel> Categories { get; set; }
    }
}
