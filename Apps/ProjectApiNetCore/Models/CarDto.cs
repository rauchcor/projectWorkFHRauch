using System.ComponentModel.DataAnnotations;

namespace ProjectApiNetCore.Models
{
    public class CarDto
    {
        [Required]
        public int Id { get; set; }

        public string Brand { get; set; }

        [Required]
        public double HorsePower { get; set; }
    }
}
