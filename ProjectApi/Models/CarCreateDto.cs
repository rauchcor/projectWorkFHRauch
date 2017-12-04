using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSelfHostedWebApi.Models
{
    public class CarCreateDto : IValidatableObject
    {
        [Required(AllowEmptyStrings =false)]
        public string Brand { get; set; }

        [Required]
        [Range(50, 500, ErrorMessage = "If it is less than 50, don't even drive it, if it is more than 500 just call it a jet")]
        public double HorsePower { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Brand == "Fiat" && HorsePower > 100)
                yield return new ValidationResult("Come on a fiat cannot have more than 100 PS");
        }
    }
}
