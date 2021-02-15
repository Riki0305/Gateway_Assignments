using SBS.BAL.Interfaces;
using SBS.Model;
using Service_Booking_System.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceManager _serviceManager;

        public ServiceController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Service
        public ActionResult Index()
        {
            var serviceList = _serviceManager.GetServices();
            return View(serviceList);
        }
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {

                return View(new Service() { Id = 0 });
            }
            else
            {
                var service = _serviceManager.GetService(id);
                return View(service);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(Service service)
        {
            if (ModelState.IsValid)
            {
               
                var result = _serviceManager.AddService(service);
                TempData["SuccessMessage"] = result.Name + " added successfully";
                MyLogger.GetInstance().Info(result.Name + " added successfully");
                return RedirectToAction("ServiceProfile", new { id = result.Id });
            }
            TempData["ErrorMessage"] = "Service not added";
            MyLogger.GetInstance().Info("Service not added");
            return Content("Not added");
        }

        public ActionResult ServiceProfile(int id)
        {

            var service = _serviceManager.GetService(id);
           
            if (service != null)
            {
                return View(service);
            }
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Delete(int id)
        {
            var service = _serviceManager.DeleteService(id);
            if (service != null)
            {
                TempData["SuccessMessage"] = service.Name + " deleted successfully";
                MyLogger.GetInstance().Info(service.Name + " deleted successfully");
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] = "Deletion is unsuccessfull";
            MyLogger.GetInstance().Info("Deletion is unsuccessfull");
            return RedirectToAction("Index");
        }

    }
}