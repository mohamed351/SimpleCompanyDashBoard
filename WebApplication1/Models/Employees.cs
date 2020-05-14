using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Employees
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public int DepartmentID { get; set; }
        [ForeignKey("DepartmentID")]
        public Department Department { get; set; }
    }

}
