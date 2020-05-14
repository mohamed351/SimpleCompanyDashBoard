using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Profiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            this.CreateMap<Department, DepartmentViewModel>()
                .ForMember(a => a.ID, x => x.MapFrom(x => x.ID))
                .ForMember(a => a.DepartmentName, x => x.MapFrom(x => x.DepartmentName));

            this.CreateMap<Department, DepartmentViewModel>()
               .ReverseMap()
              .ForMember(a => a.ID, x => x.MapFrom(x => x.ID))
              .ForMember(a => a.DepartmentName, x => x.MapFrom(x => x.DepartmentName));


           


        }

    }
}
