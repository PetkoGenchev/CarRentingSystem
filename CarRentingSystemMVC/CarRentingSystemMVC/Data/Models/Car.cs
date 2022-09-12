namespace CarRentingSystemMVC.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;
    public class Car
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CarBrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int Year { get; set; }
    }
}
