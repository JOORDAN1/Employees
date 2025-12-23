using AutoMapper;
using Employees.Entities;
using Employees.Models.ProjectsModels;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services;


public interface IProjectService
{
    IEnumerable<ProjectDto> GetAllProjects();

    ProjectDto GetProjectById(int id);

    int CreateProject(CreateProjectDto dto);

    bool UpdateProject(int id, CreateProjectDto dto);
    bool Delete(int id);
}

public class ProjectService : IProjectService
{
    private readonly EmployeesDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProjectService(EmployeesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public IEnumerable<ProjectDto> GetAllProjects()
    {
        var projects = _dbContext.Projects
            .Include(p => p.EmployeeProjects)
                .ThenInclude(ep => ep.Employee)
            .ToList();
        //
        var projectDto = _mapper.Map<List<ProjectDto>>(projects);
        return projectDto;
    }
    
    public ProjectDto GetProjectById(int id)
    {
        var project = _dbContext.Projects
            .Include(p => p.EmployeeProjects)
                .ThenInclude(ep => ep.Employee)
            .FirstOrDefault(p => p.Id == id);

        if (project == null)
        {
            return null;
        }

        var projectDto = _mapper.Map<ProjectDto>(project);
        return projectDto;
    }
    
    public int CreateProject(CreateProjectDto dto)
    {
        var project = _mapper.Map<Project>(dto);
        _dbContext.Projects.Add(project);
        _dbContext.SaveChanges();

        return project.Id;
    }
    
    public bool UpdateProject(int id, CreateProjectDto dto)
    {
        var project = _dbContext
            .Projects
            .FirstOrDefault(r => r.Id == id);
        
        if (project == null)
        {
            return false;
        }
        
        project.Name = dto.Name;
        project.Description = dto.Description;
        
        _dbContext.SaveChanges();

        return true;
    }

    public bool Delete(int id)
    {
        var project = _dbContext
            .Projects
            .FirstOrDefault(p => p.Id == id);

        if (project == null)
        {
            return false;
        }

        _dbContext.Projects.Remove(project);
        _dbContext.SaveChanges();
        return true;
    }
}