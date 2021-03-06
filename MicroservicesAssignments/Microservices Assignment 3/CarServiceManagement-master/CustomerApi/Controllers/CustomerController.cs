﻿using CustomerApi.Entities;
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
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return new CustomerService().GetCustomers();
        }

    }
}
