using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CarsWebApp.Infrastructure.Data.Domain
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
      
        public string RegNumber { get; set; } = null!;

        [Required]
     
        public string Manufacturer { get; set; } = null!;

       [Required]
        public int ModelId { get; set; }
        public virtual Model Model { get; set; } = null!;
        public string? Picture { get; set; }
        public DateTime YearOfManufacture { get; set; }

        [Required]
        [Range(1000, 30000)]
        public decimal Price { get; set; }

      

        public string OwnerId { get; set; } = null!;
        public virtual ApplicationUser Owner { get; set; } = null!;
    }
}
