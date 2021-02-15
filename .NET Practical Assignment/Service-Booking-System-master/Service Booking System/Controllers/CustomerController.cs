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
    public class CustomerController : Controller
    {
        private IServiceManager _serviceManager;

        public CustomerController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customerList = _serviceManager.GetCustomers();
            return View(customerList);
        }

        public ActionResult AddorEdit(int id=0)
        {
            if(id==0)
            {
                    
                return View(new Customer() { Id=0});
            }
            else
            {
                var user = _serviceManager.GetUser(id);
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult AddorEdit(Customer customer)
        {
            if(ModelState.IsValid)
            {
                customer.RoleId = 2;
                var result = _serviceManager.AddUser(customer);
                TempData["SuccessMessage"] = result.Name + " registered successfully";
                MyLogger.GetInstance().Info(result.Name + " registered successfully");
                return RedirectToAction("Login","Account");
            }
            TempData["ErrorMessage"] = "User not registered";
            MyLogger.GetInstance().Info("User not registered");
            return RedirectToAction("Login", "Account");
        }

        public ActionResult UserProfile(int id)
        {

            var customer = _serviceManager.GetUser(id);
            ViewBag.username = customer.Name;
            if(customer!=null)
            {
                return View(customer);
            }
            return RedirectToAction("Index","Home");
        }

       
        public ActionResult Delete(int id)
        {
           var result= _serviceManager.DeleteCustomer(id);
            if (result != null)
            {
                TempData["SuccessMessage"] = result.Name + " deleted successfully";
                MyLogger.GetInstance().Info(result.Name + " deleted successfully");
                return RedirectToAction("Index");
            }
            TempData["ErrorMessage"] =  "Deletion is unsuccessfull";
            MyLogger.GetInstance().Info("Deletion is unsuccessfull");
            return RedirectToAction("Index");
        }
    }
}