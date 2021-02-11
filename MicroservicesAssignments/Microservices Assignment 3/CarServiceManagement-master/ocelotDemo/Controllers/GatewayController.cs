using CommonObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ocelotDemo.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ocelotDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        [HttpGet,Route("GetCustomers")]
        public async Task<IEnumerable<DropdownDto>> GetCustomers()
        {
            var customers = await HttpCall.GetRequest<List<DropdownDto>>("http://localhost:53552/GetCustomers");

            return customers;
        }
        [HttpGet, Route("GetGarageOwners")]
        public async Task<IEnumerable<DropdownDto>> GetGarageOwners()
        {
            var owners = await HttpCall.GetRequest<List<DropdownDto>>("http://localhost:53552/GetGarageOwners");

            return owners;
        }
        [HttpGet, Route("GetGarages")]
        public async Task<IEnumerable<DropdownDto>> GetGarages()
        {
            var garages = await HttpCall.GetRequest<List<DropdownDto>>("http://localhost:53552/GetGarages");

            return garages;
        }
        [HttpGet, Route("GetServices")]
        public async Task<IEnumerable<DropdownDto>> GetServices()
        {
            var services = await HttpCall.GetRequest<List<DropdownDto>>("http://localhost:53552/GetServices");

            return services;
        }
        [HttpGet, Route("GetBookings")]
        public async Task<IEnumerable<DropdownDate>> GetBookings()
        {
            var bookings = await HttpCall.GetRequest<List<DropdownDate>>("http://localhost:53552/GetBookings");

            return bookings;
        }
    }
}
