using Newtonsoft.Json;
using SourceControlFinalAssignment_1.Models;
using SourceControlFinalAssignment_1.Utility;
using SourceControlFinalAssignment_1.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControlFinalAssignment_1.Controllers
{
    public class HomeController : Controller
    {
        private UserContext _context;

        public HomeController()
        {
            _context = new UserContext();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserProfile(userProfileViewModel userprofile)
        {
            var user = _context.User.Where(u => u.Name == userprofile.UserName).FirstOrDefault();
            if (user == null)
            {
                MyLogger.GetInstance().Error("User not found : " + (string)Session["username"]);
                Session.Abandon();
                return RedirectToAction("Index");
            }
                
                

            //this was for ActionResult 
            //string name = (string)Session["username"];
            //var user = _context.User.Where(u => u.Name == name).FirstOrDefault();
            //if (user == null)
            //{
            //    MyLogger.GetInstance().Error("Can not find user : " + (string)Session["username"]);
            //    return RedirectToAction("Index");
            //}

            //MyLogger.GetInstance().Info("Displaying user : " + user.Name);
            //return View(user);

            return View(user);
        }

        public JsonResult GetUser()
        {
           
            //demo of NewtonsoftJson
            string name = (string)Session["username"];
            var user = _context.User.Where(u => u.Name == name).FirstOrDefault();
            if (user == null)
            {
                MyLogger.GetInstance().Error("Can not find user : " + (string)Session["username"]);

            }

            MyLogger.GetInstance().Info("Displaying user : " + user.Name);
            User loginuser = user;
            var json = JsonConvert.SerializeObject(loginuser);
            return Json(json, JsonRequestBehavior.AllowGet);
        }

        
    }
}