using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectApiNetCore.Models;

namespace ProjectApiNetCore.Context
{
    public class CarContext : DbContext
    {
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
        }

        public DbSet<CarDto> CarItems { get; set; }

    }
}
