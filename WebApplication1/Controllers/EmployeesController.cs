using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositry;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public EmployeesController(IEmployeesRepostiry employeesRepostiry, IMapper mapper)
        {
            EmployeesRepostiry = employeesRepostiry;
            Mapper = mapper;
        }

        public IEmployeesRepostiry EmployeesRepostiry { get; }
        public IMapper Mapper { get; }

        public ActionResult<IEnumerable<EmployeesViewModel>> GetAll()
        {
            return Ok(Mapper.Map<IEnumerable<Employees>,List<EmployeesViewModel>>
                (this.EmployeesRepostiry.GetEmployeesWithDepatment()));
        }
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Employees> GetEmployees(int? ID)
        {
            if(ID == null)
            {
                return NotFound("The Employees is not found");

            }
            else
            {
               Employees employees = this.EmployeesRepostiry.Get(ID.Value);
                return Ok(employees);

            }
        }
        [HttpPost]
        public ActionResult<Employees> PostEmployees(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
              Employees employees=  this.Mapper.Map<CreateEmployeeViewModel, Employees>(viewModel);
                EmployeesRepostiry.Add(employees);
                EmployeesRepostiry.SaveAll();
                return Created("The Employees has been created", employees);

            }
            return BadRequest("Error Employees Data is Not valid");

        }
        [HttpPut]
        public ActionResult<Employees> PutEmployees(int?ID,EmployeesEditViewModel viewModel)
        {
            if(ID == null)
            {
                return BadRequest("The ID is not Found in Request");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    Employees employees = EmployeesRepostiry.Get(ID.Value);
                    Mapper.Map<EmployeesEditViewModel, Employees>(viewModel, employees);
                    EmployeesRepostiry.Edit(employees);
                    EmployeesRepostiry.SaveAll();
                    return Ok();
                }
                catch(DBConcurrencyException)
                {
                    return Conflict();
                    
                }


            }
            return BadRequest("Error Employees Data is Not valid");
        }
        [HttpDelete]
        public ActionResult Delete(int? ID)
        {
            if(ID == null)
            {
                return BadRequest("The Request of Employee is Wrong");
               
            }
            Employees employees = EmployeesRepostiry.Get(ID.Value);
            if(employees != null)
            {
                return NotFound("The Employees not found");
            }
            EmployeesRepostiry.Delete(employees);
            EmployeesRepostiry.SaveAll();
            return NoContent();

        }
      

    }
}