﻿using GarageOwnerApi.Entities;
using GarageOwnerApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageOwnerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageOwnerController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<GarageOwner> GetGarageOwners()
        {
            return new GarageOwnerService().GetGarageOwners();
        }
    }
}
