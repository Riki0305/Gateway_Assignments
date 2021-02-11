using CommonObjects.Models;
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
    public class DropdownController : ControllerBase
    {
        [HttpGet,Route("GetGarages")]
        public IEnumerable<DropdownDto> GetGarages()
        {
            return new GarageService().GetGarages().Select(r => new DropdownDto { Id = r.Id, Name = r.Name });
        }

        [HttpGet, Route("GetServices")]
        public IEnumerable<DropdownDto> GetServices()
        {
            return new ServiceService().GetServices().Select(r => new DropdownDto { Id = r.Id, Name = r.Name });
        }
    }
}
