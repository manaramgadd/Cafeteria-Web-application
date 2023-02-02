using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEndCafeteria.Models
{
    public class Employee
    {
        public int EmpID { get; set; }
        [Required(ErrorMessage = "Please enter you email!")]
        [Display(Name = "Enter email :")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please enter you password!")]
        [Display(Name = "Enter password :")]
        [DataType(DataType.Password)]
        public string pass { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }
        public string phonenumber { get; set; }
        public string JOB { get; set; }
        public int salary { get; set; }

        public Employee()
        {
        }
    }
}
