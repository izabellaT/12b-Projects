﻿using System.ComponentModel.DataAnnotations;

using CarsWebApp.Models.Model;

namespace CarsWebApp.Models.Car
{
    public class CarCreateViewModel
    {
        public int Id { get; set; }

        [Required]
       
        [Display(Name = "RegNumber")]
        public string RegNumber { get; set; } = null!;

        [Required]
     
        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; } = null!;

        [Required]
      
        [Display(Name = "Model")]
        public int ModelId { get; set; }

        [Display(Name = "Car Picture")]
        public string? Picture { get; set; }

        [Display(Name = "Year Of Manufacture")]
        public DateTime YearOfManufacture { get; set; }

        [Required]
        [Range(1000, 30000)]
        [Display(Name = "Price")]
        public decimal Price { get; set; }

        public virtual List<ModelPairViewModel> Models { get; set; } = new List<ModelPairViewModel>();
    }
}
