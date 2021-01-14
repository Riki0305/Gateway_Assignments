using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiAssignment.Model
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public System.DateTime BookingDate { get; set; }
        public int BookingStatusId { get; set; }
        [JsonIgnore]
        public virtual Booking_Status Booking_Status { get; set; }
        [JsonIgnore]
        public virtual Room Room { get; set; }
    }
}