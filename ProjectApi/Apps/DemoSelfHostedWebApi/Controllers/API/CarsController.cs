using DemoSelfHostedWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DemoSelfHostedWebApi.Controllers.API
{
    [RoutePrefix(AppConfigProvider.ControllersPrefix + "cars")]
    public class CarsController : ApiController
    {
        private static List<CarDto> cars = Enumerable.Range(1, 5)
            .Select(i => new CarDto
            {
                Id = i,
                Brand = "VW " + i,
                HorsePower = i * 23
            })
            .ToList();

        [HttpGet]
        [ResponseType(typeof(IList<CarDto>))]
        public IHttpActionResult Get()
        {
            return Ok(cars);
        }

        [HttpPost]
        [ResponseType(typeof(CarDto))]
        public IHttpActionResult Post([FromBody]CarCreateDto toCreate)
        {
            if (toCreate == null)
                return BadRequest("Car to create required in body");

            // toCreate is validated using data annotations and IValidateObject implementation
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // TODO: here create actual car later 
            // use automapper for mappings
            var carDto = new CarDto()
            {
                Id = cars.Max(x => x.Id) + 1,
                Brand = toCreate.Brand,
                HorsePower = toCreate.HorsePower
            };

            cars.Add(carDto);

            return Ok(carDto);
        }
    }
}
