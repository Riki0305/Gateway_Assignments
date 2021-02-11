using GarageOwnerApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageOwnerApi.Context
{
    public class GarageOwnerContext:DbContext
    {
        public DbSet<GarageOwner> garageOwners { get; set; }
    }
}
