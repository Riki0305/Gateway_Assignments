using Passenger_Management_App.Models;
using Passenger_Management_App.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Passenger_Management_App.Controllers
{
    // This MVC controller is just for demo purpose, I have done Unit testing for ApiPassengerController
    // and This controller is work well same as the ApiPassengerController api's
    public class PassengerController : Controller
    {

        
        private IPassengerRepository _passengerRepository;


        public PassengerController(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }
        public ActionResult Index()
        {
            var passengers = _passengerRepository.GetPassengers();
            return View(passengers);
        }

        public ActionResult AddorEdit(int id=0)
        {
            if(id==0)
            {
                return View(new Passenger() { Id = 0 });
            }
            else
            {
                var passenger = _passengerRepository.GetPassenger(id);
                return View(passenger);
            }
            
        }

        [HttpPost]
        public ActionResult AddorEdit(Passenger passenger)
        {
            if(ModelState.IsValid)
            {
                _passengerRepository.AddorEditPassenger(passenger);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            _passengerRepository.DeletePassenger(id);
            
            return RedirectToAction("Index");
        }
    }
}