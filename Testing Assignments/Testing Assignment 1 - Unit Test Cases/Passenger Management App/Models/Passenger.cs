using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Passenger_Management_App.Models
{
    public class Passenger
    {
        public int Id { get; set; }
        public string PassengerNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
    }
}