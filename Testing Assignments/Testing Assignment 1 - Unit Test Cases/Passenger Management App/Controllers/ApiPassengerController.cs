using Passenger_Management_App.Models;
using Passenger_Management_App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Passenger_Management_App.Controllers
{

    //I have done unit testing for this ApiPassengerController controller
    public class ApiPassengerController : ApiController
    {
        private IPassengerRepository _passengerRepository;

        public ApiPassengerController(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        // GET: api/ApiPassenger
        [HttpGet]
       
        public IList<Passenger> Get()
        {
            return _passengerRepository.GetPassengers();
        }

        // GET: api/ApiPassenger/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_passengerRepository.GetPassenger(id));
        }

        // POST: api/ApiPassenger
        [HttpPost]
        public Passenger Post(Passenger passenger)
        {
            return _passengerRepository.AddorEditPassenger(passenger);
        }

        // PUT: api/ApiPassenger/5
        [HttpPut]
        public Passenger Put(Passenger passenger)
        {
            return _passengerRepository.AddorEditPassenger(passenger);
        }

        // DELETE: api/ApiPassenger/5
        [HttpDelete]
        public Passenger Delete(int id)
        {
            return _passengerRepository.DeletePassenger(id);
        }
    }
}
