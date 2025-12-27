using Employees.Models;
using Employees.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;


[Route("api/")]
public class EmployeeProjectsController : ControllerBase
{
    private readonly IEmployeeProjectsService _employeeProjectsService;

    public EmployeeProjectsController(IEmployeeProjectsService employeeProjectsService)
    {
        _employeeProjectsService = employeeProjectsService;
    }
    
    
    [HttpGet("EmpPrjwithEmpId/{id}")]
    public ActionResult GetEmpPrjwithEmpId(int id)
    {
        var empPrj = _employeeProjectsService.GetEPWithEmpId(id).ToList();

        if (empPrj is null)
        {
            return NotFound();
        }
        
        return Ok(empPrj);
    }
    
    [HttpGet("EmpPrjwithPrjId/{id}")]
    public ActionResult notEmpPrjwithPrjId(int id)
    {
        var empPrj = _employeeProjectsService.GetEPWithPrjId(id).ToList();

        if (empPrj is null)
        {
            return NotFound();
        }
        
        return Ok(empPrj);
    }
    
    [HttpPost("EmpPrj")]
    public ActionResult CreateEmployee([FromBody] EmployeeProjectsDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var id = _employeeProjectsService.CreateEmployeeProjects(dto);
        return Created();
    }
    
    [HttpDelete("EmpPrj/{empId}/{prjId}")]
    public ActionResult Delete([FromRoute] int empId, [FromRoute] int prjId)
    {
        var isDeleted = _employeeProjectsService.Delete(empId, prjId);

        if (isDeleted)
        {
            return NoContent();
        }

        return NotFound();
    }
    
}