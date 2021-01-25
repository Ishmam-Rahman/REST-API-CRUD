using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using REST_API_CRUDE.EmployeeData;
using REST_API_CRUDE.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_CRUDE.Controllers
{
    
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployees(Guid id)
        {
            var employee = _employeeData.GetEmployees(id);

            if(employee!=null)
            {
                return Ok(employee);
            }
            return NotFound($"employee with Id: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
             _employeeData.AddEmployee(employee);

            return Created(HttpContext.Request.Scheme + "://"+ HttpContext.Request.Host + HttpContext.Request.Path + "/"+employee.Id,
                employee);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployees(id);

            if (employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok();
            }
            return NotFound($"employee with Id: {id} was not found");
        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditEmployee(Guid id, Employee employee)
        {
            var exemployee = _employeeData.GetEmployees(id);

            if (exemployee != null)
            {
                employee.Id = exemployee.Id;
                _employeeData.EditEmployee(employee);
               
            }
             return Ok(employee);
        }
    }
}
