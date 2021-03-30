using EMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EMS.MVC.Controllers
{
    public class AccountController : Controller
    {
        ILogger _logger;
        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }


        //<summary>
        //    returns login page.
        //</summary>
        public ActionResult Login()
        {
            try
            {
                return View();
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    redirect to login form.
        //</summary>
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    using (var response = await client.PostAsync("http://localhost:55237/api/Account/Login", content))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            var apiResponse = await response.Content.ReadAsStringAsync();
                            HttpContext.Session.SetString("Token", apiResponse);
                            HttpContext.Session.SetString("Username", model.Username);
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ViewBag.Message = "Username or Password is incorrect.";
                            return View();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    logout clicked.
        //</summary>
        [HttpGet]
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.SetString("Token", "");
                HttpContext.Session.SetString("Username", "");

                return RedirectToAction("Login", "Account");
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    error occurs.
        //</summary>
        public IActionResult Error()
        {
            return View();
        }
    }
}
