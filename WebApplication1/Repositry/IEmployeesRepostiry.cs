using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositry
{
    public interface IEmployeesRepostiry:IRepositry<Employees,int> 
    {

        IEnumerable<Employees> GetEmployeesWithDepatment(); 
    }
}
