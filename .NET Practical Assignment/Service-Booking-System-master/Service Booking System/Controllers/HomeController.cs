using Newtonsoft.Json;
using SBS.BAL.Interfaces;
using SBS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class HomeController : Controller
    {
        private IServiceManager _serviceManager;
        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public ActionResult Index()
        {
            if(Session["user"]!=null &&  Session["role"].ToString() == "2")
            {
                var customer = (Customer)Session["user"];
                ViewBag.username = customer.Name;
            }
            if (Session["user"] != null && Session["role"].ToString() == "1")
            {
                var dealer = (Dealer)Session["user"];
                ViewBag.username = dealer.Name;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}