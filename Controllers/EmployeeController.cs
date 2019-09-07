using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

using FakeDbApi.Models;
using FakeDbApi.Services;

namespace FakeDbApi.Controllers {
    [Route("api")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService) {
          _employeeService = employeeService;
        }

        [HttpGet("test")]
        public ActionResult<string> get([FromQuery(Name="page")] string page) {
          return page + " Erick...";
        }

        // [HttpGet("employees")]
        // public ActionResult<List<Employee>> Get() => _employeeService.Get();

        [HttpGet("employees")]
        public ActionResult<List<Employee>> Get(
          [FromQuery(Name="pageNumber")] int pageNumber, 
          [FromQuery(Name="pageSize")] int pageSize) {
            return _employeeService.Get(pageNumber, pageSize);
        }
        
        [HttpGet("employees/{id:length(24)}", Name="GetEmployee")]
        public ActionResult<Employee> Get(string id) {
          var employee = _employeeService.Get(id);

          if (employee == null) {
            return NotFound();
          }

          return employee;
        }

        [HttpPost("employees")]
        public ActionResult<Employee> Create(Employee employee) {
          _employeeService.Create(employee);

          return CreatedAtRoute("GetEmployee", new { id = employee.Id.ToString() }, employee);
        }

        [HttpPut("employees/{id:length(24)}")]
        public IActionResult Update(string id, Employee employeeIn) {
          var employee = _employeeService.Get(id);

          if (employee == null) {
            return NotFound();
          }

          _employeeService.Update(id, employeeIn);

          return NoContent();
        }

        [HttpDelete("employees/{id:length(24)}")]
        public IActionResult Delete(string id) {
          var employee = _employeeService.Get(id);

          if (employee == null) {
              return NotFound();
          }

          _employeeService.Remove(employee.Id);

          return NoContent();
        }
    }
}