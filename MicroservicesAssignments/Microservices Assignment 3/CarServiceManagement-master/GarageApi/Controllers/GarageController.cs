using GarageApi.Entities;
using GarageApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GarageController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Garage> GetGarages()
        {
            return new GarageService().GetGarages();
        }
    }
}
