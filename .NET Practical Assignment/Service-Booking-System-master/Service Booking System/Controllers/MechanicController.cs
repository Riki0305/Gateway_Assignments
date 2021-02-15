using SBS.BAL.Interfaces;
using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class MechanicController : Controller
    {
        private IServiceManager _serviceManager;

        public MechanicController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Service
        public ActionResult Index()
        {
            var mechanicList = _serviceManager.GetMechanics();
            return View(mechanicList);
        }
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {

                return View(new Mechanic() { Id = 0 });
            }
            else
            {
                var mechanic = _serviceManager.GetMechanic(id);
                return View(mechanic);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(Mechanic mechanic)
        {
            if (ModelState.IsValid)
            {

                var result = _serviceManager.AddMechanic(mechanic);
                TempData["SuccessMessage"] = result.Name + " added successfully";
                return RedirectToAction("MechanicProfile", new { id = result.Id });
            }
            TempData["ErrorMessage"] = "User not added";
            return Content("Not added");
        }

        public ActionResult MechanicProfile(int id)
        {

            var mechanic = _serviceManager.GetMechanic(id);

            if (mechanic != null)
            {
                return View(mechanic);
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Delete(int id)
        {
            var mechanic = _serviceManager.DeleteMechanic(id);
            if (mechanic != null)
            {
                TempData["SuccessMessage"] = mechanic.Name + " deleted successfully";
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Deletion is unsuccessfull";
            return RedirectToAction("Index");
        }

    }
}