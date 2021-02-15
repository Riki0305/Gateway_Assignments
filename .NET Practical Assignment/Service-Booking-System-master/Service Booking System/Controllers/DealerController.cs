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
    public class DealerController : Controller
    {

        private IServiceManager _serviceManager;

        public DealerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Dealer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
            {

                return View(new Dealer() { Id = 0 });
            }
            else
            {
                var user = _serviceManager.GetDealer(id);
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(Dealer dealer)
        {
            if (ModelState.IsValid)
            {
                dealer.RoleId = 1;
                var result = _serviceManager.AddDealer(dealer);
                TempData["SuccessMessage"] = result.Name + " registered successfully";
                MyLogger.GetInstance().Info(result.Name + " registered successfully");
                return RedirectToAction("Login", "Account");
            }
            TempData["ErrorMessage"] = "Dealer not registered";
            MyLogger.GetInstance().Info("Dealer not registered");
            return RedirectToAction("Login", "Account");
        }

        public ActionResult UserProfile(int id)
        {

            var dealer = _serviceManager.GetDealer(id);
            ViewBag.username = dealer.Name;
            if (dealer != null)
            {
                return View(dealer);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}