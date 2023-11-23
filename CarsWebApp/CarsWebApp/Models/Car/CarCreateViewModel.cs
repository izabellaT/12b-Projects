using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Models.Car
{
    public class CarCreateViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(8)]
        [MinLength(8)]
        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        [Display(Name = "Model")]
        public string Model { get; set; } = null!;

        [Display(Name = "Car Picture")]
        public string? Picture { get; set; }

        [Display(Name = "Year Of Manufacture")]
        public DateTime YearOfManufacture { get; set; }

        [Required]
        [Range(1000, 30000)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }
    }
}
