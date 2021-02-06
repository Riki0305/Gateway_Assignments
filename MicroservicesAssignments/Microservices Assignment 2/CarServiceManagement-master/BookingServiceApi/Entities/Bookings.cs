using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServiceApi.Entities
{
    public class Bookings
    {
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int ServiceId { get; set; }
        public Services Services { get; set; }
        public int CustomerId { get; set; }
        public Customers Customers { get; set; }
        public int GarageId { get; set; }
        public Garages Garages { get; set; }
    }
}
