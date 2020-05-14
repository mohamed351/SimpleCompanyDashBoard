using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<Employees>  Employees { get; set; }
    }
}