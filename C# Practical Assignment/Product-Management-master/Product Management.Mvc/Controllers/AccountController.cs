using Product_Management.Models;
using Product_Management.Mvc.Utility;
using Product_Management.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Product_Management.Mvc.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //Landing page for website, shows user information
        public ActionResult Index()
        {
            try
            {
                if (Session["username"] != null)
                {
                    HttpResponseMessage responseGet = GlobalVariables.WebApiClient.GetAsync("User").Result;
                    var userList = responseGet.Content.ReadAsAsync<IEnumerable<User>>().Result;

                    if (userList != null)
                    {
                        User user = userList.Where(u => u.Username == (string)Session["username"]).FirstOrDefault();
                        return View(user);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("Exception at Home page : " + ex.Message);
                return RedirectToAction("Index", "Home");
            }
            
        }
        public ActionResult Register()
        {
            return View();
        }

        //Register new user
        [HttpPost]
        public ActionResult Register(User user)
        {
            try
            {
                HttpResponseMessage responseGet = GlobalVariables.WebApiClient.GetAsync("User").Result;
                var userList = responseGet.Content.ReadAsAsync<IEnumerable<User>>().Result;

                if (userList != null)
                {
                    if (userList.Where(u => u.Username == user.Username || u.Email == user.Email).Any())
                    {
                        ModelState.AddModelError("Username", "User already exists.");
                        return View();
                    }
                    else
                    {
                        HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("User", user).Result;

                        MyLogger.GetInstance().Info("User Registered with username : " + user.Username);
                    }
                }

                Session["username"] = user.Username;
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("Exception at user Registration : " + ex.Message);
            }
            
           
            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

        //Login Existing user
        [HttpPost]
        public ActionResult Login(LoginFormViewModel user)
        {
            try
            {
                HttpResponseMessage responseGet = GlobalVariables.WebApiClient.GetAsync("User").Result;
                var userList = responseGet.Content.ReadAsAsync<IEnumerable<User>>().Result;
                var loginUser = userList.Where(u => u.Email == user.Email).FirstOrDefault();
                if (loginUser == null)
                {
                    ModelState.AddModelError("Email", "User Does not exist");
                    return View();
                }
                else
                {
                    if (loginUser.Password != user.Password)
                    {
                        ModelState.AddModelError("Password", "Incorrect Password");
                        return View();
                    }
                    else
                    {
                        Session["username"] = loginUser.Username;
                        MyLogger.GetInstance().Info("User Logged in by username : " + loginUser.Username);
                        //return Content("successfull login");
                        return RedirectToAction("Index");
                    }
                }
            }
            catch(Exception ex)
            {
                MyLogger.GetInstance().Error("Exception at user Login : " + ex.Message);
                return RedirectToAction("Index");
            }
            
            
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}