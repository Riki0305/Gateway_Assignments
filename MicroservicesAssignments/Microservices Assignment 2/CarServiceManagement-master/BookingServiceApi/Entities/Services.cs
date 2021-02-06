using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServiceApi.Entities
{
    public class Services
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GarageId { get; set; }
        public Garages Garages { get; set; }

        public string Requirements { get; set; }
    }
}
