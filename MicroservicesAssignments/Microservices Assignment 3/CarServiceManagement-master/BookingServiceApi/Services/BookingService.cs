using BookingServiceApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServiceApi.Services
{
    public class BookingService
    {
        public IEnumerable<Booking> GetBookings()
        {
            var bookings = new List<Booking>();
            for(int i=1;i<4;i++)
            {
                bookings.Add(new Booking
                {
                    Id = i,
                    CustomerId = i,
                    GarageId = i,
                    ServiceId = i,
                    BookingDate = DateTime.Now,
                    DeliveryDate = DateTime.Now,
                    
                });
                
            }
            return bookings;
        }
    }
}
