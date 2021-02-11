using CommonObjects.Models;
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
    public class DropdownController : ControllerBase
    {
        [HttpGet,Route("GetGarageOwners")]
        public IEnumerable<DropdownDto> GetGarageOwners()
        {
            return new GarageOwnerService().GetGarageOwners().Select(r => new DropdownDto { Id = r.Id, Name = r.Name });
        }
    }
}
