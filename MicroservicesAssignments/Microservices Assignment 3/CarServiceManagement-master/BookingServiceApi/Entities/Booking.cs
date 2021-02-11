using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServiceApi.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ServiceId { get; set; }
        public Service Services { get; set; }
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        public int GarageId { get; set; }
        public Garage Garages { get; set; }
    }
}
