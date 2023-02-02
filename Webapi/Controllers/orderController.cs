using Cafeteria.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public AppDb Db { get; }

        public OrderController(AppDb db)
        {
            Db = db;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            await Db.Connection.OpenAsync();
            order.Db = Db;
            try
            {
                await order.Insert();
                return new OkObjectResult(order);
            }
            catch (Exception)
            {
                return StatusCode(500, "Order cannot happen");
            }
        }
    }
}