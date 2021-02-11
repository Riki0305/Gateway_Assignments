using CommonObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.HttpAggregator.Util;

namespace Web.HttpAggregator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {
        [HttpGet, Route("GetCustomers")]
        public async Task<IEnumerable<DropdownDto>> GetCustomers()
        {
            var customers = await HttpCall.GetRequest<List<DropdownDto>>("http://localhost:58176/api/Dropdown/GetCustomers");
            
            return customers;
        }
        [HttpGet, Route("GetGarageOwners")]
        public async Task<IEnumerable<DropdownDto>> GetGarageOwners()
        {
            var owners = await HttpCall.GetRequest<List<DropdownDto>>("http://localhost:58180/api/Dropdown/GetGarageOwners");

            return owners;
        }
        [HttpGet, Route("GetGarages")]
        public async Task<IEnumerable<DropdownDto>> GetGarages()
        {
            var garages = await HttpCall.GetRequest<List<DropdownDto>>("http://localhost:58179/api/Dropdown/GetGarages");

            return garages;
        }
        [HttpGet, Route("GetServices")]
        public async Task<IEnumerable<DropdownDto>> GetServices()
        {
            var services = await HttpCall.GetRequest<List<DropdownDto>>("http://localhost:58179/api/Dropdown/GetServices");

            return services;
        }
        [HttpGet, Route("GetBookings")]
        public async Task<IEnumerable<DropdownDate>> GetBookings()
        {
            var bookings = await HttpCall.GetRequest<List<DropdownDate>>("http://localhost:58172/api/Dropdown/GetBookings");

            return bookings;
        }
    }
}
