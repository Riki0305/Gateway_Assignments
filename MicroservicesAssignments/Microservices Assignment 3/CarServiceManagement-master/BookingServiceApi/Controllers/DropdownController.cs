using BookingServiceApi.Services;
using CommonObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        [HttpGet,Route("GetBookings")]
        public IEnumerable<DropdownDate> GetBookings()
        {
            return new BookingService().GetBookings().Select(r => new DropdownDate { Id=r.Id,BookingDate = r.BookingDate,DelivertyDate=r.DeliveryDate});
        }
    }
}
