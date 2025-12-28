using Employees.Models;
using Employees.Models.JobsModels;
using Employees.Services;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Controllers;

[Route("api/")]
public class JobController : ControllerBase
{
    private readonly IJobService _jobService;

    public JobController(IJobService jobService)
    {
        _jobService = jobService;
    }

    [HttpGet("jobs")]
    public ActionResult GetJobs()
    {
        var jobs = _jobService.GetAllJobs();
        return Ok(jobs);
    }
    
    [HttpGet("jobs/{id}")]
    public ActionResult GetJobs(int id)
    {
        var job = _jobService.GetJobById(id);

        if (job is null)
        {
            return NotFound();
        }
        
        return Ok(job);
    }

    [HttpPost("jobs")]
    public ActionResult CreateJob([FromBody] DisplayJobDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var id = _jobService.CreateJob(dto);
        return Created($"/api/jobs/{id}", id);
    }

    [HttpPut("jobs/{id}")]
    public ActionResult Updatejob([FromBody] UpdateJobDto dto, [FromRoute] int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var isUpdated = _jobService.UpdateJobs(id, dto);
        if (!isUpdated)
        {
            return NotFound();
        }

        return Ok();
    }
    
    [HttpDelete("jobs/{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        var isDeleted = _jobService.Delete(id);

        if (isDeleted)
        {
            return NoContent();
        }
        
        return NotFound();
    }
    
}