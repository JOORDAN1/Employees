using Employees.Models;
using Employees.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[Route("api/")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet("employees")]
    public IActionResult GetEmployees()
    {
        var employees = _employeeService.GetAllEmployees();
        return Ok(employees);
    }
    
    [HttpGet("employees/{id}")]
    public ActionResult<EmployeeDto> GetById([FromRoute] int id)
    {
        var employee = _employeeService.GetEmployeeById(id);

        if (employee is null)
        {
            return NotFound();
        }

        return Ok(employee);
    }
    
    [HttpPost("employees")]
    public ActionResult CreateEmployee([FromBody] EmployeeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var id = _employeeService.CreateEmployee(dto);
        return Created($"/api/employees/{id}", null);
    }
    
    [HttpPut("employees/{id}")]
    public ActionResult Update([FromBody] EmployeeDto dto, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var is_Updated = _employeeService.UpdateEmployees(id, dto);
        if (!is_Updated)
        {
            return NotFound();
        }

        return Ok();
    }
    
    [HttpDelete("employees/{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _employeeService.Delete(id);

        if (isDeleted)
        {
            return NoContent();
        }

        return NotFound();
    }
}
