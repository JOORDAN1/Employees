using AutoMapper;
using Employees.Entities;
using Employees.Models;
using Employees.Models.JobsModels;
using Employees.Models.ProjectsModels;

namespace Employees;


public class EmployeeMappingProfile:Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Employee, EmployeeDto>()
            .ForMember(e => e.ProjectNames,
                p => p.MapFrom(e => e.EmployeeProjects.Select(ep => ep.Project.Name)));
        CreateMap<Job, JobDto>();
        CreateMap<CreateEmployeeDto, Employee>();
        
        CreateMap<Project, ProjectDto>()
            .ForMember(p => p.Employees,
                e => e.MapFrom(p => p.EmployeeProjects.Select(ep => ep.Employee)));
        CreateMap<Employee, ProjectEmployeeDto>();
        CreateMap<ProjectDto, Project>();

        CreateMap<Job, DisplayJobDto>();
        CreateMap<DisplayJobDto, Job>();
        
    }
    
}