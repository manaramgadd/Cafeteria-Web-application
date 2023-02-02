using FrontEndCafeteria.Helpers;
using FrontEndCafeteria.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FrontEndCafeteria.Controllers
{
    public class MenuController : Controller
    {
        static Dictionary<Int32, List<Int32>> mapUserToListOfProducts;
        static Dictionary<Int32, Int32> mapProdToQuan;


        public static Dictionary<Int32, List<Int32>> getMap1()
        {
            return mapUserToListOfProducts;
        }
        public static Dictionary<Int32, Int32> getMap2()
        {
            return mapProdToQuan;
        }
        public async Task<IActionResult> Index(Employee emp)
        {
            int id = Int32.Parse(HttpContext.Session.GetString("UserID"));
            Api api = new Api();
            HttpClient client = api.Initial();
            HttpResponseMessage getData = await client.GetAsync("api/Products");
            List<Product> products = new List<Product>();
            if (getData.IsSuccessStatusCode)
            {
                string result = getData.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<Product>>(result);
                ViewBag.User = emp;
                return View(products);
            }
            return Error();
        }
        public ActionResult AddCart(int prodID, int userid) 
        {
            if(mapUserToListOfProducts == null)
            {
                mapUserToListOfProducts = new Dictionary<int, List<int>>();
            }
            List<Int32> list = new List<Int32>();
            if(mapUserToListOfProducts.TryGetValue(userid, out list))
            {
                mapUserToListOfProducts.GetValueOrDefault(userid).Add(prodID);
            }
            else
            {
                list = new List<Int32>();
                list.Add(prodID);
                mapUserToListOfProducts.Add(userid, list);
            }
            return View();
        }
        public ActionResult DeleteCart(int prodID, int userid)
        {
            List<Int32> list = new List<Int32>();
            if (mapUserToListOfProducts.TryGetValue(userid, out list))
            {
                mapUserToListOfProducts.GetValueOrDefault(userid).Remove(prodID);
                if(mapUserToListOfProducts.GetValueOrDefault(userid).Count == 0)
                {
                    mapUserToListOfProducts.Remove(userid);
                }
            }
            return View();
        }

        public ActionResult Checkout(List<Int32> quantities, List<Int32> products)
        {
            mapProdToQuan = new Dictionary<Int32, Int32>();
            for (int i = 0; i < quantities.Count; i++)
            {
                mapProdToQuan.Add(products[i], quantities[i]);
            }
            return View();
            //return RedirectToAction("Index", "Order");
        }
        public ActionResult GoPay()
        {
            return Redirect(Url.Action("Index", "Order"));

        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
