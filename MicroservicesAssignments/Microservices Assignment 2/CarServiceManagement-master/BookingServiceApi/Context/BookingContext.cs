using BookingServiceApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServiceApi.Context
{
    public class BookingContext:DbContext
    {
        public DbSet<Bookings> bookings { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Garages> garages { get; set; }
        public DbSet<Services> services { get; set; }
    }
}
