using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageApi.Entities
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GarageId { get; set; }
        public Garage Garages { get; set; }

        public string Requirements { get; set; }
    }
}
