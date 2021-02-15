using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SBS.BAL.Interfaces;
using SBS.Model;
using Service_Booking_System.Utility;
using Service_Booking_System.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Service_Booking_System.Controllers
{
    public class AccountController : Controller
    {
        private IServiceManager _serviceManager;

        public AccountController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel loginUser)
        {
            if(ModelState.IsValid)
            {
                var result = _serviceManager.AuthenticateUser(loginUser.Email,loginUser.Password);
                                                                                
                if(result != null)
                {
                    Session["user"] = result;
                    Session["name"] = result.Name;
                    Session["id"] = result.Id;
                    Session["role"] = result.RoleId;
                    TempData["SuccessMessage"] = result.Name + " Logged in successfully";
                    MyLogger.GetInstance().Info(result.Name + " Logged in successfully");
                    return RedirectToAction("UserProfile", "Customer",result);
                }
                else
                {
                    var admin = _serviceManager.AuthenticateDealer(loginUser.Email, loginUser.Password);
                    Session["user"] = admin;
                    Session["name"] = admin.Name;
                    Session["id"] = admin.Id;
                    Session["role"] = admin.RoleId;
                    TempData["SuccessMessage"] = admin.Name + " Logged in successfully";
                    MyLogger.GetInstance().Info(admin.Name + " Logged in successfully");
                    return RedirectToAction("UserProfile", "Dealer", admin);
                }
            }
            TempData["ErrorMessage"] = "Invalid Email or Password";
            MyLogger.GetInstance().Info("Invalid Email or Password");

            return View();
        }

        public ActionResult ChangePassword(int id)
        {
            var user = _serviceManager.GetUser(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult ChangePassword(Customer customer,string oldPass,string newPass)
        {
            var user = _serviceManager.GetUser(customer.Id);
            if(user!=null)
            {
                if(user.Password == oldPass)
                {
                    user.Password = newPass;
                    user = _serviceManager.AddUser(user);
                    MyLogger.GetInstance().Info("Password changed for "+user.Name);
                    return RedirectToAction("UserProfile", "Customer", new { id = user.Id });
                }
                return View(user);
            }
            return View(user);
        }

        public ActionResult ForgotPassword()
        {
            return View(new ForgotPasswordViewModel());
        }

        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                string myGuid = Guid.NewGuid().ToString();
                var user = _serviceManager.GetUserByEmail(model.Email);
                if(user!=null)
                {
                    ForgotPasswordToken tokenObject = new ForgotPasswordToken { Token = myGuid, UserId = user.Id, RequestDateTime = DateTime.Now };
                    var tokenEntry = _serviceManager.AddForgotPasswordToken(tokenObject);
                    if(tokenEntry != null)
                    {
                        //send Email
                        try
                        {
                            MailMessage PassRecMail = new MailMessage("email@gmail.com", user.Email);
                            string Username = user.Name;
                            string EmailBody = "Hi " + Username + ",<br/><br/> Click the link below to reset your password <br/><br/> http://localhost:60335/Account/ResetPassword?token=" + myGuid;
                            PassRecMail.Body = EmailBody;
                            PassRecMail.IsBodyHtml = true;
                            PassRecMail.Subject = "Reset Password";


                            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                            smtp.Credentials = new NetworkCredential()
                            {
                                UserName = "email@gmail.com",
                                Password = "password"
                            };

                            smtp.EnableSsl = true;
                            smtp.Send(PassRecMail);
                        }
                        catch(Exception ex)
                        {
                            MyLogger.GetInstance().Error(ex.Message);
                        }
                    }
                }
                ModelState.Clear();
                model.EmailSent = true;
            }
            return View(model);
        }
        public ActionResult ResetPassword(string token)
        {
            var userTokenObject = _serviceManager.GetForgotPasswordTokenObject(token);
            if(userTokenObject != null)
            {
                var user = _serviceManager.GetUser(userTokenObject.UserId);
                var tokenDelete = _serviceManager.DeleteToken(userTokenObject);
                return View(user);
            }
            return RedirectToAction("ForgotPassword");
        }

        
        public ActionResult Logout()
        {
            Session.Abandon();
            
            return RedirectToAction("Index","Home");
        }
    }
}