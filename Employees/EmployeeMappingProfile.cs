using AutoMapper;
using Employees.Entities;
using Employees.Models;

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
    }
    
}