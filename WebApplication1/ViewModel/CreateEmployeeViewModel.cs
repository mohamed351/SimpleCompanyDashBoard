using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class CreateEmployeeViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public decimal Salary { get; set; }





    }
}
