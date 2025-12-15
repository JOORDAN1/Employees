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
            .ForMember(e => e.ProjectName,
                n => n.MapFrom(e => e.Project.Name));
        CreateMap<Job, JobDto>();
        CreateMap<CreateEmployeeDto, Employee>();
        
        CreateMap<Project, ProjectDto>();
        CreateMap<Employee, ProjectEmployeeDto>();
        CreateMap<CreateProjectDto, Project>();

        CreateMap<Job, DisplayJobDto>();
        CreateMap<CreateJobDto, Job>();
        
    }
    
}