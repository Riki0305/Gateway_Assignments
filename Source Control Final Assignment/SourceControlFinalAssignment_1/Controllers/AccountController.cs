using SourceControlFinalAssignment_1.Models;
using SourceControlFinalAssignment_1.Utility;
using SourceControlFinalAssignment_1.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControlFinalAssignment_1.Controllers
{
    public class AccountController : Controller
    {
        private UserContext _context;

        public AccountController()
        {
            _context = new UserContext();
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user,HttpPostedFileBase userImage)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Register", user);

                if(userImage==null)
                {
                    ModelState.AddModelError("ImagePath", "The user image is required");
                    return View("Register", user);
                }

                var imageName = Path.GetFileName(userImage.FileName);
                var imageExtension = Path.GetExtension(userImage.FileName).ToLower();
                
                var fullName =  DateTime.Now.ToString("yymmssfff") + imageName;
                user.ImagePath ="~/Uploads/"+ fullName;
                var fullPath = Path.Combine(Server.MapPath("~/Uploads/"), fullName);

                if(userImage.ContentLength>= 2097152)
                {
                    ModelState.AddModelError("ImagePath", "Image size should be less then 2Mb");
                    return View("Register", user);
                }

                else if((imageExtension != ".jpg" && imageExtension != ".gif" && imageExtension != ".jpeg" && imageExtension != ".png"))
                {
                    ModelState.AddModelError("ImagePath", "Only image files are allowed");
                    return View("Register", user);
                }
                else
                {
                    if (_context.User.Where(u => u.Email == user.Email || u.Name == user.Name).Any())
                    {

                        ModelState.AddModelError("Name", "User is already exists.");
                        MyLogger.GetInstance().Error("Already Exists : " + user.Name);
                        return View("Register", user);
                    }
                    userImage.SaveAs(fullPath);

                    _context.User.Add(user);

                    _context.SaveChanges();
                    MyLogger.GetInstance().Info("Added user : " + user.Name);
                    Session["username"] = user.Name;
                    return RedirectToAction("userProfile", "Home", new userProfileViewModel((string)Session["username"]));
                }

                

                //return View("Register",user);

            }
            catch (Exception es)
            {
                MyLogger.GetInstance().Error(es.ToString());
                ModelState.AddModelError("ErrorText", "Some Error uccured at server side");
                return View("Register", user);
            }
            //return View("Register",user);
            
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Login", user);

                var loginUser = _context.User.Where(u => u.Name == user.Name || u.Email == user.Name).FirstOrDefault();

                if (loginUser == null)
                {
                    ModelState.AddModelError("Name", "User name or password is incorrect, please login with correct credentials");
                    MyLogger.GetInstance().Error("Incorrect user : " + user.Name);
                    return View("Login", user);
                }
                else
                {
                    if (loginUser.Password != user.Password)
                    {
                        ModelState.AddModelError("Password", "Incorrect Password");
                        MyLogger.GetInstance().Error("Incorrect Password for user : " + user.Name);
                        return View("Login", user);
                    }
                }
                Session["username"] = loginUser.Name;
                MyLogger.GetInstance().Info("Logged in user : " + user.Name);
                return RedirectToAction("UserProfile", "Home",new userProfileViewModel((string)Session["username"]));
            }
            catch(Exception es)
            {
                MyLogger.GetInstance().Error(es.ToString());
            }

            return View(user);
        }

        public ActionResult Logout()
        {
            MyLogger.GetInstance().Debug("Logging out user : " + (string)Session["username"]);
            Session.Abandon();
            return RedirectToAction("Index","Home");
        }
    }
}