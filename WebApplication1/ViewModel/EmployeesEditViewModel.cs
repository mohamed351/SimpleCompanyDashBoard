using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.ViewModel
{
    public class EmployeesEditViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
