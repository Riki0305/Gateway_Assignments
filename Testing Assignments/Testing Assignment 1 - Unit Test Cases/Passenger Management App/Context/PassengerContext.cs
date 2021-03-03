using Passenger_Management_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Passenger_Management_App.Context
{
    public class PassengerContext : DbContext
    {
        public DbSet<Passenger>  passengers { get; set; }
    }
}