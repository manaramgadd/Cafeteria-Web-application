using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndCafeteria.Models
{
    public class Product
    {
        public int productID { get; set; }
        public string productName { get; set; }
        public int availableQuantity { get; set; }
        public int QuantityRequired { get; set; }
        public double price { get; set; }

    }
}
