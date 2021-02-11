using CommonObjects.Models;
using CustomerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropdownController : ControllerBase
    {

        [HttpGet, Route("GetCustomers")]
        public IEnumerable<DropdownDto> GetCustomers()
        {
            return new CustomerService().GetCustomers().Select(r => new DropdownDto { Id = r.Id, Name = r.Name });
        }
    }
}
