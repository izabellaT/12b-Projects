using System.ComponentModel.DataAnnotations;

namespace CarsWebApp.Models.Model
{
    public class ModelPairViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; } = null!;
    }
}
