using FrontEndCafeteria.Helpers;
using FrontEndCafeteria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using Microsoft.AspNetCore.Session;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FrontEndCafeteria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }


        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string pass)
        {
            Employee emp = new Employee();
            Api api = new Api();
            HttpClient client = api.Initial();
            HttpResponseMessage getData = await client.GetAsync(string.Format("api/Employees?email={0}&pass={1}", email, pass));
            if (getData.IsSuccessStatusCode)
            {
                string result = getData.Content.ReadAsStringAsync().Result;
                emp = JsonConvert.DeserializeObject<Employee>(result);
                HttpContext.Session.SetString("UserID", emp.EmpID.ToString());
                return RedirectToAction("Index", "Menu", emp);

            }
            return RedirectToAction("Error", new {msg = "Incorrect Email or Password"});
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Employee employee)
        {
            Api api = new Api();
            HttpClient client = api.Initial();
            //HTTP POST
            var postTask = client.PostAsJsonAsync<Employee>("api/Employees", employee);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                    return RedirectToAction("Index");
            }


            return RedirectToAction("Error", new { msg = "Email already exists" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string msg)
        {
            return View(new ErrorViewModel { errorMessage = msg, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
