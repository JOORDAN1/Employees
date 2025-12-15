using AutoMapper;
using Employees.Entities;

namespace Employees.Services;


public interface IProjectService
{
    // IEnumerable<Project> GetAllEmployees();
    // Project GetEmployeeById(int id);
    // int CreateEmployee(CreateEmployeeDto dto);
    // bool UpdateEmployees(int id, UpdateEmployeeDto dto);
    // bool Delete(int id);
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
}