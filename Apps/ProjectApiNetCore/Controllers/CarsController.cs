﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Mvc;
using ProjectApiNetCore.Context;
using ProjectApiNetCore.Models;

namespace ProjectApiNetCore.Controllers
{
    [Authorize]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    public class CarsController : Controller
    {

        private readonly CarContext _context;

        public CarsController(CarContext context)
        {
            _context = context;
            var cars = Enumerable.Range(1, 5)
                .Select(i => new CarDto
                {
                    Id = i,
                    Brand = "VW " + i,
                    HorsePower = i * 23
                })
                .ToList();
            if (_context.CarItems.Count() != 0) return;
            _context.CarItems.AddRange(cars);
            _context.SaveChanges();
        }


        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("claims")]
        public IActionResult GetClaims()
        {
            //var claims = "whalt";
            var claims = User.Claims.Select(c => new { c.Type, c.Value });
            return new JsonResult(claims);
        }


        [Microsoft.AspNetCore.Mvc.HttpGet]
        [ResponseType(typeof(IEnumerable<CarDto>))]
        [Microsoft.AspNetCore.Mvc.Route("all")]
        public IActionResult GetAll()
        {
            return Ok(_context.CarItems.ToList());
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("byId")]
        public IActionResult GetById([FromUri] long id)
        {
            var item = _context.CarItems.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [ResponseType(typeof(CarDto))]
        public IActionResult Post([System.Web.Http.FromBody]CarCreateDto toCreate)
        {
            if (toCreate == null)
                return BadRequest("Car to create required in body");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carDto = new CarDto()
            {
                Id = _context.CarItems.ToList().Max(x => x.Id) + 1,
                Brand = toCreate.Brand,
                HorsePower = toCreate.HorsePower
            };

            _context.CarItems.Add(carDto);
            _context.SaveChanges();


            return CreatedAtRoute("GetCar", new { id = carDto.Id }, carDto);
        }
    }
}