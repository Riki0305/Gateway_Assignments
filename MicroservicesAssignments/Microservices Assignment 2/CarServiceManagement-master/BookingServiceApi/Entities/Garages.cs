using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServiceApi.Entities
{
    public class Garages
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GarageOwnerId { get; set; }

        public string Address { get; set; }
    }
}
