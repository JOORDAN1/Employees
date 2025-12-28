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
                p => p.MapFrom(e => e.EmployeeProjects.Select(ep => ep.Project.Name)))
            .ForMember(e => e.JobNames,
                j => j.MapFrom(e => e.Jobs.Select(ej => ej.Name)));
        
        CreateMap<EmployeeDto, Employee>();
        
        CreateMap<Project, ProjectDto>()
            .ForMember(p => p.Employees,
                e => e.MapFrom(p => p.EmployeeProjects.Select(ep => ep.Employee)));
        CreateMap<Employee, ProjectEmployeeDto>();
        CreateMap<ProjectDto, Project>();

        CreateMap<Job, DisplayJobDto>()
            .ForMember(j => j.Employee,
                e => e.MapFrom(j => j.Employee));
        CreateMap<Employee, JobEmployeeDto>();
        CreateMap<DisplayJobDto, Job>();

        CreateMap<EmployeeProject, EmployeeProjectsDto>();
        CreateMap<EmployeeProjectsDto, EmployeeProject>();

    }
    
}