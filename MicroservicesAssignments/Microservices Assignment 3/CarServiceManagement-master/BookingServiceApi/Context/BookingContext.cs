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
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Garage> garages { get; set; }
        public DbSet<Service> services { get; set; }
    }
}
