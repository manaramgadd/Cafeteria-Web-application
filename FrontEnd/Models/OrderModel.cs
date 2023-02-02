using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndCafeteria.Models
{
    public class OrderModel
    {
        public int orderID { get; set; }
        public int EmpID { get; set; }
        public int productID { get; set; }
        public int quantityRequired { get; set; }
        public int totalprice { get; set; }
        public DateTime dateandTime { get; set; }
        public double completed { get; set; }
    }
}
