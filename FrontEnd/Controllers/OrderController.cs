using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using FrontEndCafeteria.Models;
using System.Diagnostics;
using System.Net.Http;
using Newtonsoft.Json;
using FrontEndCafeteria.Helpers;

namespace FrontEndCafeteria.Controllers
{
    public class OrderController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            int id = Int32.Parse(HttpContext.Session.GetString("UserID"));
            Dictionary<Int32, List<Int32>> mapUserToListOfProducts = MenuController.getMap1();
            Dictionary<Int32, Int32> mapProdToQuan = MenuController.getMap2();
            IList<Product> products = new List<Product>();
            for (int i = 0; i < mapUserToListOfProducts.GetValueOrDefault(id).Count; i++)
            {
                int prodID = mapUserToListOfProducts.GetValueOrDefault(id).ElementAt(i);
                Api api = new Api();
                HttpClient client = api.Initial();
                HttpResponseMessage getData = await client.GetAsync(string.Format("api/Products/" + prodID));
                if (getData.IsSuccessStatusCode)
                {
                    string result = getData.Content.ReadAsStringAsync().Result;
                    Product p = JsonConvert.DeserializeObject<Product>(result);
                    products.Add(p);
                }
            }
           
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string msg)
        {
            return View(new ErrorViewModel { errorMessage = msg, RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
