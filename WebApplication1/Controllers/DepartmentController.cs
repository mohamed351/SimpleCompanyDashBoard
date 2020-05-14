using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly CompanyContext context;

        public DepartmentController(CompanyContext context , IMapper mapper)
        {
            this.context = context;
            Mapper = mapper;
        }

        public IMapper Mapper { get; }

        public IEnumerable<DepartmentViewModel> GetEmployees(){


            return Mapper.Map<IEnumerable<Department>
                , IEnumerable<DepartmentViewModel>>(this.context.Departments.ToList());

        }
   
    }
}
