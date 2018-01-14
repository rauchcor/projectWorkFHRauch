using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectApiNetCore.Context;
using ProjectApiNetCore.Models;

namespace ProjectApiNetCore.Controllers
{

    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [Microsoft.AspNetCore.Authorization.Authorize]
    public class CarsController : ControllerBase
    {


        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("claims")]
        public IActionResult GetClaims()
        {
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            return new JsonResult(claims);
        }



        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ResponseType(typeof(IEnumerable<CarDto>))]
        [Microsoft.AspNetCore.Mvc.Route("all")]
        public IActionResult GetAll()
        {
            var cars = Enumerable.Range(1, 5)
                .Select(i => new CarDto
                {
                    Id = i,
                    Brand = "VW " + i,
                    HorsePower = i * 23
                })
                .ToList();
            return Ok(cars);
        }

    }
}
