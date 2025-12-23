using AutoMapper;
using Employees.Entities;
using Employees.Models;
using Microsoft.EntityFrameworkCore;

namespace Employees.Services;

public interface IEmployeeService
{
    IEnumerable<EmployeeDto> GetAllEmployees();
    EmployeeDto GetEmployeeById(int id);
    int CreateEmployee(CreateEmployeeDto dto);
    bool UpdateEmployees(int id, UpdateEmployeeDto dto);
    bool Delete(int id);
}

public class EmployeeService : IEmployeeService
{
    private readonly EmployeesDbContext _dbContext;
    private readonly IMapper _mapper;

    public EmployeeService(EmployeesDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public IEnumerable<EmployeeDto> GetAllEmployees()
    {
        var employees = _dbContext.Employees
            .Include(e => e.Jobs)
            .Include(e => e.EmployeeProjects)
                .ThenInclude(ep => ep.Project)
            .ToList();
        
        var employeesDto = _mapper.Map<List<EmployeeDto>>(employees);
        return employeesDto;
    }

    public EmployeeDto GetEmployeeById(int id)
    {
        var employee = _dbContext.Employees
            .Include(e => e.Jobs)
            .Include(e => e.EmployeeProjects)
                .ThenInclude(ep => ep.Project)
            .FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return null;
        }

        var result = _mapper.Map<EmployeeDto>(employee);
        return result;
    }
    
    public int CreateEmployee(CreateEmployeeDto dto)
    {
        var employee = _mapper.Map<Employee>(dto);
        _dbContext.Employees.Add(employee);
        _dbContext.SaveChanges();

        return employee.Id;
    }
    
    public bool UpdateEmployees(int id, UpdateEmployeeDto dto)
    {
        var employee = _dbContext
            .Employees
            .FirstOrDefault(r => r.Id == id);
        
        if (employee == null)
        {
            return false;
        }
        
        employee.FirstName = dto.FirstName;
        employee.LastName = dto.LastName;
        employee.Email = dto.Email;
        
        _dbContext.SaveChanges();

        return true;
    }
    
    public bool Delete(int id)
    {
        var employee = _dbContext
            .Employees
            .FirstOrDefault(r => r.Id == id);

        if (employee == null)
        {
            return false;
        }

        _dbContext.Employees.Remove(employee);
        _dbContext.SaveChanges();
        return true;
    }
    
}