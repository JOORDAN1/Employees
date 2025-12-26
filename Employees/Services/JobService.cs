using AutoMapper;
using Employees.Entities;
using Employees.Models.JobsModels;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services;


public interface IJobService
{
    IEnumerable<DisplayJobDto> GetAllJobs();
    DisplayJobDto GetJobById(int id);
    int CreateJob(DisplayJobDto dto);
    bool UpdateJobs(int id, DisplayJobDto dto);
    bool Delete(int id);

}
public class JobService : IJobService
{
    private readonly EmployeesDbContext _dbContext;
    private readonly IMapper _mapper;

    public JobService (EmployeesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<DisplayJobDto> GetAllJobs()
    {
        var jobs = _dbContext.Jobs
            .Include(j => j.Employee)
            .ToList();
        
        var jobsDto = _mapper.Map<IEnumerable<DisplayJobDto>>(jobs);
        return jobsDto;

    }

    public DisplayJobDto GetJobById(int id)
    {
        var job = _dbContext.Jobs
            .FirstOrDefault(j => j.Id == id);

        if (job == null)
        {
            return null;
        }
        
        var jobDto = _mapper.Map<DisplayJobDto>(job);
        return jobDto;
    }

    public int CreateJob(DisplayJobDto dto)
    {
        var job = _mapper.Map<Job>(dto);
        _dbContext.Add(job);
        _dbContext.SaveChanges();
        
        return job.Id;
    }
    
    public bool UpdateJobs(int id, DisplayJobDto dto)
    {
        var job = _dbContext
            .Jobs
            .FirstOrDefault(r => r.Id == id);
        
        if (job == null)
        {
            return false;
        }
        
        job.Name = dto.Name;
        job.Description = dto.Description;
        
        _dbContext.SaveChanges();

        return true;
    }
    
    public bool Delete(int id)
    {
        var job = _dbContext
            .Jobs
            .FirstOrDefault(p => p.Id == id);

        if (job == null)
        {
            return false;
        }

        _dbContext.Jobs.Remove(job);
        _dbContext.SaveChanges();
        return true;
    }
}