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
            if (!_dbContext.Employees.Any() && !_dbContext.Projects.Any())
            {
                var projects = GenerateProjects();
                _dbContext.Projects.AddRange(projects);
                _dbContext.SaveChanges();

                var employees = GenerateEmployees(projects);
                _dbContext.Employees.AddRange(employees);
                _dbContext.SaveChanges();
            }
        }
    }

    private IEnumerable<Employee> GenerateEmployees(List<Project> projects)
    {
        
        var projectRed = projects.First(p => p.Name == "ProjectRed");
        var projectBlue = projects.First(p => p.Name == "ProjectBlue");
        var Employees = new List<Employee>()
        {
            new Employee()
            {
                FirstName = "John",
                LastName = "Wick",
                Email = "johnwick@gmail.com",
                EmployeeProjects = new List<EmployeeProject>()
                {
                    new EmployeeProject { Project = projectRed }
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
                EmployeeProjects = new List<EmployeeProject>()
                {
                    new EmployeeProject { Project = projectRed },
                    new EmployeeProject { Project = projectBlue }
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
    
    private List<Project> GenerateProjects()
    {
        return new List<Project>()
        {
            new Project
            {
                Name = "ProjectRed",
                Description = "Project Red - very important project"
            },
            new Project
            {
                Name = "ProjectBlue",
                Description = "Project Blue - less important project"
            }
        };
    }
}