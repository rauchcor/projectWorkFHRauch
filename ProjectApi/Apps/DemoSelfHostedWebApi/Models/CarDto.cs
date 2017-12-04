using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSelfHostedWebApi.Models
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
