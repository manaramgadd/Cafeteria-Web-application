﻿using Cafeteria.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeteria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public AppDb Db { get; }

        public ProductsController(AppDb db)
        {
            Db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            await Db.Connection.OpenAsync();
            var product = new Product(Db);
            var result = await product.AllProductsAsync();
            if (result == null)
            {
                return StatusCode(500);
            }
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            await Db.Connection.OpenAsync();
            var product = new Product(Db);
            var result = await product.GetProduct(id);
            if (result == null)
            {
                return StatusCode(500, "Product not found");
            }
            return new OkObjectResult(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOne(int id, [FromBody] Product productBody)
        {
            await Db.Connection.OpenAsync();
            Product product = new Product(Db);
            Product result = await product.GetProduct(id);
            if (result == null)
                return StatusCode(500, "Product not found!");
            result.availableQuantity = productBody.availableQuantity;
            try
            {
                await result.UpdateAsync();
                return new OkObjectResult(result);
            }
            catch(Exception)
            {
                return StatusCode(500);
            }

        }
    }
}

