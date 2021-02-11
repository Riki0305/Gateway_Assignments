using GarageApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageApi.Context
{
    public class GarageContext:DbContext
    {
        public DbSet<Garage> garages { get; set; }
        public DbSet<Service> services { get; set; }
    }
}
