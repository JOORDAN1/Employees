using AutoMapper;
using Employees.Entities;
using Employees.Models;

namespace Employees.Services;

public interface IEmployeeProjectsService
{
    IEnumerable<EmployeeProjectsDto> GetEPWithEmpId(int projectId);

    IEnumerable<EmployeeProjectsDto> GetEPWithPrjId(int prjId);

    int CreateEmployeeProjects(EmployeeProjectsDto dto);
    bool Delete(int prjId, int empId);
}

public class EmployeeProjectsService : IEmployeeProjectsService
{
    private readonly EmployeesDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public EmployeeProjectsService(EmployeesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IEnumerable<EmployeeProjectsDto> GetEPWithEmpId(int employeeId)
    {
        var empPrj = _dbContext.EmployeeProjects
            .Where(e => e.EmployeeId == employeeId)
            .ToList();
        
        var empPrjDto = _mapper.Map<List<EmployeeProjectsDto>>(empPrj);
        return empPrjDto;
    }
    
    public IEnumerable<EmployeeProjectsDto> GetEPWithPrjId(int prjId)
    {
        var empPrj = _dbContext.EmployeeProjects
            .Where(e => e.ProjectId == prjId)
            .ToList();
        
        var empPrjDto = _mapper.Map<List<EmployeeProjectsDto>>(empPrj);
        return empPrjDto;
    }
    
    public int CreateEmployeeProjects(EmployeeProjectsDto dto)
    {
        var employeeProject = _mapper.Map<EmployeeProject>(dto);
        _dbContext.EmployeeProjects.Add(employeeProject);
        _dbContext.SaveChanges();

        return employeeProject.Id;
    }
    
    public bool Delete(int empId, int prjId)
    {
        var employeeProject = _dbContext.EmployeeProjects
            .FirstOrDefault(ep => ep.ProjectId == prjId && ep.EmployeeId == empId);

        if (employeeProject == null)
        {
            return false;
        }

        _dbContext.EmployeeProjects.Remove(employeeProject);
        _dbContext.SaveChanges();
        return true;
    }
    
}