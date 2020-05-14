using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositry
{
    public class EmployeesRepositry: Repositry<Employees,int>, IEmployeesRepostiry
    {

        public EmployeesRepositry(CompanyContext context)
            :base(context)
        {
            Context = context;
        }

        public CompanyContext Context { get; }

        public IEnumerable<Employees> GetEmployeesWithDepatment()
        {
            return Context.Employees.Include(a => a.Department).ToList();
        }
       
    }
}
