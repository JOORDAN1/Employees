using Employees.Models;
using Employees.Models.ProjectsModels;
using Employees.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[Route("api/")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    
    [HttpGet("projects")]
    public IActionResult GetProjects()
    {
        var projects = _projectService.GetAllProjects();
        return Ok(projects);
    }
    
    [HttpGet("projects/{id}")]
    public ActionResult<ProjectDto> GetById([FromRoute] int id)
    {
        var project = _projectService.GetProjectById(id);

        if (project is null)
        {
            return NotFound();
        }

        return Ok(project);
    }
    
    [HttpPost("projects")]
    public ActionResult CreateProject([FromBody] ProjectDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var id = _projectService.CreateProject(dto);
        return Created($"/api/projects/{id}", null);
    }
    
    [HttpPut("projects/{id}")]
    public ActionResult Update([FromBody] ProjectDto dto, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var is_Updated = _projectService.UpdateProject(id, dto);
        if (!is_Updated)
        {
            return NotFound();
        }

        return Ok();
    }

    [HttpDelete("projects/{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _projectService.Delete(id);

        if (isDeleted)
        {
            return NoContent();
        }
        
        return NotFound();
    }
    
    
}