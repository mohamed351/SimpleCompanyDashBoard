using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Profiles
{
    public class EmployeesProfile:Profile
    {
       
        public EmployeesProfile()
        {
           
            this.CreateMap<Employees, EmployeesViewModel>()
                 .ForMember(a => a.ID, x => x.MapFrom(a => a.ID))
                 .ForMember(a => a.Name, x => x.MapFrom(x => x.Name))
                 .ForMember(a => a.DepartmentID, x => x.MapFrom(x => x.DepartmentID))
                 .ForMember(a => a.DepartmentName, x => x.MapFrom(x => x.Department.DepartmentName));

            this.CreateMap<EmployeesEditViewModel, Employees>()
                .ForMember(a => a.Name, a => a.MapFrom(a => a.Name))
                .ForMember(a => a.DepartmentID, x => x.MapFrom(x => x.DepartmentId));





            this.CreateMap<CreateEmployeeViewModel,Employees>()
                .ForMember(a => a.DepartmentID, x => x.MapFrom(a => a.DepartmentID))
                .ForMember(a => a.Name, x => x.MapFrom(x => x.Name))
                .ForMember(a => a.Salary, x => x.MapFrom(x => x.Salary));


        }

    }
}
