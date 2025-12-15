using Employees.Entities;

namespace Employees;

public class EmployeeSeeder
{
    private readonly EmployeesDbContext _dbContext;

    public EmployeeSeeder(EmployeesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if(_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Employees.Any())
            {
                var employees = GenerateEmployees();
                _dbContext.Employees.AddRange(employees);
                _dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Employee> GenerateEmployees()
    {
        var Employees = new List<Employee>()
        {
            new Employee()
            {
                FirstName = "John",
                LastName = "Wick",
                Email = "johnwick@gmail.com",
                Project = new Project()
                {
                    Name = "ProjectRed",
                    Description = "Project Red - very important project"
                },
                Jobs = new List<Job>()
                {
                    new Job()
                    {
                        Name = "Refactor",
                        Description = "You have to refactor Test.cs"
                    },
                    new Job()
                    {
                        Name = "Code review",
                        Description = "We have to review code"
                    }
                }
            },
            new Employee()
            {
                FirstName = "Jerzy",
                LastName = "Ada",
                Email = "jerzyada@gmail.com",
                Project = new Project()
                {
                    Name = "ProjectBlue",
                    Description = "Project Red - not important project"
                },
                Jobs = new List<Job>()
                {
                    new Job()
                    {
                        Name = "Test Task",
                        Description = "Test test"
                    },
                    new Job()
                    {
                        Name = "Task Task2",
                        Description = "test2 test2"
                    }
                }
            }
        };
        
        return Employees;
    }
}