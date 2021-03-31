using EMS.Models;
using EMS.MVC.Filters;
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
    [CustomResponseHeader]
    public class EmployeeController : Controller
    {
        ILogger _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        //<summary>
        //    returns list of employees.
        //</summary>
        [ResponseCache(Duration = 3600, Location = ResponseCacheLocation.Any)]
        public async Task<ActionResult> Index()
        {
            try
            {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "")
                {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient())
                {
                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    using (var response = await client.GetAsync("http://localhost:55327/api/Employees/GetEmployees"))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<EmployeesModel>>(apiResponse);
                        return View(result);
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
        //    returns details of that employee. 
        //</summary>
        public async Task<ActionResult> Details(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "")
                {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient())
                {
                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);

                    using (var response = await client.GetAsync("http://localhost:55327/api/Employees/GetEmployee?id=" + id))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeesModel>(apiResponse);
                        return View(result);
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
        //    redirect to create employee.
        //</summary>
        public async Task<ActionResult> Create()
        {
            try
            {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "")
                {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient())
                {
                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    using (var response = await client.GetAsync("http://localhost:55327/api/Employees/GetManagers"))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<EmployeesModel>>(apiResponse);
                        ViewBag.Managers = result;
                        return View();
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
        //    create a new employee.
        //</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "")
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    using (HttpClient client = new HttpClient())
                    {
                        var token = "Bearer " + HttpContext.Session.GetString("Token");
                        client.DefaultRequestHeaders.Add("Authorization", token);
                        StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        using (var response = await client.PostAsync("http://localhost:55327/api/Employees/PostEmployee", content))
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    redirect to edit with data.
        //</summary>
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "")
                {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient())
                {

                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);

                    using (var response = await client.GetAsync("http://localhost:55327/api/Employees/GetManagers"))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<List<EmployeesModel>>(apiResponse);
                        ViewBag.Managers = result;
                    }

                    using (var response = await client.GetAsync("http://localhost:55327/api/Employees/GetEmployee?id=" + id))
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeesModel>(apiResponse);
                        return View(result);
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
        //    updates a employee.
        //</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "")
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    using (HttpClient client = new HttpClient())
                    {
                        var token = "Bearer " + HttpContext.Session.GetString("Token");
                        client.DefaultRequestHeaders.Add("Authorization", token);
                        StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                        using (var response = await client.PutAsync("http://localhost:55327/api/Employees/PutEmployee?id=" + model.Id, content))
                        {
                            return RedirectToAction("Index");
                        }
                    }
                }
                else
                {
                    return View();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }

        //<summary>
        //    delete a employee.
        //</summary>
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                if (HttpContext.Session.GetString("Token") == null || HttpContext.Session.GetString("Token") == "")
                {
                    return RedirectToAction("Login", "Account");
                }
                using (HttpClient client = new HttpClient())
                {
                    var token = "Bearer " + HttpContext.Session.GetString("Token");
                    client.DefaultRequestHeaders.Add("Authorization", token);
                    using (var response = await client.DeleteAsync("http://localhost:55327/api/Employees/DeleteEmployee?id=" + id))
                    {
                        return RedirectToAction("Index");
                    }

                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return RedirectToAction("Error", "Account");
            }
        }
    }
}
