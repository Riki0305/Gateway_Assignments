using EMS.BAL.Interface;
using EMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class EmployeesController : ControllerBase
    {
        IEmployeeManager _employee;
        ILogger _logger;

        public EmployeesController(IEmployeeManager employee, ILogger<EmployeesController> logger)
        {
            _employee = employee;
            _logger = logger;
        }


        //<summary>
        //    returns list of all the employess.
        //</summary>
        [HttpGet]
        [Route("GetEmployees")]
        public IActionResult GetEmployees()
        {
            try
            {
                return Ok(_employee.GetEmployees());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

        }

        //<summary>
        //    returns data of that employee.    
        //</summary>
        [HttpGet]
        [Route("GetEmployee")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                return Ok(_employee.GetEmployee(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //<summary>
        //    inserts employee's data.
        //</summary>
        [HttpPost]
        [Route("PostEmployee")]
        public IActionResult PostEmployee(EmployeesModel model)
        {
            try
            {
                _employee.PostEmployee(model);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //<summary>
        //    updates data of that employee.
        //</summary>
        [HttpPut]
        [Route("PutEmployee")]
        public IActionResult PutEmployee(int id, EmployeesModel model)
        {
            try
            {
                _employee.PutEmployee(id, model);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //<summary>
        //    deletes that employee.
        //</summary>
        [HttpDelete]
        [Route("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                _employee.DeleteEmployee(id);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        //<summary>
        //    returns list of all managers.
        //</summary>
        [HttpGet]
        [Route("GetManagers")]
        public IActionResult GetManagers()
        {
            try
            {
                return Ok(_employee.GetManagers());
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
